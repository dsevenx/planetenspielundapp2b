using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarstellungAttractElementProtokoll
{
    public int mNummer;

    public string mName;

    public List<DarstellungAttractElementProtokollElem> mListDarstellungAttractElementProtokollElem;


    public int mSpeedDurchschnitt;

    public int mDistanceDurchschnitt;

    // Berwertung
    public int mMasseMeistensWert;

    public int mMasseMeistensTage;


    public int mSpeedabweichung; //  Prozent

    public int mDistanzeabweichung; //  Prozent

    public int mMassenpunkte;

    public int mPunkteErmittelt;

    public DarstellungAttractElementProtokoll(int pNummer, string pName, int pMassenpunkte)
    {
        mNummer = pNummer;
        mName = pName;
        mMassenpunkte = pMassenpunkte;
        mListDarstellungAttractElementProtokollElem = new List<DarstellungAttractElementProtokollElem>();
    }

    public List<DarstellungAttractElementProtokollElem> getListDarstellungAttractElementProtokollElem()
    {
        return mListDarstellungAttractElementProtokollElem;
    }

    public void hinzufuegen(int pAbstand, string pSpeed, string pMasse)
    {
        DarstellungAttractElementProtokollElem lDarstellungAttractElementProtokollElem = new DarstellungAttractElementProtokollElem();

        lDarstellungAttractElementProtokollElem.mAbstand = pAbstand;
        lDarstellungAttractElementProtokollElem.mSpeed = Int32.Parse(pSpeed);
        lDarstellungAttractElementProtokollElem.mMasse = Int32.Parse(pMasse);

        mListDarstellungAttractElementProtokollElem.Add(lDarstellungAttractElementProtokollElem);
    }

    public void ermittel()
    {
        Dictionary<int, int> lMassenAnzahl = new Dictionary<int, int>();
        mSpeedDurchschnitt = 0;
        mDistanceDurchschnitt = 0;

        foreach (var lDarstellungAttractElementProtokollElem in mListDarstellungAttractElementProtokollElem)
        {
            // Massen
            if (lMassenAnzahl.ContainsKey(lDarstellungAttractElementProtokollElem.mMasse))
            {
                lMassenAnzahl[lDarstellungAttractElementProtokollElem.mMasse] = lMassenAnzahl[lDarstellungAttractElementProtokollElem.mMasse] + 1;
            }
            else
            {
                lMassenAnzahl.Add(lDarstellungAttractElementProtokollElem.mMasse, 1);
            }

            //Speed
            mSpeedDurchschnitt = mSpeedDurchschnitt + lDarstellungAttractElementProtokollElem.mSpeed;

            //Speed
            mDistanceDurchschnitt = mDistanceDurchschnitt + lDarstellungAttractElementProtokollElem.mAbstand;
        }

        mMasseMeistensTage = 0;
        mMasseMeistensWert = 0;
        foreach (var lMasse in lMassenAnzahl.Keys)
        {
            if (lMassenAnzahl[lMasse] > mMasseMeistensTage)
            {
                mMasseMeistensTage = lMassenAnzahl[lMasse];
                mMasseMeistensWert = lMasse;
            }
        }

        mDistanceDurchschnitt = mDistanceDurchschnitt / mListDarstellungAttractElementProtokollElem.Count;

        mSpeedDurchschnitt = mSpeedDurchschnitt / mListDarstellungAttractElementProtokollElem.Count;

        int lAbweichungDistanzSumme = 0;
        int lAbweichungSpeedSumme = 0;
        foreach (var lDarstellungAttractElementProtokollElem in mListDarstellungAttractElementProtokollElem)
        {
            lAbweichungDistanzSumme = lAbweichungDistanzSumme + Math.Abs(mDistanceDurchschnitt - lDarstellungAttractElementProtokollElem.mAbstand);

            lAbweichungSpeedSumme = lAbweichungSpeedSumme + Math.Abs(mSpeedDurchschnitt - lDarstellungAttractElementProtokollElem.mSpeed);
        }

        mDistanzeabweichung = ((lAbweichungDistanzSumme / mListDarstellungAttractElementProtokollElem.Count) * 100) / mDistanceDurchschnitt;

        mSpeedabweichung = ((lAbweichungSpeedSumme / mListDarstellungAttractElementProtokollElem.Count) * 100) / mSpeedDurchschnitt;

        mPunkteErmittelt = 0;

        if (mMasseMeistensTage >= 100)
        {
            mPunkteErmittelt += 20;
        }
        else if (mMasseMeistensTage >= 50)
        {
            mPunkteErmittelt += 10;
        }

        if (mPunkteErmittelt > 0)
        {
            mPunkteErmittelt = mPunkteErmittelt + mMassenpunkte;


            if (mDistanceDurchschnitt > 20 && mDistanceDurchschnitt <= 150)
            {
                mPunkteErmittelt += 20;
            }
            else if (ist150er())
            {
                mPunkteErmittelt += 15;
            }
            else if (ist250er())
            {
                mPunkteErmittelt += 10;
            }
            else if (mDistanceDurchschnitt > 400 && mDistanceDurchschnitt <= 700)
            {
                mPunkteErmittelt += 5;
            }

            if (mDistanzeabweichung <= 20)
            {
                mPunkteErmittelt += 20;
            }
            else if (mDistanzeabweichung <= 25)
            {
                mPunkteErmittelt += 15;
            }
            else if (mDistanzeabweichung <= 30)
            {
                mPunkteErmittelt += 10;
            }
            else if (mDistanzeabweichung <= 50)
            {
                mPunkteErmittelt += 5;
            }

            if (mSpeedabweichung <= 10)
            {
                mPunkteErmittelt += 20;
            }
            else if (mSpeedabweichung <= 15)
            {
                mPunkteErmittelt += 15;
            }
            else if (mSpeedabweichung <= 20)
            {
                mPunkteErmittelt += 10;
            }
            else if (mSpeedabweichung <= 50)
            {
                mPunkteErmittelt += 5;
            }

        }
    }

    internal bool ist150er()
    {
        return (mDistanceDurchschnitt > 150 && mDistanceDurchschnitt <= 250);

    }
    internal bool ist250er()
    {
        return (mDistanceDurchschnitt > 250 && mDistanceDurchschnitt <= 400);

    }
}
