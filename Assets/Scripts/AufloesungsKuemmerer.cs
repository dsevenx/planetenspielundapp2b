using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AufloesungsKuemmerer : MonoBehaviour
{

    public int mBreiteDisplay;

    public int mHoeheDisplay;

    public TextMeshPro mTextMeshProBeschriftungHimmelskoerper;

    public GameObject mAngabenZuSpielModi;

    public GameObject mHimmelskoerperverwalter;

    public GameObject mKartenbutton;

    public TextMeshPro mTextMeshProYou;

    public TextMeshPro mTextMeshProEinstein;

    public TextMeshPro mTextMeshProYouCards;

    public TextMeshPro mTextMeshProEinsteinCards;

    public TextMeshPro mTextMeshProKaempfe;

    public TextMeshPro mTextMeshProKaempfeErg;

    public GameObject mLernenbutton;

    public GameObject mPruefungbutton;

    public GameObject mQuartettbutton;

    public GameObject mEinstelungenbutton;

    public GameObject mErlaueterungSpielModi;

    public GameObject mArtDesHimmelskoerperbutton;

    public GameObject mArtDesHimmelskoerperbuttonVor;

    public GameObject mArtDesHimmelskoerperbuttonNext;

    public GameObject mWerGegenWenButtonbuttonEmpty;

    public GameObject mMasseButton;
    public GameObject mSonnenentfernungButton;
    public GameObject mAnzahlMondeButton;
    public GameObject mDichteButton;
    public GameObject mDurchmesserButton;
    public GameObject mMaxTemperatur;
    public GameObject mMinTemperatur;
    public GameObject mTMPMasseButton;
    public GameObject mTMPSonnenentfernungButton;
    public GameObject mTMPAnzahlMondeButton;
    public GameObject mTMPDichteButton;
    public GameObject mTMPDurchmesserButton;
    public GameObject mTMPMaxTemperatur;
    public GameObject mTMPMinTemperatur;


    public Vector3 K_WER_GEGEN_WEN_NORMAL;

    public Vector3 K_WER_GEGEN_WEN_SCHWARZE_LOCH;

    public Animator mAnimator;

    public int mAufloesungInt;

    public Material mMaterial;

    public float mTeilBreite;
    public float mTeilHoehe;

    public float mVerhaeltnis;
    public float mFaktor;

    public Vector3 mTopLeft;

    void Update()
    {
        if (mAnimator != null && mAufloesungInt > 0 && mAnimator.isInitialized)
        {
            if (mAufloesungInt == 2)
            {
                mAnimator.SetInteger("WegGegenWenInt", 2);
            }
            else
            {
                mAnimator.SetInteger("WegGegenWenInt", 1);
            }
        }
    }

    void Start()
    {
        GeraeteIFs lGeraeteIFs = new GeraeteIFs();
        lGeraeteIFs.init(Camera.main);
        mTeilBreite = lGeraeteIFs.mWidthTeil;
        mTeilHoehe = lGeraeteIFs.mHoeheTeil;
        mVerhaeltnis = lGeraeteIFs.mVerhaeltnis;
        mTopLeft = lGeraeteIFs.mTopLeft;
        Vector3 lButtonScaleLinkeMenuleiste = new Vector3(1.5f * mTeilBreite, 1.2f * mTeilHoehe, 0.5f);

        mMaterial.SetFloat("_GlossMapScale", 0.9f);

        mBreiteDisplay = Display.main.systemWidth;
        mHoeheDisplay = Display.main.systemHeight;
       
        mTextMeshProBeschriftungHimmelskoerper.transform.localPosition = new Vector3(-0.00f, 0.6f, 0.23f);
        mTextMeshProBeschriftungHimmelskoerper.fontSize = 0.45f * lGeraeteIFs.mVerhaeltnis;

        mAngabenZuSpielModi.transform.localPosition = 
            new Vector3(lGeraeteIFs.lieferPos(3, 11).x, lGeraeteIFs.lieferPos(3, 11).y, -0.15f);
        mAngabenZuSpielModi.transform.localScale = new Vector3(1f, 1f, 1f);
         
        mHimmelskoerperverwalter.transform.localPosition =
            new Vector3(lGeraeteIFs.lieferPos(21, 9).x- lGeraeteIFs.mWidthTeil / 12, lGeraeteIFs.lieferPos(21,9).y + lGeraeteIFs.mHoeheTeil/2, -0.15f);
        mHimmelskoerperverwalter.transform.localScale = new Vector3(1f, 0.5f, 1f);
  
        mTextMeshProYou.fontSize = 3f;
        mTextMeshProEinstein.fontSize = 3f;
        mTextMeshProYouCards.fontSize = 3f;
        mTextMeshProEinsteinCards.fontSize = 3f;
        mTextMeshProKaempfe.fontSize = 2f;
        mTextMeshProKaempfeErg.fontSize = 2f;

        mLernenbutton.transform.localPosition = new Vector3(0f, 4.5f, 0f);
        mLernenbutton.transform.localScale = lButtonScaleLinkeMenuleiste;
        mQuartettbutton.transform.localPosition = new Vector3(0f, 2f, 0f);
        mQuartettbutton.transform.localScale = lButtonScaleLinkeMenuleiste;
        mEinstelungenbutton.transform.localPosition = new Vector3(0, -0.5f, 0f);
        mEinstelungenbutton.transform.localScale = lButtonScaleLinkeMenuleiste;
        mPruefungbutton.transform.localPosition = new Vector3(0f, -5.5f, 0f);
        mPruefungbutton.transform.localScale = lButtonScaleLinkeMenuleiste;

        mArtDesHimmelskoerperbutton.transform.localPosition = new Vector3(0f, -3f, 0f);
        mArtDesHimmelskoerperbuttonVor.transform.localPosition = new Vector3(0f, -5.5f, 0f);
        mArtDesHimmelskoerperbuttonNext.transform.localPosition = new Vector3(5f * mTeilBreite, -5.5f, 0f);

        mArtDesHimmelskoerperbutton.transform.localScale = lButtonScaleLinkeMenuleiste;
        mArtDesHimmelskoerperbuttonVor.transform.localScale = lButtonScaleLinkeMenuleiste;
        mArtDesHimmelskoerperbuttonNext.transform.localScale = lButtonScaleLinkeMenuleiste;

        mErlaueterungSpielModi.transform.localScale = new Vector3(1f, 1f, 0.5f);
        mErlaueterungSpielModi.transform.localPosition = new Vector3(12f * mTeilBreite, 2f, 0.5f);
        mErlaueterungSpielModi.GetComponent<RectTransform>().sizeDelta = new Vector2(12, 8.5f);

        mKartenbutton.transform.localPosition = new Vector3(0.479f * lGeraeteIFs.mVerhaeltnis + 2.16f, -4.1f, -3.2f);
        mKartenbutton.transform.localScale = new Vector3(1.5f, 1.3f, 0.5f);

        K_WER_GEGEN_WEN_NORMAL =   new Vector3(2.51f * lGeraeteIFs.mVerhaeltnis + 3.87f, -3.43f, -6.6f);
        K_WER_GEGEN_WEN_SCHWARZE_LOCH =  new Vector3(2.51f * lGeraeteIFs.mVerhaeltnis + 5.44f, -3.1f, -7);


        mWerGegenWenButtonbuttonEmpty.transform.localPosition = K_WER_GEGEN_WEN_NORMAL;
        mWerGegenWenButtonbuttonEmpty.transform.localScale = new Vector3(0.57f, 0.55f, 0.5f);

        mMasseButton.transform.localPosition = new Vector3(0f, 0f, -7.5f);
        mMasseButton.transform.localScale = new Vector3(0.55f, 0.41f, 0.3f);
        mSonnenentfernungButton.transform.localPosition = new Vector3(0f, -1.4f, -7.5f);
        mSonnenentfernungButton.transform.localScale = new Vector3(0.55f, 0.41f, 0.3f);
        mAnzahlMondeButton.transform.localPosition = new Vector3(0f, -2.8f, -7.5f);
        mAnzahlMondeButton.transform.localScale = new Vector3(0.55f, 0.41f, 0.3f);
        mDichteButton.transform.localPosition = new Vector3(0f, -4.2f, -7.5f);
        mDichteButton.transform.localScale = new Vector3(0.55f, 0.41f, 0.3f);
        mDurchmesserButton.transform.localPosition = new Vector3(0f, -5.6f, -7.5f);
        mDurchmesserButton.transform.localScale = new Vector3(0.55f, 0.41f, 0.3f);
        mMaxTemperatur.transform.localPosition = new Vector3(0f, -7f, -7.5f);
        mMaxTemperatur.transform.localScale = new Vector3(0.55f, 0.41f, 0.3f);
        mMinTemperatur.transform.localPosition = new Vector3(0f, -8.4f, -7.5f);
        mMinTemperatur.transform.localScale = new Vector3(0.55f, 0.41f, 0.3f);

        mTMPMasseButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
        mTMPSonnenentfernungButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
        mTMPAnzahlMondeButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
        mTMPDichteButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
        mTMPDurchmesserButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
        mTMPMaxTemperatur.transform.localScale = new Vector3(1f, 1f, 0.5f);
        mTMPMinTemperatur.transform.localScale = new Vector3(1f, 1f, 0.5f);

        mAufloesungInt = 3; // 2048*1536  2224*1668
    }

    public Vector3 lieferAktuelleKampfPostion(bool pSchwarzeLoch)
    {
        if (pSchwarzeLoch)
        {
            return K_WER_GEGEN_WEN_SCHWARZE_LOCH;
        }
        else
        {
            return K_WER_GEGEN_WEN_NORMAL;
        }

    }
}
