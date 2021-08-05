using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceRagdollScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    }
