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

	public GameObject mZurueckButton;

	public GameObject mDeutschButton;

	public GameObject mEnglischButton;

	public GameObject mGraviErgebnisPrefab;

	public TextMeshProUGUI mTextMeshProGraviRecord;

	public GameObject mTextMeshProGameObjectButton;

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

		mBreiteDisplay = Display.main.systemWidth;
		mHoeheDisplay = Display.main.systemHeight;

		mLinkeMenuLeiste.transform.localPosition = new Vector3(lGeraeteIFs.lieferPos(3, 11).x, lGeraeteIFs.lieferPos(3, 11).y, -0.15f);
		mLinkeMenuLeiste.transform.localScale = new Vector3(1f, 1f, 1f);

		mZurueckButton.transform.localPosition = new Vector3(0, 4.5f, 0f);
		mZurueckButton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mDeutschButton.transform.localPosition = new Vector3(0f, 2f, 0f);
		mDeutschButton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mEnglischButton.transform.localPosition = new Vector3(0f, -0.5f, 0f);
		mEnglischButton.transform.localScale = lButtonScaleLinkeMenuleiste;

		mTextMeshProVortext.transform.localPosition = new Vector3(-mBreiteDisplay/2.4f, mHoeheDisplay * -0.33f +mHoeheDisplay/100, 0f);
		mTextMeshProInputfield.transform.localPosition = new Vector3(0f, mHoeheDisplay * -0.33f, 0f);
		mTextMeshProTitel.transform.localPosition = new Vector3(mBreiteDisplay / 5, mHoeheDisplay * -0.33f + mHoeheDisplay / 100, 0f);

		mTextMeshProGraviRecord.transform.localPosition = new Vector3(-mBreiteDisplay / 2.4f, mHoeheDisplay * -0.44f + mHoeheDisplay / 100, 0f);
		mTextMeshProGameObjectButton.transform.localPosition = new Vector3(0f, mHoeheDisplay * -0.44f, 0f);

		mGraviErgebnisPrefab.transform.localScale = new Vector3(0.75f, 0.75f, 1f);

		mTextMeshProVortext.fontSize = lGeraeteIFs.lieferSizeGUI(mHoeheDisplay);
		mTextMeshProTitel.fontSize = lGeraeteIFs.lieferSizeGUI(mHoeheDisplay);
		mTextMeshProGraviRecord.fontSize = lGeraeteIFs.lieferSizeGUI(mHoeheDisplay);
	}
}
