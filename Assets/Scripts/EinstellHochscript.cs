using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EinstellHochscript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

	public RawImage mBackgroundImage;

	private float mLocalCount;

	private Einstellwert mEinstellwert;

	bool mAktiv;

	void Start()
	{
		mAktiv = false;
	}

	public virtual void OnDrag(PointerEventData pPointerEventData)
	{
		// Nix
	}

	private void Update()
	{
		if (mAktiv && mEinstellwert != null && !mEinstellwert.mKlickEinzeln)
		{
			mLocalCount = (mEinstellwert.mCount + Time.deltaTime * mEinstellwert.mTimeDivisior);

			if (mLocalCount > mEinstellwert.mOben)
			{
				mLocalCount = mEinstellwert.mOben;
			}

            mEinstellwert.mCount = mLocalCount;
		}
	}

	public virtual void OnPointerDown(PointerEventData pPointerEventData)
	{
		mAktiv = true;
	}

	public virtual void OnPointerUp(PointerEventData pPointerEventData)
	{
		mAktiv = false;

		if (mEinstellwert.mKlickEinzeln && mEinstellwert.mCount < mEinstellwert.mOben)
        {
			mEinstellwert.mCount = mEinstellwert.mCount + 1;
		}
	}

    public void SetEinstellwert(Einstellwert pEinstellwert)
    {
		mEinstellwert = pEinstellwert;
	}

}

