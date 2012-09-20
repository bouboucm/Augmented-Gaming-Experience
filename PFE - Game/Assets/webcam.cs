using UnityEngine;

// Will currently only work with Unity 3.5 Public Beta
public class webcam : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    
    void Start()
    {
        webcamTexture = new WebCamTexture();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
   }

    void OnGUI()
    {
        if (webcamTexture.isPlaying)
        {
            if (GUILayout.Button("Pause"))
            {
                webcamTexture.Pause();
            }
            if (GUILayout.Button("Stop"))
            {
                webcamTexture.Stop();
            }
        }
        else
        {
            if (GUILayout.Button("Play"))
            {
                webcamTexture.Play();
            }
        }
    }
}