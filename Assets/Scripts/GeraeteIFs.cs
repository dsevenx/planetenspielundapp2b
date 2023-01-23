using System;

public class GeraeteIFs
{
	public bool istIPAD (int mBreiteDisplay, int mHoeheDisplay )
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
		return mBreiteDisplay == 2532 && mHoeheDisplay == 1170;
	}
	public  bool istIPHONE (int mBreiteDisplay, int mHoeheDisplay)
	{
		return mBreiteDisplay == 1624 && mHoeheDisplay == 750
			|| mBreiteDisplay == 2208 && mHoeheDisplay == 1242
			|| mBreiteDisplay == 2436 && mHoeheDisplay == 1125
			|| mBreiteDisplay == 2688 && mHoeheDisplay == 1242
			|| mBreiteDisplay == 1920 && mHoeheDisplay == 1080;
	}

	public  bool istIPHONE_small (int mBreiteDisplay, int mHoeheDisplay)
	{
		return mBreiteDisplay == 1334 && mHoeheDisplay == 750
			|| mBreiteDisplay == 1792 && mHoeheDisplay == 828
			|| mBreiteDisplay == 4624 && mHoeheDisplay == 2084

			|| mBreiteDisplay > 1782 && mBreiteDisplay < 1802 && mHoeheDisplay > 820 && mHoeheDisplay < 840;
	}

    internal bool istSigridPhone(int mBreiteDisplay, int mHoeheDisplay)
    {
		return mBreiteDisplay == 2280 && mHoeheDisplay == 1080;

	}
}

