using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaCol : MonoBehaviour
{
    Player pla;
    GameObject plaObj;
    GameMaster GM;
    GameObject GMObj;

    // Use this for initialization
    void Start()
    {
        plaObj = GameObject.Find("player");
        pla = plaObj.GetComponent<Player>();
        GMObj = GameObject.Find("GameMaster");
        GM = GMObj.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = plaObj.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "field")
        {
            pla.jumping = false;
        }
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
