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


    void Update()
    {
        if (mAnimator != null && mAufloesungInt > 0)
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
        mMaterial.SetFloat("_GlossMapScale", 0.9f);

        mBreiteDisplay = Display.main.systemWidth;
        mHoeheDisplay = Display.main.systemHeight;
        GeraeteIFs lGeraeteIFs = new GeraeteIFs();

        float lBreitefloat = mBreiteDisplay;
        float lHoehefloat = mHoeheDisplay;
        float lVerhaetnis = lBreitefloat / lHoehefloat;
        if (lVerhaetnis < 1.7)
        {
            mTextMeshProBeschriftungHimmelskoerper.transform.localPosition = new Vector3(-0.00f, 0.6f, 0.23f);
            mTextMeshProBeschriftungHimmelskoerper.fontSize = 0.68f;

            mAngabenZuSpielModi.transform.localPosition = new Vector3(-7.3f, -2.3f, -0.15f);
            mAngabenZuSpielModi.transform.localScale = new Vector3(1f, 1f, 1f);

            mHimmelskoerperverwalter.transform.localPosition = new Vector3(8f, 2.7f, -0.15f);
            mHimmelskoerperverwalter.transform.localScale = new Vector3(1f, 0.5f, 1f);

            mKartenbutton.transform.localPosition = new Vector3(2.6f, -4.4f, -3.2f);
            mKartenbutton.transform.localScale = new Vector3(1.5f, 1.3f, 0.5f);

            mTextMeshProYou.fontSize = 3f;
            mTextMeshProEinstein.fontSize = 3f;
            mTextMeshProYouCards.fontSize = 3f;
            mTextMeshProEinsteinCards.fontSize = 3f;
            mTextMeshProKaempfe.fontSize = 2f;
            mTextMeshProKaempfeErg.fontSize = 2f;

            mLernenbutton.transform.localPosition = new Vector3(-0.5f, 4.5f, 0f);
            mLernenbutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
            mQuartettbutton.transform.localPosition = new Vector3(-0.5f, 2f, 0f);
            mQuartettbutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
            mEinstelungenbutton.transform.localPosition = new Vector3(-0.5f, -0.5f, 0f);
            mEinstelungenbutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
            mPruefungbutton.transform.localPosition = new Vector3(-0.5f, -5.5f, 0f);
            mPruefungbutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

            mArtDesHimmelskoerperbutton.transform.localPosition = new Vector3(-0.5f, -3f, 0f);
            mArtDesHimmelskoerperbuttonVor.transform.localPosition = new Vector3(-0.5f, -5.5f, 0f);
            mArtDesHimmelskoerperbuttonNext.transform.localPosition = new Vector3(2.65f, -5.5f, 0f);

            mArtDesHimmelskoerperbutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
            mArtDesHimmelskoerperbuttonVor.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
            mArtDesHimmelskoerperbuttonNext.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

            mErlaueterungSpielModi.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mErlaueterungSpielModi.transform.localPosition = new Vector3(7.5f, 2f, 0.5f);
            mErlaueterungSpielModi.GetComponent<RectTransform>().sizeDelta = new Vector2(12, 8.5f);

            K_WER_GEGEN_WEN_NORMAL = new Vector3(7.15f + mAngabenZuSpielModi.transform.localPosition.x
                , -3.68f + mAngabenZuSpielModi.transform.localPosition.y
                , -7f + mAngabenZuSpielModi.transform.localPosition.z);
            K_WER_GEGEN_WEN_SCHWARZE_LOCH = new Vector3(7.35f + mAngabenZuSpielModi.transform.localPosition.x
                , -3.5f + mAngabenZuSpielModi.transform.localPosition.y
                , -7f + mAngabenZuSpielModi.transform.localPosition.z);
            mWerGegenWenButtonbuttonEmpty.transform.localPosition = K_WER_GEGEN_WEN_NORMAL;
            mWerGegenWenButtonbuttonEmpty.transform.localScale = new Vector3(0.57f, 0.6f, 0.5f);
            mAufloesungInt = 3; // 2048*1536  2224*1668

            mMasseButton.transform.localPosition = new Vector3(-4.75f, -7f, -7.5f);
            mMasseButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mSonnenentfernungButton.transform.localPosition = new Vector3(-4.75f, -8.4f, -7.5f);
            mSonnenentfernungButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mAnzahlMondeButton.transform.localPosition = new Vector3(-4.75f, -9.8f, -7.5f);
            mAnzahlMondeButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mDichteButton.transform.localPosition = new Vector3(-4.75f, -11.2f, -7.5f);
            mDichteButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mDurchmesserButton.transform.localPosition = new Vector3(-4.75f, -12.6f, -7.5f);
            mDurchmesserButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mMaxTemperatur.transform.localPosition = new Vector3(-4.75f, -14f, -7.5f);
            mMaxTemperatur.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mMinTemperatur.transform.localPosition = new Vector3(-4.75f, -15.4f, -7.5f);
            mMinTemperatur.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);

            mTMPMasseButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mTMPSonnenentfernungButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mTMPAnzahlMondeButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mTMPDichteButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mTMPDurchmesserButton.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mTMPMaxTemperatur.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mTMPMinTemperatur.transform.localScale = new Vector3(1f, 1f, 0.5f);
        }
        else if(lVerhaetnis < 1.8 )
        {
            // i.O.
            mTextMeshProBeschriftungHimmelskoerper.transform.localPosition = new Vector3(-0.00f, 0.6f, 0.23f);
            mTextMeshProBeschriftungHimmelskoerper.fontSize = 1.2f;

            mAngabenZuSpielModi.transform.localPosition = new Vector3(-10.5f, -2.3f, -0.15f);
            mAngabenZuSpielModi.transform.localScale = new Vector3(1f, 1f, 1f);

            mHimmelskoerperverwalter.transform.localPosition = new Vector3(9.5f, 2.7f, -0.15f);
            mHimmelskoerperverwalter.transform.localScale = new Vector3(2.2f, 0.5f, 1);

            mKartenbutton.transform.localPosition = new Vector3(2.55f, -4.9f, 0f);
            mKartenbutton.transform.localScale = new Vector3(3.16f, 2.1f, 0.5f);

            mTextMeshProYou.fontSize = 3.5f;
            mTextMeshProEinstein.fontSize = 3.5f;
            mTextMeshProYouCards.fontSize = 3.5f;
            mTextMeshProEinsteinCards.fontSize = 3.5f;
            mTextMeshProKaempfe.fontSize = 2.1f;
            mTextMeshProKaempfeErg.fontSize = 2.1f;

            mLernenbutton.transform.localPosition = new Vector3(0.2f, 4.5f, 0f);
            mLernenbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mQuartettbutton.transform.localPosition = new Vector3(0.2f, 2f, 0f);
            mQuartettbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mEinstelungenbutton.transform.localPosition = new Vector3(0.2f, -0.5f, 0f);
            mEinstelungenbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mPruefungbutton.transform.localPosition = new Vector3(0.2f, -5.5f, 0f);
            mPruefungbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);

            mArtDesHimmelskoerperbutton.transform.localPosition = new Vector3(0.2f, -3f, 0f);
            mArtDesHimmelskoerperbuttonVor.transform.localPosition = new Vector3(0.2f, -5.5f, 0f);
            mArtDesHimmelskoerperbuttonNext.transform.localPosition = new Vector3(4.85f, -5.5f, 0f);

            mArtDesHimmelskoerperbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mArtDesHimmelskoerperbuttonVor.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mArtDesHimmelskoerperbuttonNext.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);

            mErlaueterungSpielModi.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mErlaueterungSpielModi.transform.localPosition = new Vector3(9f, 2f, 0.5f);
            mErlaueterungSpielModi.GetComponent<RectTransform>().sizeDelta = new Vector2(12, 8.5f);
     
            K_WER_GEGEN_WEN_NORMAL = new Vector3(-0.64f, -5.77f, -7f);
            K_WER_GEGEN_WEN_SCHWARZE_LOCH = new Vector3(-0.37f, -5.7f, -6.49f);
            mWerGegenWenButtonbuttonEmpty.transform.localPosition = K_WER_GEGEN_WEN_NORMAL;
            mWerGegenWenButtonbuttonEmpty.transform.localScale = new Vector3(0.7f, 0.6f, 0.5f);

            mAufloesungInt = 1;

            mMasseButton.transform.localPosition = new Vector3(-4.75f, -7f, -7.5f);
            mMasseButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mSonnenentfernungButton.transform.localPosition = new Vector3(-4.75f, -8.4f, -7.5f);
            mSonnenentfernungButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mAnzahlMondeButton.transform.localPosition = new Vector3(-4.75f, -9.8f, -7.5f);
            mAnzahlMondeButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mDichteButton.transform.localPosition = new Vector3(-4.75f, -11.2f, -7.5f);
            mDichteButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mDurchmesserButton.transform.localPosition = new Vector3(-4.75f, -12.6f, -7.5f);
            mDurchmesserButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mMaxTemperatur.transform.localPosition = new Vector3(-4.75f, -14f, -7.5f);
            mMaxTemperatur.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mMinTemperatur.transform.localPosition = new Vector3(-4.75f, -15.4f, -7.5f);
            mMinTemperatur.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);

            mTMPMasseButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPSonnenentfernungButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPAnzahlMondeButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPDichteButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPDurchmesserButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPMaxTemperatur.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPMinTemperatur.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
        }
        else
        {
            mTextMeshProBeschriftungHimmelskoerper.transform.localPosition = new Vector3(-0.00f, 0.58f, 0.23f);
            mTextMeshProBeschriftungHimmelskoerper.fontSize = 1.2f;

            mAngabenZuSpielModi.transform.localPosition = new Vector3(-13.5f, -2.3f, -0.15f);
            mAngabenZuSpielModi.transform.localScale = new Vector3(1f, 1f, 1f);

            mHimmelskoerperverwalter.transform.localPosition = new Vector3(11.4f, 2.7f, -0.15f);
            mHimmelskoerperverwalter.transform.localScale = new Vector3(2.6f, 0.5f, 1);

            mKartenbutton.transform.localPosition = new Vector3(2.6f, -4.9f, 0f);
            mKartenbutton.transform.localScale = new Vector3(3.3f, 2.2f, 0.5f);

            mTextMeshProYou.fontSize = 3.5f;
            mTextMeshProYou.margin = new Vector4((mTextMeshProYou.margin.x + 0.1f),
                    mTextMeshProYou.margin.y,
                    mTextMeshProYou.margin.z, mTextMeshProYou.margin.w);
            mTextMeshProEinstein.fontSize = 3.5f;
            mTextMeshProEinstein.margin = new Vector4((mTextMeshProEinstein.margin.x + 0.1f),
                    mTextMeshProEinstein.margin.y,
                    mTextMeshProEinstein.margin.z, mTextMeshProEinstein.margin.w);
            mTextMeshProYouCards.fontSize = 3.5f;
            mTextMeshProEinsteinCards.fontSize = 3.5f;
            mTextMeshProKaempfe.fontSize = 2.15f;
            mTextMeshProKaempfe.margin = new Vector4((mTextMeshProKaempfe.margin.x + 0.1f),
                mTextMeshProKaempfe.margin.y,
                mTextMeshProKaempfe.margin.z, mTextMeshProKaempfe.margin.w);

            mTextMeshProKaempfeErg.fontSize = 2.15f;

            mLernenbutton.transform.localPosition = new Vector3(0.2f, 4.5f, 0f);
            mLernenbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mQuartettbutton.transform.localPosition = new Vector3(0.2f, 2f, 0f);
            mQuartettbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mEinstelungenbutton.transform.localPosition = new Vector3(0.2f, -0.5f, 0f);
            mEinstelungenbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mPruefungbutton.transform.localPosition = new Vector3(0.2f, -5.5f, 0f);
            mPruefungbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);

            mArtDesHimmelskoerperbutton.transform.localPosition = new Vector3(0.2f, -3f, 0f);
            mArtDesHimmelskoerperbuttonVor.transform.localPosition = new Vector3(0.2f, -5.5f, 0f);
            mArtDesHimmelskoerperbuttonNext.transform.localPosition = new Vector3(4.85f, -5.5f, 0f);

            mArtDesHimmelskoerperbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mArtDesHimmelskoerperbuttonVor.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
            mArtDesHimmelskoerperbuttonNext.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);

            mErlaueterungSpielModi.transform.localScale = new Vector3(1f, 1f, 0.5f);
            mErlaueterungSpielModi.transform.localPosition = new Vector3(10f, 1.5f, 0.5f);
            mErlaueterungSpielModi.GetComponent<RectTransform>().sizeDelta = new Vector2(12, 10f);

            K_WER_GEGEN_WEN_NORMAL = new Vector3(0.15f, -6.08f, -7f);
            K_WER_GEGEN_WEN_SCHWARZE_LOCH = new Vector3(0.35f, -5.9f, -7f);
            mWerGegenWenButtonbuttonEmpty.transform.localPosition = K_WER_GEGEN_WEN_NORMAL;
            mWerGegenWenButtonbuttonEmpty.transform.localScale = new Vector3(0.6f, 0.51f, 0.5f);
            mAufloesungInt = 2; // 22436*1125

            mMasseButton.transform.localPosition = new Vector3(-2.7f, -7f, -7.5f);
            mMasseButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mSonnenentfernungButton.transform.localPosition = new Vector3(-2.7f, -8.4f, -7.5f);
            mSonnenentfernungButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mAnzahlMondeButton.transform.localPosition = new Vector3(-2.7f, -9.8f, -7.5f);
            mAnzahlMondeButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mDichteButton.transform.localPosition = new Vector3(-2.7f, -11.2f, -7.5f);
            mDichteButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mDurchmesserButton.transform.localPosition = new Vector3(-2.7f, -12.6f, -7.5f);
            mDurchmesserButton.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mMaxTemperatur.transform.localPosition = new Vector3(-2.7f, -14f, -7.5f);
            mMaxTemperatur.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);
            mMinTemperatur.transform.localPosition = new Vector3(-2.7f, -15.4f, -7.5f);
            mMinTemperatur.transform.localScale = new Vector3(0.5f, 0.41f, 0.3f);

            mTMPMasseButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPSonnenentfernungButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPAnzahlMondeButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPDichteButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPDurchmesserButton.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPMaxTemperatur.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
            mTMPMinTemperatur.transform.localScale = new Vector3(0.9f, 1.6f, 0.5f);
        }
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
