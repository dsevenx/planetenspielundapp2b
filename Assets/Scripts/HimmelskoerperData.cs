using System.Collections;
using System.Collections.Generic;


public class HimmelskoerperData
{

	public int mIndex;

	public string mName;

	public float mMasse;

	public float mEntfernungSonne;

	public int mEntfernungSonneEinheit;


	public int mAnzahlMonde;

	public float mDichte;

	public long mDurchmesser;

	public int mMaxTemperatur;

	public int mMinTemperatur;

	public bool mRingeVorhanden;

	public int mArtHimmelskoerper;

	public float mLichtIntensitaet;

	public int mHeimatplanet;


	public Dictionary<int,string> mMyBildInfos;

	public bool istLichtvorhanden() {
		return mLichtIntensitaet>0.1;
	}


	public string lieferInfoBild(int pBildIndex) {
		return mMyBildInfos [pBildIndex];
	}

	public int lieferAnzahlBildInfo() {
		return mMyBildInfos.Count;
	}
}
