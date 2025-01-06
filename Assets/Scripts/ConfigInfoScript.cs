using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ConfigInfoScript : MonoBehaviour
{

    // Buttoneffekt

    public int mClickModiAktiv;

    private const float K_DISTANCE_KLICK = 0.5f;

    public const int K_BUTTON_ANZAHL_MAX = 99;

    public const int K_BUTTON_ANZAHL_EINFACH = 20;

    private const int K_BUTTON_INIT = 0;

    private const int K_BUTTON_DRUCK_LAEUFT = 2;

    public const string K_ANZAHL_BUTTON = "ANZAHL_BUTTON_WERT";

    public const string K_ANZAHL_BUTTON_LAST = "ANZAHL_BUTTON_WERT_LAST";


    private TextMeshPro mZurueckTextMeshProZurueck;

    private TextMeshPro mZurueckTextMeshInfos;

    private TextMeshPro mZurueckTextMeshEnglish;

    private TextMeshPro mZurueckTextMeshDeutsch;


    public TextMeshProUGUI mTextMeshSpielergebnisName;
    public TextMeshProUGUI mTextMeshSpielergebnisMasse;
    public TextMeshProUGUI mTextMeshSpielergebnisDistanz;
    public TextMeshProUGUI mTextMeshSpielergebnisDistanzAbw;
    public TextMeshProUGUI mTextMeshSpielergebnisSpeed;
    public TextMeshProUGUI mTextMeshSpielergebnisSpeedAbw;
    public TextMeshProUGUI mTextMeshSpielergebnisPunkte;

    private TextMeshProUGUI mTextMeshNameLabel;

    public TextMeshProUGUI mTextMeshGraviLabelLabel;

    public TextMeshProUGUI mTextMeshButtontext;


    public TextMeshProUGUI mTextMeshTitel;

    public TextMeshProUGUI mTextMeshKartenanzahl;


    private TMP_InputField mTextMeshNameEditfeld;

    private HighScoreVerwaltung mHighScoreVerwaltung;

    private Sprachenuebersetzer mSprachenuebersetzer;

    public GameObject mGameObjectErklärungHighscore;

    void Start()
    {
        mSprachenuebersetzer = GameObject.FindGameObjectWithTag("Sprachenuebersetzer").GetComponent<Sprachenuebersetzer>();

        mZurueckTextMeshProZurueck = GameObject.FindGameObjectWithTag("ZurueckTMPro").GetComponent<TextMeshPro>();

        mZurueckTextMeshInfos = GameObject.FindGameObjectWithTag("InfoTMPro").GetComponent<TextMeshPro>();

        mZurueckTextMeshEnglish = GameObject.FindGameObjectWithTag("EnglishTMPro").GetComponent<TextMeshPro>();

        mZurueckTextMeshDeutsch = GameObject.FindGameObjectWithTag("DeutschTMPro").GetComponent<TextMeshPro>();

        mTextMeshKartenanzahl = GameObject.FindGameObjectWithTag("KartenanzahlButton").GetComponent<TextMeshProUGUI>();

        mTextMeshNameLabel = GameObject.FindGameObjectWithTag("NameTMProLabel").GetComponent<TextMeshProUGUI>();

        mTextMeshNameEditfeld = GameObject.FindGameObjectWithTag("NameTMProEditFeld").GetComponent<TMP_InputField>();

        mHighScoreVerwaltung = GameObject.FindGameObjectWithTag("HighScoreVerwaltung").GetComponent<HighScoreVerwaltung>();

        setzeSprache();

        mGameObjectErklärungHighscore.SetActive(false);
    }

    void setzeSprache()
    {
        mZurueckTextMeshEnglish.text = VirtualLookSteuerung.K_WHITE + Sprachenuebersetzer.K_SPRACHE_ENGLSIH;
        mZurueckTextMeshDeutsch.text = VirtualLookSteuerung.K_WHITE + Sprachenuebersetzer.K_SPRACHE_DEUTSCH;

        if (mSprachenuebersetzer.getSprache() == Sprachenuebersetzer.K_DEUTSCH)
        {
            mZurueckTextMeshDeutsch.text = VirtualLookSteuerung.K_GREEN + Sprachenuebersetzer.K_SPRACHE_DEUTSCH;
        }
        if (mSprachenuebersetzer.getSprache() == Sprachenuebersetzer.K_ENGLISH)
        {
            mZurueckTextMeshEnglish.text = VirtualLookSteuerung.K_GREEN + Sprachenuebersetzer.K_SPRACHE_ENGLSIH;
        }

        mTextMeshNameEditfeld.text = mSprachenuebersetzer.lieferNamen();

        mTextMeshNameEditfeld.enabled = mHighScoreVerwaltung.istUeberLevel1();

        mTextMeshTitel.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BLEIBT_TITEL)
            + mHighScoreVerwaltung.lieferErreichteTitel();

        mTextMeshButtontext.text = PlayerPrefs.GetInt(HighScoreVerwaltung.K_GRAVI_PUNKTE) + " ";
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

                    SceneManager.LoadScene("PlanetenSpielSzene1");
                }
                else if (lRaycastHit.transform.tag.StartsWith("Deutsch"))
                {

                    mSprachenuebersetzer.setSprache(Sprachenuebersetzer.K_DEUTSCH);
                    setzeSprache();
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));

                }
                else if (lRaycastHit.transform.tag.StartsWith("English"))
                {

                    mSprachenuebersetzer.setSprache(Sprachenuebersetzer.K_ENGLISH);
                    setzeSprache();
                    StartCoroutine(clickEffektSprache(lRaycastHit.transform.gameObject));
                }
                else if (mGameObjectErklärungHighscore.activeSelf)
                {

                    clickArenaRekordButton();
                }
            }
        }

        if (mSprachenuebersetzer != null)
        {
            mZurueckTextMeshProZurueck.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ZURUECK);
            mZurueckTextMeshInfos.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_INFO_BILD_1) +
                "\n \n" + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_INFO_BILD_2) +
                "\n \n" + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_INFO_FAKTEN);

            mTextMeshNameLabel.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NAMEN_CHANGE);
            mTextMeshGraviLabelLabel.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PUNKTE_GRAVITATIONSMODUS);

        }

        mTextMeshSpielergebnisName.text = PlayerPrefs.GetString(HighScoreVerwaltung.K_GRAVI_NAME);
        mTextMeshSpielergebnisMasse.text = PlayerPrefs.GetString(HighScoreVerwaltung.K_GRAVI_MASSE);
        mTextMeshSpielergebnisDistanz.text = PlayerPrefs.GetString(HighScoreVerwaltung.K_GRAVI_DISTANZ);
        mTextMeshSpielergebnisDistanzAbw.text = PlayerPrefs.GetString(HighScoreVerwaltung.K_GRAVI_DISTANZ_ABW);
        mTextMeshSpielergebnisSpeed.text = PlayerPrefs.GetString(HighScoreVerwaltung.K_GRAVI_SPEED);
        mTextMeshSpielergebnisSpeedAbw.text = PlayerPrefs.GetString(HighScoreVerwaltung.K_GRAVI_SPEED_ABW);
        mTextMeshSpielergebnisPunkte.text = PlayerPrefs.GetString(HighScoreVerwaltung.K_GRAVI_PUNKTE_C);
        if (PlayerPrefs.GetInt(K_ANZAHL_BUTTON) == K_BUTTON_ANZAHL_MAX)
        {
            mTextMeshKartenanzahl.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ALLE_HIMMELSKOERPER);
        }
        else
        {
            mTextMeshKartenanzahl.text = PlayerPrefs.GetInt(K_ANZAHL_BUTTON) + " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HIMMELSKOERPER);
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

    public void clickArenaRekordButton()
    {
        if (mGameObjectErklärungHighscore.activeSelf)
        {
            mGameObjectErklärungHighscore.SetActive(false);
            mTextMeshButtontext.text = PlayerPrefs.GetInt(HighScoreVerwaltung.K_GRAVI_PUNKTE) + " ";
        }
        else
        {
            mTextMeshButtontext.text = VirtualLookSteuerung.K_GREEN_SCHRIFT
                + PlayerPrefs.GetInt(HighScoreVerwaltung.K_GRAVI_PUNKTE) + " ";
            mGameObjectErklärungHighscore.SetActive(true);
        }

    }

    public void clickKartenAnzahlButton()
    {
        int lAnzahlButton = PlayerPrefs.GetInt(K_ANZAHL_BUTTON);

        if (lAnzahlButton == 0 || lAnzahlButton == K_BUTTON_ANZAHL_EINFACH)
        {
            lAnzahlButton = K_BUTTON_ANZAHL_MAX;
        }
        else
        {
            lAnzahlButton = K_BUTTON_ANZAHL_EINFACH;
        }

        PlayerPrefs.SetInt(K_ANZAHL_BUTTON, lAnzahlButton);
    }
}
