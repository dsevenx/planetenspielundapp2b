using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EmojiKaufVerwaltung : MonoBehaviour
{

    public Sprachenuebersetzer mSprachenuebersetzer;

    public int mClickModiAktiv;

    private const int K_BUTTON_INIT = 0;

    private const int K_BUTTON_DRUCK_LAEUFT = 2;

    private const float K_DISTANCE_KLICK = 0.5f;

    public TextMeshPro mTextMeshProZurueck;

    public TextMeshPro mTextMeshProVorherige;
    public TextMeshPro mTextMeshProNaechste;

    public TextMeshPro mTextMeshProKaufinfo;
    public TextMeshPro mTextMeshEmojiGadgetErklaerfinfo;
   
    public TextMeshPro mTextMeshProEmoji1;
    public TextMeshPro mTextMeshProEmoji2;
    public TextMeshPro mTextMeshProEmoji3;


    public const int K_EMOJI_UFO_1 = 7;
    public const int K_EMOJI_UFO_2 = 3;
    public const string K_EMOJI_UFO_NAME = "Ufo";

    public const int K_EMOJI_KOMET_1 = 0;
    public const int K_EMOJI_KOMET_2 = 8;
    public const string K_EMOJI_KOMET_NAME = "Komet";

    public const int K_EMOJI_RAKETE_1 = 1;
    public const int K_EMOJI_RAKETE_2 = 9;
    public const string K_EMOJI_RAKETE_NAME = "Rakete";

    public const int K_EMOJI_MOND_1 = 2;
    public const int K_EMOJI_MOND_2 = 10;
    public const string K_EMOJI_MOND_NAME = "Mond";

    public const int K_EMOJI_SATELLIT_1 = 4;
    public const string K_EMOJI_SATELLIT_NAME = "Satellit";

    public const int K_EMOJI_HALBMOND_1 = 5;
    public const string K_EMOJI_HALBMOND_NAME = "Halbmond";

    public const int K_EMOJI_SATURN_1 = 6;
    public const string K_EMOJI_SATURN_NAME = "Saturn";

    public const string K_GESPIELTE_INDEX = "gespielt_emoji_index";
    public const string K_GEPSIELTE_INDEX_EMOJI_1 = "gespielt_emoji_index_1";
    public const string K_GEPSIELTE_INDEX_EMOJI_2 = "gespielt_emoji_index_2";

    private static readonly string K_SATURN_AKTIV = "SATURN_AKTIV";
    private static readonly string K_SATELLIT_AKTIV = "SATELLIT_AKTIV";
    private static readonly string K_ROCKET_AKTIV = "ROCKET_AKTIV ";
    private static readonly string K_SATURN_GEKAUFT = "SATURN_GEKAUFT";
    private static readonly string K_SATELLIT_GEKAUFT = "SATELLIT_GEKAUFT";
    private static readonly string K_ROCKET_GEKAUFT = "ROCKET_GEKAUFT";

    private static readonly int K_START_MUENZEN = 8;

    public GameObject mEmoji1;
    public GameObject mEmoji1Ring;

    public GameObject mEmoji2;
    public GameObject mEmoji2Ring;

    public GameObject mEmoji3;
    public GameObject mEmoji3Ring;

    public GameObject mEmojiBezahl;

    public GameObject mGameObjectPlaneten;
    public GameObject mGameObjectSatelitt;
    public GameObject mGameObjectRocket;

    public TextMeshPro mTextMeshProBezahlen1;
    public TextMeshPro mTextMeshProBezahlen2;

    public Dictionary<int, EmojiData> mMyEmojiDict;

    private int mIndexDesErsteEmojiInSzene;

    private int mIndexMitDemGespieltwird;

    private int mIndexZumKaufen;

    void Start()
    {
        /*
        PlayerPrefs.SetString(K_EMOJI_UFO_NAME,"");
        PlayerPrefs.SetString(K_EMOJI_KOMET_NAME, "");
        PlayerPrefs.SetString(K_EMOJI_RAKETE_NAME, "");
        PlayerPrefs.SetString(K_EMOJI_MOND_NAME, "");
        PlayerPrefs.SetString(K_EMOJI_SATELLIT_NAME, "");
        PlayerPrefs.SetString(K_EMOJI_HALBMOND_NAME, "");
        PlayerPrefs.SetString(K_EMOJI_SATURN_NAME, "");
        PlayerPrefs.SetString(K_SATURN_AKTIV, "");
        PlayerPrefs.SetString(K_SATELLIT_AKTIV, "");
        PlayerPrefs.SetString(K_ROCKET_AKTIV, "");
        PlayerPrefs.SetString(K_SATURN_GEKAUFT, "");
        PlayerPrefs.SetString(K_SATELLIT_GEKAUFT, "");
        PlayerPrefs.SetString(K_ROCKET_GEKAUFT, "");
        PlayerPrefs.SetInt(K_GESPIELTE_INDEX,0);
        set2BMuenzenAnzahl(200);
         */

        mMyEmojiDict = new Dictionary<int, EmojiData>();
        mIndexDesErsteEmojiInSzene = 1;
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_KOMET), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_KOMET)
            , K_EMOJI_KOMET_1, K_EMOJI_KOMET_2, 0, PlayerPrefs.GetString(K_EMOJI_KOMET_NAME), K_EMOJI_KOMET_NAME);
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_UFO), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_UFO),
            K_EMOJI_UFO_1, K_EMOJI_UFO_2, 10, PlayerPrefs.GetString(K_EMOJI_UFO_NAME), K_EMOJI_UFO_NAME);
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_RAKETE), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_RAKETE),
            K_EMOJI_RAKETE_1, K_EMOJI_RAKETE_2, 15, PlayerPrefs.GetString(K_EMOJI_RAKETE_NAME), K_EMOJI_RAKETE_NAME);
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_MOND), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_MOND),
            K_EMOJI_MOND_1, K_EMOJI_MOND_2, 10, PlayerPrefs.GetString(K_EMOJI_MOND_NAME), K_EMOJI_MOND_NAME);
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_SATELLIT), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_SATELLIT),
            K_EMOJI_SATELLIT_1, K_EMOJI_SATELLIT_1, 20, PlayerPrefs.GetString(K_EMOJI_SATELLIT_NAME), K_EMOJI_SATELLIT_NAME);
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_SATURN), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EMOJI_SATURN),
            K_EMOJI_SATURN_1, K_EMOJI_SATURN_1, 25, PlayerPrefs.GetString(K_EMOJI_SATURN_NAME), K_EMOJI_SATURN_NAME);

        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FLIEGENDE_OBJEKT_SATURN), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FLIEGENDE_OBJEKT_SATURN_PAY),
            -1, -1, 50, PlayerPrefs.GetString(K_SATURN_GEKAUFT), K_SATURN_GEKAUFT);
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FLIEGENDE_OBJEKT_SATELLIT), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FLIEGENDE_OBJEKT_SATELLIT_PAY),
            -1, -1, 50, PlayerPrefs.GetString(K_SATELLIT_GEKAUFT), K_SATELLIT_GEKAUFT);
        erzeuge(mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FLIEGENDE_OBJEKT_ROCKET), mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_FLIEGENDE_OBJEKT_ROCKET_PAY),
            -1, -1, 50, PlayerPrefs.GetString(K_ROCKET_GEKAUFT), K_ROCKET_GEKAUFT);

        mIndexDesErsteEmojiInSzene = 1; // beginnen immer vorn
        mIndexMitDemGespieltwird = getGespielteEmojiIndex();
        mIndexZumKaufen = 0;
    }

    public static int getGespielteEmojiIndex()
    {
        int lErg = PlayerPrefs.GetInt(K_GESPIELTE_INDEX);

        if (lErg == 0)
        {
            setGespielteEmojiIndex(1, K_EMOJI_KOMET_1, K_EMOJI_KOMET_2);
            return 1;
        }

        return lErg;
    }


    public static void setGespielteEmojiIndex(int pIndex, int pIndex1, int pIndex2)
    {
        PlayerPrefs.SetInt(K_GESPIELTE_INDEX, pIndex);
        PlayerPrefs.SetInt(K_GEPSIELTE_INDEX_EMOJI_1, pIndex1);
        PlayerPrefs.SetInt(K_GEPSIELTE_INDEX_EMOJI_2, pIndex2);
    }

    private void erzeuge(string pNAME, string pNAMEPay, int pEMOJI_NR_1, int pEMOJI_NR_2, int pPreis, string pGekauft, string pGekauftName)
    {
        EmojiData lEmojiData = new EmojiData();

        lEmojiData.mIndex = mIndexDesErsteEmojiInSzene;
        lEmojiData.mName = pNAME;
        lEmojiData.mNamePay = pNAMEPay;
        
        lEmojiData.mEmojiNr1 = pEMOJI_NR_1;
        lEmojiData.mEmojiNr2 = pEMOJI_NR_2;
        lEmojiData.mKosten = pPreis;

        if (istErworbeEmoji(pEMOJI_NR_1) || istErworbeEmoji(pEMOJI_NR_2))
        {
            lEmojiData.mGeKauft = "J";
        }
        else
        {
            lEmojiData.mGeKauft = pGekauft;
        }
        lEmojiData.mGeKauftName = pGekauftName;

        mMyEmojiDict.Add(mIndexDesErsteEmojiInSzene, lEmojiData);
        mIndexDesErsteEmojiInSzene++;

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray lRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit lRaycastHit;

            if (Physics.Raycast(lRay, out lRaycastHit))
            {
                if (lRaycastHit.transform.tag.StartsWith("Zurueck"))
                {
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                    SceneManager.LoadScene("Pruefung");
                }
                else if (lRaycastHit.transform.tag.StartsWith("EmojiKauf_1"))
                {
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                    Aktiviere(mEmoji1, 0);
                }
                else if (lRaycastHit.transform.tag.StartsWith("EmojiKauf_2"))
                {
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                    Aktiviere(mEmoji2, 1);
                }
                else if (lRaycastHit.transform.tag.StartsWith("EmojiKauf_3"))
                {
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                    Aktiviere(mEmoji3, 2);
                }
                else if (lRaycastHit.transform.tag.StartsWith("EmojiZurueck"))
                {
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                    EmojiAuswaehlen(false);
                }
                else if (lRaycastHit.transform.tag.StartsWith("EmojiVor"))
                {
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                    EmojiAuswaehlen(true);
                }
                else if (lRaycastHit.transform.tag.StartsWith("EmojBezahl"))
                {
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                    Bezahlen();
                }
                else
                {
                    mIndexZumKaufen = 0;
                }
            }
        }

        if (mSprachenuebersetzer != null)
        {
            mTextMeshProZurueck.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ZURUECK);

            mTextMeshProKaufinfo.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KAUFINFO).Replace("XX",
                 VirtualLookSteuerung.K_GOLD +
                get2BMuenzenAnzahl() + VirtualLookSteuerung.K_WHITE);
        

            mTextMeshProVorherige.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ART_DES_VOR);
            mTextMeshProNaechste.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ART_DES_NEXT);

            mTextMeshProEmoji1.text =
                lieferSpriteTextNr1(mIndexDesErsteEmojiInSzene) +
                mMyEmojiDict[mIndexDesErsteEmojiInSzene].mName +
                 lieferSpriteTextNr2(mIndexDesErsteEmojiInSzene) +
                 lieferKosten(mMyEmojiDict[mIndexDesErsteEmojiInSzene].mGeKauft, mMyEmojiDict[mIndexDesErsteEmojiInSzene].mKosten)
                ;
            mTextMeshProEmoji2.text =
                lieferSpriteTextNr1(mIndexDesErsteEmojiInSzene + 1) +
                mMyEmojiDict[mIndexDesErsteEmojiInSzene + 1].mName +
                lieferSpriteTextNr2(mIndexDesErsteEmojiInSzene + 1) + lieferKosten(mMyEmojiDict[mIndexDesErsteEmojiInSzene + 1].mGeKauft, mMyEmojiDict[mIndexDesErsteEmojiInSzene + 1].mKosten)
                ;
            mTextMeshProEmoji3.text =
                lieferSpriteTextNr1(mIndexDesErsteEmojiInSzene + 2) +
                mMyEmojiDict[mIndexDesErsteEmojiInSzene + 2].mName +
                 lieferSpriteTextNr2(mIndexDesErsteEmojiInSzene + 2) + lieferKosten(mMyEmojiDict[mIndexDesErsteEmojiInSzene + 2].mGeKauft, mMyEmojiDict[mIndexDesErsteEmojiInSzene + 2].mKosten)
                ;

            mEmojiBezahl.SetActive(false);
            if (mIndexZumKaufen > 0)
            {
                mEmojiBezahl.SetActive(true);
                mTextMeshProBezahlen1.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BEZAHLEN_1)
                  + "\n" +
                  lieferSpriteTextNr1(mIndexZumKaufen) +
                    mMyEmojiDict[mIndexZumKaufen].mNamePay + " " +
                   lieferSpriteTextNr2(mIndexZumKaufen);

                mTextMeshProBezahlen2.text = VirtualLookSteuerung.K_GOLD + "<b>" + mMyEmojiDict[mIndexZumKaufen].mKosten + "</b>  " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BEZAHLEN_2);
            }

            if (mIndexDesErsteEmojiInSzene >= 6)
            {
                mEmoji1Ring.SetActive(istSaturnAktiv());
                mEmoji2Ring.SetActive(istSatellitAktiv());
                mEmoji3Ring.SetActive(istRocketAktiv());
            }
            else
            {
                mEmoji1Ring.SetActive(mIndexDesErsteEmojiInSzene == mIndexMitDemGespieltwird);
                mEmoji2Ring.SetActive(mIndexDesErsteEmojiInSzene + 1 == mIndexMitDemGespieltwird);
                mEmoji3Ring.SetActive(mIndexDesErsteEmojiInSzene + 2 == mIndexMitDemGespieltwird);
            }
           
            if (mIndexDesErsteEmojiInSzene >= 6)
            {
                if (mIndexZumKaufen > 0)
                {
                    mGameObjectPlaneten.SetActive(false);
                    mGameObjectSatelitt.SetActive(false);
                    mGameObjectRocket.SetActive(false);
                } else
                {
                    mGameObjectPlaneten.SetActive(true);
                    mGameObjectSatelitt.SetActive(true);
                    mGameObjectRocket.SetActive(true);
                }
        
                mTextMeshEmojiGadgetErklaerfinfo.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ERKLAER_GADGET);
            }
            else
            {
                mGameObjectPlaneten.SetActive(false);
                mGameObjectSatelitt.SetActive(false);
                mGameObjectRocket.SetActive(false);

                mTextMeshEmojiGadgetErklaerfinfo.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ERKLAER_EMOJI);

            }
        }
    }

    private string lieferSpriteTextNr1(int pIndex)
    {
        if (mMyEmojiDict[pIndex].mEmojiNr1 == -1)
        {
            return "";
        }
        return "<sprite=" + mMyEmojiDict[pIndex].mEmojiNr1 + "> ";
    }

    private string lieferSpriteTextNr2(int pIndex)
    {
        if (mMyEmojiDict[pIndex].mEmojiNr2 == -1)
        {
            return "";
        }
        return " <sprite=" + mMyEmojiDict[pIndex].mEmojiNr2 + ">";
    }

    private void EmojiAuswaehlen(bool pWohin)
    {
        if (pWohin)
        {
            mIndexDesErsteEmojiInSzene = ((mIndexDesErsteEmojiInSzene + 9) - 3) % 9;
        }
        else
        {
            mIndexDesErsteEmojiInSzene = (mIndexDesErsteEmojiInSzene + 3) % 9;
        }
    }

    private string lieferKosten(string mGeKauft, int pKosten)
    {
        if (mGeKauft.Equals("J"))
        {
            return "\n<size=60%>" + VirtualLookSteuerung.K_GRAY + "(" + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ERWORBEN) + ")";
        }
        else
        {
            if (pKosten < get2BMuenzenAnzahl())
            {
                return "\n<size=60%>" + "(" + pKosten + " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KAUF_MOEGLICH) + ")";
            }
            else
            {
                return "\n<size=60%>" + VirtualLookSteuerung.K_GRAY + "(" + pKosten + " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KAUF_NICHT_MOEGLICH) + ")";
            }
        }
    }

    public static bool istErworbeEmoji(int lZufallsemoji)
    {
        if (lZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_KOMET_1
            || lZufallsemoji == EmojiKaufVerwaltung.K_EMOJI_KOMET_2
            )
        {
            return true;
        }

        return false;
    }

    private void Bezahlen()
    {
        if (mIndexZumKaufen > 0)
        {
            set2BMuenzenAnzahl(get2BMuenzenAnzahl() - mMyEmojiDict[mIndexZumKaufen].mKosten);
            mMyEmojiDict[mIndexZumKaufen].mGeKauft = "J";
            PlayerPrefs.SetString(mMyEmojiDict[mIndexZumKaufen].mGeKauftName, "J");
            mIndexZumKaufen = 0;
        }

    }

    private void Aktiviere(GameObject pEmojiAktiv, int pIndex)
    {
        if (mMyEmojiDict[mIndexDesErsteEmojiInSzene + pIndex].mGeKauft.Equals("J"))
        {
            if (mIndexDesErsteEmojiInSzene + pIndex == 7)
            {
                setSaturnAktiv(!istSaturnAktiv());
            }
            else if (mIndexDesErsteEmojiInSzene + pIndex == 8)
            {
                setSatellitAktiv(!istSatellitAktiv());
            }
            else if (mIndexDesErsteEmojiInSzene + pIndex == 9)
            {
                setRocketAktiv(!istRocketAktiv());
            }
            else
            {
                mIndexMitDemGespieltwird = mIndexDesErsteEmojiInSzene + pIndex;
                setGespielteEmojiIndex(mIndexDesErsteEmojiInSzene
                    + pIndex, mMyEmojiDict[mIndexMitDemGespieltwird].mEmojiNr1, mMyEmojiDict[mIndexMitDemGespieltwird].mEmojiNr2);
            }
        }
        else
        {
            if (get2BMuenzenAnzahl() > mMyEmojiDict[mIndexDesErsteEmojiInSzene + pIndex].mKosten)
            {
                mIndexZumKaufen = mIndexDesErsteEmojiInSzene + pIndex;
            }
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

    private int get2BMuenzenAnzahl()
    {

        int lErg = PlayerPrefs.GetInt(PruefungGUISteuerung.K_PRUEFUNG_MUENZENANZAHL);

        if (lErg < K_START_MUENZEN)
        {
            lErg = K_START_MUENZEN;
            set2BMuenzenAnzahl(lErg);
        }

        return lErg;
    }
    private void set2BMuenzenAnzahl(int pAnzahlNeu)
    {
        PlayerPrefs.SetInt(PruefungGUISteuerung.K_PRUEFUNG_MUENZENANZAHL, pAnzahlNeu);
    }

    public static int lieferAktiveEmoji(int p1oder2)
    {
        if (p1oder2 > 0)
        {
            return PlayerPrefs.GetInt(K_GEPSIELTE_INDEX_EMOJI_2);
        }
        else
        {
            return PlayerPrefs.GetInt(K_GEPSIELTE_INDEX_EMOJI_2);
        }
    }

    internal static bool istRocketAktiv()
    {
        return PlayerPrefs.GetString(K_ROCKET_AKTIV).Equals("J");
    }

    internal static bool istSatellitAktiv()
    {
        return PlayerPrefs.GetString(K_SATELLIT_AKTIV).Equals("J");
    }

    internal static bool istSaturnAktiv()
    {
        return PlayerPrefs.GetString(K_SATURN_AKTIV).Equals("J");
    }

    internal static void setRocketAktiv(Boolean pWas)
    {
        if (pWas)
        {
            PlayerPrefs.SetString(K_ROCKET_AKTIV,"J");
        } else
        {
            PlayerPrefs.SetString(K_ROCKET_AKTIV, "N");
        }
    }
    internal static void setSatellitAktiv(Boolean pWas)
    {
        if (pWas)
        {
            PlayerPrefs.SetString(K_SATELLIT_AKTIV, "J");
        }
        else
        {
            PlayerPrefs.SetString(K_SATELLIT_AKTIV, "N");
        }
    }
    internal static void setSaturnAktiv(Boolean pWas)
    {
        if (pWas)
        {
            PlayerPrefs.SetString(K_SATURN_AKTIV, "J");
        }
        else
        {
            PlayerPrefs.SetString(K_SATURN_AKTIV, "N");
        }
    }
}
