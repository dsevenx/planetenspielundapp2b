using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AufloesungskuemmererGraviArena : MonoBehaviour
{
    public int mBreiteDisplay;

    public int mHoeheDisplay;

    public GameObject mCanvasSteuerung;
    public GameObject mCanvasSteuerungKreis;

    public GameObject mCanvasSchuss;

    public GameObject mCanvasX;
    public GameObject mCanvasXHoch;
    public GameObject mCanvasXRunter;

    public GameObject mCanvasY;
    public GameObject mCanvasYHoch;
    public GameObject mCanvasYRunter;

    public GameObject mCanvasZ;
    public GameObject mCanvasZHoch;
    public GameObject mCanvasZRunter;

    public GameObject mCanvasMasse;
    public GameObject mCanvasMasseHoch;
    public GameObject mCanvasMasseRunter;

    public GameObject mCanvasWinkel;
    public GameObject mCanvasWinkelHoch;
    public GameObject mCanvasWinkelRunter;

    public GameObject mEinAusKlapper;

    public GameObject mStartStopper;

    public GameObject mZurueck;

    public GameObject mCanvasTabelleDaten;

    public GameObject mZeittext;

    public GameObject mErgebnistext;

    public GameObject mCanvasZeitErgebnis;

    public GameObject mCanvasZeitErgebnisList;

    public GameObject mCanvasZeitErgebnisGesamtpunkte;
     
    public float mBreiteCanvas;

    public float mHoeheCanvas;

    void Start()
    {

        mBreiteDisplay = Display.main.systemWidth;
        mHoeheDisplay = Display.main.systemHeight;
        GeraeteIFs lGeraeteIFs = new GeraeteIFs();

        Debug.Log("X-Breite:" + mBreiteDisplay);
        Debug.Log("Y-Breite:" + mHoeheDisplay);


        float lAnzahlHoehenTeile = 7.0f;
        if (lGeraeteIFs.istIPHONE_small(mBreiteDisplay, mHoeheDisplay))
        {
            lAnzahlHoehenTeile = 3.7f;
        }
        else if (lGeraeteIFs.istIPHONE(mBreiteDisplay, mHoeheDisplay))
        {
            lAnzahlHoehenTeile = 3.6f;

        }
        else if (lGeraeteIFs.istIPAD(mBreiteDisplay, mHoeheDisplay))
        {
            lAnzahlHoehenTeile = 7;
        }

        mBreiteCanvas = mBreiteDisplay / 8;
        float lBreiteAbstandCanvas = mBreiteCanvas / 8;

        if (mBreiteCanvas < 245)
        {
      //      mBreiteCanvas = 245;
        }

        mHoeheCanvas = mHoeheDisplay / lAnzahlHoehenTeile;
        float lPosYCanvas = mHoeheCanvas * (lAnzahlHoehenTeile-1);

      
        mEinAusKlapper.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas+mHoeheCanvas- lBreiteAbstandCanvas), 0);
        mEinAusKlapper.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas/2);

        mStartStopper.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas + 1.5f * mHoeheCanvas - 0.25f *lBreiteAbstandCanvas), 0);
        mStartStopper.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas / 2);

        mZurueck.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas + 2.1f * mHoeheCanvas - 0.25f * lBreiteAbstandCanvas), 0);
        mZurueck.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas / 2);

        mCanvasSteuerung.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasSteuerung.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        mCanvasSchuss.GetComponent<RectTransform>().position = new Vector3(NormiereX(2 *lBreiteAbstandCanvas + mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasSchuss.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        float lNewX = 1.00f;
        float lNewY = 1.07f;

        if (mCanvasX.GetComponent<RectTransform>().sizeDelta.x < 245)
        {
            lNewX = 0.8f;
        }
        if (mCanvasX.GetComponent<RectTransform>().sizeDelta.y < mHoeheCanvas  + 150)
        {
            lNewY = 0.7f;
        }
        else if (mCanvasX.GetComponent<RectTransform>().sizeDelta.y < mHoeheCanvas*2 + 50)
        {
            lNewY = 0.35f;
        }

        mCanvasSteuerungKreis.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);
        mCanvasSteuerungKreis.GetComponent<RectTransform>().localScale = new Vector2(lNewX, 0.9f);

        mCanvasX.GetComponent<RectTransform>().position = new Vector3(NormiereX(3 * lBreiteAbstandCanvas + 2*mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasX.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        mCanvasXHoch.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);
        mCanvasXRunter.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);

        mCanvasY.GetComponent<RectTransform>().position = new Vector3(NormiereX(4 * lBreiteAbstandCanvas + 3 * mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasY.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        mCanvasYHoch.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);
        mCanvasYRunter.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);

        mCanvasZ.GetComponent<RectTransform>().position = new Vector3(NormiereX(5 * lBreiteAbstandCanvas + 4 * mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasZ.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        mCanvasZHoch.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);
        mCanvasZRunter.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);

        mCanvasMasse.GetComponent<RectTransform>().position = new Vector3(NormiereX(6 * lBreiteAbstandCanvas + 5 * mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasMasse.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        mCanvasMasseHoch.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);
        mCanvasMasseRunter.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);

        mCanvasWinkel.GetComponent<RectTransform>().position = new Vector3(NormiereX(7 * lBreiteAbstandCanvas + 6 * mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasWinkel.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        mCanvasWinkelHoch.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);
        mCanvasWinkelRunter.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);

        if (lGeraeteIFs.istIPAD(mBreiteDisplay, mHoeheDisplay))
        {
            float lPosYTabelle = mHoeheDisplay + lAnzahlHoehenTeile / 11.5f * mHoeheDisplay;
            mCanvasTabelleDaten.GetComponent<RectTransform>().position = new Vector3(NormiereX(lAnzahlHoehenTeile * lBreiteAbstandCanvas + (lAnzahlHoehenTeile-1.5f) * mBreiteCanvas), -250 + mHoeheDisplay, 0);
            mCanvasTabelleDaten.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * mBreiteCanvas, 2 * mHoeheCanvas);

            mCanvasZeitErgebnis.GetComponent<RectTransform>().position = new Vector3(mBreiteDisplay / 2, mHoeheDisplay / 2, 0);
            mZeittext.GetComponent<RectTransform>().position = new Vector3(120, -40 + mHoeheDisplay, 0);
            mErgebnistext.GetComponent<RectTransform>().position = new Vector3(620, -40 + mHoeheDisplay, 0);

            mCanvasZeitErgebnisList.transform.localPosition = new Vector3(280, 150, 0);
            mCanvasZeitErgebnisGesamtpunkte.transform.localPosition = new Vector3(73, -650, 0);

        }
        else
        {
            float lPosYTabelle = mHoeheDisplay + lAnzahlHoehenTeile / 12.5f * mHoeheDisplay;
            mCanvasTabelleDaten.GetComponent<RectTransform>().position = new Vector3(NormiereX(lAnzahlHoehenTeile * lBreiteAbstandCanvas + (lAnzahlHoehenTeile + 1.5f) * mBreiteCanvas), -250 + mHoeheDisplay, 0);
            mCanvasTabelleDaten.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * mBreiteCanvas, 2 * mHoeheCanvas);

            mCanvasZeitErgebnis.GetComponent<RectTransform>().position = new Vector3(mBreiteCanvas/2,mHoeheDisplay/2 , 0);
            mZeittext.GetComponent<RectTransform>().position = new Vector3(120, -40+ mHoeheDisplay, 0);
            mErgebnistext.GetComponent<RectTransform>().position = new Vector3(620, -40+ mHoeheDisplay, 0);

            mCanvasZeitErgebnisList.transform.localPosition = new Vector3(1030, -230, 0);
            mCanvasZeitErgebnisGesamtpunkte.transform.localPosition = new Vector3(480, -255, 0);


        }
    }

    

    private float NormiereX(float pX)
    {
        return pX + mBreiteCanvas / 2;
    }

    private float NormiereY(float pY)
    {
        return pY -mHoeheDisplay + 1.5f * mHoeheCanvas;
    }
}
