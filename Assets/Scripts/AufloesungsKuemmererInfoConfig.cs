using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AufloesungsKuemmererInfoConfig : MonoBehaviour {

	public int mBreiteDisplay;

	public int mHoeheDisplay;

	public TextMeshProUGUI mTextMeshProVortext;

	public TMP_InputField mTextMeshProInputfield;

	public TextMeshProUGUI mTextMeshProTitel;


	public TextMeshProUGUI mTextMeshProGraviRecord;

	public GameObject mTextMeshProGameObjectButton;

	public Material mMaterial;


	public GameObject mLinkeMenuLeiste;

	void Start () {
		mMaterial.SetFloat("_GlossMapScale", 0.9f);

		mBreiteDisplay = Display.main.systemWidth;
		mHoeheDisplay = Display.main.systemHeight;
		GeraeteIFs lGeraeteIFs = new GeraeteIFs ();

		float lBreitefloat = mBreiteDisplay;
		float lHoehefloat = mHoeheDisplay;
		float lVerhaetnis = lBreitefloat / lHoehefloat;

		if (lGeraeteIFs.istIPHONE_small (mBreiteDisplay,mHoeheDisplay)) {

			mLinkeMenuLeiste.transform.localPosition = new Vector3 (-13.5f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3 (1f, 1f, 1f);

			mTextMeshProVortext.transform.localPosition = new Vector3 (-641f, -260f, 0f);
			mTextMeshProInputfield.transform.localPosition = new Vector3 (0f, -279f, 0f);
			mTextMeshProTitel.transform.localPosition = new Vector3 (320f, -260f, 0f);

			mTextMeshProGraviRecord.transform.localPosition = new Vector3(-641f, -352f, 0f);
			mTextMeshProGameObjectButton.transform.localPosition = new Vector3(0f, -371f, 0f);


		}
		else  if (lGeraeteIFs.istIPHONE (mBreiteDisplay,mHoeheDisplay)) {

			mLinkeMenuLeiste.transform.localPosition = new Vector3 (-13.5f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3 (1f, 1f, 1f);

			mTextMeshProVortext.transform.localPosition = new Vector3 (-641f, -240f, 0f);
			mTextMeshProInputfield.transform.localPosition = new Vector3 (0f, -250f, 0f);
			mTextMeshProTitel.transform.localPosition = new Vector3 (320f, -240f, 0f);

			mTextMeshProGraviRecord.transform.localPosition = new Vector3(-641f, -312f, 0f);
			mTextMeshProGameObjectButton.transform.localPosition = new Vector3(0f, -331f, 0f);


		}
		else if (lGeraeteIFs.istIPAD (mBreiteDisplay,mHoeheDisplay)) {

			mLinkeMenuLeiste.transform.localPosition = new Vector3 (-7.8f, -2.3f, -0.15f);
			mLinkeMenuLeiste.transform.localScale = new Vector3 (.7f, 1f, 1f);

			mTextMeshProVortext.transform.localPosition = new Vector3 (-641f, -580f, 0f);
			mTextMeshProInputfield.transform.localPosition = new Vector3 (26f, -595f, 0f);
			mTextMeshProTitel.transform.localPosition = new Vector3 (320f, -580f, 0f);

			mTextMeshProGraviRecord.transform.localPosition = new Vector3(-641f, -701f, 0f);
			mTextMeshProGameObjectButton.transform.localPosition = new Vector3(26f, -720f, 0f);


		}

	}

}
