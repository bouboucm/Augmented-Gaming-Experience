using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

public class VuzixWrapper {
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern uint WrapIWROpenTracker();
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern void WrapIWRCloseTracker();
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern void WrapIWRZeroSet();
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern void WrapIWRSetFilterState(bool on);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern bool WrapIWRGetFilterState();
	
    [DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern uint WrapIWRGetTracking(ref int yaw, ref int pitch, ref int roll);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern uint WrapIWRGet6DTracking(ref int yaw, ref int pitch, ref int roll, ref int xtrn, ref int ytrn, ref int ztrn);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern void WrapIWRSetMagAutoCorrect(bool on);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern uint WrapIWRGetMagYaw(ref int myaw);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern uint WrapIWRGetFilteredSensorData(ref int ax, ref int ay, ref int az,
															ref int lgx, ref int lgy, ref int lgz,
															ref int gx, ref int gy, ref int gz,
															ref int mx, ref int my, ref int mz);

	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern IntPtr WrapIWRSTEREO_Open();
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern void WrapIWRSTEREO_Close(IntPtr hDev);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern bool WrapIWRSTEREO_SetStereo(IntPtr hDev, bool on);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern byte WrapIWRSTEREO_WaitForAck(IntPtr hDev, bool eye);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern bool WrapIWRSTEREO_SetLR(IntPtr hDev, bool eye);
	
	[DllImport("./iWearWrapper/iWearWrapper.dll")]
    public static extern void WrapIWRSTEREO_SetLREx(IntPtr hDev, bool eye, bool wait);
}

public class vuzix : MonoBehaviour {

	public GameObject cameras;
	// Use this for initialization
	void Start () {
		VuzixWrapper.WrapIWROpenTracker();
	}
	
	// Update is called once per frame
	void Update () {
		float maxRotation = 32768;
		int yaw = 0,pitch = 0,roll = 0;
		
		VuzixWrapper.WrapIWRGetTracking(ref yaw, ref pitch, ref roll);
		
		//Debug.Log(yaw + " " + pitch + " " + roll);
		
		/*float x = -((float)pitch / maxRotation) * 180.0f;
		float y = -((float)yaw / maxRotation) * 180.0f;
		float z = (-(float)roll / maxRotation) * 180.0f;*/
		
		float x1 = -(pitch / maxRotation) * 180;
		float y1 = -(yaw / maxRotation) * 180;
		float z1 = (-roll / maxRotation) * 180;
		
//		Debug.Log(x1 + " " + y1 + " " + z1);
		
		cameras.transform.eulerAngles = new Vector3(x1,y1,z1);
	}
	
	void OnApplicationQuit() {
		VuzixWrapper.WrapIWRCloseTracker();
	}
}
