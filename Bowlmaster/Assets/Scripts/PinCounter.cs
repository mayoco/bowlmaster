using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
	public Text standingDisplay;

	private GameManager gameManager;
	private bool ballEnteredBox=false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		gameManager=GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			UpdateStandingCountAndSettle ();
		} else if (ball.inPlay&&ball.GetComponent<Rigidbody> ().velocity == Vector3.zero)
			ball.Reset();// the ball if ball stop before enter pins zone
	}
	public void Reset(){
		lastSettledCount = 10;
	}
	void UpdateStandingCountAndSettle(){
		//Update the lastStandingCount
		//Call PinsHaveSettled() when they have settled
		if(lastStandingCount != CountStanding ()){
			lastChangeTime = Time.time;
			lastStandingCount = CountStanding ();
			return;
		}
		if (Time.time - lastChangeTime > 3)//'3' -> how long to wait to consider pins settled
			PinsHaveSettled ();
	}

	int CountStanding(){
		int standing = 0;

		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding ()) {
				standing++;
			}
		}
		return standing;
	}

	void PinsHaveSettled(){

		int pinFall = lastSettledCount - CountStanding ();
		lastSettledCount = CountStanding ();
		print (pinFall);
//		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		gameManager.Bowl(pinFall);

		standingDisplay.color = Color.green;
		ballEnteredBox = false;
		lastStandingCount = -1;//indicate pins have settled,and ball not back to the box
		ball.Reset();
	}

	void OnTriggerEnter(Collider collider){
		GameObject thingHit = collider.gameObject;

		//Ball enters play box
		if (thingHit.GetComponent<Ball> ()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
	}
}
