using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        throwS();
    }

   

    private void FixedUpdate()
    {

        if (rb.velocity != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(rb.velocity.normalized);
        }

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }


    }

    public void throwS()
    {
        rb.AddRelativeForce(new Vector3(0, 400, 370));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
