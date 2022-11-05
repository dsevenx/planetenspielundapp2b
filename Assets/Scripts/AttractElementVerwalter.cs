using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class AttractElementVerwalter : MonoBehaviour
{
    public Camera mMainCamera;

    public GameObject mCube;

    public Dictionary<int, Attract4Dictionary> mMyAttractElemtentDict;

    GameObject mGameObjectMitte;

    public GameObject mPrefabOfAttractElement;

    public const float K_MASSEN_RADIUS_UMERECHENFAKTOR = 30f / (4f * 3.141f * 5f);

    public int K_ANZAHL;

    const float G = 6.6741f;

    const float K_MAX_POWER = 100000;

    const float K_MAX_POWER_MINUS = -100000;

    const float K_WINKEL_GESCHWINDIGKEIT = 0.6f;

    const float K_WINKEL_GESCHWINDIGKEIT_MIN = -1.5f;

    const float K_WINKEL_GESCHWINDIGKEIT_MAX = 1.5f;

    const float K_DISTANCE_ERHOEHER = 3f;

    public float mWeiterWeg = 30;

    // Massen
    private const float K_START_MASSE_ZENTRUM = 200000;

    public const float K_START_MASSE_EINZEL_ELEMENT = 100;

    private const float K_MAX_ANZAHL_EINZEL_ELEMENT_ERZEUGUNG_INSGESAMT = 100;

    private const float K_MAX_ERSATZ_ERZEUGUNG_MASSE = K_START_MASSE_ZENTRUM + (K_START_MASSE_EINZEL_ELEMENT * K_MAX_ANZAHL_EINZEL_ELEMENT_ERZEUGUNG_INSGESAMT);

    private float lVerbleibendeMasse;

    public int mAktuellLetzteIndexAttractElement;

    // Bewegen

    public MoveSteuerung mMoveSteuerung;

    private float mCameraFromMoveX;

    private float mCameraFromMoveZ;

    private const float K_MAX_Camera_From_Move_X = 100;

    private const float K_MAX_Camera_From_Move_Z = 100;

    private const float K_MAX_Camera_From_Move_X_MINUS = -100;

    private const float K_MAX_Camera_From_Move_Z_MINUS = -500;

    // Drehen
    public Einstellwert mEinstellDrehen;

    public DrehVektor mDrehVektorY;

    private const float K_MAX_Camera_From_Dreh_STEP = 10;

    private const float K_MAX_Camera_From_Dreh_Y = 90;

    private const float K_MAX_Camera_From_Dreh_Y_MINUS = -90;

    public const float K_DistanceCameraSonne = 260;

    private const string K_GESCHAFFT = "Geschafft";

    public const int K_URKNALL = 138;

    public EinstellHochscript mWinkelEinstellHochscript;

    public EinstellRunterScript mWinkelEinstellRunterScript;


    // Masse
    public EinstellHochscript mMasseEinstellHochscript;

    public EinstellRunterScript mMasseEinstellRunterScript;

    public Einstellwert mEinstellMasse;

    // Speed X
    public EinstellHochscript mSpeedXEinstellHochscript;

    public EinstellRunterScript mSpeedXEinstellRunterScript;

    public Einstellwert mEinstellSpeedX;

    // Speed Y
    public EinstellHochscript mSpeedYEinstellHochscript;

    public EinstellRunterScript mSpeedYEinstellRunterScript;

    public Einstellwert mEinstellSpeedY;

    // Speed Z
    public EinstellHochscript mSpeedZEinstellHochscript;

    public EinstellRunterScript mSpeedZEinstellRunterScript;

    public Einstellwert mEinstellSpeedZ;


    public Sprachenuebersetzer mSprachenuebersetzer;

    private bool mSpielZeitlaeuft;

    private float mSpielZeit;


    public TextMeshProUGUI mTextMeshSpielzeit;


    public TextMeshProUGUI mTextMeshMasseUebrig;
    public GameObject mCanvasErgebnis;
    public GameObject mTGameobjectMasseUebrig;

    // Ergebnis ANF
    public TextMeshProUGUI mTextMeshSpielergebnisName;
    public TextMeshProUGUI mTextMeshSpielergebnisMasse;
    public TextMeshProUGUI mTextMeshSpielergebnisDistanz;
    public TextMeshProUGUI mTextMeshSpielergebnisDistanzAbw;
    public TextMeshProUGUI mTextMeshSpielergebnisSpeed;
    public TextMeshProUGUI mTextMeshSpielergebnisSpeedAbw;
    public TextMeshProUGUI mTextMeshSpielergebnisPunkte;

    public TextMeshProUGUI mTextMeshGesamtpunkte;


    // Ergebnis END

    public StartStoppScript mStartStoppScript;

    public Dictionary<int, List<DarstellungAttractElement>> mAllListeAufgesammelt;


    public EinAusklappscript mEinAusklappscript;

    public DarstellungAttractelementInfos mDarstellungAttractelementInfos;

    public GameObject mDarstellungAttractelementInfosGameObject;

    public GameObject mDarstellungAttractelement4JahreInfosGameObject;

    public GameObject mDarstellungGesamtpunkteGameObject;



    /// Start
    /// ///////////////////////////////////////////////////
    /// Start


    internal Attract4Dictionary erzeugeHimmelskoerperBase()
    {
        GameObject lGameObject = Instantiate(mPrefabOfAttractElement);

        lGameObject.name = "Element_" + string.Format("{0,3:000}", mAktuellLetzteIndexAttractElement);

        AttractElelemt lAttractElelemt = lGameObject.GetComponent<AttractElelemt>();
        lAttractElelemt.mElementNummer = mAktuellLetzteIndexAttractElement;
        lAttractElelemt.mCamera = mMainCamera;
        lAttractElelemt.mThis = lGameObject;
        lAttractElelemt.mAttractElementVerwalter = this;
        lAttractElelemt.mAllEinStayTimeEintrag = new Dictionary<string, EinStayTimeEintrag>();

        Attract4Dictionary lAttract4Dictionary = new Attract4Dictionary();
        lAttract4Dictionary.mAttractElelemt = lAttractElelemt;
        lAttract4Dictionary.mGameobjectAttractElement = lGameObject;

        mMyAttractElemtentDict.Add(mAktuellLetzteIndexAttractElement, lAttract4Dictionary);

        return lAttract4Dictionary;
    }

    public int lieferZeitIndex()
    {
        return (int)mSpielZeit;
    }


    void Start()
    {
        init();
        einBlendenCanvas(false, false);
    }

    internal float lieferEinstellMasse()
    {
        if (mEinstellMasse == null)
        {
            return K_START_MASSE_EINZEL_ELEMENT;
        }
        return mEinstellMasse.mCount;
    }

    public Dictionary<int, List<DarstellungAttractElement>> liefermAllListeAufgesammelt()
    {
        return mAllListeAufgesammelt;
    }

    private void init()
    {
        mSpielZeitlaeuft = false;

        mAllListeAufgesammelt = new Dictionary<int, List<DarstellungAttractElement>>();

        mDrehVektorY = new DrehVektor();

        mMyAttractElemtentDict = new Dictionary<int, Attract4Dictionary>();

        setzePositionVonCamera(new Vector3(0, 0, K_DistanceCameraSonne));

        mCameraFromMoveX = 0;
        mCameraFromMoveZ = 0;

        setzeEinstellungen();

        mAktuellLetzteIndexAttractElement = 0;

        Attract4Dictionary lAttract4DictionaryMitte = erzeugeHimmelskoerperBase();
        mGameObjectMitte = lAttract4DictionaryMitte.mGameobjectAttractElement;

        lAttract4DictionaryMitte.mGameobjectAttractElement.GetComponent<Rigidbody>().mass = K_START_MASSE_ZENTRUM;
        lAttract4DictionaryMitte.mGameobjectAttractElement.transform.position = new Vector3(0, 0, 0);
        lAttract4DictionaryMitte.mGameobjectAttractElement.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, K_WINKEL_GESCHWINDIGKEIT, 0);
        lAttract4DictionaryMitte.mAttractElelemt.setzeTextureUndScaleAufgrundMasse();
        lAttract4DictionaryMitte.mAttractElelemt.sollGraviSpueren = true;

        erzeugePlaneten(); // erste Planeten erzeugen

        mDarstellungAttractelementInfos.init();
    }

    void erzeugePlaneten()
    {
        mAktuellLetzteIndexAttractElement++;

        Attract4Dictionary lAttract4DictionaryNeu = erzeugeHimmelskoerperBase();

        lAttract4DictionaryNeu.mGameobjectAttractElement.GetComponent<Rigidbody>().mass = mEinstellMasse.mCount;
        lAttract4DictionaryNeu.mAttractElelemt.setzeTextureUndScaleAufgrundMasse();
        aktualisierPositonPlanet();
        lAttract4DictionaryNeu.mAttractElelemt.sollGraviSpueren = false;
    }

    void Update()
    {
        if (mEinstellMasse.mCount >= K_START_MASSE_EINZEL_ELEMENT)
        {
            aktualisierPositonPlanet();
            mMyAttractElemtentDict[mAktuellLetzteIndexAttractElement].mGameobjectAttractElement.GetComponent<Rigidbody>().mass = mEinstellMasse.mCount;
            mMyAttractElemtentDict[mAktuellLetzteIndexAttractElement].mAttractElelemt.setzeTextureUndScaleAufgrundMasse();
        }

        if (mSpielZeitlaeuft)
        {
            mSpielZeit = mSpielZeit - Time.deltaTime;

            if (mSpielZeit > 0)
            {
                mTextMeshSpielzeit.text = (int)mSpielZeit + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_TIME_UNITS);
                mTextMeshMasseUebrig.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASSE_VERFUEGBAR) + " : " + (int)lVerbleibendeMasse;
            }
            else
            {
                stoppeSpiel(K_GESCHAFFT);
            }
        }
        else
        {
            mTextMeshSpielzeit.text = K_URKNALL + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_TIME_UNITS);
            //mTextMeshSpielergebnis.text = "";
        }
    }

    public void stoppeSpiel(String pMessage)
    {
        mSpielZeitlaeuft = false;
        mTextMeshSpielzeit.text = "";
        mTextMeshMasseUebrig.text = pMessage;
        mStartStoppScript.setzeTextMeshProUndEinAusklappen();


        if (pMessage.Equals(K_GESCHAFFT))
        {
            einBlendenCanvas(false, true);

            Dictionary<int, DarstellungAttractElementProtokoll> mProtkollAll = new Dictionary<int, DarstellungAttractElementProtokoll>();

            int lAnzahlPlanetenKollisionen = 0;
            int lAnzahl150er = 0;
            int lAnzahl250er = 0;
            int lGesamtpunkte = 0;

            foreach (var lProtokoll in mAllListeAufgesammelt)
            {
                foreach (DarstellungAttractElement lEinPlanet in lProtokoll.Value)
                {
                    if (lEinPlanet.mAktiv)
                    {
                        if (!mProtkollAll.ContainsKey(lEinPlanet.mNummer))
                        {
                            DarstellungAttractElementProtokoll lDarstellungAttractElementProtokoll = new DarstellungAttractElementProtokoll(lEinPlanet.mNummer, lEinPlanet.mName, lEinPlanet.mMassenpunkte);

                            lDarstellungAttractElementProtokoll.hinzufuegen(lEinPlanet.mAbstand, lEinPlanet.mSpeed, lEinPlanet.mMasse);

                            mProtkollAll.Add(lEinPlanet.mNummer, lDarstellungAttractElementProtokoll);
                        }
                        else
                        {
                            mProtkollAll[lEinPlanet.mNummer].hinzufuegen(lEinPlanet.mAbstand, lEinPlanet.mSpeed, lEinPlanet.mMasse);
                        }
                    } else
                    {
                        lAnzahlPlanetenKollisionen++;
                    }
                }
            }

            mTextMeshSpielergebnisName.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PLANETENNAME);
            mTextMeshSpielergebnisMasse.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASSEN_STABILE_TAGE);
            mTextMeshSpielergebnisDistanz.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DISTANCE);
            mTextMeshSpielergebnisDistanzAbw.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ABWEICHUNG_DISTANCE);
            mTextMeshSpielergebnisSpeed.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GESCHWINDIGEIT);
            mTextMeshSpielergebnisSpeedAbw.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GESCHWINDIGEIT_ABWEICHUNG);
            mTextMeshSpielergebnisPunkte.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PUNKTE);

            foreach (var lSatz in mProtkollAll)
            {
                lSatz.Value.ermittel();
            }

            List<KeyValuePair<int, DarstellungAttractElementProtokoll>> mProtkollAllList = mProtkollAll.OrderByDescending(d => d.Value.mPunkteErmittelt).
            ToList();

            int mRelevant = 0;
            foreach (KeyValuePair<int, DarstellungAttractElementProtokoll> lSatz in mProtkollAllList)
            {
                if (lSatz.Value.mPunkteErmittelt > 0 && mRelevant < 8)
                {
                    mTextMeshSpielergebnisName.text = mTextMeshSpielergebnisName.text + "\n" + lSatz.Value.mName;
                    mTextMeshSpielergebnisMasse.text = mTextMeshSpielergebnisMasse.text + "\n" + lSatz.Value.mMasseMeistensTage;
                    mTextMeshSpielergebnisDistanz.text = mTextMeshSpielergebnisDistanz.text + "\n" + lSatz.Value.mDistanceDurchschnitt;
                    mTextMeshSpielergebnisDistanzAbw.text = mTextMeshSpielergebnisDistanzAbw.text + "\n" + lSatz.Value.mDistanzeabweichung + " %";
                    mTextMeshSpielergebnisSpeed.text = mTextMeshSpielergebnisSpeed.text + "\n" + lSatz.Value.mSpeedDurchschnitt;
                    mTextMeshSpielergebnisSpeedAbw.text = mTextMeshSpielergebnisSpeedAbw.text + "\n" + lSatz.Value.mSpeedabweichung + " %";
                    mTextMeshSpielergebnisPunkte.text = mTextMeshSpielergebnisPunkte.text + "\n" + lSatz.Value.mPunkteErmittelt;

                    lGesamtpunkte += lSatz.Value.mPunkteErmittelt;
                    if (lSatz.Value.ist150er())
                    {
                        lAnzahl150er++;
                    }
                    else
                    if (lSatz.Value.ist250er())
                    {
                        lAnzahl250er++;
                    }
                    mRelevant++;
                }
            }
            mTextMeshSpielergebnisName.text = mTextMeshSpielergebnisName.text + "\n" + "extra";
            int lExtraPunkte = 0;

            if (lAnzahlPlanetenKollisionen < 3)
            {
                lExtraPunkte += 10;
            }
            else if (lAnzahlPlanetenKollisionen < 6)
            {
                lExtraPunkte += 5;
            }

            if (lAnzahl150er == 1)
            {
                lExtraPunkte += 20;
            }
            else if (lAnzahl150er == 2)
            {
                lExtraPunkte += 10;
            }

            if (lAnzahl250er == 1)
            {
                lExtraPunkte += 20;
            }
            else if (lAnzahl250er == 2)
            {
                lExtraPunkte += 10;
            }

            lGesamtpunkte += lExtraPunkte;

            mTextMeshSpielergebnisPunkte.text = mTextMeshSpielergebnisPunkte.text + "\n" + lExtraPunkte;
            mTextMeshGesamtpunkte.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GESAMTPUNKTE) + " " + lGesamtpunkte;

            int lAktuelleRekord = PlayerPrefs.GetInt(HighScoreVerwaltung.K_GRAVI_PUNKTE);
            if (lAktuelleRekord < lGesamtpunkte)
            {
                PlayerPrefs.SetInt(HighScoreVerwaltung.K_GRAVI_PUNKTE, lGesamtpunkte);
                mTextMeshGesamtpunkte.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GESAMTPUNKTE) + " " + lGesamtpunkte + " "+ mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NEUER_REKORD);

                PlayerPrefs.SetString(HighScoreVerwaltung.K_GRAVI_NAME, mTextMeshSpielergebnisName.text);
                PlayerPrefs.SetString(HighScoreVerwaltung.K_GRAVI_MASSE,mTextMeshSpielergebnisMasse.text );
                PlayerPrefs.SetString(HighScoreVerwaltung.K_GRAVI_DISTANZ,mTextMeshSpielergebnisDistanz.text );
                PlayerPrefs.SetString(HighScoreVerwaltung.K_GRAVI_DISTANZ_ABW, mTextMeshSpielergebnisDistanzAbw.text );
                PlayerPrefs.SetString(HighScoreVerwaltung.K_GRAVI_SPEED, mTextMeshSpielergebnisSpeed.text);
                PlayerPrefs.SetString(HighScoreVerwaltung.K_GRAVI_SPEED_ABW, mTextMeshSpielergebnisSpeedAbw.text );
                PlayerPrefs.SetString(HighScoreVerwaltung.K_GRAVI_PUNKTE_C, mTextMeshSpielergebnisPunkte.text);
            }
            else
            {
                mTextMeshGesamtpunkte.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GESAMTPUNKTE) + " " + lGesamtpunkte;
            }
        }
        else
        {
            einBlendenCanvas(false, false);
        }
    }

    private void einBlendenCanvas(bool pEnable, bool pEnde)
    {
        mDarstellungAttractelementInfosGameObject.SetActive(pEnable);
        mDarstellungAttractelement4JahreInfosGameObject.SetActive(pEnable);
        mTGameobjectMasseUebrig.SetActive(pEnable);
        mCanvasErgebnis.SetActive(pEnde);
        mDarstellungGesamtpunkteGameObject.SetActive(pEnde);
    }

    public void starteSpiel()
    {
        foreach (var lAttractelem in mMyAttractElemtentDict)
        {
            Destroy(lAttractelem.Value.mGameobjectAttractElement);
        }

        init();

        einBlendenCanvas(true, false);
        setzeEinstellungen();
        mSpielZeit = K_URKNALL;
        mSpielZeitlaeuft = true;
        lVerbleibendeMasse = K_MAX_ERSATZ_ERZEUGUNG_MASSE - K_START_MASSE_ZENTRUM;
        mStartStoppScript.setzeTextMeshProUndEinAusklappen();
    }

    public bool istSpielAmLaufen()
    {
        return mSpielZeitlaeuft;
    }



    void aktualisierPositonPlanet()
    {
        Vector3 lPostionZentrum =
        mMyAttractElemtentDict[0].mGameobjectAttractElement.transform.position;

        mMyAttractElemtentDict[mAktuellLetzteIndexAttractElement].mGameobjectAttractElement.transform.position =
        new Vector3(lPostionZentrum.x - 10, lPostionZentrum.y + 5, lPostionZentrum.z + 17 - AttractElementVerwalter.K_DistanceCameraSonne + lieferZFromMove());
    }

    public List<DarstellungAttractElement> liefer4Darstellung(String pName)
    {
        List<DarstellungAttractElement> pErgListe = new List<DarstellungAttractElement>();

        foreach (var lElement in mMyAttractElemtentDict)
        {
            if (lElement.Value.mAttractElelemt.sollGraviSpueren)
            {
                DarstellungAttractElement lSatz = new DarstellungAttractElement();

                lSatz.mNummer = lElement.Value.mAttractElelemt.mElementNummer;
                lSatz.mMassenpunkte = lElement.Value.mAttractElelemt.mMassenPunkte;
                lSatz.mName = pName + String.Format("{0:00}", lElement.Value.mAttractElelemt.mElementNummer);
                lSatz.mMasse = (int)lElement.Value.mAttractElelemt.mRigidbody.mass + "";
                lSatz.mSpeed = String.Format("{0:###0}", lElement.Value.mAttractElelemt.mRigidbody.velocity.magnitude);

                if (lElement.Value.mAttractElelemt.mElementNummer == 0)
                {
                    lSatz.mAbstand = 0;
                }
                else
                {
                    Vector3 lAbstandAlsVektor = mMyAttractElemtentDict[0].mAttractElelemt.transform.position - lElement.Value.mAttractElelemt.transform.position;
                    lSatz.mAbstand = (int)lAbstandAlsVektor.magnitude;
                }

                pErgListe.Add(lSatz);
            }
        }

        return pErgListe;
    }


    public void goPlanet()
    {

        Attract4Dictionary lAttract4Dictionary = mMyAttractElemtentDict[mAktuellLetzteIndexAttractElement];

        GameObject lGameObject = lAttract4Dictionary.mGameobjectAttractElement;

        lGameObject.GetComponent<Rigidbody>().velocity = new Vector3(mEinstellSpeedX.mCount, mEinstellSpeedY.mCount, mEinstellSpeedZ.mCount); //Vector3.zero; 8,3,8
        lGameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Vector3 lPositionZiel = new Vector3(mMainCamera.transform.position.x + mEinstellSpeedX.mCount
                                  , mMainCamera.transform.position.y + mEinstellSpeedY.mCount
                                  , mMainCamera.transform.position.z + mEinstellSpeedZ.mCount
                                  );

        AttractVector lAttractVector = ermittelKraft(lGameObject.transform.position,
            lGameObject.GetComponent<Rigidbody>().mass, 0f,
            lPositionZiel
            , mGameObjectMitte.GetComponent<Rigidbody>().mass);

        lGameObject.GetComponent<Rigidbody>().AddForce(lAttractVector.mVectorKreis);
        lGameObject.GetComponent<Rigidbody>().AddForce(lAttractVector.mVectorGravi);

        float lNeueWinkelgeschwindigkeit = UnityEngine.Random.Range(K_WINKEL_GESCHWINDIGKEIT_MIN, K_WINKEL_GESCHWINDIGKEIT_MAX);
        lGameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, lNeueWinkelgeschwindigkeit, 0);

        lAttract4Dictionary.mAttractElelemt.sollGraviSpueren = true;

        lVerbleibendeMasse = lVerbleibendeMasse - lGameObject.GetComponent<Rigidbody>().mass;
        if (lVerbleibendeMasse < mEinstellMasse.mOben)
        {
            mEinstellMasse.mOben = lVerbleibendeMasse;
            if (mEinstellMasse.mOben < mEinstellMasse.mUnten)
            {
                mEinstellMasse.mUnten = mEinstellMasse.mOben;
            }
        }
        if (lVerbleibendeMasse < mEinstellMasse.mCount)
        {
            mEinstellMasse.mCount = lVerbleibendeMasse;
        }

        if (mEinstellMasse.mCount >= K_START_MASSE_EINZEL_ELEMENT)
        {
            erzeugePlaneten();
        }
        else
        {
            mEinAusklappscript.setzeTextMeshProUndKlappenEinAus();
        }
    }

    internal void verschlucke(int pIndexGameObject)
    {
        mMyAttractElemtentDict.Remove(pIndexGameObject);
    }

    internal void setzePositionVonCamera(Vector3 mPosOfCamera)
    {
        mMainCamera.transform.position = mPosOfCamera;
    }

    private void setzeEinstellungen()
    {
        mEinstellDrehen = new Einstellwert();
        mEinstellDrehen.mOben = K_MAX_Camera_From_Dreh_Y;
        mEinstellDrehen.mUnten = K_MAX_Camera_From_Dreh_Y_MINUS;
        mEinstellDrehen.mCount = 0;
        mEinstellDrehen.mTimeDivisior = 12;
        mEinstellDrehen.mName = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WINKEL);
        mWinkelEinstellHochscript.SetEinstellwert(mEinstellDrehen);
        mWinkelEinstellRunterScript.SetEinstellwert(mEinstellDrehen);

        mEinstellMasse = new Einstellwert();
        mEinstellMasse.mOben = K_START_MASSE_ZENTRUM / 20;
        mEinstellMasse.mUnten = K_START_MASSE_EINZEL_ELEMENT;
        mEinstellMasse.mCount = K_START_MASSE_EINZEL_ELEMENT;
        mEinstellMasse.mTimeDivisior = 250;
        mEinstellMasse.mName = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_3);
        mMasseEinstellHochscript.SetEinstellwert(mEinstellMasse);
        mMasseEinstellRunterScript.SetEinstellwert(mEinstellMasse);

        mEinstellSpeedX = new Einstellwert();
        mEinstellSpeedX.mOben = 50;
        mEinstellSpeedX.mUnten = -50;
        mEinstellSpeedX.mCount = 20;
        mEinstellSpeedX.mTimeDivisior = 5;
        mEinstellSpeedX.mName = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_SPEED_X);
        mSpeedXEinstellHochscript.SetEinstellwert(mEinstellSpeedX);
        mSpeedXEinstellRunterScript.SetEinstellwert(mEinstellSpeedX);

        mEinstellSpeedY = new Einstellwert();
        mEinstellSpeedY.mOben = 50;
        mEinstellSpeedY.mUnten = -50;
        mEinstellSpeedY.mCount = 7;
        mEinstellSpeedY.mTimeDivisior = 5;
        mEinstellSpeedY.mName = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_SPEED_Y);
        mSpeedYEinstellHochscript.SetEinstellwert(mEinstellSpeedY);
        mSpeedYEinstellRunterScript.SetEinstellwert(mEinstellSpeedY);

        mEinstellSpeedZ = new Einstellwert();
        mEinstellSpeedZ.mOben = 50;
        mEinstellSpeedZ.mUnten = -50;
        mEinstellSpeedZ.mCount = 19;
        mEinstellSpeedZ.mTimeDivisior = 5;
        mEinstellSpeedZ.mName = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_SPEED_Z);
        mSpeedZEinstellHochscript.SetEinstellwert(mEinstellSpeedZ);
        mSpeedZEinstellRunterScript.SetEinstellwert(mEinstellSpeedZ);
    }



    public AttractVector ermittelKraft(Vector3 pPunkt1, float pMasse1, float pVelorcity1, Vector3 pPunkt2, float pMasse2)
    {
        AttractVector lErg = new AttractVector();

        Vector3 ldirectionGravitation = pPunkt1 - pPunkt2;
        lErg.mDistance = ldirectionGravitation.magnitude;
        float distanceGraviation = ldirectionGravitation.magnitude * K_DISTANCE_ERHOEHER;

        if (distanceGraviation == 0f)
        {
            lErg.mVectorGravi = Vector3.zero;
            lErg.mVectorKreis = Vector3.zero;
            return lErg;
        }

        float forceMagnitude = G * (pMasse1 * pMasse2) / Mathf.Pow(distanceGraviation, 2);

        float lWirksamWird = forceMagnitude;

        lErg.mVectorGravi = checkGrenzenVector(ldirectionGravitation.normalized * lWirksamWird);

        lErg.mVectorKreis = Vector3.zero;

        return lErg;
    }

    private string erzeugeKoordinate(float pFloat)
    {
        return String.Format("{0:0000}", pFloat);
    }

    private Vector3 checkGrenzenVector(Vector3 vector3)
    {
        if (vector3.x > K_MAX_POWER)
        {
            vector3.x = K_MAX_POWER;
        }
        if (vector3.y > K_MAX_POWER)
        {
            vector3.y = K_MAX_POWER;
        }
        if (vector3.z > K_MAX_POWER)
        {
            vector3.z = K_MAX_POWER;
        }
        if (vector3.x < K_MAX_POWER_MINUS)
        {
            vector3.x = K_MAX_POWER_MINUS;
        }
        if (vector3.y < K_MAX_POWER_MINUS)
        {
            vector3.y = K_MAX_POWER_MINUS;
        }
        if (vector3.z < K_MAX_POWER_MINUS)
        {
            vector3.z = K_MAX_POWER_MINUS;
        }

        return vector3;

    }


    internal DrehVektor lieferYFromDreh(float lZMove)
    {
        float lY = (float)(
            mEinstellDrehen.mCount
           + K_MAX_Camera_From_Dreh_Y_MINUS) * (float)Math.PI / 180.0f;

        float lDistance = K_DistanceCameraSonne - lZMove;

        mDrehVektorY.mX = (float)Math.Cos(lY) * lDistance;
        mDrehVektorY.mY = (float)Math.Sin(lY) * lDistance;

        return mDrehVektorY;
    }

    internal float lieferXFromMove()
    {
        float lX = mMoveSteuerung.getXMove();

        if (lX + mCameraFromMoveX > K_MAX_Camera_From_Move_X)
        {
            mCameraFromMoveX = K_MAX_Camera_From_Move_X;
        }
        else
        if (lX + mCameraFromMoveX < K_MAX_Camera_From_Move_X_MINUS)
        {
            mCameraFromMoveX = K_MAX_Camera_From_Move_X_MINUS;
        }
        else
        {
            mCameraFromMoveX = lX + mCameraFromMoveX;
        }

        return mCameraFromMoveX;
    }

    internal float lieferZFromMove()
    {
        float lZ = mMoveSteuerung.getYMove();

        if (lZ + mCameraFromMoveZ > K_MAX_Camera_From_Move_Z)
        {
            mCameraFromMoveZ = K_MAX_Camera_From_Move_Z;
        }
        else
        if (lZ + mCameraFromMoveZ < K_MAX_Camera_From_Move_Z_MINUS)
        {
            mCameraFromMoveZ = K_MAX_Camera_From_Move_Z_MINUS;
        }
        else
        {
            mCameraFromMoveZ = lZ + mCameraFromMoveZ;
        }

        return mCameraFromMoveZ;
    }

}
