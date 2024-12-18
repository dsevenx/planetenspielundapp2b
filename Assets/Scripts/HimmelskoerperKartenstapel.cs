using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntListWrapper
{
	public List<int> integerList;
}

public class HimmelskoerperKartenstapel  {

	public const int K_LEERER_STAPEL = -1;

	private List<int> mStapel;

	private string mName;

	public const string K_STAPEL = "STAPEL_";

	public HimmelskoerperKartenstapel(string pName)
    {
		mName = K_STAPEL+pName;
	}

	public void initHimmelskoerperKartenstapel(bool pVonDB) {
		mStapel = new List<int>();

		if (pVonDB)
        {
			string lGesicherteStapel = PlayerPrefs.GetString(mName);

			if (lGesicherteStapel != null && lGesicherteStapel.Length > 10)
            {
				string lFromPalyerPref = PlayerPrefs.GetString(mName);

				IntListWrapper lIntListWrapper = JsonUtility.FromJson<IntListWrapper>(lFromPalyerPref);

				mStapel = lIntListWrapper.integerList;
			}
		}
	}

	public int lieferObersteKarte() {
		if (mStapel.Count == 0) {
			return K_LEERER_STAPEL;
		}

		return mStapel [0];
	}

	public void loescheObersteKarte()
    {
		int lLetzteIndex = mStapel.Count - 1;

		for (int lIndex = 0; lIndex < lLetzteIndex; lIndex++)
		{
			mStapel[lIndex] = mStapel[lIndex + 1];
		}

		mStapel.RemoveAt(lLetzteIndex);

		sichereStapel();
	}
   
    public void legKarteAn(int pHimmelskoerper) {

		mStapel.Add (pHimmelskoerper);

		sichereStapel();
	}

	public int lieferAnzahl() {
		return mStapel.Count;
	}

	private void sichereStapel()
	{
		IntListWrapper lIntListWrapper = new IntListWrapper();
		lIntListWrapper.integerList = mStapel;
		string lJsonStapel = JsonUtility.ToJson(lIntListWrapper);
		PlayerPrefs.SetString(mName, lJsonStapel);
	}

}
