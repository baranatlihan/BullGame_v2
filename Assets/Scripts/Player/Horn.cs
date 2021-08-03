using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Horn : MonoBehaviour
{
    [SerializeField]
    private float forwardPushPower;
    [SerializeField]
    private float upPushPower;


    private void OnCollisionEnter(Collision other)
    {      

        if (other.gameObject.tag == "Enemy")
        {
            
            Vector3 dir = other.contacts[0].point - transform.position;

            /*other.gameObject.transform.GetChild(0).Find("Armature").Find("Root").GetComponent<Rigidbody>().AddForce(-dir * forwardPushPower);
            other.gameObject.transform.GetChild(0).Find("Armature").Find("Root").GetComponent<Rigidbody>().AddForce(Vector3.up * upPushPower);
            other.gameObject.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(-dir * forwardPushPower);
            other.gameObject.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(Vector3.up * upPushPower);*/

            other.gameObject.transform.GetChild(0).Find("Armature").Find("Root").GetComponent<Rigidbody>().velocity += Vector3.up * upPushPower;
            other.gameObject.transform.GetChild(0).Find("Armature").Find("Root").GetComponent<Rigidbody>().velocity += -dir * forwardPushPower;
        }

    }
}
