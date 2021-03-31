using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jump : MonoBehaviour {

	public float jump;
	bool berpijak = true;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) {
			if (berpijak) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
			}
		}
	}
}
