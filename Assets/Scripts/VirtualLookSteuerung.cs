using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class VirtualLookSteuerung : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RawImage mBackgroundImage;

    private Vector2 mInputVector;

    public Himmelskoerper mHimmelskoerper;

    public Himmelskoerperverwalter mHimmelskoerperverwalter;

    // Buttoneffekt

    public int mClickModiAktiv;

    public int mClickGewaehlteMerkmalaktiv;

    private const float K_DISTANCE_KLICK = 0.5f;

    private const int K_BUTTON_INIT = 0;

    private const int K_BUTTON_DRUCK_LAEUFT = 2;

    // GameMode

    public int mGameMode;

    public const int K_GAME_MODE_INIT = 0;

    public const int K_GAME_MODE_QUARTETT = 10;

    public const int K_GAME_MODE_QUARTETT_LAEUFT = 11;

    public const int K_GAME_MODE_QUARTETT_WINNER_YOU = 12;

    public const int K_GAME_MODE_QUARTETT_WINNER_EINSTEIN = 13;

    public const int K_GAME_MODE_LERNEN = 20;

    public const int K_GAME_MODE_LERNEN_LAEUFT = 21;

    private const string K_SPIELVARIANTE_MODE_LERNEN = "LernModus";

    private const string K_MODE_INFO_CONFIG = "InfoConfig";

    private const string K_KARTEN_BUTTON = "KartenButton";

    private const string K_SPIELVARIANTE_MODE_QUARTETT = "QuartettModus";

    private const string K_ART_HIMMELSKOERPER_EINSTELLEN = "Gravitationskampf_ArtDesHimmelskoerpers";

    private const string K_ART_HIMMELSKOERPER_PRUEFUNG = "PruefungsModus";

    private const string K_ART_HIMMELSKOERPER_VOR = "HimmelskoerpersVor";

    private const string K_ART_HIMMELSKOERPER_NEXT = "HimmelskoerpersNaechste";
    
    public GameObject mKartenButtonAnzeigeTafel;

    public GameObject mAlleHimmelskoerpermerkmalButton;

    public TextMeshPro mLernenTextmeshPro;

    public TextMeshPro mQuartettTextmeshPro;

    public TextMeshPro mEinstellungenTextmeshPro;

    public TextMeshPro mPruefungTextmeshPro;

    public TextMeshPro mArtDesHimmelskoerperTextmeshPro;

    public TextMeshPro mArtDesHimmelskoerperTextmeshProVor;

    public TextMeshPro mArtDesHimmelskoerperTextmeshProNext;

    public const string K_GOLD= "<#ffd700>";

    public const string K_WHITE = "<#FFFFFF>";

    public const string K_RED = "<#FF0000>";

    public const string K_RED_GEGNER = "<#D36E70>";

    public const string K_GREEN = "<#00FF00>";

    public const string K_STAR_WARS_YELLOW = "<#FFE81F>";

    public const string K_GRAY = "<#BEBEBE>";

    public const string K_BLUE = "<#7FFFD4>";

    public const string K_GREEN_SCHRIFT = "<#069D06>";

    public TextMeshPro mErlaeuterungTextmeshPro;

    public TextMeshPro mWinLoseTextmeshPro;

    public GameObject mGameObject4PartikelSystem;

    public GameObject mGameObject4Animation;

    public Animator mAnimator;

    // 4 Infofeld
    public const int K_STATE_INFO_FELD_NEIN = 0;
    
    public int mStateInfoFeld;

    public InfoBilderVerwalter mInfoBilderVerwalter;

    public GameObject mGameObject4InfoFeld;

    public GameObject mGameObject4InfoFeldCube;

    public GameObject mGameObjectAstronaut;

    public GameObject mGameObjectAstronautCube4Antippen;

    public GameObject mGameObjectInfoConfig;

    public GameObject mGameObjectPruefung;



    public GameObject mGameObjectInfoArtDesHimmelskoerpers;

    public GameObject mGameObjectInfoArtDesHimmelskoerpersVor;

    public GameObject mGameObjectInfoArtDesHimmelskoerpersNext;

    public int mKlickBeiLernen;

    private Sprachenuebersetzer mSprachenuebersetzer;

    private HighScoreVerwaltung mHighScoreVerwaltung;

    private int mArtDesHimmelskoerper;

    public Material mMaterialAstronatEnglish;

    public Material mMaterialAstronatDeutsch;

    void Start()
    {
        init("", 0);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (mGameMode == K_GAME_MODE_QUARTETT_WINNER_YOU || mGameMode == K_GAME_MODE_QUARTETT_WINNER_EINSTEIN)
            {
                initGameMode("", 0);
            }
            else
            {
                Ray lRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit lRaycastHit;

                if (Physics.Raycast(lRay, out lRaycastHit))
                {
                    Debug.Log("lRaycastHit.transform.name:" + lRaycastHit.transform.name);
                    if (lRaycastHit.transform.name.Equals("Astronaut")
                        || lRaycastHit.transform.name.Equals("Cube4Antippen")
                        || lRaycastHit.transform.name.Equals("RawImageFuerInfo")
                        || lRaycastHit.transform.name.Equals("Cube4InfoBild"))
                    {

                        if (mHimmelskoerper.istHimmelskoerperGueltig())
                        {
                            if (mStateInfoFeld == K_STATE_INFO_FELD_NEIN)
                            {
                                initAstronautenInfoBox(true);
                                mStateInfoFeld = mHimmelskoerperverwalter.lieferAnzahlBildAktuellerHimmelskoerper();
                            }
                            else
                            {
                                mStateInfoFeld--;
                            }

                            if (mStateInfoFeld == K_STATE_INFO_FELD_NEIN)
                            {
                                initAstronautenInfoBox(false);
                            }
                            else
                            {
                                mInfoBilderVerwalter.aktiviereBild(mHimmelskoerperverwalter.lieferBildAktuellerHimmelskoerper(mStateInfoFeld));
                            }
                        }
                    }
                    else if (lRaycastHit.transform.tag == "AngabenZumSpielmodus" && mClickModiAktiv == K_BUTTON_INIT)
                    {

                        if (lRaycastHit.transform.name.Equals(K_KARTEN_BUTTON))
                        {
                            // nix
                        }
                        else if (lRaycastHit.transform.name.Equals(K_MODE_INFO_CONFIG))
                        {
                            StartCoroutine(clickEffektModi(lRaycastHit.transform.gameObject));

                            SceneManager.LoadScene("InfoConfig");
                        }
                        else
                        {
                            if (lRaycastHit.transform.name.Equals(K_SPIELVARIANTE_MODE_LERNEN))
                            {

                                if (mGameMode == K_GAME_MODE_LERNEN || mGameMode == K_GAME_MODE_LERNEN_LAEUFT)
                                {
                                    initGameMode("", 0);
                                }
                                else
                                {
                                    initGameMode(K_SPIELVARIANTE_MODE_LERNEN, 0);
                                }
                            }
                            else if (lRaycastHit.transform.name.Equals(K_SPIELVARIANTE_MODE_QUARTETT))
                            {

                                if (mGameMode == K_GAME_MODE_QUARTETT || mGameMode == K_GAME_MODE_QUARTETT_LAEUFT)
                                {
                                    initGameMode("", 0);
                                }
                                else
                                {
                                    initGameMode(K_SPIELVARIANTE_MODE_QUARTETT, 0);

                                    mHimmelskoerperverwalter.mischeZweiStapel();
                                }
                            }
                            else if (lRaycastHit.transform.name.Equals(K_ART_HIMMELSKOERPER_EINSTELLEN))
                            {

                                if (mGameMode == K_GAME_MODE_LERNEN || mGameMode == K_GAME_MODE_LERNEN_LAEUFT)
                                {

                                    ermittelNaechteArt();
                                }
                                if (mGameMode == K_GAME_MODE_INIT)
                                {
                                    SceneManager.LoadScene("GravitationArena");
                                }
                            }
                            else if (lRaycastHit.transform.name.Equals(K_ART_HIMMELSKOERPER_PRUEFUNG))
                            {
                                if (mGameMode == K_GAME_MODE_INIT)
                                {
                                    SceneManager.LoadScene("Pruefung");
                                }
                            }
                            else if (lRaycastHit.transform.name.Equals(K_ART_HIMMELSKOERPER_VOR))
                            {

                                if (mGameMode == K_GAME_MODE_LERNEN || mGameMode == K_GAME_MODE_LERNEN_LAEUFT)
                                {
                                    pressVorherige();
                                }
                            }
                            else if (lRaycastHit.transform.name.Equals(K_ART_HIMMELSKOERPER_NEXT))
                            {

                                if (mGameMode == K_GAME_MODE_LERNEN || mGameMode == K_GAME_MODE_LERNEN_LAEUFT)
                                {
                                    pressNext();
                                }
                            }

                            StartCoroutine(clickEffektModi(lRaycastHit.transform.gameObject));
                        }


                    }
                    else if ((mGameMode == K_GAME_MODE_QUARTETT || mGameMode == K_GAME_MODE_QUARTETT_LAEUFT) &&
                             lRaycastHit.transform.tag == "Himmelskoerperverwalter" && mClickGewaehlteMerkmalaktiv == K_BUTTON_INIT)
                    {

                        mGameMode = mHimmelskoerperverwalter.verarbeiteClickAuf(lRaycastHit.transform.gameObject.name);

                        setzeErlauerungstext(mGameMode);

                        if (mGameMode == K_GAME_MODE_QUARTETT_LAEUFT)
                        {
                            StartCoroutine(clickEffektHimmelskoerperangabe(lRaycastHit.transform.gameObject));
                        }
                    }
                }
            }
        }
    }

    public IEnumerator clickEffektModi(GameObject pGameObject)
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

    public IEnumerator clickEffektHimmelskoerperangabe(GameObject pGameObject)
    {
        if (mClickGewaehlteMerkmalaktiv == K_BUTTON_INIT)
        {

            mClickGewaehlteMerkmalaktiv = K_BUTTON_DRUCK_LAEUFT;

            float lNewZ = pGameObject.transform.position.z + K_DISTANCE_KLICK;
            pGameObject.transform.position = new Vector3(pGameObject.transform.position.x, pGameObject.transform.position.y, lNewZ);
            yield return new WaitForSeconds(0.5F);

            lNewZ = pGameObject.transform.position.z - K_DISTANCE_KLICK;
            pGameObject.transform.position = new Vector3(pGameObject.transform.position.x, pGameObject.transform.position.y, lNewZ);

            mClickGewaehlteMerkmalaktiv = K_BUTTON_INIT;
        }
        yield return null;
    }





    public virtual void OnDrag(PointerEventData pPointerEventData)
    {
        if (mGameMode == K_GAME_MODE_LERNEN || mGameMode == K_GAME_MODE_LERNEN_LAEUFT)
        {

            mGameMode = K_GAME_MODE_LERNEN_LAEUFT;

            Vector2 lVectorPosInBackgroundImage;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    mBackgroundImage.rectTransform
            , pPointerEventData.position
            , pPointerEventData.pressEventCamera
            , out lVectorPosInBackgroundImage))
            {

                lVectorPosInBackgroundImage.x = (lVectorPosInBackgroundImage.x /
                mBackgroundImage.rectTransform.sizeDelta.x);

                lVectorPosInBackgroundImage.y = (lVectorPosInBackgroundImage.y /
                mBackgroundImage.rectTransform.sizeDelta.y);

                if (lVectorPosInBackgroundImage.magnitude > 0.02)
                {
                    lVectorPosInBackgroundImage = lVectorPosInBackgroundImage.normalized;
                }

                if (Math.Abs(lVectorPosInBackgroundImage.x) > (Math.Abs(lVectorPosInBackgroundImage.y) * 4))
                {
                    lVectorPosInBackgroundImage.y = 0;
                }

                if (Math.Abs(lVectorPosInBackgroundImage.y) > (Math.Abs(lVectorPosInBackgroundImage.x) * 4))
                {
                    lVectorPosInBackgroundImage.x = 0;
                }

                mInputVector = new Vector2(lVectorPosInBackgroundImage.x
                , lVectorPosInBackgroundImage.y
                );

                Debug.Log("Magnitude" + lVectorPosInBackgroundImage.magnitude + " LOOK x:" + mInputVector.x + " y:" + mInputVector.y);
            }
        }
    }

    public virtual void OnPointerDown(PointerEventData pPointerEventData)
    {
        OnDrag(pPointerEventData);
    }

    public virtual void OnPointerUp(PointerEventData pPointerEventData)
    {
        if (mStateInfoFeld == K_STATE_INFO_FELD_NEIN)
        {

            if (mGameMode == K_GAME_MODE_LERNEN || mGameMode == K_GAME_MODE_LERNEN_LAEUFT)
            {
                mGameMode = K_GAME_MODE_LERNEN_LAEUFT;
                mKlickBeiLernen++;

                if (mInputVector.x > 0)
                {
                    mHimmelskoerper.setNeuenPlanet(1, mArtDesHimmelskoerper);
                }
                else if (mInputVector.x < 0)
                {
                    mHimmelskoerper.setNeuenPlanet(-1, mArtDesHimmelskoerper);
                }
                init(K_SPIELVARIANTE_MODE_LERNEN, mGameMode);
            }
        }
    }

    public void pressVorherige()
    {
        mGameMode = K_GAME_MODE_LERNEN_LAEUFT;
        mKlickBeiLernen++;

        mHimmelskoerper.setNeuenPlanet(-1, mArtDesHimmelskoerper);

        init(K_SPIELVARIANTE_MODE_LERNEN, mGameMode);
    }

    public void pressNext()
    {
        mGameMode = K_GAME_MODE_LERNEN_LAEUFT;
        mKlickBeiLernen++;

        mHimmelskoerper.setNeuenPlanet(1, mArtDesHimmelskoerper);

        init(K_SPIELVARIANTE_MODE_LERNEN, mGameMode);
    }

    void setzeArtKategorieText()
    {
        if (mGameMode == K_GAME_MODE_INIT)
        {
            mArtDesHimmelskoerperTextmeshPro.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GRAVITATIONS_MODUS);
        }
        else
        {
            mArtDesHimmelskoerperTextmeshPro.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ART_DES_HIMMELSKOERPERS)
        + mSprachenuebersetzer.lieferWort(mArtDesHimmelskoerper);
            mArtDesHimmelskoerperTextmeshProVor.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ART_DES_VOR);
            mArtDesHimmelskoerperTextmeshProNext.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ART_DES_NEXT);

        }

    }

    public void ermittelNaechteArt()
    {
        mGameMode = K_GAME_MODE_LERNEN_LAEUFT;

        if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_ALL)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_PLANET;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_PLANET)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_STERN;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_STERN)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_MOON;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_MOON)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_BRAUNER_ZWERG;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_BRAUNER_ZWERG)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_ASTEROID;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_ASTEROID)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_ZWERGPLANET;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_ZWERGPLANET)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_SCHWARZES_LOCH;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_SCHWARZES_LOCH)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_NEBEL;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_NEBEL)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_KOMET;
        }
        else if (mArtDesHimmelskoerper == Sprachenuebersetzer.K_KOMET)
        {
            mArtDesHimmelskoerper = Sprachenuebersetzer.K_ALL;
        }

        setzeArtKategorieText();

        setzeErlauerungstext(mGameMode);

        mHimmelskoerper.setNeuenPlanet(1, mArtDesHimmelskoerper);

        mGameObjectAstronaut.SetActive(true);
    }

    public void init(string pSpielvariante, int pGameMode)
    {
        mSprachenuebersetzer = GameObject.FindGameObjectWithTag("Sprachenuebersetzer").GetComponent<Sprachenuebersetzer>();

        mHighScoreVerwaltung = GameObject.FindGameObjectWithTag("HighScoreVerwaltung").GetComponent<HighScoreVerwaltung>();

        mAnimator = mGameObject4Animation.GetComponent<Animator>();

        mInputVector = Vector3.zero;
        mClickModiAktiv = K_BUTTON_INIT;

        if (mSprachenuebersetzer.getSprache() == Sprachenuebersetzer.K_DEUTSCH)
        {
            mGameObjectAstronautCube4Antippen.GetComponent<MeshRenderer>().material = mMaterialAstronatDeutsch;
        } else
        {
            mGameObjectAstronautCube4Antippen.GetComponent<MeshRenderer>().material = mMaterialAstronatEnglish;
        }
           

        initGameMode(pSpielvariante, pGameMode);

    }

    public void initAstronautenInfoBox(bool pBild)
    {
        mGameObject4InfoFeld.SetActive(pBild);
        mGameObject4InfoFeldCube.SetActive(pBild);
        mStateInfoFeld = K_STATE_INFO_FELD_NEIN;
    }

    public void initGameMode(string pSpielvariante, int pGameMode)
    {
        string lLernen = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_LERNEN);
        string lQuartettModus = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_QUARTETT_SPIEL);
        string lZurueck = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ZURUECK);
       
        mEinstellungenTextmeshPro.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EINSTELLUNGEN);
        mPruefungTextmeshPro.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_PRUEFUNG);

        if (pSpielvariante.Equals(K_SPIELVARIANTE_MODE_QUARTETT))
        {
            if (pGameMode == 0)
            {
                mGameMode = K_GAME_MODE_QUARTETT;
                mGameObjectAstronaut.SetActive(true);
            }

            mKartenButtonAnzeigeTafel.SetActive(true);
            mAlleHimmelskoerpermerkmalButton.SetActive(true);
            mGameObjectInfoConfig.SetActive(false);
            mGameObjectPruefung.SetActive(false);
            mGameObjectInfoArtDesHimmelskoerpers.SetActive(false);
            mGameObjectInfoArtDesHimmelskoerpersVor.SetActive(false);
            mGameObjectInfoArtDesHimmelskoerpersNext.SetActive(false);

            mLernenTextmeshPro.text = K_WHITE + lLernen;
            mQuartettTextmeshPro.text = K_WHITE + lZurueck;// lQuartettModus;

            initAstronautenInfoBox(false);
        }
        else if (pSpielvariante.Equals(K_SPIELVARIANTE_MODE_LERNEN))
        {
            if (pGameMode == 0)
            {
                mGameMode = K_GAME_MODE_LERNEN;
                mKlickBeiLernen = 0;
                mHimmelskoerper.setNeuenPlanetDirekt(0);
                mArtDesHimmelskoerper = Sprachenuebersetzer.K_ALL;
            }
            else
            {
                mGameObjectAstronaut.SetActive(true);
            }
            mKartenButtonAnzeigeTafel.SetActive(false);
            mAlleHimmelskoerpermerkmalButton.SetActive(true);
            mGameObjectInfoConfig.SetActive(false);
            mGameObjectPruefung.SetActive(false);
            mGameObjectInfoArtDesHimmelskoerpers.SetActive(true);
            mGameObjectInfoArtDesHimmelskoerpersVor.SetActive(true);
            mGameObjectInfoArtDesHimmelskoerpersNext.SetActive(true);
            setzeArtKategorieText();

            mLernenTextmeshPro.text = K_WHITE + lZurueck;// lLernen;
            mQuartettTextmeshPro.text = K_WHITE + lQuartettModus;
        }
        else
        {
            mGameMode = K_GAME_MODE_INIT;
            mKlickBeiLernen = 0;
            mKartenButtonAnzeigeTafel.SetActive(false);
            mAlleHimmelskoerpermerkmalButton.SetActive(false);
            mGameObjectInfoConfig.SetActive(true);
            mGameObjectPruefung.SetActive(true);
            mGameObjectAstronaut.SetActive(false);
            mGameObjectInfoArtDesHimmelskoerpers.SetActive(true);
            mGameObjectInfoArtDesHimmelskoerpersVor.SetActive(false);
            mGameObjectInfoArtDesHimmelskoerpersNext.SetActive(false);

            mHimmelskoerper.setLeerMaterial();
            setzeArtKategorieText();

            mLernenTextmeshPro.text = K_WHITE + lLernen;
            mQuartettTextmeshPro.text = K_WHITE + lQuartettModus;

            initAstronautenInfoBox(false);
        }

        setzeErlauerungstext(mGameMode);
    }

    public int getGameMode()
    {
        return mGameMode;
    }

    public bool istStartLernen()
    {
        return mKlickBeiLernen == 1;
    }

    public void setzeErlauerungstext(int pGameMode)
    {
        if (pGameMode == K_GAME_MODE_INIT)
        {
            mErlaeuterungTextmeshPro.text = K_STAR_WARS_YELLOW + "";
            mWinLoseTextmeshPro.text = "";
            mGameObject4PartikelSystem.SetActive(false);
            mAnimator.Play("Idle");
        }
        else if (pGameMode == K_GAME_MODE_LERNEN)
        {
            mErlaeuterungTextmeshPro.text = K_STAR_WARS_YELLOW +
            mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISCHEN_1) + "\n \n" + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WISCHEN_2);
            mWinLoseTextmeshPro.text = "";
            mGameObject4PartikelSystem.SetActive(false);
            mAnimator.Play("CubeGewinn");
        }
        else if (pGameMode == K_GAME_MODE_LERNEN_LAEUFT)
        {
            mErlaeuterungTextmeshPro.text = "";
            mWinLoseTextmeshPro.text = "";
            mGameObject4PartikelSystem.SetActive(false);
            mAnimator.Play("Idle");
        }
        else if (pGameMode == K_GAME_MODE_QUARTETT)
        {
            mErlaeuterungTextmeshPro.text = ""; // K_STAR_WARS_YELLOW + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BESSERE_WERTE);
            mWinLoseTextmeshPro.text = "";
            mGameObject4PartikelSystem.SetActive(false);
            mAnimator.Play("Idle");
        }
        else if (pGameMode == K_GAME_MODE_QUARTETT_LAEUFT)
        {
            mErlaeuterungTextmeshPro.text = "";
            mWinLoseTextmeshPro.text = "";
            mGameObject4PartikelSystem.SetActive(false);
            mAnimator.Play("Idle");
        }
        else if (pGameMode == K_GAME_MODE_QUARTETT_WINNER_YOU)
        {
            mErlaeuterungTextmeshPro.text = K_STAR_WARS_YELLOW + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NEW_TITEL) + mHighScoreVerwaltung.lieferErreichteTitel();
            mWinLoseTextmeshPro.text = K_STAR_WARS_YELLOW + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_WINNER_IS_2);
            mGameObject4PartikelSystem.SetActive(true);
            mAnimator.Play("CubeGewinn");
        }
        else if (pGameMode == K_GAME_MODE_QUARTETT_WINNER_EINSTEIN)
        {
            mErlaeuterungTextmeshPro.text = K_GRAY + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BLEIBT_TITEL) + mHighScoreVerwaltung.lieferErreichteTitel();
            mWinLoseTextmeshPro.text = K_GRAY + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_LOOSER);
            mGameObject4PartikelSystem.SetActive(false);
            mAnimator.Play("Idle");
        }
    }
}
