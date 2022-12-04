using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PruefungGUISteuerung : MonoBehaviour
{
    public int mClickModiAktiv;

    private const int K_BUTTON_INIT = 0;

    private const int K_BUTTON_DRUCK_LAEUFT = 2;

    private const float K_DISTANCE_KLICK = 0.5f;


    public TextMeshPro mTextMeshProZurueck;

    public GameObject mGameObjectStartStopp;
    public TextMeshPro mTextMeshProStartStopp;

    public GameObject mGameObjectThema;
    public TextMeshPro mTextMeshProThema;

    public GameObject mGameObjectEmojiErwerben;
    public TextMeshPro mTextMeshProEmojiErwerben;

    public TextMeshPro mTextMeshProFrage;

    public TextMeshPro mWeiterTextMesPro;
    public GameObject mWeiterButton;

    public GameObject mAntwortA;
    public GameObject mAntwortB;
    public GameObject mAntwortC;
    public GameObject mAntwortD;
    public TextMeshPro mTextMeshPro_Antwort_A;
    public TextMeshPro mTextMeshPro_Antwort_B;
    public TextMeshPro mTextMeshPro_Antwort_C;
    public TextMeshPro mTextMeshPro_Antwort_D;
    public GameObject mGameObjectextMeshProAntwortA;
    public GameObject mGameObjectextMeshProAntwortB;
    public GameObject mGameObjectextMeshProAntwortC;
    public GameObject mGameObjectextMeshProAntwortD;

    public TextMeshPro mTextMeshPro_Antwort_A_Erlaerung;
    public TextMeshPro mTextMeshPro_Antwort_B_Erlaerung;
    public TextMeshPro mTextMeshPro_Antwort_C_Erlaerung;
    public TextMeshPro mTextMeshPro_Antwort_D_Erlaerung;

    public const int K_THEMA_ALLE = 10;
    public const int K_THEMA_PLANETEN = 20;
    public const int K_THEMA_STERNE = 30;
    private const String K_ID_PRUEFUNGSPIEL_THEMA = "PRUEFUNGSPIEL_THEMA";

    private const int K_PRUEFUNG_SPIEL_LAEUFT = 10;
    private const int K_PRUEFUNG_SPIEL_AUSWERTUNG = 20;
    private const int K_PRUEFUNG_SPIEL_STOPP = 30;
    private const int K_MAX_EMOJI = 11;
    public const string K_PRUEFUNG_MUENZENANZAHL = "PRUEFUNGSPIEL_MUENZENANZAHL";

    private string mAntwortGegegeben = "";
    public String mRichtigeAntwort = "";
    public GameObject mGameObjectRocket;
    public GameObject mGameObjectSaturn;
    public GameObject mGameObjectSatellit;

    private string[] mAntwortErgebnisABCD = new string[] { "", "", "", "" };
    private string[] mAntwortErgebnisABCD_Erklaerung = new string[] { "", "", "", "" };

    private int mSpielZustand;

    public PruefungVerwaltung mPruefungVerwaltung;

    public int mRichtigeInReihe = 0;

    public int mRichtigeAntworten = 0;

    public Sprachenuebersetzer mSprachenuebersetzer;

    public float mTimeMessung;

    private List<Vector3> mRaketenPunkte;

    private LineRenderer mLineRenderer;

    public Material mMaterialVonAussen;

    public NotRocketMove mNotRocketMoveSaturn;
    public NotRocketMove mNotRocketMoveSatelitt;


    void Start()
    {
        mSpielZustand = K_PRUEFUNG_SPIEL_STOPP;

        initRichtigeAntwortUndRocket();

        mLineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        //mLineRenderer.startColor = Color.yellow;
        //mLineRenderer.endColor = Color.yellow;
        mLineRenderer.startWidth = 0.1f;
        mLineRenderer.endWidth = 0.1f;
        mLineRenderer.useWorldSpace = true;
        mLineRenderer.material = mMaterialVonAussen;
        mLineRenderer.textureMode = LineTextureMode.RepeatPerSegment;

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mTimeMessung = 0;

            mRaketenPunkte = new List<Vector3>();
            ergaenzeEinenPunkt(bestimmePosition());
        }

        if (Input.GetMouseButton(0))
        {
            mTimeMessung = mTimeMessung + Time.deltaTime;

            if (mTimeMessung < 7)
            {
                Vector3 lNeuePosition = bestimmePosition();

                if (mRaketenPunkte.Count > 0 && Vector3.Distance(lNeuePosition, mRaketenPunkte[mRaketenPunkte.Count - 1]) > 0.5)
                {
                    ergaenzeEinenPunkt(lNeuePosition);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mTimeMessung > 0.25)
            {
                mLineRenderer.positionCount = 0;
            }
            else
            {
                Ray lRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit lRaycastHit;

                if (Physics.Raycast(lRay, out lRaycastHit))
                {
                    if (lRaycastHit.transform.tag.StartsWith("Zurueck"))
                    {
                        StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                        initRichtigeAntwortUndRocket();
                        SceneManager.LoadScene("PlanetenSpielSzene1");
                    }
                    else if (lRaycastHit.transform.tag.StartsWith("PruefungEmojiErwerb"))
                    {
                        StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                        initRichtigeAntwortUndRocket();
                        SceneManager.LoadScene("PruefungEmojierwerb");
                    }
                    else if (lRaycastHit.transform.tag.StartsWith("PruefungStartStopp"))
                    {
                        StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                        initRichtigeAntwortUndRocket();
                        ermittelNaechstenSpielzustand(true);

                    }
                    else
                    {
                        if (!mAntwortGegegeben.Equals(""))
                        {
                            if (lRaycastHit.transform.tag.StartsWith("Weiter"))
                            {
                                StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                            }

                            mNotRocketMoveSaturn.setStatusZurueck();
                            mNotRocketMoveSatelitt.setStatusZurueck();

                            initRichtigeAntwortUndRocket();

                            if (mPruefungVerwaltung.mEndeErreicht)
                            {
                                mSpielZustand = K_PRUEFUNG_SPIEL_AUSWERTUNG;
                            }
                            else
                            {
                                mPruefungVerwaltung.ermittelNaechsteFrage();
                            }
                        }
                        else
                        {
                            if (lRaycastHit.transform.tag.StartsWith("PruefungThema"))
                            {
                                StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                                initRichtigeAntwortUndRocket();
                                nextPruefungSpielThema();
                            }
                            else if (mSpielZustand == K_PRUEFUNG_SPIEL_AUSWERTUNG)
                            {
                                ermittelNaechstenSpielzustand(false);
                            }
                            else if (mSpielZustand == K_PRUEFUNG_SPIEL_LAEUFT)
                            {
                                if (lRaycastHit.transform.tag.StartsWith("AntwortA"))
                                {
                                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));

                                    mAntwortGegegeben = mPruefungVerwaltung.lieferFrage().mAntwortA;
                                    verarbeiteAntwort(mPruefungVerwaltung.lieferFrage(), mGameObjectextMeshProAntwortA);
                                }
                                else if (lRaycastHit.transform.tag.StartsWith("AntwortB"))
                                {
                                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));

                                    mAntwortGegegeben = mPruefungVerwaltung.lieferFrage().mAntwortB;
                                    verarbeiteAntwort(mPruefungVerwaltung.lieferFrage(), mGameObjectextMeshProAntwortB);
                                }
                                else if (lRaycastHit.transform.tag.StartsWith("AntwortC"))
                                {
                                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));

                                    mAntwortGegegeben = mPruefungVerwaltung.lieferFrage().mAntwortC;
                                    verarbeiteAntwort(mPruefungVerwaltung.lieferFrage(), mGameObjectextMeshProAntwortC);
                                }
                                else if (lRaycastHit.transform.tag.StartsWith("AntwortD"))
                                {
                                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));

                                    mAntwortGegegeben = mPruefungVerwaltung.lieferFrage().mAntwortD;
                                    verarbeiteAntwort(mPruefungVerwaltung.lieferFrage(), mGameObjectextMeshProAntwortD);
                                }
                            }
                        }
                    }
                }
            }
        }

        if (mSprachenuebersetzer != null)
        {
            mTextMeshProZurueck.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ZURUECK);
            mWeiterButton.SetActive(false);

            if (mSpielZustand == K_PRUEFUNG_SPIEL_STOPP)
            {
                setThemaUndStartStopp();

                mTextMeshPro_Antwort_A.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ANTWORT_PLATZHALTER) + "A";
                mTextMeshPro_Antwort_B.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ANTWORT_PLATZHALTER) + "B";
                mTextMeshPro_Antwort_C.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ANTWORT_PLATZHALTER) + "C";
                mTextMeshPro_Antwort_D.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ANTWORT_PLATZHALTER) + "D";

                setzeErklaerungstexteLeer();

                setzeEmojiErwerbungstext();
            }
            else if (mSpielZustand == K_PRUEFUNG_SPIEL_AUSWERTUNG)
            {
                setThemaUndStartStopp();

                string lZusammenfassung = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_ES_WAREN)
                    + VirtualLookSteuerung.K_GREEN +
                    mRichtigeAntworten + VirtualLookSteuerung.K_WHITE
                    + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_ANTWORTEN_VON) + PruefungVerwaltung.K_ANZ_FRAGEN + " "
                     + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_RICHTIG) + ".\n";

                if (istGenugRichtigFuerZweiMuenzen())
                {
                    mTextMeshProFrage.text =
                       lZusammenfassung
                     + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_ALLES_RICHTIG) + "\n\n"
                     + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_VERDIENT_MEHR);
                }
                else if (istGenugRichtigFuerEineMuenze())
                {
                    mTextMeshProFrage.text = lZusammenfassung + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_FAST_ALLES_RICHTIG) + "\n\n"
                       + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_VERDIENT_1);
                }
                else
                {
                    mTextMeshProFrage.text = lZusammenfassung + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG_ZU_WENIG_RICHTIG);
                }

                setAntwortButtonsActive(false);

                setzeErklaerungstexteLeer();

                setzeEmojiErwerbungstext();
            }
            else if (mSpielZustand == K_PRUEFUNG_SPIEL_LAEUFT)
            {
                mGameObjectStartStopp.SetActive(true);
                mTextMeshProStartStopp.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_STOPP);

                mGameObjectThema.SetActive(false);
                setAntwortButtonsActive(true);

                Pruefungdatum lPruefungdatum = mPruefungVerwaltung.lieferFrage();

                if (mRichtigeAntworten > 0)
                {
                    mTextMeshProFrage.text = "<size=50%>" + VirtualLookSteuerung.K_GREEN_SCHRIFT
                        + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BIS_JETZT_RICHTIGE_ANTWORTEN)
                        + mRichtigeAntworten
                        + "\n" + "<size=100%>" +
                    VirtualLookSteuerung.K_WHITE + lPruefungdatum.mFrage + "\n(" + mPruefungVerwaltung.getAktuelleFrageIndex() + "/" + PruefungVerwaltung.K_ANZ_FRAGEN + ")";
                }
                else
                {
                    mTextMeshProFrage.text = lPruefungdatum.mFrage + "\n(" + mPruefungVerwaltung.getAktuelleFrageIndex() + "/" + PruefungVerwaltung.K_ANZ_FRAGEN + ")";
                }

                if (mAntwortGegegeben.Equals(""))
                {
                    mTextMeshPro_Antwort_A.text = lPruefungdatum.mAntwortA;
                    mTextMeshPro_Antwort_B.text = lPruefungdatum.mAntwortB;
                    mTextMeshPro_Antwort_C.text = lPruefungdatum.mAntwortC;
                    mTextMeshPro_Antwort_D.text = lPruefungdatum.mAntwortD;

                    setzeErklaerungstexteLeer();
                }
                else
                {
                    mTextMeshPro_Antwort_A.text = mAntwortErgebnisABCD[0];
                    mTextMeshPro_Antwort_B.text = mAntwortErgebnisABCD[1];
                    mTextMeshPro_Antwort_C.text = mAntwortErgebnisABCD[2];
                    mTextMeshPro_Antwort_D.text = mAntwortErgebnisABCD[3];

                    mTextMeshPro_Antwort_A_Erlaerung.text = mAntwortErgebnisABCD_Erklaerung[0];
                    mTextMeshPro_Antwort_B_Erlaerung.text = mAntwortErgebnisABCD_Erklaerung[1];
                    mTextMeshPro_Antwort_C_Erlaerung.text = mAntwortErgebnisABCD_Erklaerung[2];
                    mTextMeshPro_Antwort_D_Erlaerung.text = mAntwortErgebnisABCD_Erklaerung[3];

                    mWeiterButton.SetActive(true);
                    mWeiterTextMesPro.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WEITER);
                }

                mGameObjectEmojiErwerben.SetActive(false);
            }
        }
    }

    private void ergaenzeEinenPunkt(Vector3 pNeuePunkt)
    {
        if (getRichtigeAntwort() != null && !getRichtigeAntwort().Equals(""))
        {
            mRaketenPunkte.Add(pNeuePunkt);
            mLineRenderer.positionCount = mRaketenPunkte.Count;
            mLineRenderer.SetPositions(mRaketenPunkte.ToArray());
        }
    }

    public List<Vector3> getmRaketenPunkte()
    {
        return mRaketenPunkte;
    }

    private Vector3 bestimmePosition()
    {
        Vector3 lVector3 = Input.mousePosition;
        lVector3.z = 14; // Abstand Kamera und Antowrten
        return Camera.main.ScreenToWorldPoint(lVector3);
    }

    private void initRichtigeAntwortUndRocket()
    {
        mAntwortGegegeben = "";
        mRichtigeAntwort = "";
        mGameObjectRocket.SetActive(false);
        mGameObjectSatellit.SetActive(false);
        mGameObjectSaturn.SetActive(false);
    }

    private bool istGenugRichtigFuerZweiMuenzen()
    {
        return PruefungVerwaltung.K_ANZ_FRAGEN == mRichtigeAntworten;
    }

    private bool istGenugRichtigFuerEineMuenze()
    {
        return PruefungVerwaltung.K_ANZ_FRAGEN == (mRichtigeAntworten + 1)
                             || PruefungVerwaltung.K_ANZ_FRAGEN == (mRichtigeAntworten + 2);
    }

    private void setThemaUndStartStopp()
    {
        mGameObjectStartStopp.SetActive(true);
        mTextMeshProStartStopp.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_START);

        mGameObjectThema.SetActive(true);
        String lZwischentext = setThemaTextMeshPro();

        setAntwortButtonsActive(true);
        mTextMeshProFrage.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FRAGE_PLATZHALTER_1)
            + lZwischentext +
            mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FRAGE_PLATZHALTER_2)
            ;
    }

    private void setAntwortButtonsActive(bool pActive)
    {
        mAntwortA.SetActive(pActive);
        mAntwortB.SetActive(pActive);
        mAntwortC.SetActive(pActive);
        mAntwortD.SetActive(pActive);
    }


    private void setzeEmojiErwerbungstext()
    {
        mGameObjectEmojiErwerben.SetActive(true);
        mTextMeshProEmojiErwerben.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_ERWERBEN_1)
              + VirtualLookSteuerung.K_GOLD + get2BMuenzenAnzahl() + VirtualLookSteuerung.K_WHITE +
            mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_ERWERBEN_2);
    }

    private int get2BMuenzenAnzahl()
    {
        return PlayerPrefs.GetInt(K_PRUEFUNG_MUENZENANZAHL);
    }
    private void set2BMuenzenAnzahl(int pAnzahlNeu)
    {
        PlayerPrefs.SetInt(K_PRUEFUNG_MUENZENANZAHL, pAnzahlNeu);
    }

    private void verarbeiteAntwort(Pruefungdatum lPruefungdatum, GameObject pGameObjectAntwortButton)
    {
        mRichtigeAntwort = "";

        setzeTextNachBeantwortung(mAntwortGegegeben, lPruefungdatum.mAntwortA
           , lPruefungdatum.mAntwortA_Erklaerung
           , lPruefungdatum.mKorrekteAntwort, 0, pGameObjectAntwortButton);
        setzeTextNachBeantwortung(mAntwortGegegeben, lPruefungdatum.mAntwortB
            , lPruefungdatum.mAntwortB_Erklaerung
            , lPruefungdatum.mKorrekteAntwort, 1, pGameObjectAntwortButton);
        setzeTextNachBeantwortung(mAntwortGegegeben, lPruefungdatum.mAntwortC
            , lPruefungdatum.mAntwortC_Erklaerung
            , lPruefungdatum.mKorrekteAntwort, 2, pGameObjectAntwortButton);
        setzeTextNachBeantwortung(mAntwortGegegeben, lPruefungdatum.mAntwortD
            , lPruefungdatum.mAntwortD_Erklaerung
            , lPruefungdatum.mKorrekteAntwort, 3, pGameObjectAntwortButton);

        if (mPruefungVerwaltung.mEndeErreicht)
        {
            if (istGenugRichtigFuerZweiMuenzen())
            {
                int lMuenzenVerdient = 2;
                set2BMuenzenAnzahl(get2BMuenzenAnzahl() + lMuenzenVerdient);
            }
            else if (istGenugRichtigFuerEineMuenze())
            {
                int lMuenzenVerdient = 1;
                set2BMuenzenAnzahl(get2BMuenzenAnzahl() + lMuenzenVerdient);
            }
        }

    }

    private void setzeTextNachBeantwortung(string pAntwortGegegeben, string pAntwort, string pAntwort_Erklaerung, string pKorrekteAntwort,
        int pABCD, GameObject pGameObjectAntwortButton)
    {
        if (pAntwort.Equals(pAntwortGegegeben))
        {
            if (pAntwort.Equals(pKorrekteAntwort))
            {
                mRichtigeInReihe++;
                mRichtigeAntworten++;
                mAntwortErgebnisABCD[pABCD] = VirtualLookSteuerung.K_GREEN_SCHRIFT + "<b>" + pAntwort + ergaenzeSprite(mRichtigeInReihe);
                mAntwortErgebnisABCD_Erklaerung[pABCD] = VirtualLookSteuerung.K_GREEN_SCHRIFT + pAntwort_Erklaerung;
                mRichtigeAntwort = pGameObjectAntwortButton.name;

                if (EmojiKaufVerwaltung.istRocketAktiv())
                {
                    mGameObjectRocket.SetActive(true);
                }
                if (EmojiKaufVerwaltung.istSatellitAktiv())
                {
                    mGameObjectSatellit.SetActive(true);
                }
                if (EmojiKaufVerwaltung.istSaturnAktiv())
                {
                    mGameObjectSaturn.SetActive(true);
                }
            }
            else
            {
                mAntwortErgebnisABCD[pABCD] = VirtualLookSteuerung.K_RED + pAntwort;
                mAntwortErgebnisABCD_Erklaerung[pABCD] = VirtualLookSteuerung.K_RED + pAntwort_Erklaerung;
            }
        }
        else
        {
            if (pAntwort.Equals(pKorrekteAntwort))
            {
                mAntwortErgebnisABCD[pABCD] = VirtualLookSteuerung.K_GREEN_SCHRIFT + "<b>" + pAntwort;
                mAntwortErgebnisABCD_Erklaerung[pABCD] = VirtualLookSteuerung.K_GREEN_SCHRIFT + pAntwort_Erklaerung;
                mRichtigeInReihe = 0;
            }
            else
            {
                mAntwortErgebnisABCD[pABCD] = "<color=#FFFFFF>" + pAntwort;
                mAntwortErgebnisABCD_Erklaerung[pABCD] = "<color=#FFFFFF>" + pAntwort_Erklaerung;
            }
        }
    }

    private string ergaenzeSprite(int mRichtigeInReihe)
    {
        string lErg = "";
        /*
        int lAnzahEmoji = 0;

        if (mRichtigeInReihe == 1)
        {
            lAnzahEmoji = 1;
        }
        else
        {
            lAnzahEmoji = 1;
        }
        */
        /*
        List<int> lListeInteger = new List<int>();
        for (int i = 0; lListeInteger.Count < lAnzahEmoji && i < 100; i++)
        {
            int lZufallsemoji = UnityEngine.Random.Range(0, K_MAX_EMOJI);

            if (!lListeInteger.Contains(lZufallsemoji)
                && EmojiKaufVerwaltung.istErworbeEmoji(lZufallsemoji)
                && !istGegenstückEmojiVorhanden(lZufallsemoji, lListeInteger)
                )
            {
                lListeInteger.Add(lZufallsemoji);
            }
        }
        for (int i = 0; i < lListeInteger.Count; i++)
        {
            lErg = lErg + " <sprite=" + lListeInteger[i] + ">";
        }
        */

        lErg = lErg + " <sprite=" + EmojiKaufVerwaltung.lieferAktiveEmoji(UnityEngine.Random.Range(0, 2)) + ">";


        return lErg;
    }

    private bool istGegenstückEmojiVorhanden(int pZufallsemoji, List<int> pListeInteger)
    {
        if (pZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_UFO_1 && pListeInteger.Contains(EmojiKaufVerwaltung.K_EMOJI_UFO_2))
        {
            return true;
        }
        if (pZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_UFO_2 && pListeInteger.Contains(EmojiKaufVerwaltung.K_EMOJI_UFO_1))
        {
            return true;
        }

        if (pZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_KOMET_1 && pListeInteger.Contains(EmojiKaufVerwaltung.K_EMOJI_KOMET_2))
        {
            return true;
        }
        if (pZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_KOMET_2 && pListeInteger.Contains(EmojiKaufVerwaltung.K_EMOJI_KOMET_1))
        {
            return true;
        }

        if (pZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_RAKETE_1 && pListeInteger.Contains(EmojiKaufVerwaltung.K_EMOJI_RAKETE_2))
        {
            return true;
        }
        if (pZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_RAKETE_2 && pListeInteger.Contains(EmojiKaufVerwaltung.K_EMOJI_RAKETE_1))
        {
            return true;
        }

        return false;
    }



    private void setzeErklaerungstexteLeer()
    {
        mTextMeshPro_Antwort_A_Erlaerung.text = "";
        mTextMeshPro_Antwort_B_Erlaerung.text = "";
        mTextMeshPro_Antwort_C_Erlaerung.text = "";
        mTextMeshPro_Antwort_D_Erlaerung.text = "";
    }

    private void ermittelNaechstenSpielzustand(bool pEchteStartStopp)
    {
        mRichtigeInReihe = 0;
        if (mSpielZustand == K_PRUEFUNG_SPIEL_LAEUFT)
        {
            mSpielZustand = K_PRUEFUNG_SPIEL_STOPP;
        }
        else if (!pEchteStartStopp && mSpielZustand == K_PRUEFUNG_SPIEL_AUSWERTUNG)
        {
            mSpielZustand = K_PRUEFUNG_SPIEL_STOPP;
        }
        else if (mSpielZustand == K_PRUEFUNG_SPIEL_STOPP
            || mSpielZustand == K_PRUEFUNG_SPIEL_AUSWERTUNG)
        {
            mSpielZustand = K_PRUEFUNG_SPIEL_LAEUFT;

            mRichtigeAntworten = 0;
            mPruefungVerwaltung.ermittelFragen(getPruefungSpielThema());
        }
    }

    private String setThemaTextMeshPro()
    {
        int lThema = getPruefungSpielThema();

        if (lThema == K_THEMA_PLANETEN)
        {
            mTextMeshProThema.text =
                   mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_VOR)
                 + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_PLANETEN)
                 ;
            return " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FRAGE_PLATZHALTER_1_A)
                + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_PLANETEN) + " ";
        }
        else if (lThema == K_THEMA_STERNE)
        {
            mTextMeshProThema.text =
                 mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_VOR)
                + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_STERNEN_1);
            return " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FRAGE_PLATZHALTER_1_A)
                + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_STERNEN_2) + " ";
        }
        else
        {
            mTextMeshProThema.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_VOR)
                + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISSEN_THEMA_ALL);
            return " ";
        }
    }

    private int getPruefungSpielThema()
    {
        return PlayerPrefs.GetInt(K_ID_PRUEFUNGSPIEL_THEMA);
    }

    public String getRichtigeAntwort()
    {
        return mRichtigeAntwort;
    }

    private void nextPruefungSpielThema()
    {
        int lThema = getPruefungSpielThema();

        if (lThema == K_THEMA_PLANETEN)
        {
            PlayerPrefs.SetInt(K_ID_PRUEFUNGSPIEL_THEMA, K_THEMA_STERNE);
        }
        else if (lThema == K_THEMA_STERNE)
        {
            PlayerPrefs.SetInt(K_ID_PRUEFUNGSPIEL_THEMA, K_THEMA_ALLE);
        }
        else
        {
            PlayerPrefs.SetInt(K_ID_PRUEFUNGSPIEL_THEMA, K_THEMA_PLANETEN);
        }
    }

    public IEnumerator clickEffektSprache(GameObject pGameObject)
    {
        if (mClickModiAktiv == K_BUTTON_INIT)
        {

            mClickModiAktiv = K_BUTTON_DRUCK_LAEUFT;

            float lNewZ = pGameObject.transform.position.z + K_DISTANCE_KLICK;
            pGameObject.transform.position = new Vector3(pGameObject.transform.position.x, pGameObject.transform.position.y, lNewZ);
            yield return new WaitForSeconds(0.2F);

            lNewZ = pGameObject.transform.position.z - K_DISTANCE_KLICK;
            pGameObject.transform.position = new Vector3(pGameObject.transform.position.x, pGameObject.transform.position.y, lNewZ);
            mClickModiAktiv = K_BUTTON_INIT;
        }
        yield return null;
    }
}
