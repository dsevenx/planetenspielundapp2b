using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AufloesungsKuemmererStart : MonoBehaviour {

	public GameObject mDeutsch;

	public GameObject mEnglisch;

	public Material mMaterial;

	public float mTeilBreite;
	public float mTeilHoehe;

	public Vector3 mTopLeft;

    void Start () {

		GeraeteIFs lGeraeteIFs = new GeraeteIFs();
		lGeraeteIFs.init(Camera.main);
		mTeilBreite = lGeraeteIFs.mWidthTeil;
		mTeilHoehe = lGeraeteIFs.mHoeheTeil;
		mTopLeft = lGeraeteIFs.mTopLeft;
	
		mMaterial.SetFloat("_GlossMapScale", 0.9f);

		mDeutsch.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(10, 12).x, lGeraeteIFs.lieferPos(10,12).y, 0f);
		mDeutsch.transform.localScale = new Vector3(1.6f, 1.4f, 0.5f);

		mEnglisch.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(22, 12).x, lGeraeteIFs.lieferPos(22,12).y, 0f);
		mEnglisch.transform.localScale = new Vector3(1.6f, 1.4f, 0.5f);
	}

}
