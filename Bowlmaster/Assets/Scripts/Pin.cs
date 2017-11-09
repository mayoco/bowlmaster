 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float standingThreshold=10f;
	public float disToRaise = 40f;

	private Rigidbody rigidBody;
//	private Vector3 StartPosition;
	private Quaternion StartRotation;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
//		StartPosition = transform.position;
		StartRotation = transform.rotation;
	}
	// Update is called once per frame
	void Update () {
	}

	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(rotationInEuler.x+90);//the original x is -90 rotated because of the model
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		//edge case for x,z rotation
		if (tiltInX >= 360)tiltInX = tiltInX % 360;
		if (tiltInX >= 180)tiltInX = 360-tiltInX;

		if (tiltInZ >= 360)tiltInZ = tiltInZ % 360;
		if (tiltInZ >= 180)tiltInZ = 360-tiltInZ;

		return tiltInX < standingThreshold && tiltInZ < standingThreshold;
	}
	public void RaiseIfStanding(){
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, disToRaise, 0), Space.World);
			rigidBody.velocity= new Vector3(0,0,0);
			rigidBody.angularVelocity = new Vector3 (0, 0, 0);
		}
	}

	public void Lower(){
		rigidBody.useGravity = true;
		rigidBody.velocity= new Vector3(0,0,0);
		rigidBody.angularVelocity = new Vector3 (0, 0, 0);
		transform.rotation = StartRotation;
			
	}
}
