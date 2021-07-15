using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    

    [SerializeField]
    private Transform mapTopRight;
    [SerializeField]
    private Transform mapBotLeft;

    private Transform target;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;



    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        
        target = FindObjectOfType<Player>().transform;
        startPos = transform.position;



        bottomLeftLimit = mapBotLeft.position + new Vector3(-5, 0, -5);
        topRightLimit = mapTopRight.position + new Vector3(+5, 0, +5f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + startPos.x, target.position.y + startPos.y, target.position.z + startPos.z);

        //keeping camera ins
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), transform.position.y, Mathf.Clamp(transform.position.z, bottomLeftLimit.z, topRightLimit.z));
    }
}
