using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreVerwaltung : MonoBehaviour
{
	private const string K_LEVEL_GESCHAFFT = "LEVEL_GESCHAFFT";

	private const string K_STUFE_GESCHAFFT = "STUFE_GESCHAFFT";

	public const string K_GRAVI_PUNKTE = "GRAVI_LEVEL";

	public const string K_GRAVI_NAME = "GRAVI_NAME";
	public const string K_GRAVI_MASSE = "GRAVI_MASSE";
	public const string K_GRAVI_DISTANZ = "GRAVI_DISTANZ";
	public const string K_GRAVI_DISTANZ_ABW = "GRAVI_DISTANZ_ABW";
	public const string K_GRAVI_SPEED = "GRAVI_SPEED";
	public const string K_GRAVI_SPEED_ABW = "GRAVI_PEED_ABW";
	public const string K_GRAVI_PUNKTE_C = "GRAVI_PUNKTE_C";

	public const int K_STUFE_GALILEO = 0;
	public const int K_STUFE_NEWTON = 1;
	public const int K_STUFE_FEYMAN = 2;

	void Start ()
	{
	//	PlayerPrefs.SetInt (K_LEVEL_GESCHAFFT, 0);
	//	PlayerPrefs.SetInt (K_STUFE_GESCHAFFT, 0);
	}

	public int getLevel ()
	{
		return PlayerPrefs.GetInt (K_LEVEL_GESCHAFFT);
	}

	public int getStufe ()
	{
		return PlayerPrefs.GetInt (K_STUFE_GESCHAFFT);
	}

		
	public bool istUeberLevel1 ()
	{
		return getLevel () > 0 || getStufe () > 0;
	}

	public void erhoeheLevel (int pMaxPlaneten)
	{
		int lStapelHoehe = pMaxPlaneten / 2;
		int lLetztesLevel = getLevel ();

		if ((lLetztesLevel + 1) > lStapelHoehe) {
			int lNeueStufe = getStufe () + 1;

			if (lNeueStufe <= K_STUFE_FEYMAN) {
				PlayerPrefs.SetInt (K_STUFE_GESCHAFFT, lNeueStufe);
				PlayerPrefs.SetInt (K_LEVEL_GESCHAFFT, 1);
			} else {
			}
		} else {
			
			PlayerPrefs.SetInt (K_LEVEL_GESCHAFFT, lLetztesLevel + 1);
		}
	}

	public string lieferErreichteTitel ()
	{
		string lErg = "";
		if (!istUeberLevel1 ()) {
			lErg = "Aristoteles - Level 1";
		} else {
			if (getStufe () == K_STUFE_GALILEO) {
				lErg = "Galileo Galilei";
			} else if (getStufe () == K_STUFE_NEWTON) {
				lErg = "Isaac Newton";
			} else if (getStufe () == K_STUFE_FEYMAN) {
				lErg = "Richard Feynman";
			}

			if (getLevel () == 1) {
				return lErg + " I.";
			} else if (getLevel () == 2) {
				return lErg + " II.";
			} else if (getLevel () == 3) {
				return lErg + " III.";
			} else if (getLevel () == 4) {
				return lErg + " IV.";
			} else if (getLevel () == 5) {
				return lErg + " V.";
			} else if (getLevel () == 6) {
				return lErg + " VI.";
			} else if (getLevel () == 7) {
				return lErg + " VII.";
			} else if (getLevel () == 8) {
				return lErg + " VIII.";
			} else if (getLevel () == 9) {
				return lErg + " IX.";
			} else if (getLevel () == 10) {
				return lErg + " X.";
			} else if (getLevel () == 11) {
				return lErg + " XI.";
			} else if (getLevel () == 12) {
				return lErg + " XII.";
			} else if (getLevel () == 13) {
				return lErg + " XIII.";
			} else if (getLevel () == 14) {
				return lErg + " XIV.";
			}  else if (getLevel () == 15) {
				return lErg + " XV.";
			}  else if (getLevel () == 16) {
				return lErg + " XVI.";
			}  else if (getLevel () == 17) {
				return lErg + " XVII.";
			}  else if (getLevel () == 18) {
				return lErg + " XVIII.";
			}  else if (getLevel () == 19) {
				return lErg + " XIV.";
			}  else if (getLevel () == 20) {
				return lErg + " XX.";
			}  else if (getLevel () == 21) {
				return lErg + " XXI.";
			}  else if (getLevel () == 22) {
				return lErg + " XXII.";
			} else {
				return lErg + " King";
			}
		}

		return lErg;
	}
}
