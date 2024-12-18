using System;
using UnityEngine;

public class GeraeteIFs
{
	public Vector3 mTopLeft;
	public Vector3 mTopRechts;
	public Vector3 mUntenRechts;
	public Vector3 mUntenLinks;

	public float mWidthTeil;
	public float mHoeheTeil;
	public float mVerhaeltnis;

	private const float K_HOEHE_DER_CAMERA_UEBER_FLAECHE = 12.7f;

    internal void init(UnityEngine.Camera pCamera)
    {

		// Ortho Perspektive
		float orthoSize = pCamera.orthographicSize;

		float mHalfWidth = orthoSize * pCamera.aspect;
		float mHalfHeight = orthoSize;
		mVerhaeltnis = mHalfWidth / mHalfHeight;

		double grad = 30;
		double bogenmaß = grad * Math.PI / 180; // Umrechnung von Grad zu Bogenmaß
		double tangens = Math.Tan(bogenmaß);

		double lGegenKathede = tangens * K_HOEHE_DER_CAMERA_UEBER_FLAECHE;
		double lAspektBeruecksichtigt = lGegenKathede * mHalfWidth / mHalfHeight;

		// Vector3 cameraPositionOrtho = pCamera.transform.position;

	    mTopRechts =  new Vector3((float)(0.2f+ lAspektBeruecksichtigt), (float)(-3.3f + lGegenKathede), -0.2f);
		mTopLeft = new Vector3((float)(0.2f - lAspektBeruecksichtigt), (float)(-3.3f + lGegenKathede), -0.2f);
		mUntenRechts = new Vector3((float)(0.2f + lAspektBeruecksichtigt), (float)(-3.3f - lGegenKathede), -0.2f);
		mUntenLinks = new Vector3((float)(0.2f - lAspektBeruecksichtigt), (float)(-3.3f - lGegenKathede), -0.2f);

		mWidthTeil = (float)(lAspektBeruecksichtigt / 16);
		mHoeheTeil = (float)(lGegenKathede / 12);
	}

	internal Vector2 lieferPos(int pX, int pY)
	{
		return new Vector2((float)(mTopLeft.x + pX * mWidthTeil), (float)(mTopLeft.y - pY * mHoeheTeil));
	}
	internal float lieferSizeGUI(int mHoeheDisplay)
	{
		if (mHoeheDisplay > 1200)
		{
			return 30;
		}
		else
		{
			return 24;
		}
	}



	/*
	 *  ALT
	 */
	public bool istIPAD(int mBreiteDisplay, int mHoeheDisplay)
	{
		return mBreiteDisplay == 2048 && mHoeheDisplay == 1536
			|| mBreiteDisplay == 2732 && mHoeheDisplay == 2048
			|| mBreiteDisplay == 2388 && mHoeheDisplay == 1668
			|| mBreiteDisplay == 2224 && mHoeheDisplay == 1668
			|| mBreiteDisplay == 2560 && mHoeheDisplay == 1440
			|| mBreiteDisplay == 1024 && mHoeheDisplay == 768;
	}

	public bool istMatthiasAltnerPhone(int mBreiteDisplay, int mHoeheDisplay)
	{
		return mBreiteDisplay == 2532 && mHoeheDisplay == 1170
		;
	}
	public bool istIPHONE(int mBreiteDisplay, int mHoeheDisplay)
	{
		return mBreiteDisplay == 1624 && mHoeheDisplay == 750

			|| mBreiteDisplay == 2208 && mHoeheDisplay == 1242
			|| mBreiteDisplay == 2436 && mHoeheDisplay == 1125
			|| mBreiteDisplay == 2688 && mHoeheDisplay == 1242
			|| mBreiteDisplay == 1920 && mHoeheDisplay == 1080;
	}

   

    public bool istIPHONE_small (int mBreiteDisplay, int mHoeheDisplay)
	{
		return 
			   mBreiteDisplay == 1792 && mHoeheDisplay == 828
			|| mBreiteDisplay == 4624 && mHoeheDisplay == 2084

			|| mBreiteDisplay > 1782 && mBreiteDisplay < 1802 && mHoeheDisplay > 820 && mHoeheDisplay < 840;
	}

    internal bool istSigridPhone(int mBreiteDisplay, int mHoeheDisplay)
    {
		return mBreiteDisplay == 2280 && mHoeheDisplay == 1080;
	}

	internal bool istNeuesPhone(int mBreiteDisplay, int mHoeheDisplay)
	{
		return mBreiteDisplay == 1334 && mHoeheDisplay == 750;
	}

	public bool istNeuesIPAD(int mBreiteDisplay, int mHoeheDisplay)
	{
		return mBreiteDisplay == 2048 && mHoeheDisplay == 1536
			|| mBreiteDisplay == 2732 && mHoeheDisplay == 2048
			|| mBreiteDisplay == 2388 && mHoeheDisplay == 1668
			|| mBreiteDisplay == 2224 && mHoeheDisplay == 1668
			|| mBreiteDisplay == 2560 && mHoeheDisplay == 1440
			|| mBreiteDisplay == 1024 && mHoeheDisplay == 768;
	}
	
}

