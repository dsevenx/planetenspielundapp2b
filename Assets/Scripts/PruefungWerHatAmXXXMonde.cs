using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerHatAmXXXMonde : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private List<HimmelskoerperData> mHimmelskoerperData;

    private bool mAmGroessten;

    public PruefungWerHatAmXXXMonde(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer,bool pAmGroessten)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        mHimmelskoerperData = mHimmelskoerperverwalter.liefer4HimmelskoerperFuerArt(Sprachenuebersetzer.K_PLANET,HimmelskoerperverwalterBase.K_ID_MOND_VERGLEICH);
        mAmGroessten = pAmGroessten;
    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferAnzahlMondtext(mHimmelskoerperData[0].mAnzahlMonde);
    }

    private string lieferAnzahlMondtext(int mAnzahlMonde)
    {
       if (mAnzahlMonde == 0)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KEINE_MODNDE_ENTDECKT);
        }
        else if (mAnzahlMonde == 1)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EIN_MODND);
        } else
        {
            return mAnzahlMonde + " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BEANNTE_MODNDE);
        }
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferAnzahlMondtext(mHimmelskoerperData[1].mAnzahlMonde);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferAnzahlMondtext(mHimmelskoerperData[2].mAnzahlMonde);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferAnzahlMondtext(mHimmelskoerperData[3].mAnzahlMonde);
    }

    string InterfacePruefung.ermittelFrage()
    {
        if (mAmGroessten)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_AM_MEISTEN_MONDE);
        } else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_AM_WENIGSTEN_MONDE);
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
                if (lHimmelskoerper.mAnzahlMonde < lErg.mAnzahlMonde && !mAmGroessten

                        ||

                    lHimmelskoerper.mAnzahlMonde > lErg.mAnzahlMonde && mAmGroessten)
                {
                    lErg = lHimmelskoerper;
                }
            }

        }

        return lErg.mName;
    }
}
