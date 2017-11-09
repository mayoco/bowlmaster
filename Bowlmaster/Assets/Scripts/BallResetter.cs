using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallResetter : MonoBehaviour {
	private Ball ball;
	// Use this for initialization
	void Start () {
	  ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider collider){
		GameObject thingLeft = collider.gameObject;

		if (thingLeft.GetComponent<Ball> ()) {
			ball.Reset ();
		}
	}
}
