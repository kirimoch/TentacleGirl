using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

   

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camePos = gameObject.transform.position;
        Vector3 plaPos = GameObject.Find("player").transform.position;
        camePos.x = plaPos.x;
        gameObject.transform.position = camePos;
    }
}
