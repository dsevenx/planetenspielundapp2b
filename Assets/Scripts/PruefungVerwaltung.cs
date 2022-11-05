using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruefungVerwaltung : MonoBehaviour
{

    private Dictionary<int, Pruefungdatum> mMyPruefungDict;

    private const string K_ART_DER_FRAGE_HIMMELSVERWALTER = "aus Himmelsverwalter";

    private const string K_ART_DER_FRAGE_DIREKT = "direkt";

    private const string K_AKTUELLE_FRAGE = "AKTUELLE_FRAGE";

    public const int K_ANZ_FRAGEN =10;

    public Sprachenuebersetzer mSprachenuebersetzer;

    public HimmelskoerperverwalterBase mHimmelskoerperverwalterBase;

    private int mIndexPruefung;

    public bool mEndeErreicht;

    public Pruefungdatum lieferFrage()
    {
        return mMyPruefungDict[getAktuelleFrageIndex()];
    }

    public int getAktuelleFrageIndex()
    {
        return PlayerPrefs.GetInt(K_AKTUELLE_FRAGE);
    }

    private void erzeugeFrage(string pArtDerFrage, InterfacePruefung pInterfacePruefung)
    {

        Pruefungdatum lPruefungdatum = new Pruefungdatum();

        lPruefungdatum.mAntwortA = pInterfacePruefung.ermittelAntwort_A();
        lPruefungdatum.mAntwortA_Erklaerung = pInterfacePruefung.ermittelAntwort_A_Erklaerung();
        lPruefungdatum.mAntwortB = pInterfacePruefung.ermittelAntwort_B();
        lPruefungdatum.mAntwortB_Erklaerung = pInterfacePruefung.ermittelAntwort_B_Erklaerung();
        lPruefungdatum.mAntwortC = pInterfacePruefung.ermittelAntwort_C();
        lPruefungdatum.mAntwortC_Erklaerung = pInterfacePruefung.ermittelAntwort_C_Erklaerung();
        lPruefungdatum.mAntwortD = pInterfacePruefung.ermittelAntwort_D();
        lPruefungdatum.mAntwortD_Erklaerung = pInterfacePruefung.ermittelAntwort_D_Erklaerung();

        lPruefungdatum.mArtDerFrage = pArtDerFrage;
        lPruefungdatum.mFrage = pInterfacePruefung.ermittelFrage();
        lPruefungdatum.mKorrekteAntwort = pInterfacePruefung.ermittelKorrekteButton();
      
        mMyPruefungDict.Add(mIndexPruefung, lPruefungdatum);
        mIndexPruefung++;
    }

    public void ermittelNaechsteFrage()
    {
        int lAktuell = getAktuelleFrageIndex();

        if (lAktuell < K_ANZ_FRAGEN)
        {
            PlayerPrefs.SetInt(K_AKTUELLE_FRAGE, lAktuell + 1);
        }

        if (getAktuelleFrageIndex() == K_ANZ_FRAGEN) { 

            mEndeErreicht = true;
        }
        else
        {
            mEndeErreicht = false;
        }
    }

    internal void ermittelFragen(int pThema)
    {
        mEndeErreicht = false;

        mMyPruefungDict = new Dictionary<int, Pruefungdatum>();
        mIndexPruefung = 1;
        PlayerPrefs.SetInt(K_AKTUELLE_FRAGE,1); // auf erste Frage

        List<String> lFragenDieNurEinmalSeinDuefen = new List<String>();
        for (int i = 0; mMyPruefungDict.Count < 10; i++)
        {
            int lProzent = UnityEngine.Random.Range(0, K_ANZ_FRAGEN*10) +1;

            if (pThema == PruefungGUISteuerung.K_THEMA_PLANETEN)
            {
                if (lProzent <= 7)  
                {
                  erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                        new PruefungWerHatAmXXXMonde(mHimmelskoerperverwalterBase, mSprachenuebersetzer, true)
                   );
                }
                else if (lProzent <= 14)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatAmXXXMonde(mHimmelskoerperverwalterBase, mSprachenuebersetzer, false)
                    );
                }
                else if (lProzent <= 21)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDichte(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, true)
                    );
                }
                else if (lProzent <= 28)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDichte(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, false)
                    );
                }
                else if (lProzent <= 35)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXMasse(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, true)
                    );
                }
                else if (lProzent <= 42)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXMasse(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, false)
                    );
                }
                else if (lProzent <= 49)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXSonnenentfernung(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, true)
                    );
                }
                else if (lProzent <= 56)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXSonnenentfernung(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, false)
                    );
                }
                else if (lProzent <= 63)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDurchmesser(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, true)
                    );
                }
                else if (lProzent <= 70)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDurchmesser(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, false)
                    );
                }
                else if (lProzent <= 77)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerAmXXXXTemperatur(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, true)
                    );
                }
                else if (lProzent <= 85)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerAmXXXXTemperatur(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_PLANET, false)
                    );
                }
                else if (lProzent <= 93)//i.O
                {
                    if (!istSchonDrin(lFragenDieNurEinmalSeinDuefen, "PruefungWerHatPhobosUndDeimos"))
                    {
                        lFragenDieNurEinmalSeinDuefen.Add("PruefungWerHatPhobosUndDeimos");
                        erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                             new PruefungWerHatPhobosUndDeimos(mHimmelskoerperverwalterBase, mSprachenuebersetzer, PruefungGUISteuerung.K_THEMA_PLANETEN)
                        );
                    }
                }
                else if (lProzent <= 100)//i.O
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatDiesenMond(mHimmelskoerperverwalterBase, mSprachenuebersetzer, PruefungGUISteuerung.K_THEMA_PLANETEN)
                    );
                }
            }
            else if (pThema == PruefungGUISteuerung.K_THEMA_STERNE)
            {
                if (lProzent <= 12)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXMasse(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, true)
                    );
                }
                else if (lProzent <= 25)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXMasse(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, false)
                    );
                }
                else if (lProzent <= 38)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXSonnenentfernung(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, true)
                    );
                }
                else if (lProzent <= 50)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXSonnenentfernung(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, false)
                    );
                }
                else if (lProzent <= 63)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDurchmesser(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, true)
                    );
                }
                else if (lProzent <= 75)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDurchmesser(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, false)
                    );
                }

                else if (lProzent <= 87)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerAmXXXXTemperatur(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, true)
                    );
                }
                else if (lProzent <= 100)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerAmXXXXTemperatur(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_STERN, false)
                    );
                }
            }
            else
            {
                if (lProzent <= 7)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                          new PruefungWerHatAmXXXMonde(mHimmelskoerperverwalterBase, mSprachenuebersetzer, true)
                     );
                }
                else if (lProzent <= 14)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatAmXXXMonde(mHimmelskoerperverwalterBase, mSprachenuebersetzer, false)
                    );
                }
                else if (lProzent <= 21)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDichte(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, true)
                    );
                }
                else if (lProzent <= 28)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDichte(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, false)
                    );
                }
                else if (lProzent <= 35)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXMasse(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, true)
                    );
                }
                else if (lProzent <= 42)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXMasse(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, false)
                    );
                }
                else if (lProzent <= 49)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXSonnenentfernung(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, true)
                    );
                }
                else if (lProzent <= 56)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXSonnenentfernung(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, false)
                    );
                }
                else if (lProzent <= 63)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDurchmesser(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, true)
                    );
                }
                else if (lProzent <= 70)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatXXXDurchmesser(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, false)
                    );
                }
                else if (lProzent <= 77)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerAmXXXXTemperatur(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, true)
                    );
                }
                else if (lProzent <= 85)
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerAmXXXXTemperatur(mHimmelskoerperverwalterBase, mSprachenuebersetzer, Sprachenuebersetzer.K_ALL, false)
                    );
                }
                else if (lProzent <= 93)//i.O
                {
                    if (!istSchonDrin(lFragenDieNurEinmalSeinDuefen, "PruefungWerHatPhobosUndDeimos"))
                    {
                        lFragenDieNurEinmalSeinDuefen.Add("PruefungWerHatPhobosUndDeimos");
                        erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                             new PruefungWerHatPhobosUndDeimos(mHimmelskoerperverwalterBase, mSprachenuebersetzer, PruefungGUISteuerung.K_THEMA_PLANETEN)
                        );
                    }
                }
                else if (lProzent <= 100)//i.O
                {
                    erzeugeFrage(K_ART_DER_FRAGE_HIMMELSVERWALTER,
                         new PruefungWerHatDiesenMond(mHimmelskoerperverwalterBase, mSprachenuebersetzer, PruefungGUISteuerung.K_THEMA_PLANETEN)
                    );
                }
            }
         }
    }

    private bool istSchonDrin(List<String> lFragenDieNurEinmalSeinDuefen, string pText)
    {
        foreach (var lPruefungsname in lFragenDieNurEinmalSeinDuefen)
        {
            if (lPruefungsname.Equals(pText))
            {
                return true;
            }
        }
        return false;
    }
}
