using UnityEngine;
using System.Collections;

public class BlobScript : MonoBehaviour {
	
	private GameObject GameObj;
	private BlobAnimator Manager;
	public void setGo(GameObject go)
	{
		GameObj = go;
	}
	public void setManagerScript(BlobAnimator script)
	{
		Manager = script;
	}
	// Use this for initialization
	void Start () {
		transform.rigidbody.AddForce(-Vector3.forward * 20);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
    void OnCollisionEnter(Collision collision) {
		print (collision.gameObject.name);
		
		if (collision.gameObject.name == "LeftHand")
		{
			GuiManager gui = GameObject.Find("GUIManager").GetComponent ("GuiManager") as GuiManager;
			gui.incScore ();
////		Destroy (GameObj);
        }
		if (collision.gameObject.name == "wallB")
		{
			GuiManager gui = GameObject.Find("GUIManager").GetComponent ("GuiManager") as GuiManager;
			gui.incScoreFoe ();
			Destroy (GameObj);
			Manager.createBlob ();
	    }
		
        
    }
	
	public void destroySphere()
	{
		Destroy(GameObj);
	}

}
