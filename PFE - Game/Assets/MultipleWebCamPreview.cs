using UnityEngine;
using System.Collections;

public class MultipleWebCamPreview: MonoBehaviour 
{
	//The texture that holds the video captured by the webcam
	private WebCamTexture webCamTexture;

	//An array that stores a reference to the names of all connected webcams
	private string[] nameWebCams;

	//The current webcam
	private int currentCam = 0;

	//The selected webcam
	private int selectedCam = 0;

    void Start()
	{
		//An integer that stores the number of connected webcams
	    int numOfCams = WebCamTexture.devices.Length;

		//Initialize the nameWebCams array to hold the same number of strings as there are webcams
		this.nameWebCams = new string[numOfCams];

		//Get the name of each connected camera and store it into the 'nameWebCams' array
		for(int i = 0; i < numOfCams; i++)
		{
			this.nameWebCams[i] = WebCamTexture.devices[i].name;			
		}

		//Initialize the webCamTexture
		webCamTexture = new WebCamTexture();
		//Assign the images captured by the first available webcam as the texture of the containing game object
        renderer.material.mainTexture = webCamTexture;
		//Start streaming the images captured by the webcam into the texture
        webCamTexture.Play();
	}

	void OnGUI()
	{
		//Render the SelectionGrid listing all the cameras and save the selected one at 'selectedCam'
		selectedCam = GUI.SelectionGrid(new Rect(20,20,200,50), currentCam, nameWebCams, 1);

		//If the selected camera isn't the current camera
		if(selectedCam != currentCam)
		{
			//Assign the value of currentCam to selectCam
			currentCam = selectedCam;
			//Stop the streaming of captured images
			webCamTexture.Stop();
			//Assign a different webcam to the webCamTexture
			webCamTexture.deviceName = WebCamTexture.devices[currentCam].name;
			//Start streaming the captured images from this webcam to the texture
			webCamTexture.Play();
		}
	}
}