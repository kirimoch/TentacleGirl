using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    Vector3 camePos;
    Vector3 plaPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camePos = gameObject.transform.position;
        plaPos = GameObject.Find("player").transform.position;
        camePos.x = plaPos.x;
        gameObject.transform.position = camePos;
    }
}
