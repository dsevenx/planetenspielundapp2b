using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class ZurueckScriptGravitationsarena : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public TextMeshProUGUI mTextMeshProUGUI;

    public Sprachenuebersetzer mSprachenuebersetzer;

    void Update()
    {
        mTextMeshProUGUI.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ZURUECK);
    }

    public virtual void OnDrag(PointerEventData pPointerEventData)
    {
        // Nix
    }

    public virtual void OnPointerDown(PointerEventData pPointerEventData)
    {
        SceneManager.LoadScene("PlanetenSpielSzene1");
    }

    public virtual void OnPointerUp(PointerEventData pPointerEventData)
    {
        // Nix
    }
}
