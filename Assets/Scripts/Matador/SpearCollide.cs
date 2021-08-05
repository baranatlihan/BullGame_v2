using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollide : MonoBehaviour
{
    private Color alphaColor;
   

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ground")
        {
            
            Rigidbody rb = GetComponentInParent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;

            GetComponent<BoxCollider>().enabled = false;

            StartCoroutine(fadeOut());

        }
    }

    private IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            alphaColor = GetComponent<MeshRenderer>().material.color;
            alphaColor.a -=0.05f;
            GetComponent<MeshRenderer>().material.color = alphaColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
