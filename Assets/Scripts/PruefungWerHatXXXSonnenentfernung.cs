using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerHatXXXSonnenentfernung : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private List<HimmelskoerperData> mHimmelskoerperData;

    private bool mAmGroessten;


    public PruefungWerHatXXXSonnenentfernung(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer, int pHimmelskoerper, bool pAmGroessten)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        mHimmelskoerperData = mHimmelskoerperverwalter.liefer4HimmelskoerperFuerArt(pHimmelskoerper, HimmelskoerperverwalterBase.K_ID_SONNENENFERNUNG_VERGLEICH);
        mAmGroessten = pAmGroessten;

    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferEntfernungstext(mHimmelskoerperData[0]);
    }

    private string lieferEntfernungstext(HimmelskoerperData pHimmelskoerperData)
    {
      
        if (pHimmelskoerperData.mIndex == Himmelskoerper.K_SONNE)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ENTF_1);
        }
        else
        {
            if (mHimmelskoerperverwalter.lieferEinheitEntfernungZu(pHimmelskoerperData.mIndex) == Sprachenuebersetzer.K_KILOMETER)
            {
                return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ENTF_2)
                    + " " + mSprachenuebersetzer.lieferWort(mHimmelskoerperverwalter.lieferEinheitEntfernungZu(pHimmelskoerperData.mIndex)) +
                    mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_IST) + string.Format("{0:0,0}", mHimmelskoerperverwalter.lieferEntfernungZurSonneZu(pHimmelskoerperData.mIndex));
            }
            else
            {
                return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ENTF_2)
                    + " " + mSprachenuebersetzer.lieferWort(mHimmelskoerperverwalter.lieferEinheitEntfernungZu(pHimmelskoerperData.mIndex)) +
                    mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_IST) + string.Format("{0:###,###,000}", mHimmelskoerperverwalter.lieferEntfernungZurSonneZu(pHimmelskoerperData.mIndex));
            }

        }
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferEntfernungstext(mHimmelskoerperData[1]);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferEntfernungstext(mHimmelskoerperData[2]);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferEntfernungstext(mHimmelskoerperData[3]);
    }

    string InterfacePruefung.ermittelFrage()
    {
        if (mAmGroessten)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_IST_AM_WEITESTEN_VON_DER_SONNE_ENTFERNT);
        }
        else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_IST_AM_KUERZESTEN_VON_DER_SONNE_ENTFERNT);
        }
    }

    string InterfacePruefung.ermittelKorrekteButton()
    {
        HimmelskoerperData lErg = null;
        foreach (var lHimmelskoerper in mHimmelskoerperData)
        {
            if (lErg == null)
            {
                lErg = lHimmelskoerper;
            }
            else
            {
                if (mHimmelskoerperverwalter.lieferEntfernungZurSonneZuVergleich(lHimmelskoerper.mIndex) > mHimmelskoerperverwalter.lieferEntfernungZurSonneZuVergleich(lErg.mIndex) && mAmGroessten
                    ||
                    mHimmelskoerperverwalter.lieferEntfernungZurSonneZuVergleich(lHimmelskoerper.mIndex) < mHimmelskoerperverwalter.lieferEntfernungZurSonneZuVergleich(lErg.mIndex) && !mAmGroessten
                    )
                {
                    lErg = lHimmelskoerper;
                }
            }

        }

        return lErg.mName;
    }
}
