using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool jumping = false;

    Rigidbody prg;

    // Use this for initialization
    void Start () {
        prg = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -130f, 0);
    }
	
	// Update is called once per frame
	void Update () {
         Vector3 ppos = transform.position; 
         Vector2 Position = transform.position;
        if (Input.GetKey("right"))
        {
            ppos.x += 0.2f;
        }
        if (Input.GetKey("left"))
        {
            ppos.x += -0.2f; 
        }
        transform.position = ppos;
        if (!jumping)
        {
            if (Input.GetKeyDown("up"))
            {
                jumping = true;
                prg.AddForce(transform.up * 7000f);

            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "field")
        {
            jumping = false;
        }
        if(col.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
