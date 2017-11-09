using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action	{Tidy,Reset,EndTurn,EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public static Action NextAction(List<int> pinFalls){
		ActionMaster am = new ActionMaster ();
		Action currentAction = new Action ();

		foreach (int pinFall in pinFalls) {
			currentAction = am.Bowl (pinFall);
		}

		return currentAction;
	}

	public Action Bowl(int pins){//make it private
		bowls [bowl-1] = pins;
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invalid pins");
		}
		//other behaviour here, e.g. last frame.

		//last frame
		if (bowl > 18) {
			if (bowl == 19) {
				bowl += 1;
				if(pins < 10)return Action.Tidy;
				return Action.Reset;
			}
			if (bowl == 20) {
				if(bowls[19-1] + pins < 10)return Action.EndGame;//lost 3rd chance
				bowl += 1;
				if (bowls[19-1]==10&&pins < 10)return Action.Tidy;//no need to reset
				return Action.Reset;
			}
			if (bowl == 21)
				return Action.EndGame;
		}


		if (bowl % 2 != 0) {//first bowl of frames
			if(pins==10){//if strike
				bowl += 2;
				return Action.EndTurn;
			}
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0) {//second bowl of frames
			bowl += 1;
			return Action.EndTurn;
		}

		//Ugly and working => pretty and working

		throw new UnityException("not sure what action to return.");
	}
}
