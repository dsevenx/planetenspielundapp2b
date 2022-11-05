using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungWerHatDiesenMond : InterfacePruefung
{
    private HimmelskoerperverwalterBase mHimmelskoerperverwalter;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private HimmelskoerperData mHimmelskoerperDataMond;

    private List<HimmelskoerperData> mHimmelskoerperData;

    public PruefungWerHatDiesenMond(HimmelskoerperverwalterBase pHimmelskoerperverwalterBase, Sprachenuebersetzer pSprachenuebersetzer, int pThema)
    {
        this.mHimmelskoerperverwalter = pHimmelskoerperverwalterBase;
        this.mSprachenuebersetzer = pSprachenuebersetzer;

        mHimmelskoerperDataMond = mHimmelskoerperverwalter.lieferEinHimmelsobjekt(Sprachenuebersetzer.K_MOON);

        if (pThema == PruefungGUISteuerung.K_THEMA_PLANETEN)
        {
            mHimmelskoerperData = mHimmelskoerperverwalter.liefer3HimmelskoerperFuerArtUndEinBestimmten(Sprachenuebersetzer.K_PLANET, mHimmelskoerperDataMond.mHeimatplanet);
        }
        else
        {
            mHimmelskoerperData = mHimmelskoerperverwalter.liefer3HimmelskoerperFuerArtUndEinBestimmten(Sprachenuebersetzer.K_ALL, mHimmelskoerperDataMond.mHeimatplanet);
        }

    }

    string InterfacePruefung.ermittelAntwort_A()
    {
        return mHimmelskoerperData[0].mName;
    }

    string InterfacePruefung.ermittelAntwort_A_Erklaerung()
    {
        return lieferMondtext(mHimmelskoerperData[0]);
    }

    private string lieferMondtext(HimmelskoerperData pHimmelskoerperData)
    {
        if (pHimmelskoerperData.mIndex == mHimmelskoerperDataMond.mHeimatplanet)
        {
            return mHimmelskoerperDataMond.mName +  mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GEHOERT_ZU) + mHimmelskoerperverwalter.getMyHimmelskoerperDict()[mHimmelskoerperDataMond.mHeimatplanet].mName;
        }
        else if (pHimmelskoerperData.mAnzahlMonde == 1)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HAT_EIN_MOND_ABER)+  mHimmelskoerperDataMond.mName+".";
        }
        else if (pHimmelskoerperData.mAnzahlMonde > 0)
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HAT_MONDE_ABER) + mHimmelskoerperDataMond.mName + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_IST_NICHT_DABEI);
        }
        else
        {
            return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KEINE_MODNDE_ENTDECKT);
        }
    }

    string InterfacePruefung.ermittelAntwort_B()
    {
        return mHimmelskoerperData[1].mName;
    }

    string InterfacePruefung.ermittelAntwort_B_Erklaerung()
    {
        return lieferMondtext(mHimmelskoerperData[1]);
    }

    string InterfacePruefung.ermittelAntwort_C()
    {
        return mHimmelskoerperData[2].mName;
    }

    string InterfacePruefung.ermittelAntwort_C_Erklaerung()
    {
        return lieferMondtext(mHimmelskoerperData[2]);
    }

    string InterfacePruefung.ermittelAntwort_D()
    {
        return mHimmelskoerperData[3].mName;
    }

    string InterfacePruefung.ermittelAntwort_D_Erklaerung()
    {
        return lieferMondtext(mHimmelskoerperData[3]);
    }

    string InterfacePruefung.ermittelFrage()
    {
        return mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ZU_WEM_GEHOERT_MOND).Replace("##",mHimmelskoerperverwalter.getMyHimmelskoerperDict()[mHimmelskoerperDataMond.mIndex].mName);
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
                if (lHimmelskoerper.mIndex == mHimmelskoerperDataMond.mHeimatplanet)
                {
                    lErg = lHimmelskoerper;
                }
            }

        }

        return lErg.mName;
    }
}
