using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using System;

public class StartStoppScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RawImage mBackgroundImage;

    public TextMeshProUGUI mTextMeshProUGUI;

    public Sprachenuebersetzer mSprachenuebersetzer;

    public GameObject mEinAusklappen;

    public GameObject mZurueck;

    public AttractElementVerwalter mAttractElementVerwalter;

    void Start()
    {
        setzeTextMeshProUndEinAusklappen();
    }

    public void setzeTextMeshProUndEinAusklappen()
    {
        bool lSpielAktiv = mAttractElementVerwalter.istSpielAmLaufen();
        if (lSpielAktiv)
        {
            mTextMeshProUGUI.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_STOPP);
        }
        else
        {
            mTextMeshProUGUI.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_START);
        }

        mEinAusklappen.GetComponent<EinAusklappscript>().setzePassend(lSpielAktiv);
        mEinAusklappen.SetActive(lSpielAktiv);
        mZurueck.SetActive(!lSpielAktiv);
    }

    public virtual void OnDrag(PointerEventData pPointerEventData)
    {
        // Nix
    }

    public virtual void OnPointerDown(PointerEventData pPointerEventData)
    {
        if (mAttractElementVerwalter.istSpielAmLaufen())
        {
            mAttractElementVerwalter.stoppeSpiel("gestoppt");
        }
        else
        {
            mAttractElementVerwalter.starteSpiel();
        }
        setzeTextMeshProUndEinAusklappen();
    }

    public virtual void OnPointerUp(PointerEventData pPointerEventData)
    {
        // Nix
    }
}
