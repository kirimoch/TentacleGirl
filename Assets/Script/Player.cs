using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool jumping = false;
    public float playerLife = 2;
    public bool hasHit = false;

    Tentacle tentacle;
    GameMaster gm;
    Rigidbody prg;
    Renderer PlaRenderer;
    public Renderer[] TenRenderer;

    // Use this for initialization
    void Start () {
        prg = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        PlaRenderer = GetComponent<MeshRenderer>();
        TenRenderer = GetComponentsInChildren<Renderer>();
        Physics.gravity = new Vector3(0, -130f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 ppos = transform.position; 
        Vector2 Position = transform.position;
        if (Input.GetKey(KeyCode.D))
        {
            ppos.x += 0.2f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            ppos.x += -0.2f; 
        }
        transform.position = ppos;
        if (!jumping)
        {
            if (Input.GetKeyDown(KeyCode.W))
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
       /* if (col.gameObject.tag == "enemy")
        {
            if (!hasHit)
            {
                hasHit = true;
                if (playerLife > 0)
                {
                    StartCoroutine(Frash(2.0f));
                }
            }
        }*/
    }

    public void Invincible()
    {
        StartCoroutine(Frash(2.0f));
    }

    void InvincibleStop()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    IEnumerator Frash(float frashTime)
    {
        Invoke("InvincibleStop", 2.5f);
        bool transparency = true;
        float startTime = Time.time;
        while(Time.time - startTime < frashTime)
        {
            transparency =! transparency;
            PlaRenderer.enabled = transparency;
            foreach (Renderer renderer in TenRenderer)
            {
                renderer.enabled = transparency;
            }
            yield return new WaitForSeconds(0.15f);
        }
        PlaRenderer.enabled = true;
        foreach (Renderer renderer in TenRenderer)
        {
            renderer.enabled = true;
        }
        hasHit = false;
    }

}
