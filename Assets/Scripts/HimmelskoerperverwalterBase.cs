using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HimmelskoerperverwalterBase : MonoBehaviour
{

    public Dictionary<int, HimmelskoerperData> mMyHimmelskoerperDict;

    public Sprachenuebersetzer mSprachenuebersetzer;

    public const string K_ZEICHEN_FUER_TEXT = "#";

    public const string K_ID_MOND_VERGLEICH = "MOND";

    public const string K_ID_MASSE_VERGLEICH = "MASSE";

    public const string K_ID_DICHTE_VERGLEICH = "DICHTE";

    public const string K_ID_SONNENENFERNUNG_VERGLEICH = "SONNEN_DISTANZ";

    public const string K_ID_TEMPERATUR_VERGLEICH = "TEMPERATUR_VERGLEICH";

    public const string K_ID_DURCHMESSER_VERGLEICH = "DURCHMESSER_VERGLEICH";

    void Start()
    {
        Init();
    }

    public void Init()
    {
        if (mMyHimmelskoerperDict == null || mMyHimmelskoerperDict.Count == 0)
        {
            mSprachenuebersetzer = GameObject.FindGameObjectWithTag("Sprachenuebersetzer").GetComponent<Sprachenuebersetzer>();

            // 0 K = -270 Grad

            // 1 Erdmasse = 5,9722 10 24 KG
            // Massen 8.93 10 23 kg   
            // Durchmesser 3630

            mMyHimmelskoerperDict = new Dictionary<int, HimmelskoerperData>();

            /**
			erzeugeInfoZumHimmelskoeper(
	Himmelskoerper.K_PLANET_J1407B,
	"Planet J1407B",
	0.00000000003f, // Masse
	5236000000f, // Sonnenentfernung
	1, // Anzahl Monde
	0.55f, // Dichte
	15, // Durchmesser
	-43, // Max
	-93, // Min
	Sprachenuebersetzer.K_LICHTJAHRE,
	new string[2] {
					"Komet_Halley_pillars",
					K_ZEICHEN_FUER_TEXT +
					mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KOMET_HALLEY_TEXT)
	},
	0.8f, // Helligkeit
	false, // Ringe
	Sprachenuebersetzer.K_PLANET);
            **/


            erzeugeInfoZumHimmelskoeper(
                Himmelskoerper.K_J1407,
                "J1407",
                2997000f, // Masse
                434, // Sonnenentfernung
                0, // Anzahl Monde
                1.41f, // Dichte
                125226, // Durchmesser mit ringe
                4400, // Max
                4400, // Min
                Sprachenuebersetzer.K_LICHTJAHRE,
                new string[2] {
                    "J1407_J1407B",
                    K_ZEICHEN_FUER_TEXT +
                    mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_1407_TEXT)
                },
                0.9f, // Helligkeit
                false, // Ringe
                Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_KOMET_HALLEY, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KOMET_HALLEY),
                0.00000000003f, 5236000000f, 0, 0.55f, 15, -43, -93,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {"Komet_Halley_pillars", K_ZEICHEN_FUER_TEXT +
                    mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KOMET_HALLEY_TEXT)
                }, 0.6f, false, Sprachenuebersetzer.K_KOMET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_KOMET_NEOWISE, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KOMET_NEOWISE),
                0.00000000001f, 46670000000f, 0, 0.55f, 5, -43, -93,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {"Komet_Neowise", K_ZEICHEN_FUER_TEXT +
                    mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KOMET_NEOWISE_TEXT)
                }, 0.7f, false, Sprachenuebersetzer.K_KOMET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_KOMET_TEBBUTT, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KOMET_TEBBUTT),
                0.00000000003f, 14960000000f, 0, 0.55f, 61, -43, -93,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {"Komet_Tebutt", K_ZEICHEN_FUER_TEXT +
                    mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KOMET_TEBBUTT_TEXT)
                }, 1.6f, false, Sprachenuebersetzer.K_KOMET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_KOMET_TSCHURI, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_KOMET_TSCHURI),
                0.000000000001674f, 837760000f, 0, 0.53f,
                4, 80, 80, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "tschuri-neu_sto_body",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KOMET_TSCHURI_TEXT)
                }, 0.2f, false, Sprachenuebersetzer.K_KOMET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_TRITON, "Triton", 0.00359f, 4509000000f, 0, 2.147f, 2707, -200, -237,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {"triton", K_ZEICHEN_FUER_TEXT +
                    mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_TRITON)
                }, 0.1f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_NEPTUN, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_ERDE, "Erde", 1f, 149600000f, 1, 5.5f, 12742, 60, -95,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "amazon-rainforest-covers", K_ZEICHEN_FUER_TEXT +
                mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_ERDE_TEXT)
            }, 0.4f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_JUPITER, "Jupiter", 317, 778500000f, 79, 1.3f, 139820, -100, -100,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Jupiter_GroessenvergleichJupiterMondeErde", K_ZEICHEN_FUER_TEXT +
                mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_JUPITER)
            }, 0.4f, true, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_SATURN, "Saturn", 95, 1427000000f, 82, 0.6f, 116460, -130, -130,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "Saturn_RingBild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_SATURN)
            }, 0.2f, true, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_URANUS, "Uranus", 14, 2884000000f, 27, 1.3f, 50724, -208, -208,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "UranusBilder",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_URANUS)
            }, 0.2f, true, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_NEPTUN, "Neptun", 17, 4509000000f, 14, 1.6f, 49244, -220, -220,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {"Neptune_storms",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_NEPTUN)
            }, 0.1f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MARS, "Mars", 0.1f, 227900000f, 2, 3.9f, 6779, 25, -120,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "Mars_FlugbahnMarsMonde",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MARS)
            }, 0.3f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MERKUR, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_MERKUR), 0.05f, 57910000, 0, 5.4f, 4879, 430, -170,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {"MerkurSchrumpft",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MERKUR_TEXT)
            }, 0.5f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_VENUS, "Venus", 0.8f, 108200000, 0, 5.2f, 12104, 500, 420,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {   "Maat_Mons_on_Venus",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_VENUS)
            }, 0.45f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_SONNE, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_SONNE), 333054f, 0, 0, 1.41f, 1391000, 4750, 4750,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "Sonnen_Sonneflecken"
                    , K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_SONNE_TEXT)
            }, 1f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_BETEIGEUZE, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BETEIGEUZE), 3663597f, 642, 0, 0.41f, 1234000000, 3226, 3226,
                Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Betelgeuse_VLT", K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_BETEIGEUZE_TEXT)
            }, 1.2f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_IO, "IO", 0.015f, 778500000f, 0, 3.53f, 3630, -130, -200,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "Io_Tupan_Patera", K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_IO)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_JUPITER, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_GANYMED, "Ganymed", 0.024f, 778500000f, 0, 1.936f, 5262, 70, -152,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "ganymed1-2",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_GANYMED)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_JUPITER, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_EUROPA, "Europa", 0.008f, 778500000f, 0, 3.01f, 3121, -160, -220,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Europa_Chaos",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_EUROPA)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_JUPITER, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_KALLISTO, "Kallisto", 0.018f, 778500000f, 0, 1.83f, 4821, 80, -165,
                Sprachenuebersetzer.K_KILOMETER, new string[2] {"KalistoEisbild", K_ZEICHEN_FUER_TEXT +
                mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KALLISTO)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_JUPITER, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_ERDMOND, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_EARTH_MOON), 0.012f, 149600000f, 0, 3.34f, 3474, 130, -160,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "mondphasen", K_ZEICHEN_FUER_TEXT +
                mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_EARTH_MOON_TEXT)
            }, 0.3f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_ERDE, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_CERES, "Ceres", 0.00015f, 414000000f,
                0, 2.08f, 946, -73, -143, Sprachenuebersetzer.K_KILOMETER, new string[2] {"Ceres_helle_fleck",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_CERES)
            }, 0.15f, false, Sprachenuebersetzer.K_ZWERGPLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            // NEU20226
            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_SEDNA, "Sedna", 0.000285f, 140200000000f,
                 0, 2.08f, 995, -240, -240, Sprachenuebersetzer.K_KILOMETER, new string[2] {"Sedna_Bild_2",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_SEDNA)
            }, 0.15f, false, Sprachenuebersetzer.K_ZWERGPLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_KEPLER_16B, "Kepler-16b", 106, 200f,
                 0, 0.96f, 105000, -70, -100, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {"Kepler_16B_2",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KEPLER_16B)
            }, 0.6f, false, Sprachenuebersetzer.K_KEINE_MODNDE_ENTDECKT, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);
 
            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MIRANDA, "Miranda", 0.000011f, 2884000000f,
                 0, 1.2f, 471, -187, -187, Sprachenuebersetzer.K_KILOMETER, new string[2] {"Miranda_2",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MIRANDA)
            }, 0.25f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_URANUS, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);
 
            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MAGNETAR, "Magnetar SGR 1806-20", 466242, 50000f,
                 0, 100000000000000f, 20, 10000000,10000000, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {"Magnertar_2",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MAGNETAR)
            }, 1.0f, false, Sprachenuebersetzer.K_NEUTRONENSTERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);
 
   
            // NEU20226

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_TITAN, "Titan", 0.0225f, 1427000000f,
                0, 1.88f, 5150, -180, -180, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Titan_sandstuerme",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_TITAN)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_SATURN, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_HARALDLESCH, "Haraldlesch", 0.0000001f, 337881751f, 0, 5.1f, 50, -75, -230,
                Sprachenuebersetzer.K_KILOMETER, new string[2] { "LeschGassner", K_ZEICHEN_FUER_TEXT +
                mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_HARALDLESCH)
            }, 0.01f, false, Sprachenuebersetzer.K_ASTEROID, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MAKEMAKE, "Makemake", 0.0005f, 6770000000f,
             1, 3.2f, 1430, -229, -241, Sprachenuebersetzer.K_KILOMETER, new string[2] { "makemakemitmond",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MAKEMAKE)
            }, 0.2f, false, Sprachenuebersetzer.K_ZWERGPLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_HAUMEA, "Haumea", 0.0006f, 6475000000f,
            2, 2.0f, 1632, -229, -241, Sprachenuebersetzer.K_KILOMETER, new string[2] { "haumeamitmond",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_HAUMEA)
            }, 0.2f, false, Sprachenuebersetzer.K_ZWERGPLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_PLUTO, "Pluto", 0.0022f, 5900000000f,
                5, 1.88f, 2376, -218, -240, Sprachenuebersetzer.K_KILOMETER, new string[2] { "plutomonde",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_PLUTO)
            }, 0.2f, false, Sprachenuebersetzer.K_ZWERGPLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_CHARON, "Charon", 0.00025f, 5900000000f,
                0, 1.71f, 1212, -220, -220, Sprachenuebersetzer.K_KILOMETER, new string[2] { "PlutoMitCharonBeule",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_CHARON)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_PLUTO, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_ERIS, "Eris", 0.0026f, 10134000000f,
                1, 2.52f, 2326, -243, -243, Sprachenuebersetzer.K_KILOMETER, new string[2] { "Eris_and_dysnomia",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_ERIS)
            }, 0.2f, false, Sprachenuebersetzer.K_ZWERGPLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_ARIADNE, "Ariadne", 0.0000002f, 335458265f, 0,
                3.5f, 66, -75, -230, Sprachenuebersetzer.K_KILOMETER, new string[2] { "AriadneFormen",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_ARIADNE)
            }, 0.2f, false, Sprachenuebersetzer.K_ASTEROID, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_PALLAS, "Pallas", 0.0000351f, 414800000f,
                0, 3f, 545, -75, -230, Sprachenuebersetzer.K_KILOMETER, new string[2] { "PallasHubbel",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_PALLAS)
            }, 0.01f, false, Sprachenuebersetzer.K_ASTEROID, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_VESTA, "Vesta", 0.0000433f, 346000000f,
                0, 3.45f, 516, -75, -230, Sprachenuebersetzer.K_KILOMETER, new string[2] { "Vesta_200",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_VESTA)
            }, 0.01f, false, Sprachenuebersetzer.K_ASTEROID, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_SIRIUS_A, "Sirius A", 666087f, 8.6f,
                0, 0.568f, 2380600, 9940, 9940, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] { "SiriusA_Bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_SIRIUS_A)
            }, 1.5f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_SIRIUS_B, "Sirius B", 326370f, 8.6f,
                0, 2380000f, 12100, 25000, 25000, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "SiriusB_Bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_SIRIUS_B)
            }, 0.8f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_ALPHA_ZENTAURI_A, "Alpha Centauri A", 367998f, 4.34f,
                0, 1.4f,
                852322, 5810, 5810, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "alpha-centauri",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_ALPHA_CENTAURI_A)
            }, 1.0f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_ALPHA_ZENTAURI_B, "Alpha Centauri B", 311050f, 4.34f,
             0, 1.5f,
             600943, 5260, 5260, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "alpha-centauri",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_ALPHA_CENTAURI_B)
            }, 1.0f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_PROXIMA_ZENTAURI, "Proxima Centauri", 40956f, 4.24f,
                0, 56.8f,
                214550, 3042, 3042, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "BildProximaCentauri",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_PROXIMA_CENTAURI)
            }, 0.8f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_PROXIMA_ZENTAURI_B, "Proxima Centauri B", 1.27f, 4.24f,
                0, 5f,
                14010, -39, -39, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "proxima_erde",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_PROXIMA_CENTAURI_B)
            }, 0.2f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);


            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_SAGITTARIUS_A, "Sagittarius A*", 1365424100000f, 26673f,
                0, 3300f,
                22500000, -270, -270, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "saggitariusBild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_SAGGITARIUS_A)
            }, 0.0f, false, Sprachenuebersetzer.K_SCHWARZES_LOCH, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_M87, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_M87), 2164696703800000f, 54800000f,
                0, 3300f,
                9724000000, -270, -270, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "M87Bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_M87_TEXT)
            }, 0.0f, false, Sprachenuebersetzer.K_SCHWARZES_LOCH, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_R_CORONA_BOREALIS, "R-Coronae-Borealis", 283096f, 6040f,
            0, 0.0002f,
            118235000, 7000, 5000, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Corona-Borealis-R-CrB_ST",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_R_CORONA_BOREALIS)
                 }, 0.95f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_STEVENSON, "Stephenson 2-18", 13323760000f, 20000f,
                 0, 0.000024f,
             2990650000, 3200, 3200, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Stephenson_2-18_zoom",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_STEPHENSON)
            }, 1.1f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_CANIS_MAJOPRIS, "Canis Majoris", 8325750f, 3900f,
                 0, 0.000025f,
            2156000000, 3500, 3500, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Canis_Majoris_zoom",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_CANIS_MAJOPRIS)
            }, 1.6f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_R136a1, "R136a1", 66606000f, 163000f,
                  0, 0.008f,
              55000000, 50000, 46000, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "R136a1_zoom",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_R136A1)
             }, 1.7f, false, Sprachenuebersetzer.K_STERN, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);


            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_KEPPLER_160D, "Kepler-160-D", 1.9f, 3140f,
              0, 5.5f,
             24200, 60, -95, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Kepler160DBild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_KEPPLER_160D)
            }, 0.4f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MOND_ENCELADUS, "Enceladus", 0.000018f, 1427000000f,
               0, 1.6f,
              504, -130, -240, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "EnceladusBild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MOND_ENCELADUS)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_SATURN, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MOND_JAPETUS, "Japetus", 0.0095f, 1427000000f,
            0, 1.27f, 1436, -180, -180, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Iapetus_equatorial_ridge",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MOND_JAPETUS)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_SATURN, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MOND_STYX, "Styx", 0.00000000126f, 7400000000f,
            0, 5.0f,
            16, -215, -240, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Styx_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MOND_STYX)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_PLUTO, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MOND_KERBEROS, "Kerberos", 0.00000000502f, 7400000000f,
             0, 5.0f, 12, -215, -240, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Kerberos_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MOND_KERBEROS)
             }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_PLUTO, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MOND_HYDRA, "Hydra", 0.00000001507f, 7400000000f,
            0, 5.0f,
            51, -215, -240, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Hydra_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MOND_HYDRA)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_PLUTO, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_MOND_NIX, "Nix", 0.00000001507f, 7400000000f,
            0, 5.0f,
            50, -215, -240, Sprachenuebersetzer.K_KILOMETER, new string[2] {
                "Nix_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_MOND_NIX)
            }, 0.2f, false, Sprachenuebersetzer.K_MOON, Himmelskoerper.K_PLUTO, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);



            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_BRAUNER_ZWERG_SCHOLZ,
                mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_BRAUNER_ZWERG_SCHOLZ), 20670.00f, 20f,
            0, 99.45f, 150000, 3050, 1800, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Scholz_Stern_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_BRAUNER_ZWERG_SCHOLZ_TEXT)
            }, 0.5f, false, Sprachenuebersetzer.K_BRAUNER_ZWERG, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_BRAUNER_ZWERG_SDSS_1416_13B, "SDSS 1416+13B", 23850f, 13.3f,
            0, 99.45f,
            150000, 227, 227, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "SDSS_1416_13B_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_BRAUNER_ZWERG_SDSS_1416_13B)
            }, 0.5f, false, Sprachenuebersetzer.K_BRAUNER_ZWERG, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);


            //            (int pIndexPlanet, string pName, float pMasseinErdMasse,
            //             float pSonneEntfernung, int pAnzahlmonde, float pDichte,
            //             long mDurchmesser, int pMaxTemperatur, int pMinTemperatur,
            //             int pEinheitEntfernung, string[] pBildInfos, float pLichtIntensitaet,
            //             bool pRinge, int pArtHimmelskoerper)

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_NEBEL_HEXENBESEN, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NEBEL_HEXENBESEN), 8991000f, 1400f,
             0, 0.00000000000000000002f,
             331100000000000, 1000, -250, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Hexenbesen_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_NEBEL_HEXENBESEN_TEXT)
           }, 0.6f, false, Sprachenuebersetzer.K_NEBEL, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);


            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_NEBEL_PFERDEKOPF, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NEBEL_PFERDEKOPF), 8991000f, 1500f,
           0, 0.00000000000000000003f,
           28500000000000, 1000, 1000, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Pferdekopf_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_NEBEL_PFERDEKOPF_TEXT)
           }, 0.7f, false, Sprachenuebersetzer.K_NEBEL, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_NEBEL_ORION, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NEBEL_ORION), 699364000f, 1344f,
          0, 0.000000000000000000001f,
          227100000000000, 1000, -270, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Orion_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_NEBEL_ORION_TEXT)
          }, 0.7f, false, Sprachenuebersetzer.K_NEBEL, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_NEBEL_KREBS, mSprachenuebersetzer.lieferWort(Sprachenuebersetzer.K_NEBEL_KREBS),
                3330540f, 6300f, 0, 0.00000000000000000001f, 104100000000000,
            500000, -240, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Krebs_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_NEBEL_KREBS_TEXT)
            }, 0.7f, false, Sprachenuebersetzer.K_NEBEL, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            /*
             * int pIndexPlanet, string pName, float pMasseinErdMasse,
                                              float pSonneEntfernung, int pAnzahlmonde, float pDichte,
                                              long mDurchmesser, int pMaxTemperatur, int pMinTemperatur,
                                              int pEinheitEntfernung, string[] pBildInfos, float pLichtIntensitaet,
                                              bool pRinge, int pArtHimmelskoerper,
                                              int pHeimatplanet
            */
            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_WASP_189_B, "WASP-189b",
                633f, 322f, 0, 0.26f, 223712,
                7730, 3470, Sprachenuebersetzer.K_LICHTJAHRE, new string[2] {
                "Wasp_189_bild",
                K_ZEICHEN_FUER_TEXT + mSprachenuebersetzer.lieferWort (Sprachenuebersetzer.K_WASP_189_B_TEXT)
            }, 0.9f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_MAX);

            erzeugeInfoZumHimmelskoeper(Himmelskoerper.K_LEER_PLANET, "", 0.0f, 0f,
                0, 0f, 2, 0, 0, Sprachenuebersetzer.K_KILOMETER, new string[0] { }, 0.2f, false, Sprachenuebersetzer.K_PLANET, Himmelskoerper.K_LEER_PLANET, ConfigInfoScript.K_BUTTON_ANZAHL_EINFACH);
        }
    }

    internal HimmelskoerperData lieferEinHimmelsobjekt(int pSternOderPlanet)
    {
        List<HimmelskoerperData> lRelevanteHimmelskoeper = new List<HimmelskoerperData>();

        foreach (int lHimmelskoerper in getMyHimmelskoerperDict().Keys)
        {
            if (getMyHimmelskoerperDict()[lHimmelskoerper].mArtHimmelskoerper.Equals(pSternOderPlanet)
                && lHimmelskoerper != Himmelskoerper.K_LEER_PLANET)
            {
                lRelevanteHimmelskoeper.Add(getMyHimmelskoerperDict()[lHimmelskoerper]);
            }
        }

        int lZufallsindex = UnityEngine.Random.Range(0, lRelevanteHimmelskoeper.Count);

        return lRelevanteHimmelskoeper[lZufallsindex];
    }

    public void erzeugeInfoZumHimmelskoeper(int pIndexPlanet, string pName, float pMasseinErdMasse,
                                              float pSonneEntfernung, int pAnzahlmonde, float pDichte,
                                              long mDurchmesser, int pMaxTemperatur, int pMinTemperatur,
                                              int pEinheitEntfernung, string[] pBildInfos, float pLichtIntensitaet, bool pRinge, int pArtHimmelskoerper,
                                              int pHeimatplanet, int pKartenanzahlZugehoerig)
    {

        HimmelskoerperData lHimmelskoerperData = new HimmelskoerperData();

        lHimmelskoerperData.mIndex = pIndexPlanet;
        lHimmelskoerperData.mName = pName;
        lHimmelskoerperData.mMasse = pMasseinErdMasse;
        lHimmelskoerperData.mEntfernungSonne = pSonneEntfernung;
        lHimmelskoerperData.mEntfernungSonneEinheit = pEinheitEntfernung;
        lHimmelskoerperData.mAnzahlMonde = pAnzahlmonde;
        lHimmelskoerperData.mDichte = pDichte;
        lHimmelskoerperData.mDurchmesser = mDurchmesser;
        lHimmelskoerperData.mMaxTemperatur = pMaxTemperatur;
        lHimmelskoerperData.mMinTemperatur = pMinTemperatur;
        lHimmelskoerperData.mLichtIntensitaet = pLichtIntensitaet;
        lHimmelskoerperData.mRingeVorhanden = pRinge;
        lHimmelskoerperData.mHeimatplanet = pHeimatplanet;
        lHimmelskoerperData.mArtHimmelskoerper = pArtHimmelskoerper;
        lHimmelskoerperData.mKartenanzahlZugehoerig = pKartenanzahlZugehoerig;
        lHimmelskoerperData.mMyBildInfos = new Dictionary<int, string>();
        int lIndexBild = 1;
        foreach (string lBildinfo in pBildInfos)
        {
            lHimmelskoerperData.mMyBildInfos.Add(lIndexBild, lBildinfo);
            lIndexBild++;
        }

        mMyHimmelskoerperDict.Add(pIndexPlanet, lHimmelskoerperData);

    }



    public Dictionary<int, HimmelskoerperData> getMyHimmelskoerperDict()
    {

        Init();

        return mMyHimmelskoerperDict;
    }


    public List<HimmelskoerperData> liefer4HimmelskoerperFuerArt(int pSternOderPlanet, string pArtVergleich)
    {
        List<HimmelskoerperData> lErg = new List<HimmelskoerperData>();

        List<HimmelskoerperData> lRelevanteHimmelskoeper = new List<HimmelskoerperData>();

        foreach (int lHimmelskoerper in getMyHimmelskoerperDict().Keys)
        {
            if ((getMyHimmelskoerperDict()[lHimmelskoerper].mArtHimmelskoerper.Equals(pSternOderPlanet) || pSternOderPlanet == Sprachenuebersetzer.K_ALL)
                && lHimmelskoerper != Himmelskoerper.K_LEER_PLANET)
            {
                lRelevanteHimmelskoeper.Add(getMyHimmelskoerperDict()[lHimmelskoerper]);
            }
        }

        for (int i = 0; lErg.Count < 4; i++)
        {
            int lZufallsindex = UnityEngine.Random.Range(0, lRelevanteHimmelskoeper.Count);

            bool lSchonMitMondDa = false;
            foreach (var lHimmelskoerperDataErg in lErg)
            {
                if (lHimmelskoerperDataErg.mAnzahlMonde == lRelevanteHimmelskoeper[lZufallsindex].mAnzahlMonde
                    && K_ID_MOND_VERGLEICH.Equals(pArtVergleich)
                    ||
                    lHimmelskoerperDataErg.mMasse == lRelevanteHimmelskoeper[lZufallsindex].mMasse
                    && K_ID_MASSE_VERGLEICH.Equals(pArtVergleich)
                    ||
                    lHimmelskoerperDataErg.mDichte == lRelevanteHimmelskoeper[lZufallsindex].mDichte
                    && K_ID_DICHTE_VERGLEICH.Equals(pArtVergleich)
                    ||
                    lHimmelskoerperDataErg.mDurchmesser == lRelevanteHimmelskoeper[lZufallsindex].mDurchmesser
                    && K_ID_DURCHMESSER_VERGLEICH.Equals(pArtVergleich)
                    ||
                    lHimmelskoerperDataErg.mEntfernungSonne == lRelevanteHimmelskoeper[lZufallsindex].mEntfernungSonne
                    && lHimmelskoerperDataErg.mEntfernungSonneEinheit == lRelevanteHimmelskoeper[lZufallsindex].mEntfernungSonneEinheit
                    && K_ID_SONNENENFERNUNG_VERGLEICH.Equals(pArtVergleich)
                    ||
                    (lHimmelskoerperDataErg.mMaxTemperatur == lRelevanteHimmelskoeper[lZufallsindex].mMaxTemperatur
                    || lHimmelskoerperDataErg.mMinTemperatur == lRelevanteHimmelskoeper[lZufallsindex].mMinTemperatur)
                    && K_ID_TEMPERATUR_VERGLEICH.Equals(pArtVergleich)
                    )
                {
                    lSchonMitMondDa = true;
                }
            }

            if (!lSchonMitMondDa)
            {
                lErg.Add(lRelevanteHimmelskoeper[lZufallsindex]);
            }
        }

        return lErg;
    }


    public List<HimmelskoerperData> liefer3HimmelskoerperFuerArtUndEinBestimmten(int pSternOderPlanet, int pZielkoerper)
    {
        List<HimmelskoerperData> lErg = new List<HimmelskoerperData>();

        List<HimmelskoerperData> lRelevanteHimmelskoeper = new List<HimmelskoerperData>();

        HimmelskoerperData lZielHimmelskoerper = null;

        foreach (int lHimmelskoerper in getMyHimmelskoerperDict().Keys)
        {
            if ((getMyHimmelskoerperDict()[lHimmelskoerper].mArtHimmelskoerper.Equals(pSternOderPlanet) || pSternOderPlanet == Sprachenuebersetzer.K_ALL)
                && lHimmelskoerper != Himmelskoerper.K_LEER_PLANET)
            {
                lRelevanteHimmelskoeper.Add(getMyHimmelskoerperDict()[lHimmelskoerper]);
            }

            if (lHimmelskoerper == pZielkoerper)
            {
                lZielHimmelskoerper = getMyHimmelskoerperDict()[lHimmelskoerper];
            }
        }

        int lZufallsindexZiel = UnityEngine.Random.Range(0, 4);

        for (int i = 0; lErg.Count < 4; i++)
        {
            if (lZufallsindexZiel == (lErg.Count))
            {
                lErg.Add(lZielHimmelskoerper);
            }
            else
            {

                int lZufallsindex = UnityEngine.Random.Range(0, lRelevanteHimmelskoeper.Count);

                bool lSchonMitMondDa = false;
                foreach (var lHimmelskoerperDataErg in lErg)
                {
                    if (lHimmelskoerperDataErg.mIndex == lRelevanteHimmelskoeper[lZufallsindex].mIndex)
                    {
                        lSchonMitMondDa = true;
                    }
                }

                if (!lSchonMitMondDa && lRelevanteHimmelskoeper[lZufallsindex].mIndex != pZielkoerper)
                {
                    lErg.Add(lRelevanteHimmelskoeper[lZufallsindex]);
                }
            }
        }

        return lErg;
    }

    public int lieferEinheitEntfernungZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mEntfernungSonneEinheit;
    }

    public float lieferEntfernungZurSonneZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mEntfernungSonne;
    }


    public float lieferEntfernungZurSonneZuVergleich(int pIndex)
    {
        if (lieferEinheitEntfernungZu(pIndex) == Sprachenuebersetzer.K_LICHTJAHRE)
        {
            return 9.461e+12f * getMyHimmelskoerperDict()[pIndex].mEntfernungSonne;
        }
        return getMyHimmelskoerperDict()[pIndex].mEntfernungSonne;
    }

    public int lieferMinTemperaturZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mMinTemperatur;
    }

    public int lieferMaxTemperaturZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mMaxTemperatur;
    }

    public long lieferDurchmesserZu(int pIndex)
    {
        return getMyHimmelskoerperDict()[pIndex].mDurchmesser;
    }

}
