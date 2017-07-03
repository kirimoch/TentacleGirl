using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaCol : MonoBehaviour
{
    Player pla;
    GameObject plaObj;

    // Use this for initialization
    void Start()
    {
        plaObj = GameObject.Find("player");
        pla = plaObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = plaObj.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            if (pla.hasHit == false)
            {
                pla.playerLife--;
                pla.hasHit = true;
                if (pla.playerLife > 0)
                {
                    pla.GetComponent<Player>().Invincible();
                }
            }
        }
    }
}
