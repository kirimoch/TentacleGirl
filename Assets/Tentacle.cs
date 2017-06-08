using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public float TentacleLength;
    public float distance;
    public GameObject[] ioints;
    public bool discovery = true;
    public bool attack;

    Rigidbody rg;
    GameObject objEnemy;


    // Use this for initialization
    void Start()
    {
        rg = ioints[0].GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (attack == false)
            {
                attack = true;
                rg.isKinematic = false;
                StartCoroutine(Wait(0.5f));
            }
        }
        if (attack)
        {
            for (int i = 2; i < ioints.Length; i++)
            {
                ioints[i - 1].transform.position = (ioints[i - 2].transform.position + ioints[i].transform.position) / 2;
            }
        }
    }

    IEnumerator Wait(float duration)
    {
        objEnemy = GameObject.Find("enemy");
        float st = Time.time;
        while (Time.time - st < duration)
        {
            Atack();
            yield return null;
        }
        Stop();

        yield return MoveLerp(ioints[0].transform, ioints[0].transform.position, ioints[ioints.Length - 1].transform.position, duration);
        st = Time.time;
        while (Time.time - st < duration)
        {
            GameObject parent = transform.parent.gameObject;
            for (int j = 0; j < ioints.Length; j++)
            {
                ioints[j].transform.position = parent.transform.position;
            }
           
            yield return null;
        }
        Stop();      
        attack = false;
        rg.isKinematic = true;
        yield break;
    }


    void Atack()
    {
        if (objEnemy != null)
        {
            ioints[0].transform.LookAt(objEnemy.transform);
            rg.AddForce(ioints[0].transform.forward * 100.0f);
        }
        else
        {
            ioints[0].transform.rotation =  Quaternion.Euler(0, 90, 0);
            rg.AddForce(ioints[0].transform.forward * 100.0f);
        }
    }

    IEnumerator MoveLerp(Transform transform, Vector3 from, Vector3 to, float duration)
    {
        float st = Time.time;
        while (Time.time - st < duration)
        {
            transform.position = Vector3.Lerp(from, to, (Time.time - st)/ duration);
            yield return null;
        }
    }
    
    void Return()
    {
        ioints[0].transform.LookAt(ioints[ioints.Length - 1].transform);
        ioints[0].transform.Translate(Vector3.forward * 20 *Time.deltaTime);
    }

    void Stop()
    {
        rg.isKinematic = true;
        rg.isKinematic = false;
    }
}
