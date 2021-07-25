using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatadorMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject spearPrefab;

    [SerializeField]
    private float fireRate = 0.22f;
    private float canFire = 0;

    private bool canMove = true;
    private GameObject player;

    private bool escapeState = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    

    private void FixedUpdate()
    {

        if (canMove)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 13f && !escapeState)
            {
                transform.position += transform.forward * Time.deltaTime * speed;

            }
            
            if(Vector3.Distance(transform.position, player.transform.position) < 8f)
            {
                escapeState = true;
            }

            if(escapeState)
            {
                transform.position -= transform.forward * Time.deltaTime * speed;

                if(Vector3.Distance(transform.position, player.transform.position) > 20f)
                {
                    escapeState = false;
                }
            }

            
            //rotation
            if(!escapeState)
            {
                Vector3 direction = player.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up * angle), rotationSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 direction = player.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-1*Vector3.up * angle), rotationSpeed * Time.deltaTime);
            }

            if(!escapeState && Vector3.Distance(transform.position, player.transform.position) <= 16f && Time.time > canFire)
            {
                throwSpear();
                canFire = Time.time + fireRate;
            }
            

        }

    }

   


    private void throwSpear()
    {
 
        GameObject spear = Instantiate(spearPrefab, transform.position + new Vector3(0.2f,0.5f,0), transform.rotation);

    }
}
