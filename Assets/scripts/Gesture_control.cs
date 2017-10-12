using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gesture_control : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		bool isInit = KinectManager.Instance.IsInitialized();  
		if (isInit) {
			if (KinectManager.Instance.IsUserDetected())
			{

				long userId = KinectManager.Instance.GetPrimaryUserID(); 

				Vector3 userPos = KinectManager.Instance.GetUserPosition(userId); 


				int jointType = (int)KinectInterop.JointType.HandLeft;
				if (KinectManager.Instance.IsJointTracked(userId,jointType))
				{
					Vector3 leftHandPos = KinectManager.Instance.GetJointKinectPosition(userId, jointType);

					KinectInterop.HandState leftHandState =  KinectManager.Instance.GetLeftHandState(userId);
					if (leftHandState == KinectInterop.HandState.Closed)
					{
						print("Left hand fisted");
					}else if (leftHandState == KinectInterop.HandState.Open)
					{
						print("Left hand released");
					}else if (leftHandState == KinectInterop.HandState.Lasso)
					{
						print("Yes!");
					}


				}
			}


		}
	}
}
