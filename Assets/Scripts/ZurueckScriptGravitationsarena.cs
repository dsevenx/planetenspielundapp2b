using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class ZurueckScriptGravitationsarena : MonoBehaviour
{
    public TextMeshProUGUI mTextMeshProUGUI;

    public Sprachenuebersetzer mSprachenuebersetzer;

    public float mTimeMessung;


    void Update()
    {
        mTextMeshProUGUI.text = mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_ZURUECK);


        if (Input.GetMouseButtonDown(0))
        {
            mTimeMessung = 0;
        }

        if (Input.GetMouseButton(0))
        {
            mTimeMessung = mTimeMessung + Time.deltaTime;

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mTimeMessung < 0.4)
            {
                SceneManager.LoadScene("PlanetenSpielSzene1");
            }
        }
    }
}
