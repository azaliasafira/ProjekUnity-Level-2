using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kamera : MonoBehaviour {

	public Transform targetCamera;
	public float smoothSpeed = 0.05f;
	public Vector3 cameraOffset;

	void FixedUpdate(){
		Vector3 desiredPos = targetCamera.position + cameraOffset;
		Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed);
		transform.position = smoothedPos;
		transform.LookAt (targetCamera);
	}

}
