using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Gesture_control2 : MonoBehaviour,KinectGestures.GestureListenerInterface {

	private Text text;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	public bool GestureCancelled(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint)
	{
		return true;
	}

	public bool GestureCompleted(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint, Vector3 screenPos)
	{

		if(gesture == KinectGestures.Gestures.SwipeRight)
		{
			text.text = "SwipeRight";
			print("SwipeRight");
		}

		return true;
	}

	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{

	}

	public void UserDetected(long userId, int userIndex)
	{
		text.text = "Detected Gesture";
		print("Detected Gesture");
	}

	public void UserLost(long userId, int userIndex)
	{
		text.text = "Hand off";
		print("Hand off");
	}


}
