using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AufloesungsKuemmererPruefung : MonoBehaviour {

	public int mBreiteDisplay;
	public int mHoeheDisplay;

	public TextMeshPro mTextMeshProFrage;

	public GameObject mGameObjectButtonAntwort_A;

	public GameObject mGameObjectButtonAntwort_B;

	public GameObject mGameObjectButtonAntwort_C;

	public GameObject mGameObjectButtonAntwort_D;

	public GameObject mCubePosA;
	public GameObject mCubePosB;
	public GameObject mCubePosC;
	public GameObject mCubePosD;

	public GameObject mWeiterButton;

	public GameObject mZurueckButton;

	public GameObject mThemabutton;

	public GameObject mStartstoppbutton;

	public GameObject mEmojikaufbutton;

	public GameObject mLinkeMenuLeiste;

	public Material mMaterial;

	public float mTeilBreite;
	public float mTeilHoehe;
	public float mVerhaeltnis;

	void Start () {

		GeraeteIFs lGeraeteIFs = new GeraeteIFs();
		lGeraeteIFs.init(Camera.main);
		mTeilBreite = lGeraeteIFs.mWidthTeil;
		mTeilHoehe = lGeraeteIFs.mHoeheTeil;
		mVerhaeltnis = lGeraeteIFs.mVerhaeltnis;
		Vector3 lButtonScaleLinkeMenuleiste = new Vector3(1.5f * mTeilBreite, 1.2f * mTeilHoehe, 0.5f);

		mMaterial.SetFloat("_GlossMapScale", 0.9f);//0.6

		mLinkeMenuLeiste.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(3, 11).x, lGeraeteIFs.lieferPos(3, 11).y, -0.15f);
		mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

		mZurueckButton.transform.localPosition = new Vector3(0, 4.5f, 0f);
		mZurueckButton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mThemabutton.transform.localPosition = new Vector3(0f, 2f, 0f);
		mThemabutton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mStartstoppbutton.transform.localPosition = new Vector3(0f, -0.5f, 0f);
		mStartstoppbutton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mEmojikaufbutton.transform.localPosition = new Vector3(0f, -3f, 0f);
		mEmojikaufbutton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mTextMeshProFrage.transform.localPosition = new Vector3(14.3f * mTeilBreite, 2f, 0f);

		mGameObjectButtonAntwort_A.transform.localPosition = new Vector3(-6.9f * mTeilBreite, -1.53f * mTeilHoehe, 0f);
		mCubePosA.transform.localPosition = new Vector3(-6.9f * mTeilBreite, -0.7f, -3f);
		mGameObjectButtonAntwort_B.transform.localPosition = new Vector3(4.5f * mTeilBreite, -1.53f * mTeilHoehe, 0f);
		mCubePosB.transform.localPosition = new Vector3(4.5f * mTeilBreite, -0.64f, -3.2f);

		mGameObjectButtonAntwort_C.transform.localPosition = new Vector3(-6.9f * mTeilBreite, -6.4f*mTeilHoehe, 0f);
		mCubePosC.transform.localPosition = new Vector3(-6.9f * mTeilBreite, -3f, -3f);
		mGameObjectButtonAntwort_D.transform.localPosition = new Vector3(4.5f * mTeilBreite, -6.4f * mTeilHoehe, 0f);
		mCubePosD.transform.localPosition = new Vector3(4.5f * mTeilBreite, -3f, -3f);

		mWeiterButton.transform.localPosition = new Vector3(-0.5f * mTeilBreite, -11f * mTeilHoehe, 0f);
		mWeiterButton.transform.localScale = new Vector3(10f * mTeilBreite / mVerhaeltnis, 0.4f, 0.5f);
	}
}
