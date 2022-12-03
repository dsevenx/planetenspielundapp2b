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

	void Start () {

		mBreiteDisplay = Display.main.systemWidth;
		mHoeheDisplay = Display.main.systemHeight;
		GeraeteIFs lGeraeteIFs = new GeraeteIFs ();

		float lBreitefloat = mBreiteDisplay;
		float lHoehefloat = mHoeheDisplay;
		float lVerhaetnis = lBreitefloat / lHoehefloat;

		if (lGeraeteIFs.istIPHONE_small(mBreiteDisplay, mHoeheDisplay))
		{
			mLinkeMenuLeiste.transform.localPosition = new Vector3(-12.9f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

			mZurueckButton.transform.localPosition = new Vector3(-0.5f, 4.5f, 0f);
			mZurueckButton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
			mThemabutton.transform.localPosition = new Vector3(-0.5f, 2f, 0f);
			mThemabutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
			mStartstoppbutton.transform.localPosition = new Vector3(-0.5f, -0.5f, 0f);
			mStartstoppbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
			mEmojikaufbutton.transform.localPosition = new Vector3(-0.5f, -3f, 0f);
			mEmojikaufbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);

			mTextMeshProFrage.transform.localPosition = new Vector3(11.5f, 2f, 0f);

			mGameObjectButtonAntwort_A.transform.localPosition = new Vector3(-6.5f, -1f, 0f);
			mCubePosA.transform.localPosition = new Vector3(-6.4f, -0.7f, -3f);
			mGameObjectButtonAntwort_B.transform.localPosition = new Vector3(5.6f, -1f, 0f);
			mCubePosB.transform.localPosition = new Vector3(3.65f, -0.64f, -3.2f);

			mGameObjectButtonAntwort_C.transform.localPosition = new Vector3(-6.5f, -4f, 0f);
			mCubePosC.transform.localPosition = new Vector3(-6.35f, -3f, -3f);
			mGameObjectButtonAntwort_D.transform.localPosition = new Vector3(5.6f, -4f, 0f);
			mCubePosD.transform.localPosition = new Vector3(3.7f, -3f, -3f);

			mWeiterButton.transform.localPosition = new Vector3(-0.5f, -7f, 0f);
			mWeiterButton.transform.localScale = new Vector3(6.5f, 0.4f, 0.5f);
		}
		else if (lGeraeteIFs.istIPHONE(mBreiteDisplay, mHoeheDisplay))
		{

			mLinkeMenuLeiste.transform.localPosition = new Vector3(-12.9f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

			mZurueckButton.transform.localPosition = new Vector3(-0.5f, 4.5f, 0f);
			mZurueckButton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
			mThemabutton.transform.localPosition = new Vector3(-0.5f, 2f, 0f);
			mThemabutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
			mStartstoppbutton.transform.localPosition = new Vector3(-0.5f, -0.5f, 0f);
			mStartstoppbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);
			mEmojikaufbutton.transform.localPosition = new Vector3(-0.5f, -3f, 0f);
			mEmojikaufbutton.transform.localScale = new Vector3(1.5f, 0.8f, 0.5f);

			mTextMeshProFrage.transform.localPosition = new Vector3(11.5f, 2f, 0f);

			mGameObjectButtonAntwort_A.transform.localPosition = new Vector3(-6.5f, -1f, 0f);
			mCubePosA.transform.localPosition = new Vector3(-6.4f, -0.7f, -3f);
			mGameObjectButtonAntwort_B.transform.localPosition = new Vector3(5.6f, -1f, 0f);
			mCubePosB.transform.localPosition = new Vector3(3.65f, -0.64f, -3.2f);

			mGameObjectButtonAntwort_C.transform.localPosition = new Vector3(-6.5f, -4f, 0f);
			mCubePosC.transform.localPosition = new Vector3(-6.35f, -3f, -3f);
			mGameObjectButtonAntwort_D.transform.localPosition = new Vector3(5.6f, -4f, 0f);
			mCubePosD.transform.localPosition = new Vector3(3.7f, -3f, -3f);

			mWeiterButton.transform.localPosition = new Vector3(-0.5f, -7f, 0f);
			mWeiterButton.transform.localScale = new Vector3(6.5f, 0.4f, 0.5f);
		}
		else if (lGeraeteIFs.istIPAD(mBreiteDisplay, mHoeheDisplay))
		{
			// i.O.
			mLinkeMenuLeiste.transform.localPosition = new Vector3(-7.3f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

			mZurueckButton.transform.localPosition = new Vector3(-0.5f, 4.5f, 0f);
			mZurueckButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
			mThemabutton.transform.localPosition = new Vector3(-0.5f, 2f, 0f);
			mThemabutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
			mStartstoppbutton.transform.localPosition = new Vector3(-0.5f, -0.5f, 0f);
			mStartstoppbutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);
			mEmojikaufbutton.transform.localPosition = new Vector3(-0.5f, -3f, 0f);
			mEmojikaufbutton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);


			mTextMeshProFrage.transform.localPosition = new Vector3(6.5f, 2f, 0f);

			mGameObjectButtonAntwort_A.transform.localPosition = new Vector3(-6.5f, -1f, 0f);
			mCubePosA.transform.localPosition = new Vector3(-6.3f, -0.7f, -3f);
			mGameObjectButtonAntwort_B.transform.localPosition = new Vector3(2f, -1f, 0f);
			mCubePosB.transform.localPosition = new Vector3(0.25f, -0.64f, -3.2f);

			mGameObjectButtonAntwort_C.transform.localPosition = new Vector3(-6.5f, -4f, 0f);
			mCubePosC.transform.localPosition = new Vector3(-6.35f, -3.3f, -3f);
			mGameObjectButtonAntwort_D.transform.localPosition = new Vector3(2f, -4f, 0f);
			mCubePosD.transform.localPosition = new Vector3(0.3f, -3.3f, -3f);

			mWeiterButton.transform.localPosition = new Vector3(-2.25f, -7f, 0f);
			mWeiterButton.transform.localScale = new Vector3(5.3f, 0.4f, 0.5f);
		}
	}
}
