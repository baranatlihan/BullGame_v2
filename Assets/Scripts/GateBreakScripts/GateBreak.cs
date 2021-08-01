using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBreak : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("asd");
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }


}
