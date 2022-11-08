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

    public GameObject mGameObjectCubePosAlternative;

    public float mZeitBeiRotieren;

    public float mWinkel;

    public Vector3 mDirection;

    private const string K_ALTERNATIVE = "ALTERNATIVE";
    private const int K_STATUS_ZIELE_BESTIMMT = 1;
    private int mStatus = 0;

    private List<Vector3> mZiel;
    // private Vector3 mZiel2;

    void Start()
    {
        mZeitBeiRotieren = 0.03f;
        mGrundspeed = 0.8f;
        mZiel = new List<Vector3>();
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

            Chase();
        } else
        {
            transform.position = mGameObjectCubePosAlternative.transform.position;
        }
        
    }

    private void bestimmeZiel(string pRichtigeAntwort)
    {
        mZiel = new List<Vector3>();
        if (pRichtigeAntwort.Contains("AntwortA"))
        {
            mZiel.Add(lieferXPlusMinus(mGameObjectCubeA.transform.position));
        }
        else if (pRichtigeAntwort.Contains("AntwortB"))
        {
            mZiel.Add(lieferXPlusMinus(mGameObjectCubeB.transform.position));
        }
        else if (pRichtigeAntwort.Contains("AntwortC"))
        {
            mZiel.Add(lieferXPlusMinus(mGameObjectCubeC.transform.position));
        }
        else if (pRichtigeAntwort.Contains("AntwortD"))
        {
            mZiel.Add(lieferXPlusMinus(mGameObjectCubeD.transform.position));
        }

        mZiel.Add(lieferXYZPlusMinus(mGameObjectCubePosAlternative.transform.position));
        mZiel.Add(lieferXYZPlusMinus(mGameObjectCubePosAlternative.transform.position));
        mZiel.Add(lieferXYZPlusMinus(mGameObjectCubePosAlternative.transform.position));
        mZiel.Add(lieferXYZPlusMinus(mGameObjectCubePosAlternative.transform.position));
        mZiel.Add(lieferXYZPlusMinus(mGameObjectCubePosAlternative.transform.position));

        mStatus = K_STATUS_ZIELE_BESTIMMT;
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

            if (mWinkel > 15)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationVonDirection, mZeitBeiRotieren);

                mZusaetzlicheSpeedForDirection = 0;
                mEntfernungZumZiel = 0;

                // transform.position = Vector3.MoveTowards(transform.position, pZiel, mGrundspeed / 2 * Time.deltaTime);

            } else
            {
                if (mZusaetzlicheSpeedForDirection == 0)
                {
                    mZusaetzlicheSpeedForDirection = 0.1f;
                    mEntfernungZumZiel = lAktuelleEntfernungZumZiel;
                } else
                {
                    if (mEntfernungZumZiel /3 < lAktuelleEntfernungZumZiel)
                    {
                        mZusaetzlicheSpeedForDirection = mZusaetzlicheSpeedForDirection + 0.05f;
                    } else
                    {
                        mZusaetzlicheSpeedForDirection = mZusaetzlicheSpeedForDirection - 0.07f;
                        if (mZusaetzlicheSpeedForDirection < 0)
                        {
                            mZusaetzlicheSpeedForDirection = 0;
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

    private Vector3 lieferXPlusMinus(Vector3 position)
    {
        return new Vector3(position.x
            + lieferZuefaellige(4)
            , position.y, position.z);
    }

    private Vector3 lieferXYZPlusMinus(Vector3 position)
    {
        return new Vector3(position.x
            + lieferZuefaellige(6)
            , position.y + lieferZuefaellige(6), position.z);
    }

    private float lieferZuefaellige(float pAmplitude)
    {
       return UnityEngine.Random.Range(0, pAmplitude) - pAmplitude/2;
    }
}
