using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts,frameTexts;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillRolls(List<int> rolls){
		string scoresString = FormatRolls (rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts [i].text = scoresString [i].ToString ();
		} 
	}
	public void FillFrames(List<int> frames){
		for (int i = 0; i < frames.Count; i++) {
			frameTexts[i].text = frames [i].ToString ();
		}
	}
	public void Clean(){
		foreach(var roll in rollTexts)roll.text=" ";
		foreach (var frame in frameTexts)frame.text = "";
	}
	public static string FormatRolls(List<int> rolls){
		StringBuilder builder = new StringBuilder();

		for (int i = 0; i < rolls.Count; i++) {
			builder.Append(rolls[i].ToString()).Append(" ");
		}

		Debug.Log("display input:"+builder);

		string output = "";
		for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length + 1;

			if (rolls [i] == 0) {
				output += "-";
			} else if ((box % 2 == 0 ||box==21)&& rolls [i - 1] + rolls [i] == 10) {
				output += "/";
			}else if(box>=19&&rolls[i]==10){
				output += "X";
			} else if (rolls [i] == 10) {
				output += "X ";
			} else {
				output += rolls [i].ToString ();
			}
		}
		Debug.Log("display output:"+output);
		return output;
	}

}
