using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public float speed;

    public PruefungGUISteuerung mPruefungGUISteuerung;

    public Vector3 mTransformZielNaeheRichtigeAntwort;

    public GameObject mGameObjectCubeTest;


    public bool mZumAlternativeZiel;

    void Start()
    {
        mZumAlternativeZiel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mPruefungGUISteuerung != null && mPruefungGUISteuerung.getGameObjectRichtigeAntwort() != null)
        {
             Chase(mPruefungGUISteuerung.getGameObjectRichtigeAntwort().transform);
        }
        
    }

    public void Chase(Transform pTransformRichtigeAntwort)
    {
        if (mZumAlternativeZiel)
        {
            bewegenUndDrehen(mTransformZielNaeheRichtigeAntwort);
        }
        else
        {
            bewegenUndDrehen(pTransformRichtigeAntwort.position);
        }
    }

    private void bewegenUndDrehen(Vector3 pTransformZielPostion)
    {
        Vector3 lZiel = new Vector3(pTransformZielPostion.x, pTransformZielPostion.y,transform.position.z);

        mGameObjectCubeTest.transform.position = lZiel;
        /*
        Vector3 lDirection = lZiel - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lDirection);
        transform.rotation = rotation;
        */
        transform.position = Vector3.MoveTowards(transform.position, lZiel, speed * Time.deltaTime);

        /*
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
