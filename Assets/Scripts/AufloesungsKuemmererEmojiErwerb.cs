using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AufloesungsKuemmererEmojiErwerb : MonoBehaviour {

	public int mBreiteDisplay;

	public int mHoeheDisplay;

	public TextMeshPro mTextMeshProKaufinfo;
	public TextMeshPro mTextMeshProEmojiGadgetErklaer;

	public GameObject mZurueckButton;

	public GameObject mVorButton;

	public GameObject mNaechsteButton;

	public GameObject mEmojiKauf1;
	public GameObject mEmojiKauf2;
	public GameObject mEmojiKauf3;
	public GameObject mEmojiKaufEingabe;
	public GameObject mEmojiFinalKaufEingabe;

	public GameObject mSaturn;
	public GameObject mSatellit;
	public GameObject mRakete;

	public Material mMaterial;

	public GameObject mLinkeMenuLeiste;

	public float mTeilBreite;
	public float mTeilHoehe;

	void Start () {

		GeraeteIFs lGeraeteIFs = new GeraeteIFs();
		lGeraeteIFs.init(Camera.main);
		mTeilBreite = lGeraeteIFs.mWidthTeil;
		mTeilHoehe = lGeraeteIFs.mHoeheTeil;
		Vector3 lButtonScaleLinkeMenuleiste = new Vector3(1.5f * mTeilBreite, 1.2f * mTeilHoehe, 0.5f);

		mMaterial.SetFloat("_GlossMapScale", 0.9f);//0.6

		mLinkeMenuLeiste.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(3,11).x, lGeraeteIFs.lieferPos(3, 11).y, -0.15f);
		mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

		mZurueckButton.transform.localPosition = new Vector3(0, 4.5f, 0f);
        mZurueckButton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mVorButton.transform.localPosition = new Vector3(0, -5.5f, 0f);
        mVorButton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mNaechsteButton.transform.localPosition = new Vector3(4.75f * mTeilBreite, -5.5f, 0f);
        mNaechsteButton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mEmojiKauf1.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(24, 9).x, lGeraeteIFs.lieferPos(24, 9).y, 0f);
		mEmojiKauf2.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(24, 13).x, lGeraeteIFs.lieferPos(24, 13).y, 0f);
		mEmojiKauf3.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(24, 17).x, lGeraeteIFs.lieferPos(24, 17).y, 0f);
		mEmojiKaufEingabe.transform.localPosition = new Vector3(3f, -4.6f, -0.5f);
		mEmojiKaufEingabe.transform.localScale = new Vector3(3.4f, 3f, 1f);

		mEmojiFinalKaufEingabe.transform.localPosition = new Vector3(-0.05f, -0.2f, -0.7f);
		mEmojiFinalKaufEingabe.transform.localScale = new Vector3(0.75f, 0.15f, 1f);

		mTextMeshProKaufinfo.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(23, 6).x, lGeraeteIFs.lieferPos(21,6).y, 0f);
		mTextMeshProEmojiGadgetErklaer.transform.localPosition = new Vector3(2*mTeilBreite, -1.0f, 0f);

		mSaturn.transform.localPosition = new Vector3(-2.4f, 0.15f, 0.5f);
		mSatellit.transform.localPosition = new Vector3(-2.3f - mTeilBreite + 0.61f, -0.01f, -3.95f);
		mRakete.transform.localPosition = new Vector3(-1.8f -mTeilBreite+0.61f, 0.5f, -2.75f);
	}
}
