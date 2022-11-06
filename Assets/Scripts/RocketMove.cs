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

    private Vector3 mZiel1;
    private Vector3 mZiel2;

    void Start()
    {
        mZeitBeiRotieren = 0.03f;
        mGrundspeed = 0.8f;
        mZiel1 = Vector3.zero;
        mZiel2 = Vector3.zero;
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
        if (pRichtigeAntwort.Contains("AntwortA"))
        {
            mZiel1 = lieferXPlusMinus(mGameObjectCubeA.transform.position);
        }
        else if (pRichtigeAntwort.Contains("AntwortB"))
        {
            mZiel1 = lieferXPlusMinus(mGameObjectCubeB.transform.position);
        }
        else if (pRichtigeAntwort.Contains("AntwortC"))
        {
            mZiel1 = lieferXPlusMinus(mGameObjectCubeC.transform.position);
        }
        else if (pRichtigeAntwort.Contains("AntwortD"))
        {
            mZiel1 = lieferXPlusMinus(mGameObjectCubeD.transform.position);
        }

        mZiel2 = lieferXYZPlusMinus(mGameObjectCubePosAlternative.transform.position);

        mStatus = K_STATUS_ZIELE_BESTIMMT;
    }

    public void Chase()
    {
        if (mZiel1 != Vector3.zero)
        {
            mZiel1 = bewegenUndDrehen(mZiel1);
        }
        else if(mZiel2 != Vector3.zero)
        {
            mZiel2 = bewegenUndDrehen(mZiel2);
        } else
        {
            mStatus = 0;
        }
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
