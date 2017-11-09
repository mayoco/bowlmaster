using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVeclocity;
	public bool inPlay=false;
	public Vector3 showvelocity;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 StartPosition;
	private Quaternion StartRotation;

	// Use this for initialization
	void Start () {
		StartPosition = transform.position;
		StartRotation = transform.rotation;
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = false;

	}

	public void Launch (Vector3 velocity)
	{
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();
	}

	public void Reset(){
		print ("ball reset.");
		rigidBody.useGravity = false;
		rigidBody.velocity = new Vector3(0,0,0);
		rigidBody.angularVelocity = new Vector3 (0, 0, 0);
		inPlay = false;
		transform.position = StartPosition;
		transform.rotation = StartRotation;
	}
	// Update is called once per frame
	void Update () {
		showvelocity = rigidBody.velocity;
	}
}
