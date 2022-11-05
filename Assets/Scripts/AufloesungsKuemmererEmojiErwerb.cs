using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AufloesungsKuemmererEmojiErwerb : MonoBehaviour {

	public int mBreiteDisplay;

	public int mHoeheDisplay;

	public TextMeshPro mTextMeshProKaufinfo;

	public GameObject mZurueckButton;

	public GameObject mVorButton;

	public GameObject mNaechsteButton;

	public GameObject mEmojiKauf1;
	public GameObject mEmojiKauf2;
	public GameObject mEmojiKauf3;
	public GameObject mEmojiKaufEingabe;
	public GameObject mEmojiFinalKaufEingabe;

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

			mLinkeMenuLeiste.transform.localPosition = new Vector3(-7.3f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

			mZurueckButton.transform.localPosition = new Vector3(-0.5f, 4.5f, 0f);
			mZurueckButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mVorButton.transform.localPosition = new Vector3(-0.5f, -5.5f, 0f);
			mVorButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mNaechsteButton.transform.localPosition = new Vector3(2.65f, -5.5f, 0f);
			mNaechsteButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mTextMeshProKaufinfo.transform.localPosition = new Vector3(6.5f, 2f, 0f);
		}
		else if (lGeraeteIFs.istIPHONE(mBreiteDisplay, mHoeheDisplay))
		{

			mLinkeMenuLeiste.transform.localPosition = new Vector3(-7.3f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

			mZurueckButton.transform.localPosition = new Vector3(-0.5f, 4.5f, 0f);
			mZurueckButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mVorButton.transform.localPosition = new Vector3(-0.5f, -5.5f, 0f);
			mVorButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mNaechsteButton.transform.localPosition = new Vector3(2.65f, -5.5f, 0f);
			mNaechsteButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mTextMeshProKaufinfo.transform.localPosition = new Vector3(6.5f, 2f, 0f);
		}
		else if (lGeraeteIFs.istIPAD(mBreiteDisplay, mHoeheDisplay))
		{
			// i.O.
			mLinkeMenuLeiste.transform.localPosition = new Vector3(-7.3f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

			mZurueckButton.transform.localPosition = new Vector3(-0.5f, 4.5f, 0f);
			mZurueckButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mVorButton.transform.localPosition = new Vector3(-0.5f, -5.5f, 0f);
			mVorButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mNaechsteButton.transform.localPosition = new Vector3(2.65f, -5.5f, 0f);
			mNaechsteButton.transform.localScale = new Vector3(1f, 0.8f, 0.5f);

			mEmojiKauf1.transform.localPosition = new Vector3(3.65f, -1.2f, 0f);
			mEmojiKauf2.transform.localPosition = new Vector3(3.65f, -3.4f, 0f);
			mEmojiKauf3.transform.localPosition = new Vector3(3.65f, -5.6f, 0f);
			mEmojiKaufEingabe.transform.localPosition = new Vector3(3f, -4.6f, -0.5f);
			mEmojiKaufEingabe.transform.localScale = new Vector3(3.4f, 3f, 1f);

		    mEmojiFinalKaufEingabe.transform.localPosition = new Vector3(-0.05f,-0.2f, -0.7f);
			mEmojiFinalKaufEingabe.transform.localScale = new Vector3(0.75f, 0.15f, 1f);

			mTextMeshProKaufinfo.transform.localPosition = new Vector3(6.5f, 2.8f, 0f);

		}
	}
}
