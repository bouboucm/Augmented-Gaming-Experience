using UnityEngine;
using System.Collections;

public class BlobAnimator : MonoBehaviour {
	public int nbW = 0;
	public int nbB = 0;
	public GameObject BlobManager;
	
	
	private GameObject[] blobsW;
	private GameObject[] blobsB;
	
	// Use this for initialization
	void Start () {

		GuiManager gui = GameObject.Find("GUIManager").GetComponent ("GuiManager") as GuiManager;
		gui.resetScores ();

		createBlob ();
	

		
	}
	
	public void createBlob ()
	{
		blobsW = new GameObject[nbW];
		blobsB = new GameObject[nbB];
		
		for (int i = 0; i < nbW + nbB; i++)
		{
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			obj.layer = 11; // layer scene3d
			//BlobScript bo = new BlobScript(obj);
			BlobScript bo = obj.AddComponent("BlobScript") as BlobScript;
			Rigidbody rigid = obj.AddComponent<Rigidbody>();
			obj.collider.material = (PhysicMaterial)Resources.Load("ball physics Material");
			bo.setGo(obj);
			bo.setManagerScript (this);
			rigid.useGravity = true;
			rigid.mass = 0.2f;
			//obj.AddComponent<BlobScript> ();
			obj.transform.localScale = new Vector3((float) 0.5, (float ) 0.5, (float) 0.5);
			obj.transform.parent = BlobManager.transform;
			//obj.AddComponent<SphereCollider> ();
			
			obj.transform.localPosition = new Vector3 (0, 0, 0);
			if (i < nbW)
			{
				blobsW[i] = obj;
			}
			else
			{
				blobsB[i - nbW] = obj;
			}
		
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Time.deltaTime);

	}
}
