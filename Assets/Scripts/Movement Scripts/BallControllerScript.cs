using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerScript : MonoBehaviour
{



    public float speed = 10f;
    private Rigidbody rb;
    private bool isJump = false;
    public float jumpForceAmount = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        Vector3 direction = Vector3.zero; //initialized to 0 0 0

        isJump = Input.GetKeyDown("space");
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        rb.AddForce(direction * speed);


        if (isJump)
        {
            rb.AddForce(Vector3.up * jumpForceAmount, ForceMode.VelocityChange);

        }
    }

}
