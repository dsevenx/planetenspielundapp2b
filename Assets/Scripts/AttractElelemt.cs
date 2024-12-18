using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttractElelemt : MonoBehaviour

{
    public GameObject mThis;

    public Material mLeerMaterial;

    public Material mSternMaterial;

    public Camera mCamera;

    public int mElementNummer;

    public Rigidbody mRigidbody;

    public Vector3 mPosOfCamera;

    public bool mReadyForCollisionUntersuchung;

    private Plane[] mPlanesVonCamera;

    public AttractElementVerwalter mAttractElementVerwalter;

    public Texture2D mTexture2DCeres; //0.00015X

    public Texture2D mTexture2DCharon; //0.00025X

    public Texture2D mTexture2DEris; // 0.0026X

    public Texture2D mTexture2DKalisto; // 0.018X

    public Texture2D mTexture2DPluto; // 0.022 X

    public Texture2D mTexture2DMerkur; // 0.05 X

    public Texture2D mTexture2DMars; // 0.1 X

    public Texture2D mTexture2DErde; // 1X

    public Texture2D mTexture2DProximaCentauriB; // 1.27 X

    public Texture2D mTexture2DNeptun; // 17 X

    public Texture2D mTexture2DJupiter; // Jupiter 317 X

    public Texture2D mTexture2DROXIMA_ZENTAURI; // 40956 X

    public Texture2D mTexture2Betelguese; // Zentrum

    public bool sollGraviSpueren;

    public int mMassenPunkte;

    public Dictionary<String, EinStayTimeEintrag> mAllEinStayTimeEintrag;

    void attract(AttractElelemt pToAttractElelemt, List<AttractElelemt> lZuDestroy)
    {
        Rigidbody rbToAttract = pToAttractElelemt.mRigidbody;

        AttractVector lKraft = mAttractElementVerwalter.ermittelKraft(mRigidbody.position, mRigidbody.mass, mRigidbody.velocity.magnitude, rbToAttract.position,
            rbToAttract.mass);

        mMassenPunkte = 0;
        if (lKraft.mVectorKreis != Vector3.zero)
        {
            rbToAttract.AddForce(lKraft.mVectorKreis);
        }
        if (lKraft.mVectorGravi != Vector3.zero)
        {
            rbToAttract.AddForce(lKraft.mVectorGravi);
        }

        if (mRigidbody.mass >= rbToAttract.mass
           && pToAttractElelemt.mReadyForCollisionUntersuchung
           && sollGraviSpueren
           && pToAttractElelemt.sollGraviSpueren
           )
        {
            if (!mAllEinStayTimeEintrag.ContainsKey(rbToAttract.name))
            {
                EinStayTimeEintrag lEinStayTimeEintrag = new EinStayTimeEintrag();
                mAllEinStayTimeEintrag.Add(rbToAttract.name, lEinStayTimeEintrag);
            }
            if (mAllEinStayTimeEintrag[rbToAttract.name].mStayTime != mAttractElementVerwalter.lieferZeitIndex())
            {
                mAllEinStayTimeEintrag[rbToAttract.name].aktualisier(lKraft.mDistance, mAttractElementVerwalter.lieferZeitIndex());

                if (mAllEinStayTimeEintrag[rbToAttract.name].istDistanceAllGroesserNull())
                {

                    if (mAllEinStayTimeEintrag[rbToAttract.name].istEintragPassend()
                        && mAllEinStayTimeEintrag[rbToAttract.name].mDistanceDurchschnitt < 25
                        )
                    {
                        float lDistanceAusRadius = bestimmeRadiusAusMasse(pToAttractElelemt.mRigidbody.mass) + bestimmeRadiusAusMasse(mRigidbody.mass);

                        if (lDistanceAusRadius + mAllEinStayTimeEintrag[rbToAttract.name].mDistanceDurchschnittVarianz > mAllEinStayTimeEintrag[rbToAttract.name].mDistanceDurchschnitt)
                        {
                            verschlucken(pToAttractElelemt.mThis, pToAttractElelemt.mRigidbody.mass, lZuDestroy);
                        }
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float lMasseCollidierte = collision.gameObject.GetComponent<Rigidbody>().mass;

        if (mRigidbody.mass >= lMasseCollidierte
            && collision.gameObject.GetComponent<AttractElelemt>().mReadyForCollisionUntersuchung
            && sollGraviSpueren
            && collision.gameObject.GetComponent<AttractElelemt>().sollGraviSpueren
            )
        {
            collision.gameObject.GetComponent<AttractElelemt>().mReadyForCollisionUntersuchung = false;

            float lGesamtMasse10Prozent = (mRigidbody.mass + lMasseCollidierte) / 10;

            float lMassenOnTable = UnityEngine.Random.Range(lGesamtMasse10Prozent / 2, lGesamtMasse10Prozent);

            if (lGesamtMasse10Prozent > lMasseCollidierte || (lMasseCollidierte - lMassenOnTable) <= AttractElementVerwalter.K_START_MASSE_EINZEL_ELEMENT)
            {
                verschlucken(collision.gameObject, lMasseCollidierte, null);
            }
            else
            {
                // Grössere saugt Masse ab
                collision.gameObject.GetComponent<Rigidbody>().mass = lMasseCollidierte - lMassenOnTable;
                mRigidbody.mass += lMassenOnTable;

                Vector3 lGeschwindigkeitKleinereObject = collision.gameObject.GetComponent<Rigidbody>().velocity;
                Vector3 lGeschwindigkeitKleinereObjectEntgegen = new Vector3((-10) * lGeschwindigkeitKleinereObject.x,
                    (-10) * lGeschwindigkeitKleinereObject.y,
                    (-10) * lGeschwindigkeitKleinereObject.z
                    );
                collision.gameObject.GetComponent<Rigidbody>().AddForce(lGeschwindigkeitKleinereObjectEntgegen);

                collision.gameObject.GetComponent<AttractElelemt>().setzeTextureUndScaleAufgrundMasse();
                setzeTextureUndScaleAufgrundMasse();
            }
        }
    }

    private void verschlucken(GameObject gameObject, float lMasseCollidierte, List<AttractElelemt> lZuDestroy)
    {
        mRigidbody.mass += lMasseCollidierte;

        if (lZuDestroy != null)
        {
            lZuDestroy.Add(gameObject.GetComponent<AttractElelemt>());
        }
        else
        {
            mAttractElementVerwalter.verschlucke(gameObject.GetComponent<AttractElelemt>().mElementNummer);
            Destroy(gameObject);

        }
    }


    // void Update() Frame update
    // FixedUpdate Physics update
    void FixedUpdate()
    {
        /*
		mRigidbody.velocity = Vector3.zero;
		mRigidbody.angularVelocity = Vector3.zero;
        */
        //mThis.GetComponent<TrailRenderer>().emitting = true;
        if (sollGraviSpueren)
        {
            List<AttractElelemt> lZuDestroy = new List<AttractElelemt>();

            if (mAttractElementVerwalter != null)
            {
                foreach (var lElement in mAttractElementVerwalter.mMyAttractElemtentDict)
                {
                    if (lElement.Value.mAttractElelemt.sollGraviSpueren && !lElement.Value.mGameobjectAttractElement.name.Equals(this.name))
                    {
                        attract(lElement.Value.mAttractElelemt, lZuDestroy);
                    }
                }

                foreach (var lZuLoeschenElement in lZuDestroy)
                {
                    mAttractElementVerwalter.verschlucke(lZuLoeschenElement.mElementNummer);
                    Destroy(lZuLoeschenElement.mThis);
                }

                if (mElementNummer == 0)
                {
                    float lXMove = mAttractElementVerwalter.lieferXFromMove();
                    float lZMove = mAttractElementVerwalter.lieferZFromMove();

                    DrehVektor lDrehvektor = mAttractElementVerwalter.lieferYFromDreh(lZMove);

                    mCamera.transform.position = new Vector3(mThis.transform.position.x + lXMove
                        ,

                        mThis.transform.position.y + lDrehvektor.mX

                        ,

                        mThis.transform.position.z + lDrehvektor.mY

                        );

                    mPosOfCamera = mCamera.transform.position;

                    mAttractElementVerwalter.setzePositionVonCamera(mPosOfCamera);

                    mCamera.transform.eulerAngles = new Vector3(mAttractElementVerwalter.mEinstellDrehen.mCount
                        , mCamera.transform.rotation.eulerAngles.y,
                         mCamera.transform.rotation.eulerAngles.z)
                        ;
                }

                mReadyForCollisionUntersuchung = true;

                mPlanesVonCamera = GeometryUtility.CalculateFrustumPlanes(mCamera);
            }
        }
    }


    public void setzeTextureUndScaleAufgrundMasse()
    {
        float lMasse = mThis.GetComponent<Rigidbody>().mass;
        mThis.GetComponent<Renderer>().material = mLeerMaterial;

        if (lMasse < 200)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DCeres;//0.00015X
            mMassenPunkte = 1;
        }
        else if (lMasse < 400)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DCharon; //0.00025X
            mMassenPunkte = 2;
        }
        else if (lMasse < 800)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DEris; // 0.0026X
            mMassenPunkte = 2;
        }
        else if (lMasse < 1000)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DKalisto; // 0.018X
            mMassenPunkte = 3;
        }
        else if (lMasse < 1200)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DPluto; // 0.022 X
            mMassenPunkte = 3;
        }
        else if (lMasse < 1600)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DMerkur; // 0.05 X
            mMassenPunkte = 4;
        }
        else if (lMasse < 2000)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DMars; // 0.1 X
            mMassenPunkte = 5;
        }
        else if (lMasse < 2500)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DErde; // 1X
            mMassenPunkte = 6;
        }
        else if (lMasse < 2700)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DProximaCentauriB; // 1.27 X
            mMassenPunkte = 5;
        }
        else if (lMasse < 3300)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DNeptun; // 17 X
            mMassenPunkte = 4;
        }
        else if (lMasse < 5500)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DJupiter; // Jupiter 317 X
            mMassenPunkte = 3;
        }
        else if (lMasse < 10000)
        {
            mThis.GetComponent<Renderer>().material.mainTexture = mTexture2DROXIMA_ZENTAURI; // 40956 X
            mMassenPunkte = 2;
        }
        else
        {
            mThis.GetComponent<Renderer>().material = mSternMaterial;
            mMassenPunkte = 5;
        }

        float lr = bestimmeRadiusAusMasse(lMasse);

        mThis.transform.localScale = new Vector3(lr, lr, lr);
    }

    private static float bestimmeRadiusAusMasse(float lMasse)
    {
        return (float)Math.Pow((double)(lMasse * AttractElementVerwalter.K_MASSEN_RADIUS_UMERECHENFAKTOR), (double)(1f / 3f));
    }
}
