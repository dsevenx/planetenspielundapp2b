using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerHatXXXDurchmesser : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private List<HimmelskoerperData> mHimmelskoerperData;

    private bool mAmGroessten;


    public PruefungWerHatXXXDurchmesser(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer, int pHimmelskoerper, bool pAmGroessten)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        mHimmelskoerperData = mHimmelskoerperverwalter.liefer4HimmelskoerperFuerArt(pHimmelskoerper, HimmelskoerperverwalterBase.K_ID_DURCHMESSER_VERGLEICH);
        mAmGroessten = pAmGroessten;

    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferDurchmessertext(mHimmelskoerperData[0]);
    }

    private string lieferDurchmessertext(HimmelskoerperData pHimmelskoerperData)
    {
        return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DURCHMESER)
            + string.Format("{0:##,###,###,###,000}", mHimmelskoerperverwalter.lieferDurchmesserZu(pHimmelskoerperData.mIndex))
            + " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KILOMETER);
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferDurchmessertext(mHimmelskoerperData[1]);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferDurchmessertext(mHimmelskoerperData[2]);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferDurchmessertext(mHimmelskoerperData[3]);
    }

    string InterfacePruefung.ermittelFrage()
    {
        if (mAmGroessten)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_DEN_GROESSTEN_DURCHMESSER);
        }
        else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_DEN_KLEINSTEN_DURCHMESSER);
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
                if (mHimmelskoerperverwalter.lieferDurchmesserZu(lHimmelskoerper.mIndex) > mHimmelskoerperverwalter.lieferDurchmesserZu(lErg.mIndex) && mAmGroessten
                    ||
                    mHimmelskoerperverwalter.lieferDurchmesserZu(lHimmelskoerper.mIndex) < mHimmelskoerperverwalter.lieferDurchmesserZu(lErg.mIndex) && !mAmGroessten
                    )
                {
                    lErg = lHimmelskoerper;
                }
            }

        }

        return lErg.mName;
    }
}
