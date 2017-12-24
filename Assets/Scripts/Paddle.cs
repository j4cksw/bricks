using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mousePos = Input.mousePosition;
		Vector3 targetPose = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));

		this.transform.position = new Vector3(Mathf.Clamp(targetPose.x, -3.5f, 3.5f), this.transform.position.y, this.transform.position.z);
	}
}
