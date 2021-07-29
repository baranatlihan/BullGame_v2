using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCounterScript : MonoBehaviour
{

    int deadCount = 0;
    private void Start()
    {
        deadCount = PlayerPrefs.GetInt("Kills");
    }
    private void Update()
    {
        PlayerPrefs.SetInt("Kills", deadCount);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" ^ other.gameObject.tag =="Escaper")
        {
            other.gameObject.tag = "Dead";
            deadCount++;
            Debug.Log("deadCount: " + deadCount);
        }
    }
}