using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	//Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative (List<int> rolls){
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	//Return a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames(List<int> rolls){
//		List<int> frameList = new List<int> ();
//		int frame=1;
//		for(var i=0;i<rolls.Count;){
//			if(frame>10)break;//break when get all frames
//			if (rolls [i] == 10&& i + 2 < rolls.Count) {
//			  //strike
//					frameList.Add (10 + rolls [i + 1] + rolls [i + 2]);
//					i++;
//			} else if (rolls [i] < 10){ 
//				if (i + 1 < rolls.Count && rolls [i] + rolls [i + 1] == 10) {
//				//spare
//					if(i+2>=rolls.Count)break;//following score uncomplete
//					frameList.Add (10 + rolls [i + 2]);
//					i += 2;
//				} else if (i + 1 < rolls.Count) {//neither strike nor spare
//					frameList.Add (rolls [i] + rolls [i + 1]);
//					i += 2;
//				} else break;
//			} else break;
//			frame++;
//		}
//		return frameList;

		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {break;}				// Prevents 11th frame score

			if (rolls[i-1] + rolls[i] < 10) {				// Normal "open" frame
				frames.Add (rolls [i-1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) {break;}				// Insufficient look-ahead

			if (rolls[i-1] == 10) {							// STRIKE
				i--;										// Strike frame has just one bowl
				frames.Add (10 + rolls [i+1] + rolls[i+2]);
			} else if (rolls[i-1] + rolls[i] == 10) {		// Calculate SPARE bonus
				frames.Add (10 + rolls [i+1]);
			}
		}

		return frames;
	}
}
