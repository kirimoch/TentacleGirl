using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public GameObject[] ioints;
    public bool attack;

    GameObject parent;
    Rigidbody trg;
    GameObject objEnemy;


    // Use this for initialization
    void Start()
    {
        trg = ioints[0].GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (attack == false)
            {
                attack = true;
                trg.isKinematic = false;
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
        st = Time.time;
        while (Time.time - st < 0.7)
        {
            Return();
            yield return null;
        }
        parent = transform.parent.gameObject;
        for (int j = 0; j < ioints.Length; j++)
        {
            ioints[j].transform.position = parent.transform.position;
        }
        Stop();      
        attack = false;
        trg.isKinematic = true;
        yield break;
    }


    void Atack()
    {
        if (objEnemy != null)
        {
            ioints[0].transform.LookAt(objEnemy.transform);
            trg.AddForce(ioints[0].transform.forward * 100.0f);
        }
        else
        {
            ioints[0].transform.rotation =  Quaternion.Euler(0, 90, 0);
            trg.AddForce(ioints[0].transform.forward * 100.0f);
        }
    }

    IEnumerator MoveLerp(Transform transform, Vector3 from, Vector3 to, float duration)
    {
        float st = Time.time;
        while (Time.time - st < 0.5f)
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
        trg.isKinematic = true;
        trg.isKinematic = false;
    }
}
