using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class InfoBilderVerwalter : MonoBehaviour
{
	public RawImage mRawImageBildInfo;

	public TextMeshProUGUI mTextMeshProBildInfo;

	public void aktiviereBild (string pNameInfoBild)
	{
		if (pNameInfoBild.StartsWith (Himmelskoerperverwalter.K_ZEICHEN_FUER_TEXT)) {
			mTextMeshProBildInfo.text = pNameInfoBild.Substring (1);
			mRawImageBildInfo.color = Color.black;
			mRawImageBildInfo.texture = null;
		} else {
			mTextMeshProBildInfo.text = "";
			mRawImageBildInfo.texture = Resources.Load ("Images/"+pNameInfoBild) as Texture2D;
			mRawImageBildInfo.color = Color.white;

		}

	}

}
