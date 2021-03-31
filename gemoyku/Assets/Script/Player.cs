using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float kecepatan, scaleX, lompat;

	// Use this for initialization
	void Start () {
		scaleX = transform.localScale.x;
	}

	void jalan_kiri(){
		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State")){
			GetComponent<Animator> ().SetTrigger ("jalan");
		}
		transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);
		transform.Translate (Vector3.left * kecepatan * Time.fixedDeltaTime, Space.Self);
	}

	void jalan_kanan(){
		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State")){
			GetComponent<Animator> ().SetTrigger ("jalan");
		}
		transform.localScale = new Vector3 (scaleX, transform.localScale.y, transform.localScale.z);
		transform.Translate (Vector3.right * kecepatan * Time.fixedDeltaTime, Space.Self);
	}

	void melompat(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, lompat);
	}

	void berhenti(){
		GetComponent<Animator> ().SetTrigger ("stop");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			jalan_kiri ();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			jalan_kanan ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			melompat ();
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
			berhenti ();
		}
	}
}
