using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AufloesungsKuemmererStart : MonoBehaviour {

	public int mBreiteDisplay;

	public int mHoeheDisplay;


	public GameObject mDeutsch;

	public GameObject mEnglisch;

	public Material mMaterial;


	void Start () {

		mMaterial.SetFloat("_GlossMapScale", 0.9f);

		mBreiteDisplay = Display.main.systemWidth;
		mHoeheDisplay = Display.main.systemHeight;
		GeraeteIFs lGeraeteIFs = new GeraeteIFs ();

		if (lGeraeteIFs.istIPHONE_small (mBreiteDisplay,mHoeheDisplay)) {

			mDeutsch.transform.localPosition = new Vector3 (8f, -1.5f, 0f);
			mDeutsch.transform.localScale = new Vector3 (2f, 1.5f, 0.5f);

			mEnglisch.transform.localPosition = new Vector3 (19f, -1.5f, 0f);
			mEnglisch.transform.localScale = new Vector3 (2f, 1.5f, 0.5f);

		} else if (lGeraeteIFs.istIPHONE (mBreiteDisplay,mHoeheDisplay)) {

			mDeutsch.transform.localPosition = new Vector3 (7f, -1.5f, 0f);
			mDeutsch.transform.localScale = new Vector3 (2.5f, 1.5f, 0.5f);

			mEnglisch.transform.localPosition = new Vector3 (19f, -1.5f, 0f);
			mEnglisch.transform.localScale = new Vector3 (2.5f, 1.5f, 0.5f);

		} else if (lGeraeteIFs.istIPAD (mBreiteDisplay,mHoeheDisplay)) {

			mDeutsch.transform.localPosition = new Vector3 (9f, -1.5f, 0f);
			mDeutsch.transform.localScale = new Vector3 (2f, 1.5f, 0.5f);

			mEnglisch.transform.localPosition = new Vector3 (17f, -1.5f, 0f);
			mEnglisch.transform.localScale = new Vector3 (2f, 1.5f, 0.5f);

		}

	}

}
