using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Himmelskoerper : MonoBehaviour
{

    public int mAktivePlanetNew;

    private int mAktivePlanet;

    public GameObject mMoveball;

    public TextMeshPro mTextMeshProName;

    // TestMeshProFuerAnzeige

    public TextMeshPro mTextMeshProMasse;
    public TextMeshPro mTextMeshProEntfernungSonne;
    public TextMeshPro mTextMeshProAnzahlMonde;
    public TextMeshPro mTextMeshProDichte;
    public TextMeshPro mTextMeshProDurchmesser;
    public TextMeshPro mTextMeshProMaxTemperatur;
    public TextMeshPro mTextMeshProMinTemperatur;

    public Himmelskoerperverwalter mHimmelskoerperverwalter;

    public const int K_MERKUR = 10;

    public Texture2D mTexture2DMerkur;

    public const int K_VENUS = 20;

    public Texture2D mTexture2DVenus;

    public const int K_ERDE = 30;

    public Texture2D mTexture2DErde;

    public const int K_MARS = 40;

    public Texture2D mTexture2DMars;

    public const int K_JUPITER = 50;

    public Texture2D mTexture2DJupiter;

    public const int K_SATURN = 60;

    public Texture2D mTexture2DSaturn;

    public const int K_URANUS = 70;

    public Texture2D mTexture2DUranus;

    public const int K_NEPTUN = 80;

    public Texture2D mTexture2DNeptun;

    public const int K_SONNE = 90;

    public Texture2D mTexture2DSonne;

    public const int K_BETEIGEUZE = 100;

    public Texture2D mTexture2DBeteigeuze;

    public const int K_HARALDLESCH = 110;

    public Texture2D mTexture2DHaraldlesch;

    public const int K_IO = 120;

    public Texture2D mTexture2DIO;

    public const int K_GANYMED = 130;

    public Texture2D mTexture2DGanymed;

    public const int K_EUROPA = 140;

    public Texture2D mTexture2DEuropa;

    public const int K_KALLISTO = 150;

    public Texture2D mTexture2DKallisto;

    public const int K_ERDMOND = 160;

    public Texture2D mTexture2DErdmond;

    public const int K_CERES = 170;

    public Texture2D mTexture2DCeres;

    public const int K_TITAN = 180;

    public Texture2D mTexture2DTitan;

    public const int K_VESTA = 190;

    public Texture2D mTexture2DVesta;

    public const int K_PALLAS = 200;

    public Texture2D mTexture2DPallas;

    public const int K_PLUTO = 210;

    public Texture2D mTexture2DPluto;

    public const int K_CHARON = 220;

    public Texture2D mTexture2DCharon;

    public const int K_ERIS = 230;

    public Texture2D mTexture2DEris;

    public const int K_ARIADNE = 240;

    public Texture2D mTexture2DARIADNE;

    public const int K_SIRIUS_A = 250;

    public Texture2D mTexture2DSiriusA;

    public const int K_SIRIUS_B = 260;

    public Texture2D mTexture2DSiriusB;

    public const int K_ALPHA_ZENTAURI_A = 270;

    public Texture2D mTexture2DALPHA_ZENTAURI_A;

    public const int K_ALPHA_ZENTAURI_B = 280;

    public Texture2D mTexture2DALPHA_ZENTAURI_B;

    public const int K_PROXIMA_ZENTAURI = 290;

    public Texture2D mTexture2DROXIMA_ZENTAURI;

    public const int K_PROXIMA_ZENTAURI_B = 300;

    public Texture2D mTexture2DPROXIMA_ZENTAURI_B;

    public const int K_SAGITTARIUS_A = 310;

    public Texture2D mTexture2DSagittarius_A;

    public const int K_M87 = 320;

    public Texture2D mTexture2DM87;

    public const int K_TRITON = 330;

    public Texture2D mTexture2DTriton;

    public const int K_KOMET_HALLEY = 340;

    public Texture2D mTexture2DHalley;

     public const int K_J1407 = 350;

    public Texture2D mTexture2DJ1407;

    public const int K_R_CORONA_BOREALIS = 360;

    public Texture2D mTextureR_CORONA_BOREALIS;

    public const int K_STEVENSON = 370;

    public Texture2D mTextureStevenson;

    public const int K_KEPPLER_160D = 380;

    public Texture2D mTextureKeppler160D;

    public const int K_MOND_ENCELADUS = 390;

    public Texture2D mTextureEnceladus;

    public const int K_MOND_JAPETUS = 400;

    public Texture2D mTextureJapetus;

    public const int K_KOMET_NEOWISE = 410;

    public Texture2D mTexture2DNEOWISE;

    public const int K_KOMET_TEBBUTT = 420;

    public Texture2D mTexture2DTEBBUTT;

    public const int K_KOMET_TSCHURI = 430;

    public Texture2D mTexture2DTSCHURI;

    public const int K_MOND_NIX = 440;

    public Texture2D mTexture2D_MOND_NIX;

    public const int K_MOND_HYDRA= 450;

    public Texture2D mTexture2D_MOND_HYDRA;

    public const int K_MOND_KERBEROS = 460;

    public Texture2D mTexture2D_MOND_KERBEROS;

    public const int K_MOND_STYX = 470;

    public Texture2D mTexture2D_MOND_STYX;


    public const int K_BRAUNER_ZWERG_SCHOLZ = 480;

    public Texture2D mTexture2D_BRAUNER_ZWERG_SCHOLZ;

    public const int K_BRAUNER_ZWERG_SDSS_1416_13B = 490;

    public Texture2D mTexture2D_BRAUNER_ZWERG_SDSS_1416_13B;

    public const int K_NEBEL_PFERDEKOPF = 500;

    public Texture2D mTexture2D_NebelPferdekopf;

    public const int K_NEBEL_KREBS = 510;

    public Texture2D mTexture2D_NebelKrebs;

    public const int K_NEBEL_ORION = 520;

    public Texture2D mTexture2D_NebelOrion;

    public const int K_WASP_189_B = 530;

    public Texture2D mTexture2D_Wasp189B;

    public const int K_NEBEL_HEXENBESEN = 540;

    public Texture2D mTexture2D_NebelHexenbesen;

    public const int K_MAKEMAKE = 550;

    public Texture2D mTexture2DMakemake;

      public const int K_HAUMEA = 560;

    public Texture2D mTexture2DHaumea;

    public const int K_CANIS_MAJOPRIS= 570;

    public Texture2D mTexture2DCanisMajoris;

    public const int K_R136a1= 580;

    public Texture2D mTexture2DR136a1;

      public const int K_SEDNA = 590;

    public Texture2D mTexture2DSedna;

      public const int K_KEPLER_16B = 600;

    public Texture2D mTexture2DKepler16b;

    //letzter
    public const int K_MIRANDA = 610;

    public Texture2D mTexture2DMiranda;

    // allg
    public GameObject mWerGegenWenButtonbuttonEmpty;

    private Vector3 mVectorMoveBallStart;

    private Vector3 mVectorMoveBallStartFinish;


    private Vector3 mVectorThisBallStart;

    private Vector3 mVectorThisBallStartFinish;

    public Texture2D mTextureHubbel;

    public const int K_LEER_PLANET = 10000;

    public int K_MAX;

    public int K_ERST;

    public Light mLicht;

    public GameObject mGameObjectLicht;


    public GameObject mRingObject;

    private float mDurchmesserbild;

    private Sprachenuebersetzer mSprachenuebersetzer;


    public GameObject mGameObjectSchwarzeLochErhitztGas;

    public GameObject mKometenschweif;

    public GameObject mBorealis;

    public GameObject mEnceladusSuedpol;

    public GameObject mCubeAmHimmelskoerper;

    public Material mMaterial_NebelKrebs;

    void Start()
    {
        K_MAX = K_MIRANDA; // letzte hinzugekommene Himmelskoerper
        K_ERST = K_MERKUR;

        mGameObjectSchwarzeLochErhitztGas.SetActive(false);

        mSprachenuebersetzer = GameObject.FindGameObjectWithTag("Sprachenuebersetzer").GetComponent<Sprachenuebersetzer>();

        mAktivePlanetNew = 0;
        mAktivePlanet = 0;

        mVectorMoveBallStart = mMoveball.transform.position; // lVectorMoveBallStart	{(-37.8, 0.0, 2.0)}	UnityEngine.Vector3
                                                             //mVectorMoveBallStartFinish = new Vector3(-37.4f,-1.46f,-4.4f);
        mVectorMoveBallStartFinish = new Vector3(-37f, -2.6f, -7.34f);

        Vector3 lVectorMoveBallStartStartFinish = new Vector3(
                                                      mVectorMoveBallStartFinish.x - mVectorMoveBallStart.x,
                                                      mVectorMoveBallStartFinish.y - mVectorMoveBallStart.y,
                                                      mVectorMoveBallStartFinish.z - mVectorMoveBallStart.z);

        mVectorThisBallStart = this.transform.position;

        mVectorThisBallStartFinish = new Vector3(mVectorThisBallStart.x + lVectorMoveBallStartStartFinish.x,
            mVectorThisBallStart.y + lVectorMoveBallStartStartFinish.y,
            mVectorThisBallStart.z + lVectorMoveBallStartStartFinish.z);

        mDurchmesserbild = 10000;

        setLeerMaterial();

        mHimmelskoerperverwalter.Init();

        mRingObject.SetActive(false);
        mKometenschweif.SetActive(false);
        mBorealis.SetActive(false);
        mEnceladusSuedpol.SetActive(false);
        RenderSettings.fog = false;
    }

    void initPositionen(int pPlanet)
    {
        if (pPlanet == Himmelskoerper.K_LEER_PLANET)
        {
            mMoveball.transform.position = mVectorMoveBallStartFinish;
            this.transform.position = mVectorThisBallStartFinish;
        }
        else
        {
            this.transform.position = mVectorThisBallStart;
            mMoveball.transform.position = mVectorMoveBallStart;
        }

    }

    public bool istSchwarzeLochAktivePlanet()
    {
        if (mHimmelskoerperverwalter.istGueltigeIndex(mAktivePlanet))
        {
            return mHimmelskoerperverwalter.istSchwarzesLoch(mAktivePlanet);
        }
        return false;
    }

    public bool istHimmelskoerperGueltig()
    {
        return mHimmelskoerperverwalter.istGueltigeIndex(mAktivePlanetNew);
    }

    void Update()
    {
        if (!istHimmelskoerperGueltig())
        {
            setLeerMaterial();

        }
        else
        {
            if (mAktivePlanet > 0)
            {
                this.transform.localScale = new Vector3(mDurchmesserbild, mDurchmesserbild, mDurchmesserbild);

                Vector3 lVectorMoveball = new Vector3(mMoveball.transform.position.x + 37.2f
            , mMoveball.transform.position.y + .5f
                , mMoveball.transform.position.z + 2f + mDurchmesserbild);

                this.transform.position = lVectorMoveball;
            }

            if (mAktivePlanetNew != mAktivePlanet)
            {
                mAktivePlanet = mAktivePlanetNew;
                initPositionen(mAktivePlanet);


                mRingObject.SetActive(mHimmelskoerperverwalter.lieferRingObjekt(mAktivePlanet));
                mGameObjectLicht.SetActive(mHimmelskoerperverwalter.lieferLichtAn(mAktivePlanet));
                mLicht.intensity = mHimmelskoerperverwalter.lieferHelligkeit(mAktivePlanet);
                RenderSettings.fog = false;
                mCubeAmHimmelskoerper.SetActive(false);

                MeshRenderer lMeshRenderer = GetComponent<MeshRenderer>();
                lMeshRenderer.enabled = true;

                mKometenschweif.SetActive(mHimmelskoerperverwalter.lieferKometenschweif(mAktivePlanet));
                mBorealis.SetActive(mHimmelskoerperverwalter.lieferBorealis(mAktivePlanet));
                mEnceladusSuedpol.SetActive(mHimmelskoerperverwalter.lieferEnceladusSuedpol(mAktivePlanet));

                if (mAktivePlanet == K_MERKUR)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DMerkur;
                }
                else if (mAktivePlanet == K_VENUS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DVenus;
                }
                else if (mAktivePlanet == K_ERDE)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DErde;
                }
                else if (mAktivePlanet == K_MARS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DMars;
                }
                else if (mAktivePlanet == K_JUPITER)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DJupiter;
                    mRingObject.transform.localScale = new Vector3(1.5f, 0.0002f, 1.4f);
                    setzeRotateRinge(3f, -173, -7.6f);
                }
                else if (mAktivePlanet == K_SATURN)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DSaturn;
                    mRingObject.transform.localScale = new Vector3(1.5f, 0.03f, 2f);
                    setzeRotateRinge(20f, -6f, 0f);
                }
                else if (mAktivePlanet == K_URANUS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DUranus;
                    mRingObject.transform.localScale = new Vector3(1.4f, 0.001f, 1.8f);
                    setzeRotateRinge(20f, -6, 0f);
                }
                else if (mAktivePlanet == K_NEPTUN)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DNeptun;
                }
                else if (mAktivePlanet == K_SONNE)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DSonne;
                }
                else if (mAktivePlanet == K_BETEIGEUZE)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DBeteigeuze;
                }
                else if (mAktivePlanet == K_HARALDLESCH)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DHaraldlesch;
                }
                else if (mAktivePlanet == K_IO)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DIO;
                }
                else if (mAktivePlanet == K_ERDMOND)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DErdmond;
                }
                else if (mAktivePlanet == K_GANYMED)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DGanymed;
                }
                else if (mAktivePlanet == K_EUROPA)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DEuropa;
                }
                else if (mAktivePlanet == K_KALLISTO)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DKallisto;
                }
                else if (mAktivePlanet == K_CERES)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DCeres;
                }
                else if (mAktivePlanet == K_SEDNA)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DSedna;
                }
                else if (mAktivePlanet == K_KEPLER_16B)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DKepler16b;
                }
                else if (mAktivePlanet == K_MIRANDA)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DMiranda;
                }
                else if (mAktivePlanet == K_TITAN)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DTitan;
                }
                else if (mAktivePlanet == K_PLUTO)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DPluto;
                }
                else if (mAktivePlanet == K_MAKEMAKE)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DMakemake;
                }
                else if (mAktivePlanet == K_HAUMEA)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DHaumea;
                }
                else if (mAktivePlanet == K_CHARON)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DCharon;
                }
                else if (mAktivePlanet == K_ARIADNE)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DARIADNE;
                }
                else if (mAktivePlanet == K_PALLAS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DPallas;
                }
                else if (mAktivePlanet == K_VESTA)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DVesta;
                }
                else if (mAktivePlanet == K_ERIS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DEris;
                }
                else if (mAktivePlanet == K_SIRIUS_A)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DSiriusA;
                }
                else if (mAktivePlanet == K_SIRIUS_B)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DSiriusB;
                }
                else if (mAktivePlanet == K_ALPHA_ZENTAURI_A)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DALPHA_ZENTAURI_A;
                }
                else if (mAktivePlanet == K_ALPHA_ZENTAURI_B)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DALPHA_ZENTAURI_B;
                }
                else if (mAktivePlanet == K_PROXIMA_ZENTAURI)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DROXIMA_ZENTAURI;
                }
                else if (mAktivePlanet == K_PROXIMA_ZENTAURI_B)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DPROXIMA_ZENTAURI_B;
                }
                else if (mAktivePlanet == K_M87)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DM87;
                }
                else if (mAktivePlanet == K_SAGITTARIUS_A)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DSagittarius_A;
                }
                else if (mAktivePlanet == K_TRITON)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DTriton;
                }
                else if (mAktivePlanet == K_KOMET_HALLEY)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DHalley;
                }
                else if (mAktivePlanet == K_KOMET_NEOWISE)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DNEOWISE;
                }
                else if (mAktivePlanet == K_KOMET_TEBBUTT)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DTEBBUTT;
                }
                else if (mAktivePlanet == K_KOMET_TSCHURI)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DTSCHURI;
                }
                else if (mAktivePlanet == K_J1407)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DJ1407;
                }
                else if (mAktivePlanet == K_R_CORONA_BOREALIS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTextureR_CORONA_BOREALIS;
                }
                else if (mAktivePlanet == K_STEVENSON)
                {
                    GetComponent<Renderer>().material.mainTexture = mTextureStevenson;
                }
                else if (mAktivePlanet == K_KEPPLER_160D)
                {
                    GetComponent<Renderer>().material.mainTexture = mTextureKeppler160D;
                }
                else if (mAktivePlanet == K_MOND_ENCELADUS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTextureEnceladus;
                }
                else if (mAktivePlanet == K_MOND_JAPETUS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTextureJapetus;
                }
                else if (mAktivePlanet == K_MOND_STYX)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_MOND_STYX;
                }
                else if (mAktivePlanet == K_MOND_KERBEROS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_MOND_KERBEROS;
                }
                else if (mAktivePlanet == K_MOND_HYDRA)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_MOND_HYDRA;
                }
                else if (mAktivePlanet == K_MOND_NIX)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_MOND_NIX;
                }
                else if (mAktivePlanet == K_BRAUNER_ZWERG_SCHOLZ)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_BRAUNER_ZWERG_SCHOLZ;
                }
                else if (mAktivePlanet == K_BRAUNER_ZWERG_SDSS_1416_13B)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_BRAUNER_ZWERG_SDSS_1416_13B;
                }
                else if (mAktivePlanet == K_CANIS_MAJOPRIS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DCanisMajoris;
                }
                else if (mAktivePlanet == K_R136a1)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2DR136a1;
                }
                else if (mAktivePlanet == K_NEBEL_PFERDEKOPF)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_NebelPferdekopf;
                    RenderSettings.fog = true;
                    //RenderSettings.fogColor = new Color(78, 36, 32, 100);
                    RenderSettings.fogDensity = 0.2f;
                }
                else if (mAktivePlanet == K_NEBEL_HEXENBESEN)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_NebelHexenbesen;
                    RenderSettings.fog = true;
                    //RenderSettings.fogColor = new Color(78, 36, 32, 100);
                    RenderSettings.fogDensity = 0.15f;
                }
                else if (mAktivePlanet == K_NEBEL_KREBS)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_NebelKrebs;
                    // RenderSettings.fog = true;
                    // RenderSettings.fogColor = new Color(183,173,201, 100);
                    // RenderSettings.fogDensity = 0.06f;
                    lMeshRenderer.enabled = false;
                    mCubeAmHimmelskoerper.SetActive(true);
                    mCubeAmHimmelskoerper.GetComponent<Renderer>().material.mainTexture = mTexture2D_NebelKrebs;

                }
                else if (mAktivePlanet == K_NEBEL_ORION)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_NebelOrion;
                    RenderSettings.fog = true;
                    //RenderSettings.fogColor = new Color(189, 15, 123,255);
                    RenderSettings.fogDensity = 0.05f;
                }
                else if (mAktivePlanet == K_WASP_189_B)
                {
                    GetComponent<Renderer>().material.mainTexture = mTexture2D_Wasp189B;
                }
                else if (mAktivePlanet == K_LEER_PLANET)
                {
                    GetComponent<Renderer>().material.mainTexture = mTextureHubbel;
                    lMeshRenderer.enabled = false;
                }

                if (mHimmelskoerperverwalter.lieferErdmassen(mAktivePlanet) < 0.001)
                {
                    mTextMeshProMasse.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_1) + string.Format("{0:0.00000000000}", mHimmelskoerperverwalter.lieferErdmassen(mAktivePlanet)) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_2);
                }
                else if (mHimmelskoerperverwalter.lieferErdmassen(mAktivePlanet) > 10000000)
                {
                    mTextMeshProMasse.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_1) + string.Format("{0:###,###,000,000,000}", mHimmelskoerperverwalter.lieferErdmassen(mAktivePlanet)) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_2);
                }
                else
                {
                    mTextMeshProMasse.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_1) + mHimmelskoerperverwalter.lieferErdmassen(mAktivePlanet) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MASS_2);
                }

                if (mHimmelskoerperverwalter.lieferEntfernungZurSonneZu(mAktivePlanet) == 0)
                {
                    mTextMeshProEntfernungSonne.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ENTF_1);
                }
                else
                {
                    if (mHimmelskoerperverwalter.lieferEinheitEntfernungZu(mAktivePlanet) == Sprachenuebersetzer.K_KILOMETER)
                    {
                        mTextMeshProEntfernungSonne.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ENTF_2)
                            + " " + mSprachenuebersetzer.lieferWort(mHimmelskoerperverwalter.lieferEinheitEntfernungZu(mAktivePlanet)) +
                            mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_IST) + string.Format("{0:0,0}", mHimmelskoerperverwalter.lieferEntfernungZurSonneZu(mAktivePlanet));
                    }
                    else
                    {
                        mTextMeshProEntfernungSonne.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ENTF_2)
                            + " " + mSprachenuebersetzer.lieferWort(mHimmelskoerperverwalter.lieferEinheitEntfernungZu(mAktivePlanet)) +
                            mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_IST) + string.Format("{0:###,###,000}", mHimmelskoerperverwalter.lieferEntfernungZurSonneZu(mAktivePlanet));
                    }

                }
                if (mHimmelskoerperverwalter.lieferAnzahlMondeZu(mAktivePlanet) == 0)
                {
                    mTextMeshProAnzahlMonde.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HAS_NO_MOON);
                }
                else if (mHimmelskoerperverwalter.lieferAnzahlMondeZu(mAktivePlanet) == 1)
                {
                    mTextMeshProAnzahlMonde.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HAS_1_MOON);
                }
                else
                {
                    mTextMeshProAnzahlMonde.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HAS_X_MOON_1) + " " + mHimmelskoerperverwalter.lieferAnzahlMondeZu(mAktivePlanet) + " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_HAS_X_MOON_2);
                }
                mTextMeshProDichte.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DICHTE_1) + mHimmelskoerperverwalter.lieferDichteZu(mAktivePlanet) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DICHTE_2);
                mTextMeshProDurchmesser.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_DURCHMESER) + string.Format("{0:##,###,###,###,000}", mHimmelskoerperverwalter.lieferDurchmesserZu(mAktivePlanet)) + " " + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KILOMETER);
                mTextMeshProMinTemperatur.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MIN_TEMP) + "\n" + mHimmelskoerperverwalter.lieferMinTemperaturZu(mAktivePlanet) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GRAD);
                mTextMeshProMaxTemperatur.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MAX_TEMP) + "\n" + mHimmelskoerperverwalter.lieferMaxTemperaturZu(mAktivePlanet) + mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_GRAD);

                mTextMeshProName.text = mHimmelskoerperverwalter.lieferNameZuObereAnzeige(mAktivePlanet);
                if (mTextMeshProName.text.Length < 20)
                {
                    mTextMeshProName.fontSize = 1.05f;
                }
                else if (istSchwarzeLochAktivePlanet())
                {
                    mTextMeshProName.fontSize = 0.65f;
                }
                else
                {
                    mTextMeshProName.fontSize = 1f;
                }
                double lZahl = mHimmelskoerperverwalter.lieferDurchmesserZu(mAktivePlanet);
                mDurchmesserbild = (float)Math.Log(lZahl, 4d);

                if (istSchwarzeLochAktivePlanet())
                {
                    mHimmelskoerperverwalter.schauAufObject(true);
                    if (mAktivePlanet == K_M87)
                    {
                        mGameObjectSchwarzeLochErhitztGas.SetActive(true);
                    }
                    else
                    {
                        mGameObjectSchwarzeLochErhitztGas.SetActive(false);
                    }
                }
                else
                {
                    mHimmelskoerperverwalter.schauAufObject(false);
                    mGameObjectSchwarzeLochErhitztGas.SetActive(false);
                }

            }
        }
    }

    internal void setAktivenPlanetZurueck()
    {
        mAktivePlanet = 0;
    }

    public void setLeerMaterial()
    {
        GetComponent<Renderer>().material.mainTexture = mTextureHubbel;
        mRingObject.SetActive(false);
        mTextMeshProName.text = "";
        this.transform.localScale = new Vector3(0, 0, 0);
        mDurchmesserbild = 0;
        mAktivePlanetNew = 0;
        mGameObjectLicht.SetActive(false);
        mTextMeshProMasse.text = "";
        mTextMeshProEntfernungSonne.text = "";
        mTextMeshProAnzahlMonde.text = "";
        mTextMeshProDichte.text = "";
        mTextMeshProDurchmesser.text = "";
        mTextMeshProMinTemperatur.text = "";
        mTextMeshProMaxTemperatur.text = "";
        mGameObjectSchwarzeLochErhitztGas.SetActive(false);
        mHimmelskoerperverwalter.schauAufObject(false);
        mWerGegenWenButtonbuttonEmpty.SetActive(false);
        mKometenschweif.SetActive(false);
        RenderSettings.fog = false;
        mCubeAmHimmelskoerper.SetActive(false);
        mBorealis.SetActive(false);
    }

    private void setzeRotateRinge(float pX, float pY, float pZ)
    {

        Vector3 lOldLocalRotation;

        for (int i = 0; i < 5; i++)
        {
            lOldLocalRotation = mRingObject.transform.localRotation.eulerAngles;
            mRingObject.transform.Rotate(new Vector3(bestimme180Gegenteil(lOldLocalRotation.x),
                0, 0), Space.Self);
            lOldLocalRotation = mRingObject.transform.localRotation.eulerAngles;
            mRingObject.transform.Rotate(new Vector3(0,
                bestimme180Gegenteil(lOldLocalRotation.y), 0), Space.Self);
            lOldLocalRotation = mRingObject.transform.localRotation.eulerAngles;
            mRingObject.transform.Rotate(new Vector3(0, 0, bestimme180Gegenteil(lOldLocalRotation.z)), Space.Self);
        }

        mRingObject.transform.Rotate(new Vector3(pX, pY, pZ), Space.Self);
    }

    private float bestimme180Gegenteil(float pWinkel)
    {

        float lErg = 0;
        if (pWinkel > -180 && pWinkel < 180)
        {
            lErg = -1 * pWinkel;
        }
        else if (pWinkel <= -180)
        {
            lErg = -1 * (360 + pWinkel);
        }
        else
        {
            lErg = (360 - pWinkel);
        }

        if (lErg < 0.1 && lErg > -0.1)
        {
            return 0;
        }

        return lErg;
    }



    public void setNeuenPlanetDirekt(int pPlanet)
    {
        mAktivePlanetNew = pPlanet;
    }

    public void setNeuenPlanet(int pRichtung, int pArtDesHimmelskoerper)
    {
        if (pRichtung > 0)
        {
            mAktivePlanetNew = mAktivePlanet + 10;
            if (mAktivePlanetNew > K_MAX)
            {
                mAktivePlanetNew = K_ERST;
            }
        }
        else
        {
            mAktivePlanetNew = mAktivePlanet - 10;
            if (mAktivePlanetNew < K_ERST)
            {
                mAktivePlanetNew = K_MAX;
            }
        }

        if (pArtDesHimmelskoerper == Sprachenuebersetzer.K_ALL
            || mHimmelskoerperverwalter.istHimmelskoerperDieseArt(mAktivePlanetNew, pArtDesHimmelskoerper))
        {
            return;
        }
        else
        {
            mAktivePlanet = mAktivePlanetNew;
            setNeuenPlanet(pRichtung, pArtDesHimmelskoerper);
        }

    }

    public int lieferAktuellenHimmelskoerper()
    {
        return mAktivePlanet;
    }
}
