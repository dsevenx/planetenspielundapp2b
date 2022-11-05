using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EinstellRunterScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RawImage mBackgroundImage;

    private float mLocalCount;

    private Einstellwert mEinstellwert;

    public TextMeshProUGUI mTextMeshProUGUI;

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
        if (mEinstellwert != null)
        {

            if (mAktiv)
            {
                mLocalCount = (mEinstellwert.mCount - Time.deltaTime * mEinstellwert.mTimeDivisior);

                if (mLocalCount < mEinstellwert.mUnten)
                {
                    mLocalCount = mEinstellwert.mUnten;
                }

                mEinstellwert.mCount = mLocalCount;
            }

            mTextMeshProUGUI.text = mEinstellwert.mName + (int)mEinstellwert.mCount;
        }
    }

    public virtual void OnPointerDown(PointerEventData pPointerEventData)
    {
        mAktiv = true;
    }

    public virtual void OnPointerUp(PointerEventData pPointerEventData)
    {
        mAktiv = false;
    }

    public void SetEinstellwert(Einstellwert pEinstellwert)
    {
        mEinstellwert = pEinstellwert;
    }
}


