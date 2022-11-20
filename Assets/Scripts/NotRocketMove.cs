using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRocketMove : MonoBehaviour
{
    public float mGrundspeed;

    public PruefungGUISteuerung mPruefungGUISteuerung;

    public GameObject mGameObjectCubeA;
    public GameObject mGameObjectCubeB;
    public GameObject mGameObjectCubeC;
    public GameObject mGameObjectCubeD;

    public GameObject mGameObjectCubePosAlternative;

    private const int K_STATUS_ZIELE_BESTIMMT = 1;
    private int mStatus = 0;

   
    private List<Vector3> mZiel;
    public float mXAbweichung;
    public float myAbweichung1;
    public float myAbweichung2;
    public float mzAbweichung;

    void Start()
    {
        mZiel = new List<Vector3>();
        transform.position = bestimmeAusganspunkt();
    }

    private Vector3 bestimmeAusganspunkt()
    {
         return new Vector3(mGameObjectCubePosAlternative.transform.position.x + mXAbweichung,
            mGameObjectCubePosAlternative.transform.position.y,
             mGameObjectCubePosAlternative.transform.position.z);
    }

    void Update()
    {
        if (mPruefungGUISteuerung != null && mPruefungGUISteuerung.getRichtigeAntwort() != null
            && !mPruefungGUISteuerung.getRichtigeAntwort().Equals(""))
        {
            if (mStatus == 0)
            {
                bestimmeZiel(mPruefungGUISteuerung.getRichtigeAntwort());
            }
        }
        else
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

        Vector3 lNextZiel = bestimmeAusganspunkt();

        if (pRichtigeAntwort.Contains("AntwortA"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeA.transform.position, myAbweichung1);
        }
        else if (pRichtigeAntwort.Contains("AntwortB"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeB.transform.position, myAbweichung1);
        }
        else if (pRichtigeAntwort.Contains("AntwortC"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeC.transform.position, myAbweichung2);
        }
        else if (pRichtigeAntwort.Contains("AntwortD"))
        {
            lNextZiel = lieferXPlusMinus(mGameObjectCubeD.transform.position,myAbweichung2);
        }
        mZiel.Add(lNextZiel);

        List<Vector3> lPunkteVonAussen = mPruefungGUISteuerung.getmRaketenPunkte();

        if (lPunkteVonAussen != null && lPunkteVonAussen.Count > 1)
        {
            foreach (Vector3 lVector3 in lPunkteVonAussen)
            {
                float lVersuchDistanz = Vector3.Distance(lVector3, lNextZiel);

                if (lVersuchDistanz > 0.8)
                {
                    mZiel.Add(lVector3);
                    lNextZiel = lVector3;
                }
            }

            mZiel[mZiel.Count - 1] = lPunkteVonAussen[lPunkteVonAussen.Count - 1];
        }

        mStatus = K_STATUS_ZIELE_BESTIMMT;
    }

    public void Chase()
    {
        Vector3 lAktuelleZiel = lieferAktuelleZiel();

        if (lAktuelleZiel != Vector3.zero)
        {
            Vector3 lNeueZiel = bewegen(lAktuelleZiel);

            if (lNeueZiel == Vector3.zero)
            {
                mZiel.Remove(lAktuelleZiel);
            }
        }
        else
        {
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

    private Vector3 bewegen(Vector3 pZiel)
    {

        float lAktuelleEntfernungZumZiel = Vector3.Distance(transform.position, pZiel);

        if (lAktuelleEntfernungZumZiel > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, pZiel, mGrundspeed * Time.deltaTime);

            return pZiel;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private Vector3 lieferXPlusMinus(Vector3 position, float myAbweichung)
    {
        return new Vector3(position.x
            + lieferZuefaellige(2.5f)
            , position.y+ myAbweichung, position.z+mzAbweichung);
    }

    private float lieferZuefaellige(float pAmplitude)
    {
        return UnityEngine.Random.Range(0, pAmplitude) - pAmplitude / 2;
    }
}
