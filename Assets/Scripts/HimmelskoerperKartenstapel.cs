using System.Collections;
using System.Collections.Generic;


public class HimmelskoerperKartenstapel  {

	public const int K_LEERER_STAPEL = -1;

	private IList<int> mStapel;

	public HimmelskoerperKartenstapel()
    {
		mStapel = null;
	}

	public void initHimmelskoerperKartenstapel() {
		mStapel = new List<int>();
	}

	public int lieferObersteKarte() {
		if (mStapel.Count == 0) {
			return K_LEERER_STAPEL;
		}

		int lErg = mStapel [0];

		int lLetzteIndex = mStapel.Count - 1;

		for (int lIndex = 0; lIndex < lLetzteIndex; lIndex++) {
			mStapel [lIndex] = mStapel [lIndex + 1];
		}

		mStapel.RemoveAt (lLetzteIndex);

		return lErg;
	}

	public void legKarteAn(int pHimmelskoerper) {

		mStapel.Add (pHimmelskoerper);
	}

	public int lieferAnzahl() {
		return mStapel.Count;
	}
}
