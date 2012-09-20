using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
	
	public GUIText ScoreR;
	public GUIText ScoreL;
	public GUIText ScoreFoeR;
	public GUIText ScoreFoeL;
	public int score = 0;
	public int scoreFoe = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void resetScores ()
	{
		ScoreR.guiText.text = "0";
		ScoreL.guiText.text = "0";
		ScoreFoeR.guiText.text = "0";
		ScoreFoeL.guiText.text = "0";
		score = scoreFoe = 0;
	}
	
	public void incScore ()
	{
		score++;
		ScoreR.guiText.text = (score).ToString ();
		ScoreL.guiText.text = (score).ToString ();
			
	}
	public void incScoreFoe ()
	{
		scoreFoe++;
		ScoreFoeR.guiText.text = (scoreFoe).ToString ();
		ScoreFoeL.guiText.text = (scoreFoe).ToString ();
		
	}
}
