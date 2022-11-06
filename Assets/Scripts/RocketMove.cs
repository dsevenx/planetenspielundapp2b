using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public float speed;

    public PruefungGUISteuerung mPruefungGUISteuerung;

    public Vector3 mTransformZielNaeheRichtigeAntwort;

    public GameObject mGameObjectCubeA;
    public GameObject mGameObjectCubeB;
    public GameObject mGameObjectCubeC;
    public GameObject mGameObjectCubeD;

    public GameObject mGameObjectCubePosAlternative;

    public float mZeitBeiRotieren;

    public float mWinkel;

    public bool mZumAlternativeZiel;

    public Vector3 mDirection;

    private const string K_ALTERNATIVE = "ALTERNATIVE";

    void Start()
    {
        mZumAlternativeZiel = false;
        mZeitBeiRotieren = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        if (mPruefungGUISteuerung != null && mPruefungGUISteuerung.getRichtigeAntwort() != null
            && !mPruefungGUISteuerung.getRichtigeAntwort().Equals(""))
        {
             Chase(mPruefungGUISteuerung.getRichtigeAntwort());
        } else
        {
            transform.position = mGameObjectCubePosAlternative.transform.position;
        }
        
    }

    public void Chase(String pRichtigeAntwort)
    {
        if (mZumAlternativeZiel)
        {
            bewegenUndDrehen(K_ALTERNATIVE);
        }
        else
        {
            bewegenUndDrehen(pRichtigeAntwort);
        }
    }

    private void bewegenUndDrehen(String pRichtigeAntwort)
    {
        Vector3 lZiel = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        if (pRichtigeAntwort.Contains("AntwortA"))
        {
             lZiel = mGameObjectCubeA.transform.position;
        }
        else if (pRichtigeAntwort.Contains("AntwortB"))
        {
            lZiel = mGameObjectCubeB.transform.position;
        }
        else if (pRichtigeAntwort.Contains("AntwortC"))
        {
            lZiel = mGameObjectCubeC.transform.position;
        } else if (pRichtigeAntwort.Contains("AntwortD"))
        {
            lZiel = mGameObjectCubeD.transform.position;
        } else
        {
            lZiel = mGameObjectCubePosAlternative.transform.position;
         }
     
        mDirection = (lZiel - transform.position).normalized;

        Quaternion rotationVonDirection = Quaternion.LookRotation(mDirection);

        if (Vector3.Distance(transform.position, lZiel) > 0.02)
        {
            mWinkel = Quaternion.Angle(transform.rotation, rotationVonDirection);

            if (mWinkel > 10)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationVonDirection, mZeitBeiRotieren); ;
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, lZiel, speed * Time.deltaTime);
            }
        }
        else
        {
            if (mZumAlternativeZiel)
            {
                mZumAlternativeZiel = false;
            }
            else
            {
                mZumAlternativeZiel = true;
            }
        }

        /*
        Vector3 lZiel = new Vector3(pTransformZielPostion.x, pTransformZielPostion.y,transform.position.z);

        mGameObjectCubeTest.transform.position = lZiel;

        if (Vector3.Distance(transform.position, lZiel) < 0.3)
        {
            if (mZumAlternativeZiel)
            {
                mZumAlternativeZiel = false;
            } else
            {
                mZumAlternativeZiel = true;
                mTransformZielNaeheRichtigeAntwort = new Vector3(lZiel.x + lieferZuefaellige(),
                    lZiel.y + lieferZuefaellige(),
                    lZiel.z);
            }
        }
        */
    }

    private float lieferZuefaellige()
    {
        float lErg = 0; // (UnityEngine.Random.Range(0, 2000) - 1000) / 1000f;

        return lErg;
    }
}
