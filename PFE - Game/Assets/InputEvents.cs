using UnityEngine;
using System.Collections;

public class InputEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Escape Key: Quit game
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();		
		
		// Backspace Key: Reset the game
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			// Get the GuiManager to reset the scores
			GameObject go = GameObject.Find("GUIManager");
			GuiManager guiM = go.GetComponent<GuiManager>();
			guiM.resetScores();
			
			// Destroy all the spheres
			GameObject goBlobM = GameObject.Find("blobManager");
			BlobAnimator blobAnim = goBlobM.GetComponent<BlobAnimator>();
			BlobScript[] BlobScriptList = goBlobM.GetComponentsInChildren<BlobScript>();
			
			foreach (BlobScript script in BlobScriptList)
				script.destroySphere();
			
			// Create a new sphere
			blobAnim.createBlob();
		}
	}
}
