using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerAmXXXXTemperatur : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private List<HimmelskoerperData> mHimmelskoerperData;

    private bool mAmGroessten;


    public PruefungWerAmXXXXTemperatur(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer, int pHimmelskoerper, bool pAmGroessten)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        mHimmelskoerperData = mHimmelskoerperverwalter.liefer4HimmelskoerperFuerArt(pHimmelskoerper, HimmelskoerperverwalterBase.K_ID_TEMPERATUR_VERGLEICH);
        mAmGroessten = pAmGroessten;

    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferTemperaturtext(mHimmelskoerperData[0]);
    }

    private string lieferTemperaturtext(HimmelskoerperData pHimmelskoerperData)
    {
      
        if (mAmGroessten)
        {
             return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MAX_TEMP) + "\n"
                + mHimmelskoerperverwalter.lieferMaxTemperaturZu(pHimmelskoerperData.mIndex) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GRAD);
        }
        else
        {
            if (pHimmelskoerperData.mArtHimmelskoerper == Sprachenuebersetzer.K_SCHWARZES_LOCH)
            {
                return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MIN_TEMP) + "\n"
                     + mHimmelskoerperverwalter.lieferMinTemperaturZu(pHimmelskoerperData.mIndex) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GRAD) + "\n(Hawking-" + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_TEMPERATUR)+")";

            } else
            {
                return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MIN_TEMP) + "\n"
                     + mHimmelskoerperverwalter.lieferMinTemperaturZu(pHimmelskoerperData.mIndex) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GRAD);
            }
        }
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferTemperaturtext(mHimmelskoerperData[1]);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferTemperaturtext(mHimmelskoerperData[2]);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferTemperaturtext(mHimmelskoerperData[3]);
    }

    string InterfacePruefung.ermittelFrage()
    {
        if (mAmGroessten)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WER_IST_AM_HEISSESTEN);
        }
        else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BEI_WEM_IST_ES_AM_KAELTESTEN);
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
                if (mHimmelskoerperverwalter.lieferMaxTemperaturZu(lHimmelskoerper.mIndex) > mHimmelskoerperverwalter.lieferMaxTemperaturZu(lErg.mIndex) && mAmGroessten
                    ||
                    mHimmelskoerperverwalter.lieferMinTemperaturZu(lHimmelskoerper.mIndex) < mHimmelskoerperverwalter.lieferMinTemperaturZu(lErg.mIndex) && !mAmGroessten
                    )
                {
                    lErg = lHimmelskoerper;
                }
            }

        }

        return lErg.mName;
    }
}
