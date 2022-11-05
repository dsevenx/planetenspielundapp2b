using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class EinAusklappscript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RawImage mBackgroundImage;

    bool mAktiv;

    public TextMeshProUGUI mTextMeshProUGUI;

    public Sprachenuebersetzer mSprachenuebersetzer;

    public GameObject mOberCanvas;

    public AttractElementVerwalter mAttractElementVerwalter;


    void Start()
    {
        mAktiv = true;
        setzeTextMeshProUndKlappenEinAus();
    }

    public void setzeTextMeshProUndKlappenEinAus()
    {
        if (mAttractElementVerwalter.lieferEinstellMasse() < AttractElementVerwalter.K_START_MASSE_EINZEL_ELEMENT)
        {
            mOberCanvas.SetActive(false);
            mTextMeshProUGUI.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NO_MASSE);
        } else
        {
            if (mAktiv)
            {
                mTextMeshProUGUI.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EINKLAPPEN);
            }
            else
            {
                mTextMeshProUGUI.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_AUSKLAPPEN);
            }

            mOberCanvas.SetActive(mAktiv);
        }
    }

    public virtual void OnDrag(PointerEventData pPointerEventData)
    {
        // Nix
    }

    internal void setzePassend(bool mSpielLaeuft)
    {
        if (mSpielLaeuft)
        {
            mAktiv = true;
        } else
        {
            mAktiv = false;
        }
        setzeTextMeshProUndKlappenEinAus();
    }

    public virtual void OnPointerDown(PointerEventData pPointerEventData)
    {
        mAktiv = !mAktiv;
        setzeTextMeshProUndKlappenEinAus();
    }

    public virtual void OnPointerUp(PointerEventData pPointerEventData)
    {
        // Nix
    }
}

