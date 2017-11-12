using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GameManager : MonoBehaviour {
	
	public List<int> rolls=new List<int>();
	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;
	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();
	}
	public void Bowl(int pinFall){
		rolls.Add (pinFall);

		scoreDisplay.FillRolls (rolls);
		scoreDisplay.FillFrames (ScoreMaster.ScoreCumulative(rolls));

		pinSetter.PerformAction (ActionMaster.NextAction(rolls));
		//Debug
		StringBuilder builder = new StringBuilder();

		for (int i = 0; i < rolls.Count; i++) {
			builder.Append(rolls[i].ToString()).Append(" ");
		}
		Debug.Log("after perform nextAction:"+builder);
		//Debug until this line



		ball.Reset ();

	}
	public void ResetScore(){
		rolls=new List<int>();
		scoreDisplay.Clean ();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
