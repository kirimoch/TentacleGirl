using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float spead;
    public Rigidbody energ;

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, -130f, 0);
        energ = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        energ.AddForce(transform.right * spead);
    }
}
