using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerHatXXXMasse : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private List<HimmelskoerperData> mHimmelskoerperData;

    private bool mAmGroessten;


    public PruefungWerHatXXXMasse(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer, int pHimmelskoerper, bool pAmGroessten)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        mHimmelskoerperData = mHimmelskoerperverwalter.liefer4HimmelskoerperFuerArt(pHimmelskoerper, HimmelskoerperverwalterBase.K_ID_MASSE_VERGLEICH);
        mAmGroessten = pAmGroessten;
    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferMassentext(mHimmelskoerperData[0].mMasse);
    }

    private string lieferMassentext(float pMasse)
    {
       if (pMasse < 0.001)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_1) + string.Format("{0:0.00000000000}", pMasse) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_2);
        }
        else if (pMasse > 10000000)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_1) + string.Format("{0:###,###,000,000,000}", pMasse) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_2);
        }
        else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_1) + pMasse + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_2);
        }
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferMassentext(mHimmelskoerperData[1].mMasse);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferMassentext(mHimmelskoerperData[2].mMasse);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferMassentext(mHimmelskoerperData[3].mMasse);
    }

    string InterfacePruefung.ermittelFrage()
    {
        if (mAmGroessten)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_MEHR_MASSE);
        }
        else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_WENIGER_MASSE);
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
                if (lHimmelskoerper.mMasse < lErg.mMasse && !mAmGroessten

                        ||

                    lHimmelskoerper.mMasse > lErg.mMasse && mAmGroessten)
                {
                    lErg = lHimmelskoerper;
                }
            }
        }

        return lErg.mName;
    }
}
