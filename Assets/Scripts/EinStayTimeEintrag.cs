using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinStayTimeEintrag
{
    public int mStayTime = 0;

    private float mDistTime1 = 0;
    private float mDistTime2 = 0;
    private float mDistTime3 = 0;

    public float mDistanceDurchschnitt = 0;

    public float mDistanceDurchschnittVarianz = 0;


    internal void aktualisier(float pDistance, int pTime)
    {
        mDistTime3 = mDistTime2;
        mDistTime2 = mDistTime1;
        mDistTime1 = pDistance;

        mStayTime = pTime;

        mDistanceDurchschnitt = (mDistTime1 + mDistTime2 + mDistTime3) / 3;

        mDistanceDurchschnittVarianz = mDistanceDurchschnitt / 10;

    }

    internal bool istDistanceAllGroesserNull()
    {
        return mDistTime3 > 0 && mDistTime2 > 0 && mDistTime1 > 0;
    }

    internal bool istEintragPassend()
    {
        return (mDistTime3 + mDistanceDurchschnittVarianz > mDistTime2
                    && mDistTime3 + mDistanceDurchschnittVarianz > mDistTime1

                    && mDistTime2 + mDistanceDurchschnittVarianz > mDistTime3
                    && mDistTime2 + mDistanceDurchschnittVarianz > mDistTime1

                    && mDistTime1 + mDistanceDurchschnittVarianz > mDistTime3
                    && mDistTime1 + mDistanceDurchschnittVarianz > mDistTime2);
    }
}
