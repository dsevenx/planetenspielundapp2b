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

    public GameObject mCanvas4Daten;

    public GameObject mText4Jahre;

    public GameObject mTextMasseUebrig;

    public GameObject mTextGesamtPunkte;

    public float mBreiteCanvas;
    public float mVerhaeltis;
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

    public TextMeshProUGUI mTextMeshProZeit;
    public TextMeshProUGUI mTextMeshProMasseUebrig;

    public GameObject mGameObjectListeName;
    public GameObject mGameObjectListeMasse;
    public GameObject mGameObjectListeGeschwindigkeit;
    public GameObject mGameObjectListeAbstand;
    

    public float mAnzahlHoehenTeile;
    public float mScaleHochRunterX;
    public float mScaleHochRunterY;

    public int mFontSize;
    public int mBreite;

    /*
    void testy(String pText,float p133, float p211, float p216, float p177)
    {
        // Gegebene Vektoren und zugeordnete Werte für e
        double[,] vectors = {
            { 1.33, 7.125, 215.6, p133 },
            { 2.111, 4.5, 240, p211 },
            { 2.167, 4.383, 294.3, p216 },
            { 1.778, 5.341, 140.42, p177}
       };

        // Berechne Durchschnitt der x-, y- und z-Komponenten
        double avgX = 0, avgY = 0, avgZ = 0;
        for (int i = 0; i < vectors.GetLength(0); i++)
        {
            avgX += vectors[i, 0];
            avgY += vectors[i, 1];
            avgZ += vectors[i, 2];
        }
        avgX /= vectors.GetLength(0);
        avgY /= vectors.GetLength(0);
        avgZ /= vectors.GetLength(0);

        // Berechne Durchschnitt des Wertes "e"
        double avgE = 0;
        for (int i = 0; i < vectors.GetLength(0); i++)
        {
            avgE += vectors[i, 3];
        }
        avgE /= vectors.GetLength(0);

        // Lineare Regression
        double m = 0, n = 0, p = 0, b = 0;
        for (int i = 0; i < vectors.GetLength(0); i++)
        {
            m += (vectors[i, 0] - avgX) * (vectors[i, 3] - avgE);
            n += (vectors[i, 1] - avgY) * (vectors[i, 3] - avgE);
            p += (vectors[i, 2] - avgZ) * (vectors[i, 3] - avgE);
            b += (vectors[i, 0] - avgX) * (vectors[i, 0] - avgX) +
                 (vectors[i, 1] - avgY) * (vectors[i, 1] - avgY) +
                 (vectors[i, 2] - avgZ) * (vectors[i, 2] - avgZ);
        }
        m /= b;
        n /= b;
        p /= b;
        b = avgE - m * avgX - n * avgY - p * avgZ;

        // Ausgabe der gefundenen Regressionskoeffizienten
        Debug.Log(pText + "((float)(("+m+" * mVerhaeltis) + ("+n+" * mAnzahlHoehenTeile) + ("+ p +"* mHoeheCanvas) + " + b+"));");
      
        // Berechnung des Wertes "e" für jeden Vektor
        for (int i = 0; i < vectors.GetLength(0); i++)
        {
            double calculatedE = m * vectors[i, 0] + n * vectors[i, 1] + p * vectors[i, 2] + b;
            Debug.Log("e für Vector (" + vectors[i, 0] + ", " + vectors[i, 1] + ", " + vectors[i, 2] + "): " + calculatedE);
        }
    }
    */

    void Start()
    {
        //testy("testx",240,360, 300,255);
        //testy("testy", -425,- 200,- 305,- 50);

        mBreiteDisplay = Display.main.systemWidth;
        mHoeheDisplay = Display.main.systemHeight;
        GeraeteIFs lGeraeteIFs = new GeraeteIFs();
        lGeraeteIFs.init(Camera.main);
        mVerhaeltis = lGeraeteIFs.mVerhaeltnis;

        mAnzahlHoehenTeile = 9.5f / mVerhaeltis;

        mHoeheCanvas = mHoeheDisplay / mAnzahlHoehenTeile;
        float lPosYCanvas = mHoeheCanvas * (mAnzahlHoehenTeile - 1);

        mBreiteCanvas = mHoeheCanvas;
        float lBreiteAbstandCanvas = mBreiteCanvas / 8;
        float lPosYHochRunterCanvas =
            ((float)((9.08994253409362E-05 * mVerhaeltis) + (-0.000287347559337193 * mAnzahlHoehenTeile) + (0.0112722959982346 * mHoeheCanvas) + 10.4173781566851));

        mScaleHochRunterX = ((float)(0.0000366f * mVerhaeltis - 0.000119f * mAnzahlHoehenTeile + 0.00379 * mHoeheCanvas + 0.0493f));
        mScaleHochRunterY = 0.88f; // passt generell

        int lCellX = (int)230;
        int lCellY = (int)(mHoeheCanvas - 50) / 2;//80;
        int lPpaddingTop = -12;
        int lPosYHochRunterText = 5;
        float lNewXSteuerungskreis = 0.85f;
        int lYSpacing = 50;

        mFontSize = (int)(6 * mHoeheDisplay * mBreiteDisplay / 1000000 + 15);
        int lGesamtpunktefontsize = mFontSize * 2;
        int lFontSizeErgebnis = (int)(mFontSize * 0.95f);

        setze4Canvas4Daten();

        mTextMeshProName.fontSize = lFontSizeErgebnis;
        mTextMeshProMasse.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittDistanz.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittDistanzAbweichung.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittGeschwindigkeit.fontSize = lFontSizeErgebnis;
        mTextMeshProDurchschnittGeschwindigkeitAbweichung.fontSize = lFontSizeErgebnis;
        mTextMeshProPunkte.fontSize = lFontSizeErgebnis;

        mTextMeshProZurueck.fontSize = mFontSize;
        mTextMeshProStartstopp.fontSize = mFontSize;
        mTextMeshProEinklappen.fontSize = mFontSize;

        mTextMeshProListeName.fontSize = mFontSize * 0.75f;
        mTextMeshProListeMasse.fontSize = mFontSize * 0.75f;
        mTextMeshProListeGeschwindigkeit.fontSize = mFontSize * 0.75f;
        mTextMeshProListeAbstand.fontSize = mFontSize * 0.75f;

        mTextMeshProGesamtPunkte.fontSize = lGesamtpunktefontsize;

        int lFontSizeWinkelUndCo = mFontSize / 2;
        mTextMeshProEinWinkel.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinMasse.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinX.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinY.fontSize = lFontSizeWinkelUndCo;
        mTextMeshProEinZ.fontSize = lFontSizeWinkelUndCo;

        mTextMeshProZeit.fontSize = mFontSize * 0.85f;
        mTextMeshProMasseUebrig.fontSize = mFontSize * 0.85f;

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

        stelleCanvasEin(mCanvasX, mCanvasXHochrunter, mCanvasXHoch, mCanvasXRunter, lBreiteAbstandCanvas, lPosYCanvas, mScaleHochRunterX, mScaleHochRunterY, lPpaddingTop, lYSpacing, 2, 3, mCanvasXHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasY, mCanvasYHochrunter, mCanvasYHoch, mCanvasYRunter, lBreiteAbstandCanvas, lPosYCanvas, mScaleHochRunterX, mScaleHochRunterY, lPpaddingTop, lYSpacing, 3, 4, mCanvasYHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasZ, mCanvasZHochrunter, mCanvasZHoch, mCanvasZRunter, lBreiteAbstandCanvas, lPosYCanvas, mScaleHochRunterX, mScaleHochRunterY, lPpaddingTop, lYSpacing, 4, 5, mCanvasZHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasMasse, mCanvasMasseHochrunter, mCanvasMasseHoch, mCanvasMasseRunter, lBreiteAbstandCanvas, lPosYCanvas, mScaleHochRunterX, mScaleHochRunterY, lPpaddingTop, lYSpacing, 5, 6, mCanvasMasseHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);

        stelleCanvasEin(mCanvasWinkel, mCanvasWinkelHochrunter, mCanvasWinkelHoch, mCanvasWinkelRunter, lBreiteAbstandCanvas, lPosYCanvas, mScaleHochRunterX, mScaleHochRunterY, lPpaddingTop, lYSpacing, 6, 7, mCanvasWinkelHochRunterText, lCellX, lCellY, lPosYHochRunterCanvas, lPosYHochRunterText);


    }

    private void setze4Canvas4Daten()
    {
        mBreite = mBreiteDisplay / 11 - 30;
        int lBreiteName = (int)(mBreite * 1.3f);
        int lBreiteKorr = mBreiteDisplay / 100;
        int lHoeheKorr = mHoeheDisplay / (mHoeheDisplay/35);

        int lY = -lHoeheKorr + mHoeheDisplay;
        int lX = 0;

        // Zeit
        lX = lX + mBreite / 2 + lBreiteKorr;
        mText4Jahre.GetComponent<RectTransform>().position = new Vector3(lX, lY, 0);
        mText4Jahre.GetComponent<RectTransform>().sizeDelta = new Vector3(mBreite, 50, 0);

        // Masse
        lX = lX + 5*mBreite + lBreiteKorr;
        mTextMasseUebrig.GetComponent<RectTransform>().position = new Vector3(lX, lY, 0);
        mTextMasseUebrig.GetComponent<RectTransform>().sizeDelta = new Vector3(mBreite, 50, 0);

        // Gesamtpunkte
        mTextGesamtPunkte.GetComponent<RectTransform>().position = new Vector3(mBreiteDisplay / 3, -lHoeheKorr + 1*mHoeheDisplay/4, 0);
        mTextGesamtPunkte.GetComponent<RectTransform>().sizeDelta = new Vector3(mBreiteDisplay/2, mHoeheDisplay/5, 0);

        // Planeten Ausgabe
        lX = mBreiteDisplay - lBreiteName - mBreite - mBreite - 3*lBreiteKorr;
        mTextMeshProListeName.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProListeName.GetComponent<RectTransform>().sizeDelta = new Vector2(lBreiteName, 60);

        lX = lX + lBreiteName;
        mTextMeshProListeMasse.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProListeMasse.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 60);

        lX = lX + mBreite;
        mTextMeshProListeGeschwindigkeit.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProListeGeschwindigkeit.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 60);

        lX = lX + mBreite;
        mTextMeshProListeAbstand.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProListeAbstand.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 60);

        // Endauswertung
        lY = lY + 2*lHoeheKorr;
        lX = mBreiteDisplay/3;
        mTextMeshProName.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProName.GetComponent<RectTransform>().sizeDelta = new Vector2(lBreiteName, 100);

        lX = lX + lBreiteName;
        mTextMeshProMasse.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProMasse.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 100);

        lX = lX + lBreiteName;
        mTextMeshProDurchschnittDistanz.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProDurchschnittDistanz.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 100);

        lX = lX + mBreite;
        mTextMeshProDurchschnittDistanzAbweichung.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProDurchschnittDistanzAbweichung.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 100);

        lX = lX + mBreite;
        mTextMeshProDurchschnittGeschwindigkeit.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProDurchschnittGeschwindigkeit.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 100);

        lX = lX + mBreite;
        mTextMeshProDurchschnittGeschwindigkeitAbweichung.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProDurchschnittGeschwindigkeitAbweichung.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 100);

        lX = lX + mBreite;
        mTextMeshProPunkte.GetComponent<RectTransform>().position = new Vector2(lX, lY);
        mTextMeshProPunkte.GetComponent<RectTransform>().sizeDelta = new Vector2(mBreite, 100);
    }

    private void stelleCanvasEin(GameObject pCanvas, GameObject pCanvasHochrunter, GameObject pCanvasHoch, GameObject pCanvasRunter,
        float lBreiteAbstandCanvas, float lPosYCanvas, float lNewX, float lNewY, int lPpaddingTop, int lYSpacing, int pFaktor, int pFaktorVorn,
        GameObject mCanvasMasseHochRunterText, int pCellX, int pCellY, float pPosYHochRunterCanvas, int pPosYHochRunterText)
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
        return pY - mHoeheDisplay + 1.65f * mHoeheCanvas;
    }
}
