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
			text.text = "用户 SwipeRight 手势";
			print("用户 SwipeRight 手势");
		}

		return true;
	}

	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{

	}

	public void UserDetected(long userId, int userIndex)
	{
		text.text = "检测到手势";
		print("检测到手势");
	}

	public void UserLost(long userId, int userIndex)
	{
		text.text = "手离开了";
		print("手离开了");
	}


}
