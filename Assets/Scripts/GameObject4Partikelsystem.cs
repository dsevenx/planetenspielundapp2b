using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject4Partikelsystem : MonoBehaviour {

	float K_SPEED = 350f;

	void Update () {

		transform.Rotate (Vector3.back * K_SPEED * Time.deltaTime,Space.Self);
	}
}
