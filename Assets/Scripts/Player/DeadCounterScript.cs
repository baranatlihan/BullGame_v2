using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCounterScript : MonoBehaviour
{
    //dead count u böl çýkar bi þeyler yap gaine aktar
    private int deadCount = 0;
    private int deadMoney;
    //public static UpgradeManager instance;

    private void Update()
    {
        deadMoney = (deadCount / 2) + 1;
        //UpgradeManager.instance.totalGain = deadMoney;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag =="Escaper")
        {
            other.gameObject.tag = "Dead";
            deadCount++;
            Debug.Log("deadCount: " + deadCount);
        }
    }


}