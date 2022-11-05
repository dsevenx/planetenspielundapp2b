using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DarstellungAttractelementInfos : MonoBehaviour
{

    public AttractElementVerwalter mAttractElementVerwalter;

    public TextMeshProUGUI mTextMeshProName;

    public TextMeshProUGUI mTextMeshProMasse;

    public TextMeshProUGUI mTextMeshProSpeed;

    public TextMeshProUGUI mTextMeshProAbstand;

    public Sprachenuebersetzer mSprachenuebersetzer;

    List<DarstellungAttractElement> mAllListex;

    private string mLebte;

    private string mFuer;

    private void Start()
    {
        init();
     
        mLebte = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_LEBTE);
        mFuer = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FUER);

    }

    public void init()
    {
        mAllListex = new List<DarstellungAttractElement>();
    }

    void Update()
    {
        int lZeitIndex = mAttractElementVerwalter.lieferZeitIndex();

        if (lZeitIndex > 0 && lZeitIndex < AttractElementVerwalter.K_URKNALL)
        {
            if(!mAttractElementVerwalter.liefermAllListeAufgesammelt().ContainsKey(lZeitIndex))
            {
                List<DarstellungAttractElement>  mAllListKopie = new List<DarstellungAttractElement>();

                foreach (var lDarstellungAttractElementAll in mAllListex)
                {
                    if (lDarstellungAttractElementAll.mNummer != 0)
                    {
                        mAllListKopie.Add(lDarstellungAttractElementAll.lieferKopie());
                    }
                }
                mAttractElementVerwalter.liefermAllListeAufgesammelt().Add(lZeitIndex, mAllListKopie);
            }
        }

        string lNamePlaneten = mSprachenuebersetzer.lieferNamen();

        if (lNamePlaneten.Length>4)
        {
            lNamePlaneten = lNamePlaneten.Substring(0, 4);
        }

        foreach (DarstellungAttractElement lDarstellungAttractElementAll in mAllListex)
        {
            lDarstellungAttractElementAll.mAktiv = false; ;
        }

        foreach (DarstellungAttractElement lDarstellungAttractElement in mAttractElementVerwalter.liefer4Darstellung(lNamePlaneten))
        {
            bool lGefundenInAll = false;
            foreach (DarstellungAttractElement lDarstellungAttractElementAll in mAllListex)
            {
                if (lDarstellungAttractElement.mName.Equals(lDarstellungAttractElementAll.mName))
                {
                    lGefundenInAll = true;
                    lDarstellungAttractElementAll.mAktiv = true;
                    lDarstellungAttractElementAll.mAbstand = lDarstellungAttractElement.mAbstand;
                    lDarstellungAttractElementAll.mMasse = lDarstellungAttractElement.mMasse;
                    lDarstellungAttractElementAll.mSpeed = lDarstellungAttractElement.mSpeed;
                    lDarstellungAttractElementAll.mNummer = lDarstellungAttractElement.mNummer;
                    lDarstellungAttractElementAll.mTime = lDarstellungAttractElementAll.mTime + Time.deltaTime;
                }
            }

            if (!lGefundenInAll)
            {
                lDarstellungAttractElement.mAktiv = true;
                lDarstellungAttractElement.mTime = Time.deltaTime;
                mAllListex.Add(lDarstellungAttractElement);
            }
        }

        mTextMeshProName.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NAMEN_COLUMN) + "\n";
        mTextMeshProMasse.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_3) + "\n";
        mTextMeshProSpeed.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_SPEED) + "\n" ;
        mTextMeshProAbstand.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DISTANZ) + "\n" ;

        foreach (DarstellungAttractElement lDarstellungAttractElement in mAllListex)
        {
            mTextMeshProName.text = mTextMeshProName.text + lDarstellungAttractElement.mName + "\n";
            if (lDarstellungAttractElement.mAktiv)
            {
                mTextMeshProMasse.text = mTextMeshProMasse.text + lDarstellungAttractElement.mMasse + "\n";
                mTextMeshProSpeed.text = mTextMeshProSpeed.text + lDarstellungAttractElement.mSpeed + "\n";
                mTextMeshProAbstand.text = mTextMeshProAbstand.text + lDarstellungAttractElement.mAbstand + "\n";
            }
            else
            {
                mTextMeshProMasse.text = mTextMeshProMasse.text + mLebte + "\n";
                mTextMeshProSpeed.text = mTextMeshProSpeed.text + mFuer + "\n";
                mTextMeshProAbstand.text = mTextMeshProAbstand.text + (int) lDarstellungAttractElement.mTime + "\n";
            }

        }
    }
}
