using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerHatXXXDichte : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private List<HimmelskoerperData> mHimmelskoerperData;

    private bool mAmGroessten;

    public PruefungWerHatXXXDichte(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer, int pHimmelskoerper, bool pAmGroessten)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        mHimmelskoerperData = mHimmelskoerperverwalter.liefer4HimmelskoerperFuerArt(pHimmelskoerper,HimmelskoerperverwalterBase.K_ID_DICHTE_VERGLEICH);
        mAmGroessten = pAmGroessten;
    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferDichtetext(mHimmelskoerperData[0].mDichte);
    }

    private string lieferDichtetext(float pDichte)
    {
       return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DICHTE_1) + pDichte
            + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DICHTE_2);
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferDichtetext(mHimmelskoerperData[1].mDichte);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferDichtetext(mHimmelskoerperData[2].mDichte);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferDichtetext(mHimmelskoerperData[3].mDichte);
    }

    string InterfacePruefung.ermittelFrage()
    {
        if (mAmGroessten)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_GROESSTE_DICHTE);
        } else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_WENIGSTEN_DICHTE);
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
                if (lHimmelskoerper.mDichte < lErg.mDichte
                   && !mAmGroessten

                       ||

                   lHimmelskoerper.mDichte > lErg.mDichte
                   && mAmGroessten)
                {
                    lErg = lHimmelskoerper;
                }
            }

        }

        return lErg.mName;
    }
}
