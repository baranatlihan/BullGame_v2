using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCounterScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag =="Escaper" || other.gameObject.tag == "Audience")
        {
            other.gameObject.tag = "Dead";
            GameManager.instance.deadCount++;
            Debug.Log("Kill: " + GameManager.instance.deadCount);
        }
    }


}