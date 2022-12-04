using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprachenuebersetzer : MonoBehaviour
{

    private Dictionary<int, Sprachdatum> mMyHimmelskoerperDict;

    public const string K_NAME = "NAME";

    private const string K_INIT_YOU = "You";

    private const string K_INIT_DU = "Du";

    private const string K_SPRACHE = "Sprache";

    public const string K_SPRACHE_DEUTSCH = "Deutsch";

    public const string K_SPRACHE_ENGLSIH = "English";

    public const int K_DEUTSCH = 10;

    public const int K_ENGLISH = 20;

    private int mAktuelleSprache;

    public const int K_ZURUECK = 10;

    public const int K_PRUEFUNG = 11;

    public const int K_WISSEN_THEMA_VOR = 14;
    public const int K_WISSEN_THEMA_ALL = 15;
    public const int K_WISSEN_THEMA_PLANETEN = 16;
    public const int K_WISSEN_THEMA_STERNEN_1 = 17;
    public const int K_WISSEN_THEMA_STERNEN_2 = 18;

    public const int K_FRAGE_PLATZHALTER_1 = 20;
    public const int K_FRAGE_PLATZHALTER_1_A = 21;
    public const int K_FRAGE_PLATZHALTER_2 = 22;

    public const int K_ANTWORT_PLATZHALTER = 23;

    public const int K_INFO_BILD_1 = 27;

    public const int K_INFO_BILD_2 = 28;

    public const int K_INFO_FAKTEN = 30;

    public const int K_KAUFINFO = 35;
    public const int K_BEZAHLEN_1 = 36;
    public const int K_BEZAHLEN_2 = 37;

    public const int K_ERWORBEN = 38;
    public const int K_KAUF_MOEGLICH = 39;
    public const int K_KAUF_NICHT_MOEGLICH = 40;


    public const int K_LERNEN = 41;

    public const int K_EMOJI_ERWERBEN_1 = 42;
    public const int K_EMOJI_ERWERBEN_2 = 43;


    public const int K_QUARTETT_SPIEL = 50;

    public const int K_EINSTELLUNGEN = 60;
    public const int K_ERKLAER_GADGET = 61;
    public const int K_ERKLAER_EMOJI = 62;


    public const int K_WISCHEN_1 = 70;
    public const int K_WISCHEN_2 = 71;

    public const int K_DU_MIT = 75;
    public const int K_GEGEN = 76;
    public const int K_EINSTEIN_MIT = 77;

    public const int K_NAMEN_CHANGE = 80;
    public const int K_NAMEN_COLUMN = 81;
    public const int K_PUNKTE_GRAVITATIONSMODUS = 82;


    public const int K_INIT_NAME = 90;

    public const int K_LEBTE = 95;
    public const int K_FUER = 96;
    public const int K_WEITER= 97;

    public const int K_WINNER_IS_1 = 100;

    public const int K_WINNER_IS_2 = 101;

    public const int K_LOOSER = 110;

    public const int K_BESSERE_WERTE = 120;

    public const int K_NEW_TITEL = 130;

    public const int K_BLEIBT_TITEL = 140;

    // ANF ARTEN
    public const int K_PLANET = 150;

    public const int K_STERN = 160;

    public const int K_MOON = 170;

    public const int K_BRAUNER_ZWERG = 175;

    public const int K_ASTEROID = 180;

    public const int K_ZWERGPLANET = 190;

    public const int K_SCHWARZES_LOCH = 200;

    public const int K_NEBEL = 202;

    public const int K_KOMET = 205;
    // END ARTEN


    public const int K_MASS_1 = 210;
    public const int K_MASS_2 = 211;
    public const int K_MASS_3 = 212;
    public const int K_WINKEL = 213;

    public const int K_ENTF_1 = 220;
    public const int K_ENTF_2 = 221;
    public const int K_IST = 222;
    public const int K_KILOMETER = 223;
    public const int K_LICHTJAHRE = 224;

    public const int K_HAS_NO_MOON = 230;
    public const int K_HAS_1_MOON = 231;
    public const int K_HAS_X_MOON_1 = 232;
    public const int K_HAS_X_MOON_2 = 233;

    public const int K_DICHTE_1 = 240;
    public const int K_DICHTE_2 = 241;

    public const int K_TEMPERATUR = 245;
    

    public const int K_DURCHMESER = 250;

    public const int K_MIN_TEMP = 260;
    public const int K_MAX_TEMP = 261;
    public const int K_GRAD = 262;

    public const int K_ALL = 270;
    public const int K_ART_DES_HIMMELSKOERPERS = 271;
    public const int K_ART_DES_VOR = 275;
    public const int K_ART_DES_NEXT = 276;
    public const int K_GRAVITATIONS_MODUS = 272;

    public const int K_EMOJI_UFO = 280;
    public const int K_EMOJI_KOMET = 281;
    public const int K_EMOJI_RAKETE = 282;
    public const int K_EMOJI_MOND = 283;
    public const int K_EMOJI_SATELLIT= 284;
    public const int K_EMOJI_HALBMOND = 285;
    public const int K_EMOJI_SATURN = 286;

    public const int K_FLIEGENDE_OBJEKT_SATURN = 287;
    public const int K_FLIEGENDE_OBJEKT_SATELLIT = 288;
    public const int K_FLIEGENDE_OBJEKT_ROCKET = 289;
    public const int K_FLIEGENDE_OBJEKT_SATURN_PAY = 291;
    public const int K_FLIEGENDE_OBJEKT_SATELLIT_PAY = 292;
    public const int K_FLIEGENDE_OBJEKT_ROCKET_PAY = 293;

    public const int K_ERDE = 300;
    public const int K_ERDE_TEXT = 301;
    public const int K_JUPITER = 310;
    public const int K_SATURN = 320;
    public const int K_URANUS = 330;
    public const int K_NEPTUN = 340;

    public const int K_MARS = 350;


    public const int K_MERKUR = 360;
    public const int K_MERKUR_TEXT = 370;
    public const int K_VENUS = 380;
    public const int K_SONNE = 390;
    public const int K_SONNE_TEXT = 400;
    public const int K_BETEIGEUZE = 410;
    public const int K_BETEIGEUZE_TEXT = 420;
    public const int K_IO = 430;
    public const int K_GANYMED = 440;
    public const int K_EUROPA = 450;
    public const int K_KALLISTO = 460;
    public const int K_EARTH_MOON_TEXT = 470;
    public const int K_EARTH_MOON = 480;
    public const int K_CERES = 490;
    public const int K_TITAN = 500;
    public const int K_CHARON = 510;
    public const int K_HARALDLESCH = 520;
    public const int K_ERIS = 530;
    public const int K_ARIADNE = 540;
    public const int K_PALLAS = 550;
    public const int K_VESTA = 560;
    public const int K_SIRIUS_A = 570;
    public const int K_SIRIUS_B = 580;
    public const int K_ALPHA_CENTAURI_A = 590;
    public const int K_ALPHA_CENTAURI_B = 600;

    public const int K_R_CORONA_BOREALIS = 605;
    public const int K_STEPHENSON = 606;
    public const int K_KEPPLER_160D = 607;
    public const int K_MOND_ENCELADUS = 608;
    public const int K_MOND_JAPETUS = 609;

    public const int K_PROXIMA_CENTAURI = 610;
    public const int K_PROXIMA_CENTAURI_B = 611;
    public const int K_SAGGITARIUS_A = 620;
    public const int K_M87_TEXT = 630;
    public const int K_M87 = 631;
    public const int K_PLUTO = 640;
    public const int K_TRITON = 650;

    public const int K_KOMET_HALLEY = 660;
    public const int K_KOMET_HALLEY_TEXT = 661;

    public const int K_KOMET_NEOWISE = 662;
    public const int K_KOMET_NEOWISE_TEXT = 663;

    public const int K_KOMET_TEBBUTT = 664;
    public const int K_KOMET_TEBBUTT_TEXT = 665;

    public const int K_1407_TEXT = 671;

    public const int K_SPEED = 679;
    public const int K_SPEED_X = 680;
    public const int K_SPEED_Y = 681;
    public const int K_SPEED_Z = 682;

    public const int K_DISTANZ = 685;


    public const int K_EINKLAPPEN = 690;
    public const int K_AUSKLAPPEN = 691;
    public const int K_NO_MASSE = 692;


    public const int K_START = 700;
    public const int K_STOPP = 701;

    public const int K_TIME_UNITS = 800;
    public const int K_WER_HAT_AM_MEISTEN_MONDE = 801;
    public const int K_WER_HAT_MEHR_MASSE = 802;
    public const int K_WER_HAT_WENIGER_MASSE = 803;
    public const int K_WER_HAT_GROESSTE_DICHTE = 804;
    public const int K_WER_HAT_WENIGSTEN_DICHTE = 805;
    public const int K_WER_HAT_AM_WENIGSTEN_MONDE = 806;


    public const int K_MASSE_VERFUEGBAR = 808;

    public const int K_PLANETENNAME = 810;
    public const int K_MASSEN_STABILE_TAGE = 812;
    public const int K_DISTANCE = 813;
    public const int K_ABWEICHUNG_DISTANCE = 814;
    public const int K_GESCHWINDIGEIT = 815;
    public const int K_GESCHWINDIGEIT_ABWEICHUNG = 816;
    public const int K_PUNKTE = 817;
    public const int K_GESAMTPUNKTE = 818;
    public const int K_NEUER_REKORD = 819;

    public const int K_PRUEFUNG_ALLES_RICHTIG = 820;
    public const int K_PRUEFUNG_FAST_ALLES_RICHTIG = 821;
    public const int K_PRUEFUNG_ZU_WENIG_RICHTIG = 822;

    public const int K_PRUEFUNG_VERDIENT_MEHR = 823;
    public const int K_PRUEFUNG_VERDIENT_1 = 825;
    public const int K_PRUEFUNG_ES_WAREN = 826;
    public const int K_PRUEFUNG_ANTWORTEN_VON = 827;

    public const int K_PRUEFUNG_RICHTIG = 830;

    public const int K_BIS_JETZT_RICHTIGE_ANTWORTEN = 835;

    public const int K_KEINE_MODNDE_ENTDECKT = 850;
    public const int K_EIN_MODND = 851;
    public const int K_BEANNTE_MODNDE = 852;

    public const int K_KOMET_TSCHURI = 900;
    public const int K_KOMET_TSCHURI_TEXT = 901;

    public const int K_MOND_STYX = 910;
    public const int K_MOND_KERBEROS = 911;
    public const int K_MOND_HYDRA = 912;
    public const int K_MOND_NIX = 913;

    public const int K_BRAUNER_ZWERG_SCHOLZ = 920;
    public const int K_BRAUNER_ZWERG_SCHOLZ_TEXT = 921;
    public const int K_BRAUNER_ZWERG_SDSS_1416_13B = 922;


    public const int K_NEBEL_PFERDEKOPF = 950;
    public const int K_NEBEL_PFERDEKOPF_TEXT = 951;

    public const int K_NEBEL_ORION = 954;
    public const int K_NEBEL_ORION_TEXT = 955;

    public const int K_NEBEL_KREBS = 960;
    public const int K_NEBEL_KREBS_TEXT = 961;

    public const int K_WASP_189_B_TEXT = 962;
    

    public const int K_WER_HAT_AM_PHOBOS_UND_DEIMOS = 970;
    public const int K_PHOBOS_UND_DEIMOS = 971;
    public const int K_HAT_MONDE_ABER_NICHT_DEIMOS_UND_PHOBOS = 972;
    public const int K_NUR_PLANETEN_HABEN_MONDE = 973;

    public const int K_GEHOERT_ZU = 980;
    public const int K_HAT_MONDE_ABER = 981;
    public const int K_IST_NICHT_DABEI = 982;
    public const int K_ZU_WEM_GEHOERT_MOND = 983;
    public const int K_HAT_EIN_MOND_ABER = 984;

    public const int K_WER_IST_AM_WEITESTEN_VON_DER_SONNE_ENTFERNT = 985;
    public const int K_WER_IST_AM_KUERZESTEN_VON_DER_SONNE_ENTFERNT = 986;

    public const int K_WER_IST_AM_HEISSESTEN = 990;
    public const int K_BEI_WEM_IST_ES_AM_KAELTESTEN = 991;

    public const int K_WER_HAT_DEN_GROESSTEN_DURCHMESSER = 995;
    public const int K_WER_HAT_DEN_KLEINSTEN_DURCHMESSER = 996;

    void Start()
    {
        init();

        // PlayerPrefs.SetString (Sprachenuebersetzer.K_NAME, "");
    }

    public void init()
    {
        mMyHimmelskoerperDict = new Dictionary<int, Sprachdatum>();

        mAktuelleSprache = PlayerPrefs.GetInt(K_SPRACHE);

        hinzuInsDic(K_ZURUECK, "back", "zurück", "", "", "");
        hinzuInsDic(K_INFO_BILD_1, "Pictures of heavenly bodies: NASA, ESA", "Fotos von Himmelskörpern: NASA, ESA", "", "", "");
        hinzuInsDic(K_INFO_BILD_2, "Pictures of H.Lesch, J. Gassner: 'Urknall,Weltall und das Leben'", "Fotos von H.Lesch, J. Gassner: 'Urknall,Weltall und das Leben'", "", "", "");
        hinzuInsDic(K_INFO_FAKTEN, "The astronomical facts have been calculated as best as possible, but no guarantee is given that they are correct. " +
            "We are happy to receive your comments.",
            "Die astronomischen Fakten sind bestmöglich recherchiert, aber es wird keine Gewähr auf Korrektheit übernommen. Gern nehmen wir Ihre Hinweise entgegegen.", "", "", "");

        hinzuInsDic(K_KAUFINFO, "Here you can exchange your XX 2B-coins.",
         "Hier können Sie Ihre XX 2B-Münzen eintauschen.", "", "", "");

        hinzuInsDic(K_ERKLAER_GADGET, "The small objects float to the correct answer. You can draw a line with your finger. The small objects also fly off this line. Several objects can be activated.",
        "Die kleinen Objekte schweben zur richtigen Antwort. Mit dem Finger kann man eine Linie zeichnen. Diese Linie fliegen die kleine Objekte zusätzlich mit ab. Es können mehrere Objekte aktiviert werden.", "", "", "");

        hinzuInsDic(K_ERKLAER_EMOJI, "The emojis appear in the text of the correct answer. Only one emoji can be activated.",
        "Die Emojis erscheinen im Text der richtigen Antwort. Es kann nur ein Emoji aktiviert werden.", "", "", "");

        hinzuInsDic(K_BEZAHLEN_1, "pay",
        "bezahle", "", "", "");
        hinzuInsDic(K_BEZAHLEN_2, "2B-coins",
        "2B-Münzen", "", "", "");

        hinzuInsDic(K_ERWORBEN, "already acquired",
             "bereits erworben", "", "", "");
        hinzuInsDic(K_KAUF_MOEGLICH, "2B-C. Purchase is possible",
             "2B-M. Kauf ist möglich", "", "", "");
        hinzuInsDic(K_KAUF_NICHT_MOEGLICH, "2B-C. Purchase is not possible",
             "2B-M. Kauf ist nicht möglich", "", "", "");


        hinzuInsDic(K_PRUEFUNG, "exam\n", "Prüfung\n", "", "", "");
        hinzuInsDic(K_WISSEN_THEMA_VOR, "topic\n", "Thema\n", "", "", "");
        hinzuInsDic(K_WISSEN_THEMA_ALL, "everything", "alles", "", "", "");
        hinzuInsDic(K_WISSEN_THEMA_PLANETEN, "planets", "Planeten", "", "", "");
        hinzuInsDic(K_WISSEN_THEMA_STERNEN_1, "stars", "Sterne", "", "", "");
        hinzuInsDic(K_WISSEN_THEMA_STERNEN_2, "stars", "Sternen", "", "", "");
        hinzuInsDic(K_FRAGE_PLATZHALTER_1, "Here you can test your knowledge", "Hier können Sie Ihr Wissen", "", "", "");
        hinzuInsDic(K_FRAGE_PLATZHALTER_1_A, "of ", "zu ", "", "", "");
        hinzuInsDic(K_FRAGE_PLATZHALTER_2, " - only A, B, C or D is correct.", "prüfen - es ist immer nur A, B, C oder D richtig.", "", "", "");

        hinzuInsDic(K_KEINE_MODNDE_ENTDECKT, "No moons are known.", "Es sind keine Mond bekannt.", "", "", "");
        hinzuInsDic(K_EIN_MODND, "A moon is known.", "Ein Mond ist bekannt.", "", "", "");
        hinzuInsDic(K_BEANNTE_MODNDE, "Two moons are known.", "Zwei Monde sind bekannt.", "", "", "");

        hinzuInsDic(K_WER_IST_AM_HEISSESTEN, "Who is the hottest?", "Wer ist am heißesten?", "", "", "");
        hinzuInsDic(K_BEI_WEM_IST_ES_AM_KAELTESTEN, "Who can also be very cold?", "Wer kann auch sehr kalt sein?", "", "", "");

        hinzuInsDic(K_WER_HAT_DEN_GROESSTEN_DURCHMESSER, "Who has the largest diameter?", "Wer hat den größten Durchmesser?", "", "", "");
        hinzuInsDic(K_WER_HAT_DEN_KLEINSTEN_DURCHMESSER, "Who has the smallest diameter?", "Wer hat den kleinsten Durchmesser?", "", "", "");

        hinzuInsDic(K_ANTWORT_PLATZHALTER, "answer ", "Antwort ", "", "", "");

        hinzuInsDic(K_LERNEN, "learning", "Lernen", "", "", "");

        hinzuInsDic(K_EMOJI_ERWERBEN_1, "purchase emoji\n<size=60%>(", "Emoji erwerben\n<size=60%>(", "", "", "");
        hinzuInsDic(K_EMOJI_ERWERBEN_2, " 2B-coins)", " 2B-Münzen)", "", "", "");

        hinzuInsDic(K_QUARTETT_SPIEL, "quartet\ngame", "Quartett-\nspiel", "", "", "");
        hinzuInsDic(K_EINSTELLUNGEN, "settings", "Ein-\nstellungen", "", "", "");

        hinzuInsDic(K_WISCHEN_1, "The key physical data of the celestial body are presented on the right-hand side. " +
            "In the game you click the physical parameter button, where you think you're hitting the celestial body of the opponent 'Einstein'.\n" +
            "\n<size=70%>For mass, the heavier the better.\n" +
            "For distance from the sun, the farther the better.\n" +
            "For number of moons, the more the better.\n" +
            "For density, the higher the better.\n" +
            "For diameter, the larger the better.\n" +
            "At maximum temperature, the more the better.\n" +
            "At minimum temperature, the deeper the better.",
            "Auf der rechten Seiten werden die physikalischen Eckdaten des Himmelskörper präsentiert. " +
            "Im Spiel wählt man den physikalischen Parameterbutton, wo man glaubt den Himmelskörper vom Gegenspieler 'Einstein' zu schlagen.\n" +
            "\n<size=70%>Bei Masse gilt, je schwerer, desto besser.\n" +
            "Bei Sonnenentfernung gilt, je weiter, desto besser.\n" +
            "Bei Anzahl Monde gilt, je mehr, desto besser.\n" +
            "Bei Dichte gilt, je höher, desto besser.\n" +
            "Bei Durchmesser gilt, je größer, desto besser.\n" +
            "Bei maximale Temperatur gilt, je mehr, desto besser.\n" +
            "Bei minimale Temperatur gilt, je tiefer, desto besser.", "", "", "");
        hinzuInsDic(K_WISCHEN_2, "The astronaut can provide interesting information about the celestial body.", "Der Astronaut kann interessante Infos zum Himmelskörper mitteilen.", "", "", "");

        hinzuInsDic(K_DU_MIT, "You with", "Du mit", "", "", "");
        hinzuInsDic(K_GEGEN, "vs", "gegen", "", "", "");
        hinzuInsDic(K_EINSTEIN_MIT, "Einstein with", "Einstein mit", "", "", "");

        hinzuInsDic(K_NAMEN_CHANGE, "Your name \n(changeable from level 2)", "Deinen Namen \n(ab Level 2 änderbar)", "", "", "");
        hinzuInsDic(K_NAMEN_COLUMN, "name", "Namen", "", "", "");
        hinzuInsDic(K_PUNKTE_GRAVITATIONSMODUS, "points in\ngravity mode", "Punkte im\nGravitationsmodus", "", "", "");

        hinzuInsDic(K_INIT_NAME, K_INIT_YOU, K_INIT_DU, "", "", "");

        hinzuInsDic(K_LEBTE, "lived", "lebte", "", "", "");
        hinzuInsDic(K_FUER, "for", "für", "", "", "");

        hinzuInsDic(K_WEITER, "next", "weiter", "", "", "");

        

        hinzuInsDic(K_WINNER_IS_1, "The Winner is ", "Der Gewinner ist", "", "", "");
        hinzuInsDic(K_WINNER_IS_2, "You are the Winner ! ", "Der Gewinner bist Du ! ", "", "", "");

        hinzuInsDic(K_LOOSER, "Lost - don't give up ! ", "Verloren - gib nicht auf ! ", "", "", "");

        hinzuInsDic(K_BESSERE_WERTE, "Click right buttons with better values - You have this:", "Klick rechte Buttons mit besseren Werten - Du hast den: ", "", "", "");

        hinzuInsDic(K_NEW_TITEL, "title achieved :\n", "Titel erreicht :\n", "", "", "");
        hinzuInsDic(K_BLEIBT_TITEL, "Title :\n ", "Titel :\n  ", "", "", "");

        hinzuInsDic(K_PLANET, "planet", "Planet", "", "", "");
        hinzuInsDic(K_STERN, "star", "Stern", "", "", "");
        hinzuInsDic(K_MOON, "moon", "Mond", "", "", "");
        hinzuInsDic(K_BRAUNER_ZWERG, "brown dwarf", "brauner Zwerg", "", "", "");
        hinzuInsDic(K_ASTEROID, "asteroid", "Asteroid", "", "", "");
        hinzuInsDic(K_ZWERGPLANET, "dwarf planet", "Zwergplanet", "", "", "");
        hinzuInsDic(K_SCHWARZES_LOCH, "Black hole", "Schwarzes Loch", "", "", "");
        hinzuInsDic(K_NEBEL, "nebula", "Nebel", "", "", "");
        hinzuInsDic(K_KOMET, "comet", "Komet", "", "", "");

        hinzuInsDic(K_ART_DES_HIMMELSKOERPERS, "type of\nheavenly body\n", "Art des\nHimmels-\nkörper\n", "", "", "");
        hinzuInsDic(K_ART_DES_VOR, "<- previous\n", "<- vorherige\n", "", "", "");
        hinzuInsDic(K_ART_DES_NEXT, "-> next\n", "-> nächste\n", "", "", "");
        hinzuInsDic(K_GRAVITATIONS_MODUS, "gravity\nmode\n", "Gravi-\ntations-\nmodus\n", "", "", "");

        hinzuInsDic(K_ALL, "all", "alle", "", "", "");


        hinzuInsDic(K_MASS_1, "Mass is ", "Masse beträgt ", "", "", "");
        hinzuInsDic(K_MASS_2, " Earth masses", " Erdmassen ", "", "", "");
        hinzuInsDic(K_MASS_3, "mass ", "Masse ", "", "", "");
        hinzuInsDic(K_WINKEL, "Angle ", "Winkel ", "", "", "");


        hinzuInsDic(K_ENTF_1, "from sun to sun is 0 km", "von Sonne zu Sonne ist 0 km", "", "", "");
        hinzuInsDic(K_ENTF_2, "Sun distance in", "Sonnenentfernung in", "", "", "");
        hinzuInsDic(K_IST, " is ", " ist ", "", "", "");
        hinzuInsDic(K_KILOMETER, "kilometre", "Kilometer", "", "", "");
        hinzuInsDic(K_LICHTJAHRE, "light years", "Lichtjahre", "", "", "");

        hinzuInsDic(K_HAS_NO_MOON, "has no moon", "hat keinen Mond", "", "", "");
        hinzuInsDic(K_HAS_1_MOON, "has one moon", "hat einen Mond", "", "", "");
        hinzuInsDic(K_HAS_X_MOON_1, "has", "hat ", "", "", "");
        hinzuInsDic(K_HAS_X_MOON_2, "moons", " Monde", "", "", "");

        hinzuInsDic(K_PLANETENNAME, "planet\n\n", "Planet\n\n", "", "", "");
        hinzuInsDic(K_MASSEN_STABILE_TAGE, "day of\nconst\nmass", "Tage\nstabiler\nMasse", "", "", "");
        hinzuInsDic(K_DISTANCE, "average\ndistance\n", "durchschn\nDistanz\n", "", "", "");
        hinzuInsDic(K_ABWEICHUNG_DISTANCE, "+/-\n\n", "+/-\n\n", "", "", "");
        hinzuInsDic(K_GESCHWINDIGEIT, "speed\n\n", "Gesch\nwindigkeit\n", "", "", "");
        hinzuInsDic(K_GESCHWINDIGEIT_ABWEICHUNG, "+/-\n\n", "+/-\n\n", "", "", "");
        hinzuInsDic(K_PUNKTE, "points\n\n", "Punkte\n\n", "", "", "");
        hinzuInsDic(K_GESAMTPUNKTE, "total points:", "Gesamtpunkte:", "", "", "");
        hinzuInsDic(K_NEUER_REKORD, " (new record)", " (neuer Rekord)", "", "", "");


        hinzuInsDic(K_DICHTE_1, "Density is ", "Dichte beträgt ", "", "", "");
        hinzuInsDic(K_DICHTE_2, " Grams per cm ^ 3", " Gramm je cm^3", "", "", "");

        hinzuInsDic(K_TEMPERATUR, "temperature", " Temperatur", "", "", "");
 
        hinzuInsDic(K_DURCHMESER, "Diameter is ", "Durchmesser ist ", "", "", "");

        hinzuInsDic(K_MIN_TEMP, "minimum outside temperature ", "minimale Aussentemperatur ", "", "", "");
        hinzuInsDic(K_MAX_TEMP, "maximum outside temperature ", "maximale Aussentemperatur ", "", "", "");
        hinzuInsDic(K_GRAD, " Degree", " Grad", "", "", "");


        hinzuInsDic(K_ERDE_TEXT, "The earth was very hot in the beginning and most likely collided with the moon. " +
            "Earth is the only planet with life and a 'too big' moon. " +
            "There are people on earth who have built houses, roads and bridges. " +
            "Due to the favorable distance from the sun, the water on Earth is liquid. " +
            "Earth is also called the blue planet because of the oceans.",

            "Die Erde war am Anfang sehr heiß und ist sehr wahrscheinlich mit dem Mond zusammengestossen." +
            "Die Erde ist der einzige Planet mit Leben und einem 'zu großen' Mond. " +
            "Auf der Erde gibt es Menschen, die Häuser,Strassen und Brücken gebaut haben. " +
            "Durch die günstige Entfernung von der Sonne ist das vorhandene Wasser auf der Erde flüssig. " +
            "Die Erde nennt man auch wegen den Ozeanen den blauen Planeten. ", "", "", "");

        hinzuInsDic(K_ERDE, "Earth", "Erde", "", "", "");

        hinzuInsDic(K_EMOJI_UFO, "UFO", "UFO", "", "", "");
        hinzuInsDic(K_EMOJI_KOMET, "Comet", "Komet", "", "", "");
        hinzuInsDic(K_EMOJI_RAKETE, "Rocket", "Rakete", "", "", "");
        hinzuInsDic(K_EMOJI_MOND, "Moon", "Mond", "", "", "");
        hinzuInsDic(K_EMOJI_SATELLIT, "satellite", "Satellit", "", "", "");
        hinzuInsDic(K_EMOJI_HALBMOND, "crescent", "Halbmond", "", "", "");
        hinzuInsDic(K_EMOJI_SATURN, "Saturn", "Saturn", "", "", "");

        hinzuInsDic(K_FLIEGENDE_OBJEKT_SATURN, "a small moving planet.", "ein kleiner sich bewegender Planet.", "", "", "");
        hinzuInsDic(K_FLIEGENDE_OBJEKT_SATURN_PAY, "a small moving planet.", "den kleinen sich bewegenden Planet.", "", "", "");
        hinzuInsDic(K_FLIEGENDE_OBJEKT_SATELLIT, "a moving artificial satellite.", "ein sich bewegender künstlicher Satellitt.", "", "", "");
        hinzuInsDic(K_FLIEGENDE_OBJEKT_SATELLIT_PAY, "a moving artificial satellite.", "den sich bewegenden künstlichen Satellitt.", "", "", "");
        hinzuInsDic(K_FLIEGENDE_OBJEKT_ROCKET, "a small jetting rocket.", "eine kleine herumdüsende Rakete.", "", "", "");
        hinzuInsDic(K_FLIEGENDE_OBJEKT_ROCKET_PAY, "a small jetting rocket.", "die kleine herumdüsende Rakete.", "", "", "");

        hinzuInsDic(K_JUPITER, "If the gas planet Jupiter were 80 times larger, it could itself become a star. On Jupiter " +
            "a cyclone has been raging for more than 300 years. " +
            "Jupiter spins very quickly - a day has only 10 hours. Jupiter has very thin rings. " +
            "Jupiter has 4 large and 75 small moons, Ganymede is the largest moon and is even the" +
            " largest moon in the solar system. See also in the following picture."

            , "Wenn der Gasplanet Jupiter 80 mal größer wäre, dann könnte er selbst ein Stern werden. Auf dem Jupiter " +
            "tobt ein Wirbelsturm seit mehr als 300 Jahren. " +
            "Der Jupiter dreht sich sehr schnell - ein Tag hat nur 10 Stunden. Jupiter hat ganz ganz dünne Ringe. " +
            "Jupiter hat 4 große und 75 kleine Monde, Ganymed ist der größte Mond und ist sogar der " +
            "größte Mond im Sonnensystem. Siehe auch auf dem folgenden Bild.", "", "", "");

        hinzuInsDic(K_SATURN, "The rings from Saturn consist of water ice and rocks and 'rain' down on Saturn. " +
            "In a few hundred million years these rings will be gone. Saturns magnetic field is very weak" +
            "- even weaker than that of Earth, but even stronger than that of Mars. In the following picture from the Cassini spacecraft " +
            "you can see the rings and even the earth in the background.",

            "Die Ringe vom Saturn bestehen aus Wassereis und Gesteinsbrocken und 'regnen' auf den Saturn nieder. " +
            "In ein paar hundertmillionen Jahren werden diese Ringe verschwunden sein. Das Magnetfeld des Saturn ist sehr schwach " +
            "- sogar schwächer als das von der Erde, aber noch stärker als das vom Mars. Im folgenden Bild der Raumsonde Cassini kann " +
            "man die Ringe und im Hintergrund sogar die Erde erkennen.", "", "", "");


        hinzuInsDic(K_URANUS, "Like Saturn, Uranus also has rings. " +
            "It is the third largest planet and is the first planet that was discovered with a telescope. " +
            "Uranus has only on the equator some areas that behave like day and night, " +
            "the rest have 'polar day' or 'polar night'.",

            "Uranus hat wie der Saturn auch Ringe. " +
            "Er ist der drittgrößte Planet und ist der erste Planet, der mit einem Teleskop entdeckt worden ist. " +
            "Der Uranus hat nur am Äquator Gebiete, die sich wie Tag und Nacht verhalten, " +
            "der Rest hat 'Polartag' oder 'Polarnacht'.", "", "", "");


        hinzuInsDic(K_NEPTUN, "The gas planets Neptune and Uranus are almost the same size and both have a bluish color." +
            "There are 2 cyclones on Neptune - the large dark spot and the small dark spot. " +
            "Since 1999, the Hubbel Telescope has not been able to 'find' the large spot. " +
            "By the was Neptune is also called the god of the sea.",

            "Die Gasplaneten Neptun und Uranus sind fast gleich groß und haben beide eine bläuliche Farbe. " +
            "Auf Neptun gibt es auch 2 Wirbelstürme - den großen dunklen Fleck und den kleinen dunklen Fleck. " +
            "Seit 1999 kann das Teleskop Hubbel den großen Fleck nicht mehr 'finden'. " +
            "Neptun nennt man auch den Gott des Meeres. "

            , "", "", "");

        hinzuInsDic(K_TRITON,
            "The moon Triton is one of the coldest moons in the solar system. The moon Triton has few impact craters. " +
            "It is believed that Triton came from the outer solar system and Neptune captured it. " +
            "Sinks and even geysers have been observed on Triton. A summer on trition lasts 40 years. The solar radiation generated during this time" +
            " ice volcanism. The moon Triton orbits Neptune in the opposite direction of its rotation. His name is also Neptune I.",

            "Der Mond Triton ist eine der kältesten Monde im Sonnensystem. Der Mond Triton hat wenig Einschlagkrater. " +
            "Man vermutet, das Triton von äusseren Sonnensystem kam und Neptun ihn eingefangen hat. " +
            "Auf Triton sind Senken und sogar Geysire beobachtet worden. Ein Sommer auf Trition dauert 40 Jahre -  während dieser Zeit erzeugt " +
            "die Sonnenstrahlung Eisvulkanismus. Der Mond Triton umläuft Neptun entgegengesetzt dessen Drehrichtung (retrograd)." +
            " Seine Bezeichnung ist auch Neptun I."
            , "", "", "");

        hinzuInsDic(K_KOMET_HALLEY,
            "Halley's comet",
            "Halleysche Komet"
            , "", "", "");

        hinzuInsDic(K_KOMET_HALLEY_TEXT,
            "On average, Halley's comet comes back to us every 75.3 years. " +
            "If Jupiter 'distracts him' it can sometimes be 79 years. " +
            "He last came in 1986. The comet's tail is created by the sun and therefore always 'points' away from the sun. " +
            "In former time Comets used to be thought to bring bad luck. " +
            "Halley loses 0.25 % of its mass in one revolution, which is 50 tons per second.",

            "Der Halleysche Komet kommt im Mittel alle 75,3 Jahre wieder bei uns vorbei. " +
            "Wenn Jupiter Ihn stark 'ablenkt' können es auch mal 79 Jahre werden. " +
            ". Zuletzt kam er 1986. Der Kometenschweife entsteht durch die Sonne und 'zeigt' deswegen auch immer von der Sonne weg. " +
            "Früher glaubte man Kometen bringen Unglück. Halley verliert 0,25 % seiner Masse bei einem Umlauf, das sind 50 Tonnen pro Sekunde."
            , "", "", "");

        hinzuInsDic(K_KOMET_NEOWISE,
      "NEOWISE comet",
      "Neowise Komet"
      , "", "", "");

        hinzuInsDic(K_KOMET_NEOWISE_TEXT,

             "On July 23, 2020, the NEOWISE comet was the shortest distance to Earth at approximately 103.5 million kilometers. " +
             "Its orbital period is a proud 6690 years, which also depends heavily on how planets like Jupiter influence it. " +
             "It owes its name to the reactivated WISE telescope (Wide-field Infrared Survey Explorer). The following image was taken from the ISS. "
             ,

             "Der NEOWISE Komet hatte am 23. Juli 2020 mit ca. 103,5 Millionen Kilometer seine kürzeste Distanz zur Erde. " +
             "Seine Umlaufzeit beträgt stolze 6690 Jahre, die auch stark davon abhängt wie ihn Planeten wie Jupiter beeinflussen. " +
             " Sein Name verdankt er dem reaktivierte WISE Teleskop (Wide-field Infrared Survey Explorer). Das folgende Bild ist von der ISS aus aufgenommen. "
             , "", "", "");


        hinzuInsDic(K_KOMET_TEBBUTT,
      "comet tebbutt",
      "Komet Tebbutt"
      , "", "", "");

        hinzuInsDic(K_KOMET_TEBBUTT_TEXT,
            "The comet was named after the Australian amateur astronomer John Tebbutt. For 8 days, Tebbutt could only see that the object was slowly getting lighter. " +
            "It was only on the ninth day that he was able to determine a self-movement. John Tebbutt calculated that on June 29, 1861 the comet would be very close to Earth. " +
            "In fact, on June 30, 1861, the comet was only 19.8 million kilometers from Earth. The comet was so bright that its light cast shadows on Earth. " +
            "The comet only needs 409 years for its orbit.",

            "Der Komet wurde nach dem australischen Amateurastronom John Tebbutt benannt. Tebbutt konnte 8 Tage lang nur feststellen, das das Objekt langsam heller wurde. " +
            " Erst am neunten Tag konnte er eine Eigenbwegung feststellen. John Tebbutt berechnete , das am 29. Juni 1861 der Komet sehr nah zur Erde sein wird. " +
            "Tatsächlich war der Komet am 30. Juni 1861 nur 19,8 Mio Kilometer von der Erde weg. Der Komet war so hell, das sein Licht auf der Erde Schatten warf." +
            " Für seine Umlaufbahn benötigt der Komet nur 409 Jahre. "
            , "", "", "");

        hinzuInsDic(K_KOMET_TSCHURI,
         "Tschurjumow-Gerassimenko",
         "Tschurjumow-Gerassimenko"
         , "", "", "");

        hinzuInsDic(K_BRAUNER_ZWERG_SCHOLZ,
        "Scholz' star",
        "Scholz' Stern"
         , "", "", "");

        hinzuInsDic(K_KOMET_TSCHURI_TEXT,
            "Comet Churyumov-Gerasimenko (Tschuri) has been observed by ESA's Rosetta probe. " +
            "On November 12, 2014, a lander (Philae) landed on a comet for the first time in the history of space travel." +
            "The gas cloud around the celestial body even contains molecular oxygen - until now it was thought that this was not possible." +
            "Oxygen is very reactive and could have combined with hydrogen to form water.",

            "Der Komet Tschurjumow-Gerassimenko (Tschuri) ist von der ESA Sonde Rosetta beobachtet worden. " +
            "Am 12. November 2014 landete es als erstes in der Geschichte der Raumfahrt auf einem Kometen ein Lander (Philae). " +
            "Die Gaswolke um den Himmelskörper enthält sogar molekularen Sauerstoff - bisher dachte man dies sei nicht möglich. " +
            "Sauerstoff ist sehr reaktiv und hätte sich ja mit dem Wassrstoff zu Wasser verbinden können."
            , "", "", "");

        hinzuInsDic(K_MARS, "Mars has no longer a global magnetic field. Mars has the highest mountain in the entire solar system. Mount 'Olympus Mons' is 26 kilometers high. " +
            "Its atmosphere is 95% carbon dioxide. " +
            "In the following picture you can see the two moons Deimos and Phobos.",

            "Der Mars hat kein globales Magnetfeld mehr. Der Mars hat den höchsten Berg im ganzen Sonnensystem. Berg 'Olympus Mons' ist 26 Kilometer hoch. " +
            "Seine Atmosphäre besteht zu 95 % aus Kohlendioxid. " +
            "Auf dem folgenden Bild kann man die beiden Monde Deimos und Phobos sehen.", "", "", "");

        hinzuInsDic(K_MERKUR, "Mercury", "Merkur", "", "", "");

        hinzuInsDic(K_MERKUR_TEXT, "Mercury is the smallest and closest planet to the sun. It orbits the sun fastest. " +
            "Mercury is still cooling, which is causing it to shrink. " +
            "There is even ice on its side facing away from the sun. " +
            "When the sun becomes a red giant in 4 to 5 billion years, Mercury will be the first to be devoured. " +
            "The following picture was taken by the Messenger.",

            "Der Merkur ist der sonnennächste und kleinste Planet. Er umkreist die Sonne am schnellsten. " +
            "Der Merkur kühlt immer noch aus, was ihn schrumpfen läßt. " +
            "Auf seiner der Sonne abgewandten Seite gibt es sogar Eis. " +
            "Wenn die Sonne in 4 bis 5 Mrd. Jahren zum Roten Riesen wird, dann wird der Merkur als erstes 'verschlungen'. " +
            "Das folgende Bild hat die 'Messenger' aufgenommen.", "", "", "");

        hinzuInsDic(K_VENUS, "Venus is after the sun and moon " +
            "the third brightest object in the sky. " +
            "Venus is turning retrograde. In addition to Venus, only Uranus has such a twist." +
            "The atmosphere consists mainly of carbon dioxide. It rains sulfuric acid, which is very dangerous for humans. " +
            "Venus has few mountains and valleys. There are also volcanoes on Venus - volcano 'Maat Mons' can be seen in the picture below.",

            "Die Venus ist nach Sonne und Mond " +
            "das dritthellste Objekt am Himmel. " +
            "Die Venus dreht sich rückläufig. Neben der Venus hat eine solche Eigendrehung nur der Uranus. " +
            "Die Atmosphäre besteht hauptsächlich aus Kohlendioxod. Es regnet dort für Menschen sehr gefährliche Schwefelsäure. " +
            "Die Venus hat wenige Berge und Täler. Auf der Venus gibt es auch Vulkane - Vulkan 'Maat Mons' ist auf dem folgenden Bild zu sehen.", "", "", "");



        hinzuInsDic(K_SONNE, "Sun", "Sonne", "", "", "");
        hinzuInsDic(K_SONNE_TEXT, "The sun is a star. It is very hot at the core, atomic nuclei fuse there and light is generated. " +
            "The sun has the strongest magnetic field in the solar system " +
            "with many poles. This magnetic field can be so strong at certain points that it cools the surface. " +
            "In the following picture you can see these spots as black spots.", "Die Sonne ist ein Stern. Sie ist im Kern sehr heiß, dort verschmelzen Atomkerne und dabei entsteht Licht. Die Sonne hat das stärkste Magnetfeld im Sonnensystem " +
            "mit vielen Polen. Dieses Magnetfeld kann an bestimmten Stellen so stark sein, daß es die Oberfläche abkühlt. " +
            "Auf dem folgende Bild kann man diese Stellen als schwarze Flecken erkennen.", "", "", "");

        hinzuInsDic(K_BETEIGEUZE, "Betelgeuse", "Beteigeuze", "", "", "");
        hinzuInsDic(K_BETEIGEUZE_TEXT, "Betelgeuse is a red giant that, if it were in our solar system, " +
            "it would need the space up to Jupiter's orbit. " +
            "Betelgeuse will end up in a supernova. A supernova also creates heavy elements such as gold. " +
            "Betelgeuse is one of the ten brightest stars in the night sky. But it is currently a little darker. Its size fluctuates by 15 percent." +
            "It is one of the few stars that can be recognized as a surface - see picture",

            "Beteigeuze ist ein roter Riese, der, wäre er in unserem Sonnensystem, er den Platz bis zur Jupiterlaufbahn benötigen würde. " +
            "Beteigeuze wird einmal in einer Supernova enden. Bei einer Supernova entstehen auch schwere Elemente wie z.B. Gold. " +
            "Beteigeuze ist einer der zehn hellsten Sterne am Nachthimmel. Aktuell ist es aber etwas dunkler. Seine Größe schwankt um 15 Prozent. " +
            "Er ist einer der wenigen Sterne, die man als Fläche erkennen kann - siehe Bild", "", "", "");
        hinzuInsDic(K_IO, "IO is the shortest distance from Jupiter." +
            "There are many active volcanoes on IO. There is very likely liquid sulfur in the volcanic craters." +
            "Jupiter's strong magnetic field generates electricity on IO, which ultimately leads to mass loss.",

            "IO ist der Mond mit dem kürzesten Abstand zum Jupiter. " +
            "Auf IO gibt es viele aktive Vulkane. In den Vulkanenkratern gibt es sehr wahrscheinlich flüssigen Schwefel. " +
            "Das starke Magnetfeld von Jupiter erzeugt auf IO Strom, der letztlich Massenverlust bewirkt.", "", "", "");

        hinzuInsDic(K_GANYMED, "The Ganymede is Jupiter's largest moon and " +
            "also the largest moon in the solar system. Ganymede is even larger than Mercury, but not as heavy. Ganymede has an iron core " +
            "and also a magnetic field, which enables a thin atmosphere. The surface consists of a thick layer of ice.",

            "Der Ganymed ist der größte Mond vom Jupiter und " +
            "auch der größte Mond im Sonnensystem. Ganymed ist sogar größer als der Merkur, aber nicht so schwer. Ganymed hat einen Eisenkern " +
            "und auch ein Magnetfeld, welches eine dünne Atmosphäre ermöglicht. Die Oberfläche besteht aus einer dicken Eisschicht.", "", "", "");


        hinzuInsDic(K_EUROPA, "Europe is the smallest of the 4 big " +
            "Jupiter's moon. It is completely covered with ice and " +
            "probably has a huge ocean 100 kilometers deep under the ice. The surface looks scratched and " +
            "contains few craters. Probably meteoroid impacts freeze quickly." +
            "The moon Europe has 3 times more water than the earth. The following picture shows the ice surface.",

            "Europa ist der kleinste der 4 großen " +
            "Jupitermonde. Er ist komplett mit Eis bedeckt und " +
            "hat wahrscheinlich einen riesigen Ozean von 100 Kilometer Tiefe unter dem Eis. Die Oberfläche sieht zerkratzt aus und " +
            "enthält wenig Krater. Wahrscheinlich frieren Meteorideneinschläge schnell zu. " +
            "Der Mond Europa hat 3 mal mehr Wasser als die Erde. Das folgende Bild zeigt die Eisoberfläche.", "", "", "");


        hinzuInsDic(K_KALLISTO, "Kallisto is an ice moon and has " +
            "many impact craters " +
            "on its surface. The largest crater is called Heimdall and has a diameter of 210 kilometers. " +
            "Under the 200 km outer ice sheet there is probably a 10 km deep salt ocean. " +
            "This ocean enables a small magnetic field through Jupiter.",

            "Kallisto ist ein Eismond und hat " +
            "viele Einschlagkrater " +
            "auf seiner Oberfläche. Der größte Krater heißt Heimdall und hat ein Durchmesser von 210 Kilometer. " +
            "Unter der 200 Kilometer äußeren Eisdecke liegt wahrscheinlich ein 10 Kilometer tiefer Salzozean. " +
            "Dieser Ozean ermöglicht über den Jupiter ein kleines Magnetfeld.", "", "", "");

        hinzuInsDic(K_EARTH_MOON_TEXT, "The earth moon is the only satellite of the earth. " +
            "The earth's moon always shows the same 'face' to the earth. " +
            "This is called bound rotation. The rock on the moon and earth is very similar, so there was " +
            "probably a collision of the two celestial bodies. The following picture shows the lunar cycle. " +
            "The cycle begins with the new moon and then goes from the growing moon to " +
            "full moon and from the full moon over the waning moon back to the beginning.",

            "Der Erdmond ist der einzige Trabant der Erde. " +
            "Der Erdmond zeigt der Erde immer das gleiche 'Gesicht', " +
            "das nennt man gebundene Rotation. Das Gestein auf Mond und Erde ist sehr ähnlich, deswegen gab es " +
            "wahrscheinlich eine Kollision der beiden Himmelskörper. Auf dem folgenden Bild kann man den Mondzyklus sehen. " +
            "Der Zyklus beginnt mit dem Neumond und geht dann vom wachsendem Mond bis zum " +
            "Vollmond und vom Vollmond über den abnehmenden Mond wieder zum Anfang.", "", "", "");

        hinzuInsDic(K_EARTH_MOON, "earth moon", "Erdmond", "", "", "");

        hinzuInsDic(K_CERES, "Ceres is the largest dwarf planet in the asteroid belt. Ceres consists of a lot of frozen water. " +
            "The ice sometimes also seems to melt and trigger 'landslides'. " +
            "Although Ceres is very small, it has high mountains and deep valleys (up to 15 km).",

            "Ceres ist der größte Zwergplanet im Asteroidengürtel. Ceres besteht aus sehr viel gefrorenen Wasser. " +
            "Das Eis scheint auch manchmal zu schmelzen und löst 'Erdrutsche' aus. Obwohl Ceres sehr klein ist, hat er hohe Berge und tiefe Täler (bis 15 km)." +
            "An den hellen Flecken wie im folgenden Bild scheint Wasser zu verdampfen.", "", "", "");

        hinzuInsDic(K_TITAN, "Titan is the largest moon of Saturn. It has a methane-rich atmosphere. Its surface is comparable to Earth - " +
            "10% from the surface are lakes." +
            "Its highest mountain is 3337 meters high and is located in 'Mithrim Montes' - a large underground ocean is suspected. " +
            "The following picture shows pictures of the dust storms.",
            "Titan ist der größte Saturnmond. Er hat eine methanreiche Atmosphäre. Seine Oberfläche ist der Erde vergleichbar - sie besteht" +
            " aus etwa 10 % Seen. " +
            "Sein höchster Berg ist 3337 Meter hoch und liegt im 'Mithrim Montes' - es wird ein großer unterirdisches Ozean vermutet. " +
            "Das folgende Bild zeigt Aufnahmen der Staubstürme.", "", "", "");

        hinzuInsDic(K_HARALDLESCH, "The asteroid Haraldlesch is named after the " +
            "German physicist, astronomer, philosopher Harald Lesch. " +
            "He is known, among other things, with the format 'Urknall, Weltall und das Leben' with Josef Gasnner. " +
            "This asteroid has no spherical shape and the very small diameter can only be estimated at the moment. " +
            "If very small asteroids (approx. <25 meters) fall on the earth, they become metorids, " +
            "if these also arrive on earth, then they are metorites.",

            "Der Asteroid Haraldlesch ist nach dem " +
            "deutschen Physiker,Astronom,Philosoph Harald Lesch benannt. " +
            "Er ist u.a. durch das Format 'Urknall,Weltall und das Leben' mit Josef Gasnner bekannt. " +
            "Dieser Asteroid hat keine Kugelform und der sehr kleine Durchmesser kann zur Zeit nur geschätzt werden. " +
            "Wenn sehr kleine Asteroiden (ca. < 25 Meter) auf die Erde fallen, werden Sie zu Meteoroiden, " +
            "kommen diese auch auf der Erde an, dann sind es Meteoriten.", "", "", "");

        hinzuInsDic(K_PLUTO, "Pluto lost its planetary status through the discovery of other smaller planets. " +
            "Pluto's orbit around the sun is an ellipse. The long distance is 7.7 billion kilometers, the short " +
            "distance is 4.4 billion kilometers. " +
            "Pluto even has 5 moons: Charon, Nix, Hydra, Styx, Kerberos. Pluto 'fights' with Eris for the title of the largest dwarf planet." +
            "But Pluto is not as heavy as Eris in any case.",

            "Durch die Entdeckung weiterer kleinerer Planeten verlor Pluto sein Planetenstatus. " +
            "Plutos Bahn um die Sonne ist eine Ellipse. Der Lange Abstand ist 7,7 Mrd. Kilometer, der kurze Abstand ist 4,4 Mrd. Kilometer. " +
            "Pluto hat sogar 5 Monde : Charon, Nix, Hydra, Styx, Kerberos. Pluto 'kämpft' mit Eris um den Titel größte Zwergplanet. " +
            "Pluto ist aber in jedem Fall nicht so schwer wie Eris.", "", "", "");


        hinzuInsDic(K_CHARON, "Charon is a very big moon for Pluto. Charon is half the diameter of Pluto " +
            "and has at least 1/10 of the earth's mass. " +
            "Charon has mountains and gorges on the north side. The south side is smooth and " +
            "contains the expected impact craters. Charon looks like a Pluto bump on telescopes.",

            "Charon ist für Pluto ein sehr grosser Mond. Charon hat die Hälfte von Plutos Durchmesser " +
            "und hat immerhin 1/10 der Erdmasse. " +
            "Charon hat auf der nördlichen Seite Berge und Schluchten. Die südliche Seite ist glatt und " +
            "enthält die erwarteten Einschlagkrater. Charon sieht auf Teleskopen wie eine Beule von Pluto aus.", "", "", "");

        hinzuInsDic(K_ERIS, "The ice planet Eris is a very bright and the heaviest dwarf planet -" +
            "Pluto could be ahead of Eris in diameter. Eris moves very slowly and is therefore almost 'overlooked'. " +
            "In the following brightness-enhanced image you can also see the moon Dysnomia at the bottom left.",

            "Der Eisplanet Eris ist ein sehr heller und der schwerste Zwergplanet - " +
            "im Durchmesser könnte Pluto vor Eris liegen. Eris bewegt sich sehr langsam und ist deswegen fast 'übersehen' worden." +
            " Im folgenden helligkeitsverstärkten Bild kann man links unten auch den Mond Dysnomia erkennen.", "", "", "");


        hinzuInsDic(K_ARIADNE, "Ariadne is an asteroid in the main asteroid belt. " +
            "Ariadne is a woman's name in Greek mythology. Ariadne helped defeat the Minotaur and " +
            "later married the wine god Dionysos. The asteroids near Ariadne form the Ariadne family. " +
            "The exact appearance of Ariadne can currently only be guessed at.", "Ariadne ist ein Asteroid im Asteroiden-Hauptgürtel. " +
            "Ariadne ist ein Frauenname in der grieschischen Mythologie. Ariadne half den Minotaurus zu besiegen und " +
            "heiratete spätere den Weingott Dionysos. Die Asteroiden in der Nähe von Ariadne bilden die Ariadne-Familie. " +
            "Das genaue Aussehen von Ariadne kann derzeit nur vermutet werden.", "", "", "");

        hinzuInsDic(K_PALLAS,
            "Pallas is the second heaviest asteroid in the asteroid belt. " +
            "But Pallas is the largest asteroid in the asteroid belt. Pallas is a protoplanet, " +
            "i.e. it is a forerunner of a real planet. The following picture shows a photo taken by the Hubbel Telescope.",

            "Pallas ist der zweitschwerste Asteroid im Asteroidengürtel. " +
            "Pallas ist aber der grösste Asteroid im Asteroidengürtel. Pallas ist ein Protoplanet, " +
            "d.h. er ist ein Vorläufer eines echten Planeten. Das folgende Bild zeigt eine Aufnahme vom Hubbel Telescope.", "", "", "");

        hinzuInsDic(K_VESTA, "Vesta is the second largest asteroid in the asteroid belt. " +
            "Vesta is the heaviest asteroid in the asteroid belt. Vesta has a large proportion of metal." +
            "Vesta is a protoplanet, i.e. it is a forerunner of a real planet. In the following picture is the original picture on the left. " +
            "On the right side is a picture with more contrast.",

            "Vesta ist der zweitgrösste Asteroid im Asteroidengürtel. " +
            "Vesta ist aber der schwerste Asteroid im Asteroidengürtel. Vesta hat eine großen Metallanteil. " +
            "Vesta ist ein Protoplanet, d.h. er ist ein Vorläufer eines echten Planeten. Im folgenden Bild ist links die Originalaufnahme und " +
            "rechts eine mit mehr Kontrast.", "", "", "");

        hinzuInsDic(K_SIRIUS_A, "Sirius A is the larger star in the Sirius binary system. " +
            "Sirius A is the brightest star that can be observed in the night sky. A third companion is believed to be, " +
            "could not be confirmed so far.",

            "Sirius A ist der größere Stern im Doppelsternsystem Sirius. " +
            "Sirius A ist der hellste Stern, der am Nachthimmel beobachtet werden kann. Ein dritter Begleiter wird vermutet, " +
            "konnte aber bisher nicht bestätigt werden.", "", "", "");
        hinzuInsDic(K_SIRIUS_B, "Sirius B is in the Sirus binary star system the " +
            "smaller star. Sirius B is a white dwarf. Sirius B is about the size of Earth, " +
            "but Sirus B is as heavy as the sun. " +
            "The special thing about white dwarfs is that their diameter decreases with increasing mass. " +
            "A white dwarf can only be stable up to 1.5 times the mass of the sun.", "Sirius B ist im Sirus-Doppelsternsystem der " +
            "kleinere Stern. Sirius B ist ein weißer Zwerg. Sirius B ist von der Grösse etwa so groß wie die Erde, " +
            "aber Sirus B ist genauso schwer wie die Sonne. " +
            "Das Besondere bei weißen Zwergen ist, das deren Durchmesser mit zunehmender Masse abnimmt. " +
            "Ein weißer Zwerg kann nur bis zu einer 1,5-fachen Masse der Sonne stabil sein.", "", "", "");

        hinzuInsDic(K_ALPHA_CENTAURI_A, "Alpha Centauri A is part of the double star system Alpha Centauri. " +
            "The binary star system lies in the constellation of the centaur. " +
            "Alpha Centauri A is richer in metals than our sun and therefore older than our sun.",

            "Alpha Zentauri A ist Teil des Doppelsternsystem Alpha Zentauri. " +
            "Das Doppelsternsystem liegt im Sternbild des Zentauren. " +
            "Alpha Centauri A ist metallreicher als unsere Sonne und damit auch älter als unsere Sonne. ", "", "", "");

        hinzuInsDic(K_ALPHA_CENTAURI_B, "Alpha Centauri B is part of the double star system Alpha Centauri. " +
            "The single stars of the double star system can only be recognized separately in the telescope. " +
            "Alpha Centauri A and B were created at the same time.", "Alpha Zentauri B ist Teil des Doppelsternsystem Alpha Zentauri. " +
            "Die Einzelsterne des Doppelsternsystem sind erst im Fernrohr separat erkennbar. " +
            "Alpha Zentauri A und B sind zur gleichen Zeit entstanden.", "", "", "");


        hinzuInsDic(K_R_CORONA_BOREALIS,
            "R-Corona-Borealis lies in the 'target' of the constellation Corona-Borealis. The yellow giant star has a high proportion of helium. " +
            "When helium fuses to carbon, dust is created that is repelled at irregular intervals. When such a cloud of dust comes into our line of sight, " +
            "the star is getting darker.",

            "R-Corona-Borealis liegt in der 'Zielscheibe' vom Sternbild Corona-Borealis. Der gelbe Riesenstern hat einen hohen Heliumanteil. " +
            "Wenn Helium zu Kohlenstoff fusioniert, entsteht Staub, der in unregelmäßigen Abständen abgestossen wird. Wenn eine solche Staubwolke in unsere Sichtlinie kommt, " +
            "wird der Stern dunkler."
            , "", "", "");
        hinzuInsDic(K_STEPHENSON,
            "Stephenson 2 - 18 is a red giant star. It is located in the Stephenson star cluster and is one of the largest stars ever. " +
            "Sizing a star is not easy because the brightness decreases with distance from the square, " +
            "i.e. if the distance is not correct it is not the size. ",

            "Stephenson 2 - 18 ist ein roter Riesenstern. Er befindet sich im Stephenson Sternenhaufen und ist einer der grössten Sterne überhaupt. " +
            "Die Grössenbestimmung eines Sterns ist nicht einfach, da die Helligkeit mit dem Abstand zum Quadrat abnimmt, " +
            "d.h. wenn der Abstand nicht korrekt ist, ist es die Größe auch nicht."
            , "", "", "");
        hinzuInsDic(K_KEPPLER_160D,
            "Kepler 160 D (KOI-456.04) is almost twice the size of the Earth and " +
            "orbits a sun-like star. This also at a distance, " +
            "which allows life-friendly temperatures on the planet's surface. " +
            "The temperature should be about 5 degrees on average (10 degrees less than on Earth). " +
            "The light intensity would be 93% of the earthly value."
            ,
            "Kepler 160 D (KOI-456.04) ist knapp doppelt so groß wie die Erde und " +
            "umkreist einen sonnenähnlichen Stern. In einem Abstand, " +
            "der lebensfreundliche Temperaturen auf der Planetenoberfläche zulässt. " +
            "Die Temperatur müsste im Durchschnitt ca. 5 Grad sein (10 Grad weniger als die Durchschnittstemperatur der Erde). " +
            "Die Lichtstärke wäre 93 % des irdische Wertes."
            , "", "", "");

        hinzuInsDic(K_MOND_ENCELADUS,
            "The moon Enceladus releases particles at the south pole. Because Enceladus also moves on a dense part of the Saturn ring, " +
            "one suspects that Enceladus produces this part of the ring itself. Due to this south polar activity one also suspects " +
            "under the ocean, which is under the ice crust, volcanic activity.",

            "Der Mond Enceladus stösst am Südpol Partikel aus. Da Enceladus sich auch auf einem dichten Teil des Saturnrings bewegt, " +
            "vermutet man, das Enceladus diesen Ringteil selbst erzeugt. Durch diese Südpolaktivität vermutet man auch " +
            "unter dem Ozean, der sich unter der Eiskruste befindet, vulkanische Aktivitäten."
            , "", "", "");
        hinzuInsDic(K_MOND_JAPETUS,
            "Japetus probably consists almost entirely of water ice. " +
            "However, the moon has a very dark region that is named after your explorer Giovanni Domenico Cassini. " +
            "Japetus also has a 1300 km ridge, the origin of which is a great mystery.",

            "Japetus besteht wahrscheinlich fast komplett aus Wassereis. " +
            "Der Mond hat jedoch eine sehr dunkle Region, die nach Ihrem Entdecker Giovanni Domenico Cassini benannt ist. " +
            "Japetus hat auch einen 1300 km langen Bergrücken, dessen Ursprung ein großes Rätsel ist."

            , "", "", "");

        hinzuInsDic(K_PROXIMA_CENTAURI,
            "Proxima Centauri is the closest star to the sun. " +
            "Proxima Centauri is a red dwarf. Red dwarfs are the most common type of stars. " +
            "Red dwarfs already have enough mass to burn hydrogen. " +
            "Red dwarfs burn very slowly and therefore do not shine so brightly. " +
            "Proxima has strong energy outbreaks (flares) that make the star appear differently bright. " +
            "In the following picture you can see that Proxima is only slightly larger than Jupiter.",

            "Proxima Centauri ist der nächste Stern zur Sonne. " +
            "Proxima Centauri ist ein roter Zwerg. Rote Zwerge sind die häufigste Art von Sternen. " +
            "Rote Zwerge haben schon genug Masse um Wasserstoff zu verbrennen. " +
            "Rote Zwerge verbrennen aber nur sehr langsam und leuchten deswegen nicht so hell. " +
            "Proxima hat starke Energieausbrüche (Flares), die den Stern unterschiedlich hell erscheinen lassen. " +
            "Auf dem folgenden Bild kann man sehen, das Proxima nur wenig größer als der Jupiter ist. ", "", "", "");

        hinzuInsDic(K_PROXIMA_CENTAURI_B, "Proxima Centauri B is an exoplanet, " +
            "which is even in the habitable zone of its star Proxima Centauri. " +
            "Habitable zone means that there should be liquid water. " +
            "Proxima Centauri B always turns the same side to its star. This side could not only be very hot, " +
            "but also exposed to strong X-rays. The opposite side is very cold. " +
            "The density of the planet can currently only be estimated.",

            "Proxima Centauri B ist ein Exoplanet, " +
            "der sich sogar in der habitablen Zone von seinem Stern Proxima Centauri befindet. " +
            "Habitable Zone bedeutet, dass es flüssiges Wasser geben müsste. " +
            "Proxima Centauri B wendet seinem Stern immer die gleiche Seite zu. Diese Seite könnte dadurch nicht nur sehr heiss, " +
            "sondern auch starker Röntgenstrahlung ausgesetzt sein. Die abgewandte Seite ist sehr kalt. " +
            "Die Dichte des Planeten kann derzeit nur geschätzt werden.", "", "", "");

        hinzuInsDic(K_SAGGITARIUS_A, "Sagittarius A* is the black hole in the center of our Milky Way. " +
            "It has about 4.1 million solar masses. This black hole is more passive, " +
            "we can only observe it through the effects of gravity on flying stars. " +
            "Black holes are 'only' active for about 100 million years, after which they 'devoured' their surroundings. " +
            "In the picture you can see how the color of the passing starlight changes due to gravity." +
            "The Hawking temperature is used for comparability.",

            "Sagittarius A* ist das schwarze Loch im Zentrum unserer Milchstraße. " +
            "Es hat etwa 4,1 Millionen Sonnenmassen. Dieses schwarze Loch ist eher passiv," +
            " wir können es nur durch Schwerkraftwirkungen auf vorbeifliegende Sterne beobachten. " +
            "Schwarze Löcher sind 'nur' etwa 100 Millionen Jahre aktiv, danach haben Sie ihre Umgebung leer 'gefressen'. " +
            "Im Bild sieht man wie sich die Farbe des vorbeifliegenden Sternenlichts durch die Schwerkraft verändert." +
            "Für die Vergleichbarkeit wird die Hawkingtemperatur verwendet.", "", "", "");

        hinzuInsDic(K_M87_TEXT, "The black hole in the center of the giant galaxy M87 has 6.5 billion solar masses. " +
            "The following photo is the first photo of a black hole. It was measured using interference. " +
            "(like the stripes in the double slit experiment) " +
            "The light source are the particles that heat up when they plunge into the rotating black hole " +
            "and the projection surface are 8 radio telescopes on Earth. The temperature in black holes is not known. However, the Hawking temperature is used for comparability.",

            "Das schwarze Loch im Zentrum der Riesengalaxie M87 hat 6,5 Millarden Sonnenmassen. " +
            "Das folgende Foto ist das erste Foto von einem schwarzen Loch. Es wurde mit Hilfe von Interferenz(Überlagerung) gemessen. " +
            "(wie die Streifen beim Doppelspaltexperiment) " +
            "Die Lichtquelle sind die Teilchen die sich beim Hineinstürzen in das sich drehenden schwarzen Lochs aufheizen" +
            " und die Projektionsfläche sind 8 Radioteleskope auf der Erde. Die Temperatur in schwarzen Löchern ist nicht bekannt. Für die Vergleichbarkeit wird aber die Hawkingtemperatur verwendet.", "", "", "");
        hinzuInsDic(K_M87, "Centre of M87", "Zentrum von M87", "", "", "");


        hinzuInsDic(K_1407_TEXT,

            "J1407 is a young star ('only' 16 million years old). The special thing is its companion." +
            "It could be a brown dwarf or an exoplanet with a huge ring system." +
            "One suspects a planet with rings, because the companion darkened the J1407 in different ways during the 56-day flyby." +
            "The 1/2% or even 2 percent darkening would explain rings with gaps."

            , "J1407 ist ein junger Stern ('nur' 16 MillionenJahre alt). Das besondere ist sein Begleiter. " +
            "Es könnte entweder ein brauner Zwerg oder ein Exoplanet mit riesigem Ringsystem sein. " +
            "Man vermutet eher einen Planet mit Ringen, weil der Begleiter den J1407 im 56 Tage dauernden Vorbeiflug sehr unterschiedlich stark verdunkelt hat. " +
            "Die mal 1/2 % bis sogar 2 prozentige Verdunkelung würden Ringe mit Lücken erklären.",
            "", "", "");


        hinzuInsDic(K_SPEED,
            "speed"
            , "Geschw.", "", "", "");

        hinzuInsDic(K_SPEED_X,
            "Speed X "
            , "Geschw.X", "", "", "");

        hinzuInsDic(K_SPEED_Y,
        "Speed Y "
        , "Geschw.Y", "", "", "");

        hinzuInsDic(K_SPEED_Z,
        "Speed Z "
        , "Geschw.Z", "", "", "");

        hinzuInsDic(K_DISTANZ,
        "dist."
        , "Abstand", "", "", "");

        hinzuInsDic(K_EINKLAPPEN,
        " collapse"
        , " Einklappen", "", "", "");

        hinzuInsDic(K_AUSKLAPPEN,
        " unfold"
        , " Ausklappen", "", "", "");

        hinzuInsDic(K_NO_MASSE,
       "no mass\nmore"
       , "keine Masse\nmehr", "", "", "");

        hinzuInsDic(K_START,
         " start"
         , " Start", "", "", "");

        hinzuInsDic(K_STOPP,
        " stop"
        , " Stopp", "", "", "");

        hinzuInsDic(K_TIME_UNITS,
      " time units"
      , " Zeiteinheiten", "", "", "");

        hinzuInsDic(K_WER_HAT_AM_MEISTEN_MONDE,
   "Which planet has the most moons?"
   , "Welcher Planet hat die meisten Monde?", "", "", "");


        hinzuInsDic(K_WER_HAT_AM_WENIGSTEN_MONDE,
   "Which planet has the fewest moons?"
   , "Welcher Planet hat die wenigsten Monde?", "", "", "");

        hinzuInsDic(K_WER_HAT_AM_PHOBOS_UND_DEIMOS,
   "Which planet has the moons Phobos and Deimos?"
   , "Welcher Planet hat die Monde Phobos und Deimos?", "", "", "");



    hinzuInsDic(K_GEHOERT_ZU,
    " belongs to "
   , " gehört zu ", "", "", "");
    hinzuInsDic(K_HAT_MONDE_ABER,
    "has moons, but "
   , "hat Monde, aber ", "", "", "");
    hinzuInsDic(K_IST_NICHT_DABEI,
    " doesn't."
   , " ist nicht dabei.", "", "", "");
    hinzuInsDic(K_ZU_WEM_GEHOERT_MOND,
    "Which celestial body does ## belong to?"
   , "Zu welchem Himmelskörper gehört ##?", "", "", "");
    hinzuInsDic(K_HAT_EIN_MOND_ABER,
    "has a moon, but that's not "
   , "hat ein Mond, aber das ist nicht ", "", "", "");

    hinzuInsDic(K_WER_IST_AM_WEITESTEN_VON_DER_SONNE_ENTFERNT,
    "Which celestial body is furthest from the sun?"
   , "Welcher Himmelskörper ist am weitesten von der Sonne entfernt?", "", "", "");
    hinzuInsDic(K_WER_IST_AM_KUERZESTEN_VON_DER_SONNE_ENTFERNT,
     "Which celestial body is closest to the sun?"
   , "Welcher Himmelskörper ist am nähsten an der Sonne?", "", "", "");


    hinzuInsDic(K_WER_HAT_MEHR_MASSE,
   "Who has more mass?"
   , "Wer hat mehr Masse?", "", "", "");
        hinzuInsDic(K_WER_HAT_WENIGER_MASSE,
       "Who has less mass?"
       , "Wer hat weniger Masse?", "", "", "");

        

        hinzuInsDic(K_WER_HAT_GROESSTE_DICHTE,
    "Who has higher density?"
    , "Wer hat höhere Dichte?", "", "", "");

        hinzuInsDic(K_WER_HAT_WENIGSTEN_DICHTE,
        "Which has the lower density?"
        , "Wer hat die kleinere Dichte?", "", "", "");

        hinzuInsDic(K_MASSE_VERFUEGBAR,
    " mass available"
    , " Masse verfügbar", "", "", "");

        hinzuInsDic(K_MOND_STYX,
     "The moon Styx is the smallest of Pluto. It was discovered by the Hubbel space telescope while searching for planetary rings. " +
     "Styx is close to a 1:3 orbit resonance with Charon. " +
     "This means that if Styx has circled the center of gravity of Pluto / Charon 1 time, then Charon has done this 3 times in the same time.",

     "Der Mond Styx ist der kleinste Plutomond. Er wurde bei der Suche nach Planetenringen vom Hubbel-Weltraumteleskop entdeckt. " +
     "Styx befindet sich dabei nahe einer 1:3-Bahnresonanz mit Charon. " +
     "Dies bedeutet, wenn Styx 1 mal den Schwerpunkt von Pluto/Charon umrundet hat, dann hat Charon dies in der gleichen Zeit 3 Mal getan."
     , "", "", "");

        hinzuInsDic(K_MOND_KERBEROS,
     "The moon Kerberos has only 10% the brightness of Nix." +
     "The moon was discovered by the Hubbel Space Telescope in 2011 with an exposure time of 8 minutes. " +
     "Its orbit around Pluto is nearly circular. " +
     "(57,780 km ± 20 km) The photo was taken from a distance of 396,100 km from the 'New Horizons' spacecraft.",

     "Der Mond Kerberos hat nur 10% der Helligkeit von Nix. " +
     "Der Mond wurde 2011 vom Hubbel-Weltraumteleskop mit einer Belichtungszeit von 8 Minuten entdeckt. " +
     "Seine Umlaufbahn um Pluto ist nahezu kreisförmig. " +
     "(57.780 km ± 20 km) Das Foto ist aus 396.100 km Entfernung von der Raumsonde 'New Horizons' aufgenommen worden."
     , "", "", "");
        hinzuInsDic(K_MOND_HYDRA,
      "The moon Hydra was discovered together with the moon Nix in 2005 with the Hubbel space telescope." +
      "Hydra is the outermost moon of Pluto. It is believed that its surface consists entirely of water ice. " +
      "The moon's orbit also indicates that it is not a captured asteroid, " +
      "but like Nix is further parts of the collision of Charon and Pluto.",

      "Der Mond Hydra wurde gemeinsam mit Mond Nix 2005 mit dem Hubbel-Weltraumteleskop entdeckt. " +
      "Hydra ist der äußerste Mond vn Pluto. Man vermutet, das seine Oberfläche komplett aus Wassereis besteht. Die Bahn des Mondes deutet auch daraufhin, das er kein eingefangener Asteroid ist, " +
      "sondern wie Nix weitere Teile der Kollision von Charon und Pluto ist."
      , "", "", "");

        hinzuInsDic(K_MOND_NIX,
      "The moon Nix was discovered together with the moon Hydra with the Hubbel space telescope in 2005. " +
      "Since an asteroid was already named Nyx (Nyx was the mother of Charon in Greek mythology), " +
      "a slightly different spelling was chosen. ",
      "Der Mond Nix wurde gemeinsam mit Mond Hydra erst 2005 mit dem Hubbel-Weltraumteleskop entdeckt. " +
      "Da bereits ein Asteroid den Namen Nyx (Nyx war die Mutter von Charon in der griechischen Mythologie) erhalten hatte, " +
      "wurde eine leicht veränderte Schreibweise gewählt. "
      , "", "", "");

        hinzuInsDic(K_BRAUNER_ZWERG_SCHOLZ_TEXT,
      "This brown dwarf and its companion (a red dwarf) passed our solar system in 0.82 light years 70,000 years ago. It is believed that these two stars could be seen with the naked eye. " +
      "Such an approximation only occurs about every 9 million years.",
       "Diese braune Zwerg und sein Begleiter (ein roter Zwerg) passierten vor 70.000 Jahren unser Sonnensystem in 0.82 Lichtjahren. Man vermutet, das diese beiden Sterne mit bloßem Auge zu erkennen waren. " +
      "Solch eine Annährung tritt nur nur ca. alle 9 Miollionen Jahre auf."
      , "", "", "");

        hinzuInsDic(K_BRAUNER_ZWERG_SDSS_1416_13B,
      "SDSS 1416 + 13B is the coolest brown dwarf that has been discovered so far. The 'only' 227 degrees Celcis suggests that the star is very old - an estimated 10 billion years. " +
      "This brown dwarf cannot be seen in the visible range, but only in the infrared range. Like most brown dwarfs, SDSS 1416 + 13B and SDSS 1416 + 13A form a binary star system.",

      "SDSS 1416+13B ist der bislang kühlste Braune Zwerg, der entdeckt worden ist. Die 'nur' 227 Grad Celcis deutet daraufhin hin das, der Stern sehr alt ist - geschätzt werden 10 Milliarden Jahren. " +
      "Dieser braune Zwerg kann nicht im sichtbaren Bereich gesehen werden, sondern nur noch noch im infrarot Bereich. Wie die meisten braunen Zwerge bildet SDSS 1416+13B mit SDSS 1416+13A ein Doppelsternsystem. "
      , "", "", "");

        hinzuInsDic(K_NEBEL_PFERDEKOPF,
       "Horsehead Nebula",
       "Pferdekopfnebel"
        , "", "", "");

        hinzuInsDic(K_NEBEL_PFERDEKOPF_TEXT,
        "The Horsehead Nebula was discovered by photography in 1887. The nebula itself is a collection of gas and dust that emits very little light and therefore appears dark. The nebula consists largely of hydrogen.",
         "Der Pferdekopfnebel wurde 1887 mittels Photogrphie entdeckt. Der Nebel selbst ist eine Ansammlung von Gas und Staub, die nur sehr wenig Licht abstrahlen und deswegen dunkel erscheinen. Der Nebel besteht zum großen Teil aus Wasserstoff."
        , "", "", "");

        hinzuInsDic(K_NEBEL_ORION,
        "OrionNebula",
        "Orionnebel"
         , "", "", "");

        hinzuInsDic(K_NEBEL_ORION_TEXT,
        "The Orion Nebula is visible to the naked eye and was thought to be a star until the 17th century. With the first telescopes, however, the various objects could be recognized. By the end of the 19th century, several hundred stars had already been discovered. Today, the Orion Nebula is one of the best-studied star-forming regions.",
        "Der Orionnebel ist mit bloßem Auge erkennbar und wurde bis ins 17. Jahrhundert für ein Stern gehalten. Mit den ersten Fernrohren jedoch konnten die verschiedenen Objekte erkannt werden. Ende des 19. Jahrhunderts waren bereits mehrere hundert Sterne entdeckt. Heute ist der Orionnebel eines der am besten erforschten Sternentstehungsgebiete."
        , "", "", "");

        hinzuInsDic(K_NEBEL_KREBS,
        "Crab Nebula",
        "Krebsnebel"
        , "", "", "");

        hinzuInsDic(K_NEBEL_KREBS_TEXT,
        "The Crab Nebula emerged from a supernova about 1000 years ago. Inside the Crab Nebula is a very hot neutron star - this pulsar spins very quickly (30 times per second) and has a diameter of 28 to 30 km. This dwarf star generates a super strong magnetic field of about 100 million Tesla. The fog is expanding at about 1500 km per second. Gamma rays shoot out of the nebula again and again.",
        "Der Krebsnebel ist aus einer Supernova vor ca. 1000 Jahren entstanden. Im Innern des Krebsnebel ist ein sehr heisser Neutronenstern - dieser Pulsar dreht sich sehr schnell (30 mal pro Sekunde) und hat einen Durchmesser von 28 bis 30 km. Dieser Zwergstern erzeugt ein super starkes Magnetfeld ca. 100 Mio. Tesla. Der Nebel dehnt sich mit ca. 1500 km pro Sekunde aus. Aus dem Nebel schiessen auch immer wieder Gamma-Strahlen."
        , "", "", "");

        hinzuInsDic(K_WASP_189_B_TEXT,
        "The ultra-hot exoplanet was discovered in 2018. It orbits its star in 2.7 days and at a very small distance (5% of Earth-Sun). The planet moves in locked rotation. The atmosphere of the day side and that of the night side are in such an exchange that it can even rain gems. The planet was determined in the transit procedure, during which it eclipses its star for a short time in the flyby with a certain intensity.",
        "Der ultraheise Exoplanet wurde 2018 entdeckt. Er bewegt sich in 2,7 Tagen um seinen Stern und dies in einem sehr kleinem Abstand (5% von Erde-Sonne). Der Planet bewegt sich in gebundener Rotation. Die Athmosphäre der Tageseite und die der Nachtseite sind in einem solchem Austausch, das es sogar Edelsteine regnen kann. Der Planet wurde im Transitverfahren bestimmt, hierbei verdunkelt er seine Stern für kurze Zeit im Vorbeiflug in einer gewissen Stärke."
        , "", "", "");
        

        hinzuInsDic(K_PRUEFUNG_ALLES_RICHTIG,
              "You can be proud of yourself.",
              "Du kannst stolz auf dich sein."
              , "", "", "");

        hinzuInsDic(K_PRUEFUNG_FAST_ALLES_RICHTIG,
          "This was a good performance.",
          "Dies war eine gute Leistung."
          , "", "", "");

        hinzuInsDic(K_PRUEFUNG_ZU_WENIG_RICHTIG,
       "Keep at it and keep training - you'll make it soon.",
       "Bleib dran und trainier weiter - Du schaffst es bald."
       , "", "", "");

        hinzuInsDic(K_PRUEFUNG_VERDIENT_MEHR,
        "You earned " +
         VirtualLookSteuerung.K_GOLD +
        "two" +
        VirtualLookSteuerung.K_WHITE +
        " 2B-coins.",
        "Du hast Dir " +
        VirtualLookSteuerung.K_GOLD +
        "zwei" +
        VirtualLookSteuerung.K_WHITE +
        " 2B-Münzen verdient."
         , "", "", "");

        hinzuInsDic(K_PRUEFUNG_VERDIENT_1,
        "You earned " +
        VirtualLookSteuerung.K_GOLD +
        "one" +
         VirtualLookSteuerung.K_WHITE +
        " 2B-coin.",
        "Du hast Dir " +
        VirtualLookSteuerung.K_GOLD +
        "eine" +
        VirtualLookSteuerung.K_WHITE +
        " 2B-Münze verdient."
        , "", "", "");

        hinzuInsDic(K_PRUEFUNG_RICHTIG,
          "correct",
          "richtig"
          , "", "", "");

        hinzuInsDic(K_BIS_JETZT_RICHTIGE_ANTWORTEN,
        "Correct answers so far:",
        "Bis jetzt richtige Antworten:"
        , "", "", "");
        

        hinzuInsDic(K_PRUEFUNG_ES_WAREN,
          "There were ",
          "Es waren "
          , "", "", "");

        hinzuInsDic(K_PRUEFUNG_ANTWORTEN_VON,
          " answers out of 10 ",
          " Antworten von "
         , "", "", "");

        hinzuInsDic(K_PHOBOS_UND_DEIMOS,
          "and they belong to the smallest moons at all",
          "und sie gehören zu den kleinsten Monden überhaupt"
         , "", "", "");

        hinzuInsDic(K_HAT_MONDE_ABER_NICHT_DEIMOS_UND_PHOBOS,
         ".. has moons but they are not called Phobos and Deimos",
         ".. hat Monde aber die heissen nicht Phobos und Deimos"
        , "", "", "");

        hinzuInsDic(K_NUR_PLANETEN_HABEN_MONDE,
        ".. only planets have moons",
        ".. nur Planeten haben Monde"
       , "", "", "");

        /**
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
        hinzuInsDic (K_GRAD, " Degree",  " Grad","", "", "");
    **/
    }

    public void hinzuInsDic(int pWelches, string pEnglish, string pDeutsch, string pSprache3, string pSprache4, string pSprache5)
    {
        Sprachdatum lSprachdatum = new Sprachdatum();
        lSprachdatum.mKonstSatz = pWelches;
        lSprachdatum.mDeutsch = pDeutsch;
        lSprachdatum.mEnglish = pEnglish;
        mMyHimmelskoerperDict.Add(pWelches, lSprachdatum);
    }


    public string lieferWort(int pWelches)
    {
        Sprachdatum lSprachdatum = getMyHimmelskoerperDict()[pWelches];

        if (mAktuelleSprache == K_ENGLISH)
        {
            return lSprachdatum.mEnglish;
        }
        else
        {
            return lSprachdatum.mDeutsch;
        }
    }

    public Dictionary<int, Sprachdatum> getMyHimmelskoerperDict()
    {
        if (mMyHimmelskoerperDict == null || mMyHimmelskoerperDict.Count == 0)
        {
            init();
        }

        return mMyHimmelskoerperDict;
    }

    public void setSprache(int pSprache)
    {
        PlayerPrefs.SetInt(K_SPRACHE, pSprache);
        mAktuelleSprache = PlayerPrefs.GetInt(K_SPRACHE);
    }

    public int getSprache()
    {
        getMyHimmelskoerperDict();

        return mAktuelleSprache;
    }

    public void setzeNamen(string pName)
    {
        if (pName != null && pName.Length > 2 && !pName.Equals(K_INIT_YOU) && !pName.Equals(K_INIT_DU))
        {
            if (pName.Length < 11)
            {
                PlayerPrefs.SetString(Sprachenuebersetzer.K_NAME, pName);
            }
            else
            {
                PlayerPrefs.SetString(Sprachenuebersetzer.K_NAME, pName.Substring(0, 11));
            }
        }
    }

    public string lieferNamen()
    {

        string lName = PlayerPrefs.GetString(Sprachenuebersetzer.K_NAME);

        if (lName == null || lName.Length == 0)
        {
            return lieferWort(Sprachenuebersetzer.K_INIT_NAME);
        }

        return lName;
    }

    public bool istInitName()
    {

        return lieferNamen().Equals(K_INIT_DU) || lieferNamen().Equals(K_INIT_YOU);
    }

}
