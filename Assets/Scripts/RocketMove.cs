using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public float mGrundspeed;
    public float mZusaetzlicheSpeedForDirection;
    public float mEntfernungZumZiel;

    public PruefungGUISteuerung mPruefungGUISteuerung;

    public Vector3 mTransformZielNaeheRichtigeAntwort;

    public GameObject mGameObjectCubeA;
    public GameObject mGameObjectCubeB;
    public GameObject mGameObjectCubeC;
    public GameObject mGameObjectCubeD;

    public GameObject mGameObjectRichtungsduesen;
    public GameObject mGameObjectSchubduesen1;
    public GameObject mGameObjectSchubduesen2;

    public GameObject mGameObjectCubePosAlternative;

    public float mZeitBeiRotieren;

    public float mWinkel;
    public float mWinkelLast;

    public Vector3 mDirection;

    private const string K_ALTERNATIVE = "ALTERNATIVE";
    private const int K_STATUS_ZIELE_BESTIMMT = 1;
    private int mStatus = 0;
    private int mPhase = 0;

    private const int K_NEUES_ZIEL = 10;
    private const int K_AUF_DEM_WEG_ZUM_ZIEL = 20;
    private const int K_AUF_DEM_WEG_ZUM_ZIEL_TEIL_GEDREHT = 30;

    public int mInputPhase = 0;
    private const int K_INPUT_PHASE_LAEUFT = 10;
    private const int K_INPUT_PHASE_BEENDET = 20;
    private const int K_WINKEL_ZUM_ZIEL_PASSEND_GENUG = 7;
    private List<Vector3> mZiel;
    // private Vector3 mZiel2;

    void Start()
    {
        mZeitBeiRotieren = 0.03f;
        mGrundspeed = 0.03f;
        mZiel = new List<Vector3>();
        transform.position = mGameObjectCubePosAlternative.transform.position;
        mWinkel = 0;
        mWinkelLast = 0;
        mGameObjectRichtungsduesen.SetActive(false);
        mGameObjectSchubduesen1.SetActive(false);
        mGameObjectSchubduesen2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mPruefungGUISteuerung != null && mPruefungGUISteuerung.getRichtigeAntwort() != null
            && !mPruefungGUISteuerung.getRichtigeAntwort().Equals(""))
        {
            if (mStatus == 0)
            {
                bestimmeZiel(mPruefungGUISteuerung.getRichtigeAntwort());
            }
       } else
        {
            if (mStatus == 0)
            {
                bestimmeZiel("");
            }
        }

        Chase();
    }

    private void bestimmeZiel(string pRichtigeAntwort)
    {
        mZiel = new List<Vector3>();

        Vector3 lNextZiel = mGameObjectCubePosAlternative.transform.position;

        if (pRichtigeAntwort.Contains("AntwortA"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeA.transform.position);
        }
        else if (pRichtigeAntwort.Contains("AntwortB"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeB.transform.position);
        }
        else if (pRichtigeAntwort.Contains("AntwortC"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeC.transform.position);
        }
        else if (pRichtigeAntwort.Contains("AntwortD"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeD.transform.position);
        }
        mZiel.Add(lNextZiel);

        List<Vector3> lPunkteVonAussen = mPruefungGUISteuerung.getmRaketenPunkte();

        if (lPunkteVonAussen != null && lPunkteVonAussen.Count > 1)
        {
            foreach (Vector3 lVector3 in lPunkteVonAussen)
            {
                float lVersuchDistanz = Vector3.Distance(lVector3, lNextZiel);

                if (lVersuchDistanz > 4)
                {
                    mZiel.Add(lVector3);
                    lNextZiel = lVector3;
                }
            }

            mZiel[mZiel.Count - 1] = lPunkteVonAussen[lPunkteVonAussen.Count - 1];
        }
        /*
        else
        {
            lNextZiel = lieferXYZPlusMinus(mGameObjectCubePosAlternative.transform.position, lNextZiel);
            mZiel.Add(lNextZiel);
         }
        */

        mStatus = K_STATUS_ZIELE_BESTIMMT;
        mPhase = K_NEUES_ZIEL;
        mWinkelLast = 0;
    }

    public void Chase()
    {
        Vector3 lAktuelleZiel = lieferAktuelleZiel();

        if (lAktuelleZiel != Vector3.zero)
        {
            Vector3 lNeueZiel = bewegenUndDrehen(lAktuelleZiel);

            if (lNeueZiel == Vector3.zero)
            {
                mZiel.Remove(lAktuelleZiel);
                mPhase = K_NEUES_ZIEL;
            }
        } else {
            mStatus = 0;
        }
    }

    private Vector3 lieferAktuelleZiel()
    {
        foreach (Vector3 lVector in mZiel)
        {
            if (lVector != Vector3.zero)
            {
                return lVector;
            }
        }

        return Vector3.zero;
    }

    private Vector3 bewegenUndDrehen(Vector3 pZiel)
    {
           
        mDirection = (pZiel - transform.position).normalized;

        Quaternion rotationVonDirection = Quaternion.LookRotation(mDirection);

        float lAktuelleEntfernungZumZiel = Vector3.Distance(transform.position, pZiel);

        if (lAktuelleEntfernungZumZiel > 0.02)
        {
            mWinkel = Quaternion.Angle(transform.rotation, rotationVonDirection);

            if (mWinkel > K_WINKEL_ZUM_ZIEL_PASSEND_GENUG && mPhase == K_NEUES_ZIEL)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationVonDirection, mZeitBeiRotieren);

                mZusaetzlicheSpeedForDirection = 0;
                mEntfernungZumZiel = 0;

                if (mWinkelLast == mWinkel)
                {
                    transform.position = Vector3.MoveTowards(transform.position, pZiel, (mGrundspeed + mZusaetzlicheSpeedForDirection) * Time.deltaTime);
                    einstellenSchubDuesen(true);
                } else
                {
                    einstellenSchubDuesen(false);
                }

                einstellenRichtungsduesen(true);
                mWinkelLast = mWinkel;
            }
            else
            {
                einstellenRichtungsduesen(false);

                if (mPhase == K_NEUES_ZIEL)
                {
                    mPhase = K_AUF_DEM_WEG_ZUM_ZIEL;
                }
           
                if (mZusaetzlicheSpeedForDirection == 0)
                {
                    mZusaetzlicheSpeedForDirection = 0.1f;
                    mEntfernungZumZiel = lAktuelleEntfernungZumZiel;
                } else
                {
                    if (mEntfernungZumZiel * 0.6f < lAktuelleEntfernungZumZiel)
                    {
                        mZusaetzlicheSpeedForDirection = mZusaetzlicheSpeedForDirection + 0.03f;

                        einstellenSchubDuesen(true);
                    } else
                    {
                        if (mZusaetzlicheSpeedForDirection > 0.03)
                        {
                            mZusaetzlicheSpeedForDirection = mZusaetzlicheSpeedForDirection - 0.02f;
                        }
                    
                        if (mPhase == K_AUF_DEM_WEG_ZUM_ZIEL)
                        {
                            Vector3 lGegenDirection = mDirection * -1;
                            Quaternion rotationVonGegenDirection = Quaternion.LookRotation(lGegenDirection);

                            float lGegenWinkel = Quaternion.Angle(transform.rotation, rotationVonGegenDirection);

                            if (lGegenWinkel > K_WINKEL_ZUM_ZIEL_PASSEND_GENUG)
                            {
                                transform.rotation = Quaternion.Slerp(transform.rotation, rotationVonGegenDirection, mZeitBeiRotieren);

                                einstellenRichtungsduesen(true);

                                if (lGegenWinkel > K_WINKEL_ZUM_ZIEL_PASSEND_GENUG * 11)
                                {
                                    einstellenSchubDuesen(false);
                                } else
                                {
                                    einstellenSchubDuesen(true);
                                }
                            }
                            else
                            {
                                mPhase = K_AUF_DEM_WEG_ZUM_ZIEL_TEIL_GEDREHT;
                                einstellenSchubDuesen(true);
                            }
                           
                        } else
                        {
                            einstellenSchubDuesen(true);
                        }
                    }
                }
                transform.position = Vector3.MoveTowards(transform.position, pZiel, (mGrundspeed+ mZusaetzlicheSpeedForDirection) * Time.deltaTime);
            }

            return pZiel;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void einstellenSchubDuesen(bool pActive)
    {
        mGameObjectSchubduesen1.SetActive(pActive);
        mGameObjectSchubduesen2.SetActive(pActive);
    }

    private void einstellenRichtungsduesen(bool pActive)
    {
        mGameObjectRichtungsduesen.SetActive(pActive);
    }


    private Vector3 lieferXPlusMinus(Vector3 position)
    {
        return new Vector3(position.x
            + lieferZuefaellige(4)
            , position.y, position.z);
    }

    private Vector3 lieferXYZPlusMinus(Vector3 position, Vector3 pLastZiel)
    {
        Vector3 lErg = pLastZiel;
        float lMaxDistanz = 0;

        for (int i = 0; i < 20; i++)
        {
            Vector3 lVersuch =  new Vector3(position.x
             + lieferZuefaellige(6)
             , position.y + lieferZuefaellige(4), position.z);

            float lVersuchDistanz = Vector3.Distance(lVersuch, pLastZiel);

            if (lVersuchDistanz > lMaxDistanz) {
                lMaxDistanz = lVersuchDistanz;
                lErg = lVersuch;
            }
        }

        return lErg;
    }

    private float lieferZuefaellige(float pAmplitude)
    {
       return UnityEngine.Random.Range(0, pAmplitude) - pAmplitude/2;
    }
}
