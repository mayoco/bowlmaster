using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Vector3 dragStart,dragEnd;
	private float startTime,endTime;
	private Ball ball;


	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void MoveStart(float amount){
		if (ball.inPlay)//only can adjust before it launched
			return;
		ball.transform.Translate(new Vector3(amount,0,0));
	}

	public void DragStar(){
	//Capture time&position of drag start
		dragStart = Input.mousePosition;
		startTime=Time.time;

	}

	public void DragEnd(){
		if (ball.inPlay)
			return;
		//Launch the ball
		dragEnd=Input.mousePosition;
		endTime = Time.time;

		float dragDuration = endTime - startTime;
		float launchSpeedX = (dragEnd.x - dragStart.x) / (2*dragDuration);
		float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

		launchSpeedZ = launchSpeedZ > 900 ? 900 : launchSpeedZ;//set max speed

		Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);

		ball.inPlay = true;
		ball.Launch(launchVelocity);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
