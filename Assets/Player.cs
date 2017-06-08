using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float accel = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(
       transform.right * Input.GetAxisRaw("Horizontal") * accel + transform.up * Input.GetAxisRaw("Vertical") * accel,
       ForceMode.Impulse);
    }
}
