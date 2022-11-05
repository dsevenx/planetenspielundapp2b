using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerHatPhobosUndDeimos : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private List<HimmelskoerperData> mHimmelskoerperData;

    public PruefungWerHatPhobosUndDeimos(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer, int pThema)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        if (pThema == PruefungGUISteuerung.K_THEMA_PLANETEN)
        {
            mHimmelskoerperData = mHimmelskoerperverwalter.liefer3HimmelskoerperFuerArtUndEinBestimmten(Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_MARS);
        } else
        {
            mHimmelskoerperData = mHimmelskoerperverwalter.liefer3HimmelskoerperFuerArtUndEinBestimmten(Sprachenuebersetzer.K_ALL, Himmelskoerper.K_MARS);
        }
       
    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferErklaerungstext(mHimmelskoerperData[0]);
    }

    private string lieferErklaerungstext(HimmelskoerperData pHimmelskoerperData)
    {
         if (pHimmelskoerperData.mIndex == Himmelskoerper.K_MARS)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PHOBOS_UND_DEIMOS);
        }
        else 
        {
            if (pHimmelskoerperData.mArtHimmelskoerper.Equals(Sprachenuebersetzer.K_PLANET))
            {
                if (pHimmelskoerperData.mAnzahlMonde == 0)
                {
                    return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KEINE_MODNDE_ENTDECKT);
                } else if (pHimmelskoerperData.mAnzahlMonde == 1)
                {
                    return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EIN_MODND);
                }
                else 
                {
                    return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HAT_MONDE_ABER_NICHT_DEIMOS_UND_PHOBOS);
                }
            } else
            {
                return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NUR_PLANETEN_HABEN_MONDE);
            }
        } 
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferErklaerungstext(mHimmelskoerperData[1]);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferErklaerungstext(mHimmelskoerperData[2]);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferErklaerungstext(mHimmelskoerperData[3]);
    }

    string InterfacePruefung.ermittelFrage()
    {
        return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_HAT_AM_PHOBOS_UND_DEIMOS);
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
                if (lHimmelskoerper.mIndex == Himmelskoerper.K_MARS)
                {
                    lErg = lHimmelskoerper;
                }
            }
        }

        return lErg.mName;
    }
}
