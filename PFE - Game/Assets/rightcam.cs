using UnityEngine;
using System.Collections;

public class rightcam : MonoBehaviour {
	
		//The texture that holds the video captured by the webcam
	private WebCamTexture webCamTexture;

	//The selected webcam
	public int selectedCam = 0;
	    void Start()
	{
		//An integer that stores the number of connected webcams
	    int numOfCams = WebCamTexture.devices.Length;
		print (selectedCam);
		print (WebCamTexture.devices[selectedCam].name);
		//renderer.material.color = new Color (255, 255, 255);
		

		//Initialize the webCamTexture
		webCamTexture = new WebCamTexture();

		
        renderer.material.mainTexture = webCamTexture;
		webCamTexture.deviceName = WebCamTexture.devices[selectedCam].name;
			//Start streaming the captured images from this webcam to the texture
		
		//Start streaming the images captured by the webcam into the texture
        webCamTexture.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
