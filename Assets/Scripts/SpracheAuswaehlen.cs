using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpracheAuswaehlen : MonoBehaviour {

	// Buttoneffekt

	public int mClickModiAktiv;

	private const float K_DISTANCE_KLICK = 0.5f;

	private const int K_BUTTON_INIT = 0;

	private const int K_BUTTON_DRUCK_LAEUFT = 2;


	public Sprachenuebersetzer mSprachenuebersetzer;

	void Start () {
		mSprachenuebersetzer = GameObject.FindGameObjectWithTag ("Sprachenuebersetzer").GetComponent<Sprachenuebersetzer> ();
	
		//mSprachenuebersetzer.setSprache (0); // nur für Test
	}
	
	void Update ()
	{
		if (mSprachenuebersetzer.getSprache () != 0) {
			SceneManager.LoadScene ("PlanetenSpielSzene1");
		}

		if (Input.GetMouseButtonDown (0)) {

			Ray lRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit lRaycastHit;

			if (Physics.Raycast (lRay, out lRaycastHit)) {
			 if (lRaycastHit.transform.tag.StartsWith ("Deutsch")) {

					mSprachenuebersetzer.setSprache (Sprachenuebersetzer.K_DEUTSCH);
					StartCoroutine (clickEffektSprache (lRaycastHit.transform.gameObject));

				}else if (lRaycastHit.transform.tag.StartsWith ("English")) {

					mSprachenuebersetzer.setSprache (Sprachenuebersetzer.K_ENGLISH);
					StartCoroutine (clickEffektSprache (lRaycastHit.transform.gameObject));
				}
			}
		}
	}

	public IEnumerator clickEffektSprache (GameObject pGameObject)
	{
		if (mClickModiAktiv == K_BUTTON_INIT) {

			mClickModiAktiv = K_BUTTON_DRUCK_LAEUFT;

			float lNewZ = pGameObject.transform.position.z + K_DISTANCE_KLICK;
			pGameObject.transform.position = new Vector3 (pGameObject.transform.position.x, pGameObject.transform.position.y, lNewZ);
			yield return new WaitForSeconds (0.2F);

			lNewZ = pGameObject.transform.position.z - K_DISTANCE_KLICK;
			pGameObject.transform.position = new Vector3 (pGameObject.transform.position.x, pGameObject.transform.position.y, lNewZ);
			mClickModiAktiv = K_BUTTON_INIT;
		}
		yield return null;
	}
}
