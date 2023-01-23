using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AufloesungskuemmererGraviArena : MonoBehaviour
{
    public int mBreiteDisplay;

    public int mHoeheDisplay;

    public GameObject mCanvasSteuerung;
    public GameObject mCanvasSteuerungKreis;

    public GameObject mCanvasSchuss;

    public GameObject mCanvasX;
    public GameObject mCanvasXHochrunter;
    public GameObject mCanvasXHoch;
    public GameObject mCanvasXRunter;
    public GameObject mCanvasXHochRunterText;

    public GameObject mCanvasY;
    public GameObject mCanvasYHochrunter;
    public GameObject mCanvasYHoch;
    public GameObject mCanvasYRunter;
    public GameObject mCanvasYHochRunterText;

    public GameObject mCanvasZ;
    public GameObject mCanvasZHochrunter;
    public GameObject mCanvasZHoch;
    public GameObject mCanvasZRunter;
    public GameObject mCanvasZHochRunterText;

    public GameObject mCanvasMasse;
    public GameObject mCanvasMasseHochrunter;
    public GameObject mCanvasMasseHoch;
    public GameObject mCanvasMasseRunter;
    public GameObject mCanvasMasseHochRunterText;

    public GameObject mCanvasWinkel;
    public GameObject mCanvasWinkelHochrunter;
    public GameObject mCanvasWinkelHoch;
    public GameObject mCanvasWinkelRunter;
    public GameObject mCanvasWinkelHochRunterText;

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

    public TextMeshProUGUI mTextMeshProName;
    public TextMeshProUGUI mTextMeshProMasse;
    public TextMeshProUGUI mTextMeshProDurchschnittDistanz;
    public TextMeshProUGUI mTextMeshProDurchschnittDistanzAbweichung;
    public TextMeshProUGUI mTextMeshProDurchschnittGeschwindigkeit;
    public TextMeshProUGUI mTextMeshProDurchschnittGeschwindigkeitAbweichung;
    public TextMeshProUGUI mTextMeshProPunkte;

    public TextMeshProUGUI mTextMeshProGesamtPunkte;

    public TextMeshProUGUI mTextMeshProZurueck;
    public TextMeshProUGUI mTextMeshProStartstopp;
    public TextMeshProUGUI mTextMeshProEinklappen;

    public TextMeshProUGUI mTextMeshProEinWinkel;
    public TextMeshProUGUI mTextMeshProEinMasse;
    public TextMeshProUGUI mTextMeshProEinX;
    public TextMeshProUGUI mTextMeshProEinY;
    public TextMeshProUGUI mTextMeshProEinZ;

    public TextMeshProUGUI mTextMeshProListeName;
    public TextMeshProUGUI mTextMeshProListeMasse;
    public TextMeshProUGUI mTextMeshProListeGeschwindigkeit;
    public TextMeshProUGUI mTextMeshProListeAbstand;


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

        mHoeheCanvas = mHoeheDisplay / lAnzahlHoehenTeile;
        float lPosYCanvas = mHoeheCanvas * (lAnzahlHoehenTeile - 1);

        float lNewX = 1.00f;
        float lNewY = 1.07f;
        float lNewXSteuerungskreis = 1.00f;
        int lPpaddingTop = -4;
        int lYSpacing = -25;
        int lCanvas4Datentabellenkorrektur = 0;
        int lCellX = 200;
        int lCellY = 115;
        int lPosYHochRunterCanvas = 8;
        int lPosYHochRunterText= 5;
        int lFontSize  = 28;
        int lFontSizeErgebnis = 28;
        int lTabelleYPos = -250;
        int lKorrErgebnisListeX = 0;
        int lKorrErgebnisListeY = 0;
        float lKorrEregbnisXScale = 0.68f;
        int lGesamtpunktefontsize = 65;
        int lKorrErgebnisGesamtPunkte = 0;



        if (lGeraeteIFs.istIPHONE_small(mBreiteDisplay, mHoeheDisplay))
        {
            // IPhone Small
            mHoeheCanvas = 170;
            if (mHoeheDisplay > 2000)
            {
                // India Phone
                mHoeheCanvas = mHoeheDisplay / 4.8f;
                lFontSize = 60;
                lFontSizeErgebnis =40;
                lPosYCanvas = lPosYCanvas + mHoeheDisplay / 21;
                lNewX = 0.72f*3;
                lNewY = 0.52f*3;
                lNewXSteuerungskreis = 0.72f;
                lPpaddingTop = -60;
                lTabelleYPos = -500;

                lPosYHochRunterCanvas = 22;
                lYSpacing = 150;
                lCellX = 230;
                lCellY = 100;
                lCanvas4Datentabellenkorrektur = 500;
                lKorrErgebnisListeX = mBreiteDisplay / 2 - 80;
                lKorrErgebnisListeY = mHoeheDisplay / 4 * (-1) -  140;
                lKorrEregbnisXScale = 2.3f;
                lGesamtpunktefontsize = 100;
                lKorrErgebnisGesamtPunkte = -350;
            }
            else  if (mHoeheDisplay > 1200)
            {
                mHoeheCanvas = mHoeheDisplay / 4.8f;
                lFontSize = 38;
                lFontSizeErgebnis = 38;
                lNewX = 0.72f;
                lNewY = 0.52f;
                lNewXSteuerungskreis = 0.72f;
                lYSpacing = -15;
                lCanvas4Datentabellenkorrektur = -98;
                lKorrEregbnisXScale = 1.6f;
            }
            else
            {
                lNewX = 0.72f;
                lNewY = 0.52f;
                lNewXSteuerungskreis = 0.72f;
                lYSpacing = -15;
                lCanvas4Datentabellenkorrektur = -98;

            }
            lPpaddingTop = -9;
          
            float lPosYTabelle = mHoeheDisplay + lAnzahlHoehenTeile / 12.5f * mHoeheDisplay;
            mCanvasTabelleDaten.GetComponent<RectTransform>().position = new Vector3(
                NormiereX(lAnzahlHoehenTeile * lBreiteAbstandCanvas + (lAnzahlHoehenTeile + 1.5f) * mBreiteCanvas)
                + lCanvas4Datentabellenkorrektur
                , lTabelleYPos + mHoeheDisplay, 0);
            mCanvasTabelleDaten.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * mBreiteCanvas, 2 * mHoeheCanvas);

            mCanvasZeitErgebnis.GetComponent<RectTransform>().position = new Vector3(mBreiteCanvas / 2, mHoeheDisplay / 2, 0);
            mZeittext.GetComponent<RectTransform>().position = new Vector3(120, -40 + mHoeheDisplay, 0);
            mErgebnistext.GetComponent<RectTransform>().position = new Vector3(620, -40 + mHoeheDisplay, 0);

            mCanvasZeitErgebnisList.transform.localPosition = new Vector3(920+ lKorrErgebnisListeX, -230- lKorrErgebnisListeY, 0);
            mCanvasZeitErgebnisList.transform.localScale = new Vector3(lKorrEregbnisXScale, 1.13F, 1F);
            mCanvasZeitErgebnisGesamtpunkte.transform.localPosition = new Vector3(480+ lKorrErgebnisListeX, -255 + lKorrErgebnisGesamtPunkte, 0);
        }
        else if (lGeraeteIFs.istIPHONE(mBreiteDisplay, mHoeheDisplay))
        {
            // D7X Iphone
            lNewX = 0.82f;
            lNewY = 0.87f;
            lNewXSteuerungskreis = 0.82f;
            mHoeheCanvas = 190;

            lPpaddingTop = -19;
            lYSpacing = 40;
            lCellX = 230;
            lCellY = 80;
            lPosYHochRunterCanvas = 6;
            lPosYHochRunterText = 3;
            lFontSize = 28;
            lFontSizeErgebnis = 28;

            float lPosYTabelle = mHoeheDisplay + lAnzahlHoehenTeile / 12.5f * mHoeheDisplay;
            mCanvasTabelleDaten.GetComponent<RectTransform>().position = new Vector3(NormiereX(lAnzahlHoehenTeile * lBreiteAbstandCanvas + (lAnzahlHoehenTeile + 1.5f) * mBreiteCanvas) + lCanvas4Datentabellenkorrektur, lTabelleYPos + mHoeheDisplay, 0);
            mCanvasTabelleDaten.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * mBreiteCanvas, 2 * mHoeheCanvas);

            mCanvasZeitErgebnis.GetComponent<RectTransform>().position = new Vector3(mBreiteCanvas / 2 + 100, mHoeheDisplay / 2, 0);
            mZeittext.GetComponent<RectTransform>().position = new Vector3(120, -40 + mHoeheDisplay, 0);
            mErgebnistext.GetComponent<RectTransform>().position = new Vector3(620, -40 + mHoeheDisplay, 0);

            mCanvasZeitErgebnisList.transform.localPosition = new Vector3(1100, -230, 0);
            mCanvasZeitErgebnisGesamtpunkte.transform.localPosition = new Vector3(480, -255, 0);
        }
        else if (lGeraeteIFs.istIPAD(mBreiteDisplay, mHoeheDisplay))
        {
            // IPAD###
            lNewX = 0.85f;
            lNewY = 1.07f;
            lNewXSteuerungskreis = 0.85f;
            lPpaddingTop = -12;
            lYSpacing = 50;
            lCellX = 230;
            lCellY = 80;
            lTabelleYPos = -260;
            lFontSize = 33;
            lFontSizeErgebnis = 25;

            lCanvas4Datentabellenkorrektur = -100;

            float lPosYTabelle = mHoeheDisplay + lAnzahlHoehenTeile / 11.5f * mHoeheDisplay;
            mCanvasTabelleDaten.GetComponent<RectTransform>().position = new Vector3(NormiereX(lAnzahlHoehenTeile * lBreiteAbstandCanvas + (lAnzahlHoehenTeile - 1.5f) * mBreiteCanvas) + lCanvas4Datentabellenkorrektur, lTabelleYPos + mHoeheDisplay, 0);
            mCanvasTabelleDaten.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * mBreiteCanvas, 2 * mHoeheCanvas);

            mCanvasZeitErgebnis.GetComponent<RectTransform>().position = new Vector3(mBreiteDisplay / 2, mHoeheDisplay / 2, 0);
            mZeittext.GetComponent<RectTransform>().position = new Vector3(120, -40 + mHoeheDisplay, 0);
            mErgebnistext.GetComponent<RectTransform>().position = new Vector3(620, -40 + mHoeheDisplay, 0);

            mCanvasZeitErgebnisList.transform.localPosition = new Vector3(620, 140, 0);
            mCanvasZeitErgebnisList.transform.localScale = new Vector3(0.8f, 1.13F, 1F);
            mCanvasZeitErgebnisGesamtpunkte.transform.localPosition = new Vector3(73, -400, 0);
        }
        else if (lGeraeteIFs.istSigridPhone(mBreiteDisplay, mHoeheDisplay))
        {
            // Sigrid Phone ###
            lNewX = 0.91f;
            lNewY = 0.91f;
            lNewXSteuerungskreis = 0.91f;
            mHoeheCanvas = 280;

            lPpaddingTop = -58;
            lYSpacing = 46;
            lCellX = 300;
            lCellY = 116;
            lPosYHochRunterCanvas = -37;
            lPosYHochRunterText = 3;
            lPosYCanvas = lPosYCanvas - 155;

            lFontSize = mHoeheDisplay / 30;
            lFontSizeErgebnis = mHoeheDisplay / 30;
            lTabelleYPos = -320;
            lCanvas4Datentabellenkorrektur = -1000;

            float lPosYTabelle = mHoeheDisplay + lAnzahlHoehenTeile / 12.5f * mHoeheDisplay;
            mCanvasTabelleDaten.GetComponent<RectTransform>().position = new Vector3(NormiereX(lAnzahlHoehenTeile * lBreiteAbstandCanvas + (lAnzahlHoehenTeile + 1.5f) * mBreiteCanvas) + lCanvas4Datentabellenkorrektur, lTabelleYPos  + mHoeheDisplay, 0);
            mCanvasTabelleDaten.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * mBreiteCanvas, 2 * mHoeheCanvas);

            mCanvasZeitErgebnis.GetComponent<RectTransform>().position = new Vector3(mBreiteCanvas / 2 + 600, mHoeheDisplay / 2, 0);
            mZeittext.GetComponent<RectTransform>().position = new Vector3(120, -40 + mHoeheDisplay, 0);
            mErgebnistext.GetComponent<RectTransform>().position = new Vector3(1100, -60 + mHoeheDisplay, 0);

            mCanvasZeitErgebnisList.transform.localPosition = new Vector3(mBreiteDisplay / 2 + 160, -70, 0);
            
            mCanvasZeitErgebnisList.transform.localScale = new Vector2(1, 1.13f);
            mCanvasZeitErgebnisGesamtpunkte.transform.localPosition = new Vector3(480, -455, 0);
        }
        else 
        {
            // M.Altner Phone ###
            lNewX = 0.91f;
            lNewY = 0.91f;
            lNewXSteuerungskreis = 0.91f;
            mHoeheCanvas = 280;

            lPpaddingTop = -58;
            lYSpacing = 46;
            lCellX = 300;
            lCellY = 116;
            lPosYHochRunterCanvas = -37;
            lPosYHochRunterText = 3;
            lPosYCanvas = lPosYCanvas - 155;

            lFontSize = mHoeheDisplay / 30;
            lFontSizeErgebnis = mHoeheDisplay / 40;
            lTabelleYPos = -320;
            lCanvas4Datentabellenkorrektur = -1000;

            float lPosYTabelle = mHoeheDisplay + lAnzahlHoehenTeile / 12.5f * mHoeheDisplay;
            mCanvasTabelleDaten.GetComponent<RectTransform>().position = new Vector3(NormiereX(lAnzahlHoehenTeile * lBreiteAbstandCanvas + (lAnzahlHoehenTeile + 1.5f) * mBreiteCanvas) + lCanvas4Datentabellenkorrektur, lTabelleYPos + mHoeheDisplay, 0);
            mCanvasTabelleDaten.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * mBreiteCanvas, 2 * mHoeheCanvas);

            mCanvasZeitErgebnis.GetComponent<RectTransform>().position = new Vector3(mBreiteCanvas / 2 + 600, mHoeheDisplay / 2, 0);
            mZeittext.GetComponent<RectTransform>().position = new Vector3(120, -40 + mHoeheDisplay, 0);
            mErgebnistext.GetComponent<RectTransform>().position = new Vector3(1100, -60 + mHoeheDisplay, 0);

            mCanvasZeitErgebnisList.transform.localPosition = new Vector3(mBreiteDisplay / 2 + 170, -40, 0);
           
            mCanvasZeitErgebnisList.transform.localScale = new Vector2(0.95f, 1.13f);
            mCanvasZeitErgebnisGesamtpunkte.transform.localPosition = new Vector3(480, -455, 0);
        }

        mTextMeshProName.fontSize = lFontSizeErgebnis;
        mTextMeshProMasse.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittDistanz.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittDistanzAbweichung.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittGeschwindigkeit.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittGeschwindigkeitAbweichung.fontSize = lFontSizeErgebnis;
        mTextMeshProPunkte.fontSize = lFontSizeErgebnis;

        mTextMeshProZurueck.fontSize = lFontSize;
        mTextMeshProStartstopp.fontSize = lFontSize;
        mTextMeshProEinklappen.fontSize = lFontSize;

        mTextMeshProListeName.fontSize = lFontSize *0.75f;
        mTextMeshProListeMasse.fontSize = lFontSize * 0.75f;
        mTextMeshProListeGeschwindigkeit.fontSize = lFontSize * 0.75f;
        mTextMeshProListeAbstand.fontSize = lFontSize * 0.75f;

        mTextMeshProGesamtPunkte.fontSize = lGesamtpunktefontsize;

        int lFontSizeWinkelUndCo = lFontSize / 2;
        mTextMeshProEinWinkel.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinMasse.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinX.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinY.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinZ.fontSize = lFontSizeWinkelUndCo;

        mEinAusKlapper.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas + mHoeheCanvas - lBreiteAbstandCanvas), 0);
        mEinAusKlapper.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas / 2);

        mStartStopper.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas + 1.5f * mHoeheCanvas - 0.25f * lBreiteAbstandCanvas), 0);
        mStartStopper.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas / 2);

        mZurueck.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas + 2.1f * mHoeheCanvas - 0.25f * lBreiteAbstandCanvas), 0);
        mZurueck.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas / 2);

        mCanvasSteuerung.GetComponent<RectTransform>().position = new Vector3(NormiereX(lBreiteAbstandCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasSteuerung.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);

        mCanvasSchuss.GetComponent<RectTransform>().position = new Vector3(NormiereX(2 * lBreiteAbstandCanvas + mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        mCanvasSchuss.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);


        mCanvasSteuerungKreis.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);
        mCanvasSteuerungKreis.GetComponent<RectTransform>().localScale = new Vector2(lNewXSteuerungskreis, lNewXSteuerungskreis);

        stelleCanvasEin(mCanvasX, mCanvasXHochrunter, mCanvasXHoch, mCanvasXRunter, lBreiteAbstandCanvas, lPosYCanvas, lNewX, lNewY, lPpaddingTop, lYSpacing, 2, 3, mCanvasXHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasY, mCanvasYHochrunter, mCanvasYHoch, mCanvasYRunter, lBreiteAbstandCanvas, lPosYCanvas, lNewX, lNewY, lPpaddingTop, lYSpacing, 3, 4, mCanvasYHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasZ, mCanvasZHochrunter, mCanvasZHoch, mCanvasZRunter, lBreiteAbstandCanvas, lPosYCanvas, lNewX, lNewY, lPpaddingTop, lYSpacing, 4, 5, mCanvasZHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasMasse,mCanvasMasseHochrunter, mCanvasMasseHoch, mCanvasMasseRunter,lBreiteAbstandCanvas, lPosYCanvas, lNewX, lNewY, lPpaddingTop, lYSpacing, 5,6, mCanvasMasseHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasWinkel, mCanvasWinkelHochrunter, mCanvasWinkelHoch, mCanvasWinkelRunter, lBreiteAbstandCanvas, lPosYCanvas, lNewX, lNewY, lPpaddingTop, lYSpacing, 6,7, mCanvasWinkelHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

       
    }

  
    private void stelleCanvasEin(GameObject pCanvas, GameObject pCanvasHochrunter, GameObject pCanvasHoch, GameObject pCanvasRunter,
        float lBreiteAbstandCanvas, float lPosYCanvas, float lNewX, float lNewY, int lPpaddingTop, int lYSpacing, int pFaktor, int pFaktorVorn,
        GameObject mCanvasMasseHochRunterText, int pCellX,int pCellY, int pPosYHochRunterCanvas, int pPosYHochRunterText)
    {
        pCanvas.GetComponent<RectTransform>().position = new Vector3(NormiereX(pFaktorVorn * lBreiteAbstandCanvas + pFaktor * mBreiteCanvas), NormiereY(lPosYCanvas), 0);
        pCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas);
        pCanvasHochrunter.GetComponent<RectTransform>().localPosition = new Vector3(0, pPosYHochRunterCanvas, 0);
        pCanvasHochrunter.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreiteCanvas, mHoeheCanvas - lYSpacing);
        pCanvasHochrunter.GetComponent<UnityEngine.UI.GridLayoutGroup>().spacing = new Vector2(2, lYSpacing);
        pCanvasHochrunter.GetComponent<UnityEngine.UI.GridLayoutGroup>().padding.top = lPpaddingTop;
        pCanvasHochrunter.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = new Vector2(pCellX, pCellY);
        pCanvasHoch.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);
        pCanvasRunter.GetComponent<RectTransform>().localScale = new Vector2(lNewX, lNewY);
        mCanvasMasseHochRunterText.GetComponent<RectTransform>().localPosition = new Vector3(0, pPosYHochRunterText, 0);
    }


    private float NormiereX(float pX)
    {
        return pX + mBreiteCanvas / 2;
    }

    private float NormiereY(float pY)
    {
        return pY -mHoeheDisplay + 1.65f * mHoeheCanvas;
    }
}
