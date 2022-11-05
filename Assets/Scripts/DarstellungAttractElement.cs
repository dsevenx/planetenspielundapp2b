using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarstellungAttractElement
{
    public int mNummer;

    public string mName;

    public string mSpeed;

    public string mMasse;

    public int mAbstand;

    public float mTime;

    public bool mAktiv;

    public int mMassenpunkte;

    internal DarstellungAttractElement lieferKopie()
    {
        DarstellungAttractElement lErg = new DarstellungAttractElement();

        lErg.mNummer = this.mNummer;
        lErg.mName = this.mName;
        lErg.mSpeed = this.mSpeed;
        lErg.mMasse = this.mMasse;
        lErg.mAbstand = this.mAbstand;
        lErg.mTime = this.mTime;
        lErg.mAktiv = this.mAktiv;
        lErg.mMassenpunkte = this.mMassenpunkte;

        return lErg;
    }
}
