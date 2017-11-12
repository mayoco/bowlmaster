using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
//	public int lastStandingCount = -1;
	public GameObject playagainbutton;
	public Object newPins;

//	private ActionMaster actionMaster=new ActionMaster(); 
//	private float lastChangeTime;
//	private bool ballEnteredBox=false;
//	private Ball ball;
//	private int lastSettledCount = 10;
	private Animator animator;
	private PinCounter pinCounter;
	private ScoreDisplay scoreDisplay;
	// Use this for initialization
	void Start () {
//		ball = GameObject.FindObjectOfType<Ball> ();
		animator = GetComponent<Animator> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RaisePins(){
	//raise standing ins only by distanceToRaise
		//Debug.Log("Raise Pins.");
		var pins = GameObject.FindObjectsOfType<Pin> ();
		foreach (var pin in pins) {
				pin.RaiseIfStanding ();
		}
	}

	public void LowerPins(){
		//Debug.Log("Lower Pins.");
		var pins = GameObject.FindObjectsOfType<Pin> ();
		foreach (var pin in pins) {
				pin.Lower ();
		}
	}
//	public void ResetBall(){
//		ball.Reset ();
//	}
	public void RenewPins(){
		//Debug.Log("Renew Pins.");
		Object.Instantiate (newPins,new Vector3(0,0,1829),Quaternion.identity);
		pinCounter.Reset ();
	}

//	void UpdateStandingCountAndSettle(){
//		//Update the lastStandingCount
//		//Call PinsHaveSettled() when they have settled
//		if(lastStandingCount != CountStanding ()){
//			lastChangeTime = Time.time;
//			lastStandingCount = CountStanding ();
//			return;
//		}
//		if (Time.time - lastChangeTime > 3)//'3' -> how long to wait to consider pins settled
//			PinsHaveSettled ();
//	}

//	int CountStanding(){
//		int standing = 0;
//
//		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
//			if (pin.IsStanding ()) {
//				standing++;
//			}
//		}
//		return standing;
//	}

//	void PinsHaveSettled(){
//		
//		int pinFall = lastSettledCount - CountStanding ();
//		lastSettledCount = CountStanding ();
//		print (pinFall);
//		ActionMaster.Action action = actionMaster.Bowl (pinFall);
//
//		if (action == ActionMaster.Action.Tidy) {
//			animator.SetTrigger ("tidyTrigger");
//		} else if (action == ActionMaster.Action.EndTurn) {
//			animator.SetTrigger ("resetTrigger");
//		}else if (action == ActionMaster.Action.Reset) {
//			animator.SetTrigger ("resetTrigger");
//		}else if (action == ActionMaster.Action.EndGame) {
//			throw new UnityException ("handle end game.");
//		}
//
//		standingDisplay.color = Color.green;
//		ballEnteredBox = false;
//		lastStandingCount = -1;//indicate pins have settled,and ball not back to the box
//		ball.Reset();
//	}

//	void OnTriggerEnter(Collider collider){
//		GameObject thingHit = collider.gameObject;
//
//		//Ball enters play box
//		if (thingHit.GetComponent<Ball> ()) {
//			ballEnteredBox = true;
//			standingDisplay.color = Color.red;
//		}
//	}

	public void PerformAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
		}else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
		}else if (action == ActionMaster.Action.EndGame) {
			playagainbutton.SetActive(true);
			Debug.Log ("handle end game.");
		}
	}
}
