using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Himmelskoerperverwalter : HimmelskoerperverwalterBase
{

    private HimmelskoerperKartenstapel mStapelEinstein;

    private HimmelskoerperKartenstapel mStapelYou;

    private const int K_MAX_IN_STAPEL = 1000;

    public TextMeshPro mTextMeshKartenAnzahlYou;

    public TextMeshPro mTextMeshKartenAnzahlEinstein;

    public TextMeshPro mTextMeshKampfAktuelleKampf;

    public GameObject mGameObjectKampfAktuelleKampf;

    public TextMeshPro mTextMeshKampfProtokoll;

    public TextMeshPro mTextMeshKampfProtokollGewinner;

    public TextMeshPro mTextMeshProYou;

    public Himmelskoerper mHimmelskoerper;

    public int mIndexYou;

    public int mIndexEinstein;

    public const string K_WIN_YOU = "You";

    public const string K_WIN_EINSTEIN = "Einstein";

    public const string K_WIN_NOBODY = "-";

    public const string K_ZU_ERSETZEN = "???";

    public int mSpielZug;

    private string mWinner;

    private HighScoreVerwaltung mHighScoreVerwaltung;

    private string mNameEinsteinHimmelskoerper;

    public GameObject mGameObjectAngabeMasse;

    public GameObject mGameObjectAngabeEntfernung;

    public GameObject mGameObjectAngabeDurchmesser;

    public GameObject mGameObjectAngabeAnzahlMonde;

    public GameObject mGameObjectAngabeMaxTemp;

    public GameObject mGameObjectAngabeMinTemp;

    public GameObject mGameObjectAngabeDichte;

    public GameObject mGameObjectAngabeLernen;

    public GameObject mGameObjectAngabeQuartett;

    public GameObject mGameObjectAngabeInfoConfig;

    public GameObject mGameObjectArtDesHimmelskoerper;

    public GameObject mGameObjectHimmelskoerperVor;

    public GameObject mGameObjectHimmelskoerperNaechste;

    public GameObject mGameObjectKartenButton;

    private Quaternion mGameObjectAngabeMasseRotation;

    private Quaternion mGameObjectAngabeEntfernungRotation;

    private Quaternion mGameObjectAngabeDurchmesserRotation;

    private Quaternion mGameObjectAngabeAnzahlMondeRotation;

    private Quaternion mGameObjectAngabeMaxTempRotation;

    private Quaternion mGameObjectAngabeMinTempRotation;

    private Quaternion mGameObjectAngabeDichteRotation;

    private Quaternion mGameObjectLernenRotation;

    private Quaternion mGameObjectQuartettRotation;

    private Quaternion mGameObjectInfoConfigRotation;

    private Quaternion mGameObjectArtDesHimmelskoerperRotation;

    private Quaternion mGameObjectHimmelskoerperVorRotation;

    private Quaternion mGameObjectHimmelskoerperNaechsteRotation;

    private Quaternion mGameObjectKartenButtonRotation;

    private Quaternion mGameObjectAktuelleKampfRotation;

    public AufloesungsKuemmerer mAufloesungsKuemmerer;

    public int mAnzahlMoeglKartenInStapel;

    void Start()
    {
        Debug.Log("jetzt von MacBookAir");

        Init();
    }

    public new void Init()
    {
        base.Init();

        if (mStapelEinstein == null || mStapelYou == null)
        {
            mSprachenuebersetzer = GameObject.FindGameObjectWithTag("Sprachenuebersetzer").GetComponent<Sprachenuebersetzer>();

            mHighScoreVerwaltung = GameObject.FindGameObjectWithTag("HighScoreVerwaltung").GetComponent<HighScoreVerwaltung>();

            mTextMeshProYou.text = mSprachenuebersetzer.lieferNamen();

            mTextMeshKampfProtokoll.text = "";
            mTextMeshKampfProtokollGewinner.text = "";
            mGameObjectKampfAktuelleKampf.SetActive(false);

            mStapelEinstein = new HimmelskoerperKartenstapel("Einstein");
            mStapelYou = new HimmelskoerperKartenstapel("You");

        }

        mAnzahlMoeglKartenInStapel = base.getMyHimmelskoerperDict().Count;
    }

    public bool lieferBorealis(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mIndex == Himmelskoerper.K_R_CORONA_BOREALIS;
    }

    public bool lieferEnceladusSuedpol(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mIndex == Himmelskoerper.K_MOND_ENCELADUS;
    }


    public void schauAufObject(bool pSoll)
    {
        mGameObjectAngabeMasse.transform.rotation = mGameObjectAngabeMasseRotation;
        mGameObjectAngabeEntfernung.transform.rotation = mGameObjectAngabeEntfernungRotation;
        mGameObjectAngabeAnzahlMonde.transform.rotation = mGameObjectAngabeAnzahlMondeRotation;
        mGameObjectAngabeMaxTemp.transform.rotation = mGameObjectAngabeMaxTempRotation;
        mGameObjectAngabeMinTemp.transform.rotation = mGameObjectAngabeMinTempRotation;
        mGameObjectAngabeDurchmesser.transform.rotation = mGameObjectAngabeDurchmesserRotation;
        mGameObjectAngabeDichte.transform.rotation = mGameObjectAngabeDichteRotation;
        mGameObjectAngabeLernen.transform.rotation = mGameObjectLernenRotation;
        mGameObjectAngabeQuartett.transform.rotation = mGameObjectQuartettRotation;
        mGameObjectAngabeInfoConfig.transform.rotation = mGameObjectInfoConfigRotation;
        mGameObjectArtDesHimmelskoerper.transform.rotation = mGameObjectArtDesHimmelskoerperRotation;
        mGameObjectHimmelskoerperVor.transform.rotation = mGameObjectHimmelskoerperVorRotation;
        mGameObjectHimmelskoerperNaechste.transform.rotation = mGameObjectHimmelskoerperNaechsteRotation;
        mGameObjectKartenButton.transform.rotation = mGameObjectKartenButtonRotation;
        mGameObjectKampfAktuelleKampf.transform.rotation = mGameObjectAktuelleKampfRotation;
        mGameObjectKampfAktuelleKampf.transform.localPosition = mAufloesungsKuemmerer.lieferAktuelleKampfPostion(false);

        if (pSoll)
        {
            mGameObjectAngabeMasse.transform.Rotate(new Vector3(0f, 35f, 2f));
            mGameObjectAngabeEntfernung.transform.Rotate(new Vector3(0f, 35f, 1f));
            mGameObjectAngabeAnzahlMonde.transform.Rotate(new Vector3(0f, 35f, 0.5f));
            mGameObjectAngabeDichte.transform.Rotate(new Vector3(0f, 35f, 0f));
            mGameObjectAngabeDurchmesser.transform.Rotate(new Vector3(0f, 35f, -0.5f));
            mGameObjectAngabeMaxTemp.transform.Rotate(new Vector3(0f, 35f, -1f));
            mGameObjectAngabeMinTemp.transform.Rotate(new Vector3(0f, 35f, -2f));

            mGameObjectAngabeLernen.transform.Rotate(new Vector3(0f, -20f, -5f));
            mGameObjectAngabeQuartett.transform.Rotate(new Vector3(0f, -20f, -2f));
            mGameObjectAngabeInfoConfig.transform.Rotate(new Vector3(0f, -20f, -2f));
            mGameObjectArtDesHimmelskoerper.transform.Rotate(new Vector3(0f, -20f, 2f));
            mGameObjectKartenButton.transform.Rotate(new Vector3(0f, -20f, -2f));

            mGameObjectHimmelskoerperVor.transform.Rotate(new Vector3(0f, -20f, 2f));
            mGameObjectHimmelskoerperNaechste.transform.Rotate(new Vector3(0f, -20f, 2f));

            mGameObjectKampfAktuelleKampf.transform.Rotate(new Vector3(0f, -20f, -2f));
            mGameObjectKampfAktuelleKampf.transform.localPosition = mAufloesungsKuemmerer.lieferAktuelleKampfPostion(true);

        }
    }

    private bool IstZugehoerigPassend(int pKartenanzahlZugehoerig)
    {
        if (pKartenanzahlZugehoerig == ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH)
        {
            return true;
        }
        if (PlayerPrefs.GetInt(ConfigInfoScript.K_ANZAHL_BUTTON) >= pKartenanzahlZugehoerig)
        {
            return true;
        }

        return false;
    }

    public void mischeZweiStapel(bool pVonDB)
    {
        Dictionary<int, int> lMischstapel = new Dictionary<int, int>();

        int lMaxIndex = K_MAX_IN_STAPEL;

        foreach (int lHimmelskoerper in getMyHimmelskoerperDict().Keys)
        {

            if (lHimmelskoerper.Equals(Himmelskoerper.K_LEER_PLANET)
                || !IstZugehoerigPassend(getMyHimmelskoerperDict()[lHimmelskoerper].mKartenanzahlZugehoerig)
            )
            {
                // nicht in Stapel
            }
            else
            {
                int lMischstapelIndex = UnityEngine.Random.Range(0, K_MAX_IN_STAPEL);

                if (!lMischstapel.ContainsKey(lMischstapelIndex))
                {
                    lMischstapel.Add(lMischstapelIndex, lHimmelskoerper);
                }
                else
                {
                    lMaxIndex++;
                    lMischstapel.Add(lMaxIndex, lHimmelskoerper);
                }
            }
        }

        mStapelEinstein.initHimmelskoerperKartenstapel(pVonDB);
        mStapelYou.initHimmelskoerperKartenstapel(pVonDB);

        if (pVonDB && mStapelEinstein.lieferAnzahl() > 0 && mStapelYou.lieferAnzahl() > 0)
        {
            // bereits gefüllt
        }
        else
        {
            int lKartenWegenLevel = (mHighScoreVerwaltung.getLevel() - 1) * 2;

            bool l4You = true;
            for (int lIndex = 0; lIndex <= lMaxIndex; lIndex++)
            {

                if (lMischstapel.ContainsKey(lIndex))
                {

                    if (lKartenWegenLevel > 0)
                    {
                        mStapelEinstein.legKarteAn(lMischstapel[lIndex]);
                        lKartenWegenLevel--;
                    }
                    else
                    {
                        if (l4You)
                        {
                            mStapelYou.legKarteAn(lMischstapel[lIndex]);
                        }
                        else
                        {
                            mStapelEinstein.legKarteAn(lMischstapel[lIndex]);
                        }
                        l4You = !l4You;
                    }
                }
            }
        }

        mSpielZug = 0;

        verarbeiteZiehung("", "");

        PlayerPrefs.SetInt(ConfigInfoScript.K_ANZAHL_BUTTON_LAST, PlayerPrefs.GetInt(ConfigInfoScript.K_ANZAHL_BUTTON));
    }

    public string lieferErgebnis(float pYou, float pEinstein)
    {
        if (pYou > pEinstein)
        {
            return K_WIN_YOU;
        }
        if (pYou < pEinstein)
        {
            return K_WIN_EINSTEIN;
        }
        return K_WIN_NOBODY;
    }

    public string lieferletzenWinner()
    {
        return mWinner;
    }

    public int verarbeiteClickAuf(string pName)
    {
        mWinner = ermitteltErgebnis(pName);

        if (mWinner.Equals(K_WIN_YOU))
        {
            mStapelYou.legKarteAn(mIndexYou);
            mStapelYou.legKarteAn(mIndexEinstein);
            mStapelYou.loescheObersteKarte();
            mStapelEinstein.loescheObersteKarte();
        }
        else if (mWinner.Equals(K_WIN_EINSTEIN))
        {
            mStapelEinstein.legKarteAn(mIndexEinstein);
            mStapelEinstein.legKarteAn(mIndexYou);
            mStapelYou.loescheObersteKarte();
            mStapelEinstein.loescheObersteKarte();
        }
        else
        {
            mStapelYou.legKarteAn(mIndexYou);
            mStapelEinstein.legKarteAn(mIndexEinstein);
            mStapelYou.loescheObersteKarte();
            mStapelEinstein.loescheObersteKarte();
        }

        if (mStapelYou.lieferAnzahl() == 0)
        {
            verarbeiteZiehung(mWinner, K_WIN_EINSTEIN);
            return VirtualLookSteuerung.K_GAME_MODE_QUARTETT_WINNER_EINSTEIN;
        }
        else if (mStapelEinstein.lieferAnzahl() == 0)
        {
            verarbeiteZiehung(mWinner, K_WIN_YOU);
            return VirtualLookSteuerung.K_GAME_MODE_QUARTETT_WINNER_YOU;
        }
        else
        {
            verarbeiteZiehung(mWinner, "");
            return VirtualLookSteuerung.K_GAME_MODE_QUARTETT_LAEUFT;

            //				verarbeiteZiehung (mWinner, K_WIN_YOU);
            //				return VirtualLookSteuerung.K_GAME_MODE_QUARTETT_WINNER_YOU;
        }

    }

    public string ermitteltErgebnis(string pName)
    {

        if (pName.Equals("AngabeMasse"))
        {
            return lieferErgebnis(lieferErdmassen(mIndexYou), lieferErdmassen(mIndexEinstein));
        }
        else if (pName.Equals("AngabeEntferungSonne"))
        {
            return lieferErgebnis(lieferEntfernungZurSonneZuVergleich(mIndexYou), lieferEntfernungZurSonneZuVergleich(mIndexEinstein));
        }
        else if (pName.Equals("AngabeAnzahlMonde"))
        {
            return lieferErgebnis(lieferAnzahlMondeZu(mIndexYou), lieferAnzahlMondeZu(mIndexEinstein));
        }
        else if (pName.Equals("AngabeDichte"))
        {
            return lieferErgebnis(lieferDichteZu(mIndexYou), lieferDichteZu(mIndexEinstein));
        }
        else if (pName.Equals("AngabeDurchmesser"))
        {
            return lieferErgebnis(lieferDurchmesserZu(mIndexYou), lieferDurchmesserZu(mIndexEinstein));
        }
        else if (pName.Equals("AngabeMaxTemperatur"))
        {
            return lieferErgebnis(lieferMaxTemperaturZu(mIndexYou), lieferMaxTemperaturZu(mIndexEinstein));
        }
        else if (pName.Equals("AngabeMinTemperatur"))
        {
            return lieferErgebnis(lieferMinTemperaturZu(mIndexEinstein), lieferMinTemperaturZu(mIndexYou));
        }
        else
        {
            return K_WIN_NOBODY;
        }

    }

    public void verarbeiteZiehung(string pLastErgebnis, string pFinalWinner)
    {
        mGameObjectKampfAktuelleKampf.SetActive(false);

        if (!pLastErgebnis.Equals(""))
        {
            mTextMeshKampfProtokollGewinner.text = mTextMeshKampfProtokollGewinner.text.Replace("?", pLastErgebnis);
        }

        mTextMeshKartenAnzahlEinstein.text = "" + mStapelEinstein.lieferAnzahl();
        mTextMeshKartenAnzahlYou.text = "" + mStapelYou.lieferAnzahl();

        if (!pFinalWinner.Equals(""))
        {
            mTextMeshKampfProtokoll.text = mTextMeshKampfProtokoll.text.Replace(K_ZU_ERSETZEN, mNameEinsteinHimmelskoerper);

            if (pFinalWinner.Equals(K_WIN_YOU))
            {
                if (mSprachenuebersetzer.istInitName())
                {
                    mTextMeshKampfProtokoll.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WINNER_IS_2) + "\n" + mTextMeshKampfProtokoll.text;
                    mTextMeshKampfProtokollGewinner.text = "" + "\n" + mTextMeshKampfProtokollGewinner.text;
                }
                else
                {
                    mTextMeshKampfProtokoll.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WINNER_IS_1) + "\n" + mTextMeshKampfProtokoll.text;
                    mTextMeshKampfProtokollGewinner.text = mSprachenuebersetzer.lieferNamen() + "\n" + mTextMeshKampfProtokollGewinner.text;
                }

                mHighScoreVerwaltung.erhoeheLevel(getMyHimmelskoerperDict().Count - 1);
            }
            else
            {
                mTextMeshKampfProtokoll.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WINNER_IS_1) + "\n" + mTextMeshKampfProtokoll.text;
                mTextMeshKampfProtokollGewinner.text = pFinalWinner + "\n" + mTextMeshKampfProtokollGewinner.text;
            }

            mHimmelskoerper.setNeuenPlanetDirekt(Himmelskoerper.K_LEER_PLANET);
        }
        else
        {
            mIndexYou = mStapelYou.lieferObersteKarte();
            mIndexEinstein = mStapelEinstein.lieferObersteKarte();

            string lNameYou = lieferNameZu(mIndexYou);

            string lFARBE = "<#FFFFFF>";
            if (lieferLichtintensitaet(mIndexYou) >= 0.9)
            {
                lFARBE = "<#000000>";
            }

            string lNameEinstein = "";
            mNameEinsteinHimmelskoerper = lieferNameZu(mIndexEinstein);
            if (mHighScoreVerwaltung.getStufe() == HighScoreVerwaltung.K_STUFE_GALILEO)
            {
                string lTestNameEinstein = lieferNameZu(mIndexEinstein) + " (" + lieferArtHimmelskoerperZu(mIndexEinstein) + ")";

                if ((lNameYou.Length + lTestNameEinstein.Length) > 26)
                {
                    lNameEinstein = lieferNameZu(mIndexEinstein);
                }
                else
                {
                    lNameEinstein = lTestNameEinstein;
                }

            }
            else if (mHighScoreVerwaltung.getStufe() == HighScoreVerwaltung.K_STUFE_NEWTON)
            {
                lNameEinstein = K_ZU_ERSETZEN + "(" + lieferArtHimmelskoerperZu(mIndexEinstein) + ")";
            }
            else if (mHighScoreVerwaltung.getStufe() == HighScoreVerwaltung.K_STUFE_FEYMAN)
            {
                lNameEinstein = K_ZU_ERSETZEN;
            }

            if (!pLastErgebnis.Equals(""))
            {
                mTextMeshKampfProtokoll.text = mTextMeshKampfProtokoll.text.Replace(K_ZU_ERSETZEN, mNameEinsteinHimmelskoerper);
                mTextMeshKampfProtokoll.text = lNameYou + " vs. " + lNameEinstein + "\n" + mTextMeshKampfProtokoll.text;
                mTextMeshKampfProtokollGewinner.text = "?" + "\n" + mTextMeshKampfProtokollGewinner.text;
            }
            else
            {
                mTextMeshKampfProtokoll.text = lNameYou + " vs. " + lNameEinstein;
                mTextMeshKampfProtokollGewinner.text = "?";
            }


            mGameObjectKampfAktuelleKampf.SetActive(true);
            mTextMeshKampfAktuelleKampf.text =
                VirtualLookSteuerung.K_GREEN_SCHRIFT +
                mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DU_MIT) +
                " " + "<b>" + lNameYou + "</b>" + VirtualLookSteuerung.K_WHITE +
                " " + lFARBE +
                mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GEGEN) +
                " \n" +
                VirtualLookSteuerung.K_GEGNER_FARBE_IM_WER_GEGEN_KAMPF_BILD +
                mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EINSTEIN_MIT) + " " +
                lNameEinstein;


            mHimmelskoerper.setNeuenPlanetDirekt(mIndexYou);
            mSpielZug++;
        }
    }


    public string lieferNameZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mName;
    }

    public float lieferLichtintensitaet(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mLichtIntensitaet;
    }

    public string lieferNameZuObereAnzeige(int pIndex)
    {
        if (pIndex == Himmelskoerper.K_LEER_PLANET)
        {
            return "";
        }
        if (mHighScoreVerwaltung.getStufe() == HighScoreVerwaltung.K_STUFE_GALILEO)
        {
            string lArtHimmelskoerper = mSprachenuebersetzer.lieferWort(getMyHimmelskoerperDict()[pIndex].mArtHimmelskoerper);

            return getMyHimmelskoerperDict()[pIndex].mName + "(" + lArtHimmelskoerper + ")";
        }
        else
        {
            return getMyHimmelskoerperDict()[pIndex].mName;
        }
    }


    public string lieferArtHimmelskoerperZu(int pIndex)
    {
        return mSprachenuebersetzer.lieferWort(getMyHimmelskoerperDict()[pIndex].mArtHimmelskoerper);
    }

    public float lieferErdmassen(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mMasse;
    }

    public bool istGueltigeIndex(int pIndex)
    {
        if (pIndex == 0)
        {
            return false;
        }
        if (getMyHimmelskoerperDict() == null)
        {
            return false;
        }
        return getMyHimmelskoerperDict().ContainsKey(pIndex);
    }


    public bool istSchwarzesLoch(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mArtHimmelskoerper.Equals(Sprachenuebersetzer.K_SCHWARZES_LOCH);
    }

    public int lieferAnzahlBildAktuellerHimmelskoerper()
    {
        return getMyHimmelskoerperDict()[mHimmelskoerper.lieferAktuellenHimmelskoerper()].lieferAnzahlBildInfo();
    }

    public string lieferBildAktuellerHimmelskoerper(int pBildIndex)
    {
        return getMyHimmelskoerperDict()[mHimmelskoerper.lieferAktuellenHimmelskoerper()].lieferInfoBild(pBildIndex);
    }


    public bool lieferRingObjekt(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mRingeVorhanden;
    }

    public bool lieferLichtAn(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].istLichtvorhanden();
    }


    public float lieferHelligkeit(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mLichtIntensitaet;
    }

    public int lieferAnzahlMondeZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mAnzahlMonde;
    }

    public float lieferDichteZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mDichte;
    }


    public bool istStartQuartett()
    {
        return mSpielZug <= 1;
    }

    public bool istDritteQuartett()
    {
        float lSpielZugFloat = mSpielZug;

        float lSpielzugDurch3Float = lSpielZugFloat / 3;

        int lSpielzugDurch3Int = (int)lSpielzugDurch3Float;

        return (lSpielzugDurch3Int * 3) == mSpielZug;
    }

    public bool lieferKometenschweif(int pIndex)
    {
        if (istHimmelskoerperDieseArt(pIndex, Sprachenuebersetzer.K_KOMET))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool istHimmelskoerperDieseArt(int pIndPlanet, int pArtDesHimmelskoerper)
    {

        return (getMyHimmelskoerperDict()[pIndPlanet].mArtHimmelskoerper == pArtDesHimmelskoerper);
    }

    public List<HimmelskoerperData> liefer4Planeten()
    {
        List<HimmelskoerperData> lErg = new List<HimmelskoerperData>();

        List<HimmelskoerperData> lRelevantePlaneten = new List<HimmelskoerperData>();

        foreach (int lHimmelskoerper in getMyHimmelskoerperDict().Keys)
        {
            if (getMyHimmelskoerperDict()[lHimmelskoerper].mArtHimmelskoerper.Equals(Sprachenuebersetzer.K_PLANET))
            {
                lRelevantePlaneten.Add(getMyHimmelskoerperDict()[lHimmelskoerper]);
            }
        }

        for (int i = 0; lErg.Count < 4; i++)
        {
            int lZufallsindex = UnityEngine.Random.Range(0, lRelevantePlaneten.Count);

            bool lSchonMitMondDa = false;
            foreach (var lHimmelskoerperDataErg in lErg)
            {
                if (lHimmelskoerperDataErg.mAnzahlMonde == lRelevantePlaneten[lZufallsindex].mAnzahlMonde)
                {
                    lSchonMitMondDa = true;
                }
            }

            if (!lSchonMitMondDa)
            {
                lErg.Add(lRelevantePlaneten[lZufallsindex]);
            }
        }

        return lErg;
    }


}
