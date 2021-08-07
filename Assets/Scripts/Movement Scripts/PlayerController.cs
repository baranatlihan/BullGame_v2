using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Joystick joystick;
    private bool canMove = true;
    private Rigidbody rb;
    public Animator animat;
    public float speed;
    public float rotationSpeed;

    private void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        speed  = 7 + PlayerPrefs.GetInt("speed", 1);
    }

    void Update()
    {
        if (canMove)
        {

            if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f || joystick.Vertical > 0.2f || joystick.Vertical < -0.2f)
            {
                transform.position += transform.forward * Time.deltaTime * speed * (Mathf.Abs(joystick.Vertical) + Mathf.Abs(joystick.Horizontal));
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rotationCalculator(), 0), rotationSpeed * Time.deltaTime);

                animat.SetBool("run", true);
            }
            else
            {
                animat.SetBool("run", false);
            }
        }
        
        
            rb.velocity = Vector3.zero;
        
    }

    private float rotationCalculator()
    {
        float calculation = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * 180 / Mathf.PI;
        return calculation;
    }

}
