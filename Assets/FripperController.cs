using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;
	private float defaultAngle = 20;
	private float flickAngle = -20;
	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint>();
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.flickAngle);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle(this.flickAngle);
		}

		if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.defaultAngle);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle(this.defaultAngle);
		}

		foreach (Touch touch in Input.touches){
			Debug.Log(touch.position.x);
			bool isleft = touch.position.x < -0.7f;
			if (isleft && tag == "LeftFripperTag" || !isleft && tag == "RightFripperTag") {
				if (touch.phase == TouchPhase.Began){
					SetAngle(this.flickAngle);
				} else if (touch.phase == TouchPhase.Ended) {
					SetAngle(this.defaultAngle);
				}
			}
		}
	}

	public void SetAngle(float angle){
		JointSpring js = this.myHingeJoint.spring;
		js.targetPosition = angle;
		this.myHingeJoint.spring = js;
	}
}
