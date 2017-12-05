using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Gesture_tst : MonoBehaviour {

	public GameObject Cube_man;
	GameObject Hip_Center;
	GameObject Spine;
	GameObject Neck;
	GameObject Head;
	GameObject Shoulder_Left;
	GameObject Elbow_Left;
	GameObject Wrist_Left;
	GameObject Hand_Left;
	GameObject Shoulder_Right;
	GameObject Elbow_Right;
	GameObject Wrist_Right;
	GameObject Hand_Right;
	Vector3 vc_R_Hand_to_R_Elbow;
	Vector3 vc_R_Hand_to_L_Elbow;
	Vector3 vc_L_Hand_to_R_Elbow;
	Vector3 vc_L_Hand_to_L_Elbow;
	Vector3 vc_L_Elbow_to_L_Shoulder;
	Vector3 vc_R_Elbow_to_R_Shoulder;
	Vector3 vc_R_Hand_to_L_Hand;
	Vector3 Middle_of_two_Hands;
	Vector3 vc_Md_Hands_to_Head;
    string gesture_Msg;

	void init_variables(){
		Hip_Center = Cube_man.transform.Find("00_Hip_Center").gameObject;
		Spine = Cube_man.transform.Find("01_Spine").gameObject;
		Neck = Cube_man.transform.Find("02_Neck").gameObject;
		Head = Cube_man.transform.Find("03_Head").gameObject;
		Shoulder_Left = Cube_man.transform.Find("04_Shoulder_Left").gameObject;
		Elbow_Left = Cube_man.transform.Find("05_Elbow_Left").gameObject;
		Wrist_Left = Cube_man.transform.Find("06_Wrist_Left").gameObject;
		Hand_Left = Cube_man.transform.Find("07_Hand_Left").gameObject;
		Shoulder_Right = Cube_man.transform.Find("08_Shoulder_Right").gameObject;
		Elbow_Right = Cube_man.transform.Find("09_Elbow_Right").gameObject;
		Wrist_Right = Cube_man.transform.Find("10_Wrist_Right").gameObject;
		Hand_Right = Cube_man.transform.Find("11_Hand_Right").gameObject;
	}



	// Use this for initialization
	void Start () {
		// Create joint varibales
		init_variables ();

	}
	//
	void Check_trumpet(){
		bool[] trumpet_boollist=new bool[5];


		// Relationship Creation
		vc_R_Hand_to_R_Elbow = Hand_Right.transform.position - Elbow_Right.transform.position; //(1.1,-14.6,2.7)
		vc_R_Hand_to_L_Elbow = Hand_Right.transform.position - Elbow_Left.transform.position;
		vc_L_Hand_to_R_Elbow = Hand_Left.transform.position - Elbow_Right.transform.position;
		vc_L_Hand_to_L_Elbow = Hand_Left.transform.position - Elbow_Left.transform.position;
		vc_L_Elbow_to_L_Shoulder = Elbow_Left.transform.position - Shoulder_Left.transform.position;
		vc_R_Elbow_to_R_Shoulder = Elbow_Right.transform.position - Shoulder_Right.transform.position;
		vc_R_Hand_to_L_Hand = Hand_Right.transform.position - Hand_Left.transform.position;
		Middle_of_two_Hands = (Hand_Right.transform.position + Hand_Left.transform.position )/ 2;
		vc_Md_Hands_to_Head = Middle_of_two_Hands - Head.transform.position;

		//_______________Troubleshooting Codes______________
		string check1;
		string check2;
		string check3;
		string check4;
		string check5;
		//___________________________________________________

		string trumpet_Msg;
		//1st Check: Hands Above Elbow 
		bool currCheck;
		if (vc_R_Hand_to_R_Elbow.y > 0 && vc_L_Hand_to_L_Elbow.y>0)
		{		
			currCheck=true;
			check1="Check 1:Hands Above Elbow = Correct";//Uncomment: Troubleshooting Codes
		}
		else {
			currCheck=false;
			check1="Check 1:Hands Below Elbow = Wrong";//Uncomment: Troubleshooting Codes
		}
		trumpet_boollist[0]=currCheck;

		//2nd Check: Elbow below Shoulder
		if (vc_L_Elbow_to_L_Shoulder.y < 0&&vc_R_Elbow_to_R_Shoulder.y < 0)
		{
			currCheck=true;
			check2="Check 2:Elbow Below Shoulder = Correct";//Uncomment: Troubleshooting Codes
		}
		else{
			currCheck=false;
			check2="Check 2:Elbow Above Elbow = Wrong";//Uncomment: Troubleshooting Codes
		}
		trumpet_boollist[1]=currCheck;

		//3rd Check: Right Hands & Left Hand Close togther
		double distance = Math.Sqrt(Math.Pow(vc_R_Hand_to_L_Hand.x,2) + Math.Pow(vc_R_Hand_to_L_Hand.y,2) + Math.Pow(vc_R_Hand_to_L_Hand.z, 2));
		if (distance < 3)
		{
			currCheck=true;
			check3="Check 3:Right and Left Hands close together= Correct";//Uncomment: Troubleshooting Codes

		}
		else{
			currCheck=false;
			check3="Check 3:Right and Left Hands too far = Wrong";//Uncomment: Troubleshooting Codes
		}
		trumpet_boollist[2]=currCheck;

		//4th Check: Middle of 2 hands are below head
		if (vc_Md_Hands_to_Head.y < 0)
		{
			currCheck=true;
			check4="Check 4: 2 Hands below head = Correct";//Uncomment: Troubleshooting Codes

		}
		else{
			currCheck=false;
			check4="Check 4: 2 Hands above head = Wrong";//Uncomment: Troubleshooting Codes
		}
		trumpet_boollist[3]=currCheck;

		//5th Check: Middle of 2 hands, x directions are not too far from head
		if ((vc_Md_Hands_to_Head.x <1) && (vc_Md_Hands_to_Head.x > -1))
		{
			currCheck=true;
			check5="Check 5: xdirection of Hands are close to head= Correct"+" | hands to head x: "+vc_Md_Hands_to_Head.x;//Uncomment: Troubleshooting Codes
		}
		else{
			currCheck=false;
			check5="Check 5: xdirection of Hands too far from head= Wrong";//Uncomment: Troubleshooting Codes
		}
		trumpet_boollist[4]=currCheck;

		//Loop through trumpet_boollist if all true means its trumpet condition
		bool gestureBool=true;
		trumpet_Msg="Gesture: Trumpet!";
		for (int i=0; i < trumpet_boollist.Length; i++) {
			if(trumpet_boollist[i]==false){
				trumpet_Msg="Gesture: Error";//Uncomment: Troubleshooting Codes
				gestureBool=false;
			}
		}
			
		if (gestureBool) {
			gesture_Msg = "Trumpet";
		}
		//print("Trumpet Check"+"\n");
		//print(check1+"\n");
		//print(check2+"\n");
		//print(check3+"\n");
		//print(check4+"\n");
		//print(check5+"\n");
		print(trumpet_Msg+"\n");
    }
	void CheckPiano(){
		// Relationship Creation
		vc_R_Hand_to_R_Elbow = Hand_Right.transform.position - Elbow_Right.transform.position; //(1.1,-14.6,2.7)
		vc_R_Hand_to_L_Elbow = Hand_Right.transform.position - Elbow_Left.transform.position;
		vc_L_Hand_to_R_Elbow = Hand_Left.transform.position - Elbow_Right.transform.position;
		vc_L_Hand_to_L_Elbow = Hand_Left.transform.position - Elbow_Left.transform.position;
		vc_L_Elbow_to_L_Shoulder = Elbow_Left.transform.position - Shoulder_Left.transform.position;
		vc_R_Elbow_to_R_Shoulder = Elbow_Right.transform.position - Shoulder_Right.transform.position;
		vc_R_Hand_to_L_Hand = Hand_Right.transform.position - Hand_Left.transform.position;
		Middle_of_two_Hands = (Hand_Right.transform.position + Hand_Left.transform.position )/ 2;
		vc_Md_Hands_to_Head = Middle_of_two_Hands - Head.transform.position;

		//_______________Troubleshooting Codes______________
		string check1;
		string check2;
		string check3;
		string check4;
		string check5;
		//___________________________________________________

		bool[] piano_boollist = new bool[1];
		bool currCheck;
		string piano_Msg;
		//1st Check: Hands within a range of Elbow for y & x 
		if ((vc_R_Hand_to_R_Elbow.y < 2.0 && vc_R_Hand_to_R_Elbow.y > -2.0) && (vc_L_Hand_to_L_Elbow.y < 2.0 && vc_L_Hand_to_L_Elbow.y > -2.0)
			&& vc_R_Hand_to_R_Elbow.x < 2.0 && vc_L_Hand_to_L_Elbow.x > -2.0)
		{
			currCheck=true;
			check1= "Check1: Hand within elbow range = Correct";
		}
		else {
			currCheck=false;
			check1 = "Check1: Hand too far from elbow = Wrong";}
		piano_boollist [0] = currCheck;

		piano_Msg="Gesture: Piano!";
		bool gestureBool=true;
		for (int i=0; i < piano_boollist.Length; i++) {
			if(piano_boollist[i]==false){
				piano_Msg="Gesture: Error";//Uncomment: Troubleshooting Codes
				gestureBool=false;
			}
		}
		if (gestureBool) {
			gesture_Msg = "Piano";
		}
		//print("Right Hand: " + Hand_Right.transform.position+"\n"); //(12.0,-5.7,-4.3) right hand
		//print("Right Elbow: " + Elbow_Right.transform.position + "\n"); //(9.7,8.8,-5.0) right elbow
		//print("vc_R_hand to R_elbow: "+vc_R_Hand_to_R_Elbow); //(2.3,-14.5,0.7)
		//print("vc_L_hand to L_elbow: "+vc_L_Hand_to_L_Elbow); //(2.3,-14.5,0.7)
		print(piano_Msg+"\n");
	}
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag("tst_tag2").GetComponent<Text>().text = gesture_Msg;
		gesture_Msg = "Error";
		Check_trumpet ();
		CheckPiano ();
	}
}
