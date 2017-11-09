using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset =ActionMaster.Action.Reset;
	private ActionMaster.Action endGame =ActionMaster.Action.EndGame;
	//private ActionMaster actionMaster;

	[SetUp]//setup for each test
	public void Setup(){
		pinFalls = new List<int> ();
	}

	[Test]
	public void T00PassingTest(){
		Assert.AreEqual (1, 1);
	}


	[Test]
	public void T01OneStrikeReturnsEndTurn(){
		pinFalls.Add (10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction (pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy(){
		int[] rolls={8};
		Assert.AreEqual (tidy, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T03Bowl28SpareReturnsEndTurn(){
		int[] rolls={2,8};
		Assert.AreEqual (endTurn, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T04CheckLastFrameForAllStrike(){
		int[] rolls1={10,10,10,10,10,10,10,10,10,10};//strike on bowl=19
		Assert.AreEqual (reset, ActionMaster.NextAction (rolls1.ToList()));
		int[] rolls2={10,10,10,10,10,10,10,10,10,10,10};//strike on bowl=20
		Assert.AreEqual (reset, ActionMaster.NextAction (rolls2.ToList()));
		int[] rolls3={10,10,10,10,10,10,10,10,10,10,10,10};//strike on bowl=21
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls3.ToList()));
	}

	[Test]
	public void T05CheckLastFrameSpareReturn(){
		int[] rolls1={10,10,10,10,10,10,10,10,10,2};
		Assert.AreEqual (tidy, ActionMaster.NextAction (rolls1.ToList()));
		int[] rolls2={10,10,10,10,10,10,10,10,10,2,8};
		Assert.AreEqual (reset, ActionMaster.NextAction (rolls2.ToList()));
		int[] rolls3={10,10,10,10,10,10,10,10,10,2,8,10};
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls3.ToList()));
	}

	[Test]
	public void T06CheckLastFrameMissReturn(){
		int[] rolls1={10,10,10,10,10,10,10,10,10,2};
		Assert.AreEqual (tidy, ActionMaster.NextAction (rolls1.ToList()));
		int[] rolls2={10,10,10,10,10,10,10,10,10,2,6};
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls2.ToList()));
	}

	[Test]
	public void T07CheckResetAtStrikeInLastFrame(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10 };
		Assert.AreEqual(reset,ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T08CheckResetAtSpareInLastFrame(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9};
		Assert.AreEqual(reset,ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T09YouTubeRollsEndInEndGame(){
		int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2,9};
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]//similar to T06
	public void T10GameEndsAtBowl20(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1};
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T11TidyAtBowl20(){
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10,0};
		Assert.AreEqual (tidy, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T12Zero10Spare(){
		int[] rolls = { 0,10,5,1};
		Assert.AreEqual (endTurn, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test]
	public void T13Dondi10thFrameTurkey(){
		int[] rolls1 = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10};
		Assert.AreEqual (reset, ActionMaster.NextAction (rolls1.ToList()));
		int[] rolls2 = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,10};
		Assert.AreEqual (reset, ActionMaster.NextAction (rolls2.ToList()));
		int[] rolls3 = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,10,10};
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls3.ToList()));
	}

}
