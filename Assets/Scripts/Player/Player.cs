using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject horns; // 1
    [SerializeField]
    private GameObject hornConnect; // 0.8
    [SerializeField]
    private BoxCollider hornCollider; // 0.4

    void Start()
    {
        hornUpdate();
    }

    
    void Update()
    {
        
    }

    public void hornUpdate()
    {
        horns.transform.localScale += new Vector3(PlayerPrefs.GetInt("hornLength", 1) * 0.1f, 0, 0);
        hornConnect.transform.localScale += new Vector3(0, 0, PlayerPrefs.GetInt("hornLength", 1) * 0.08f);
        hornCollider.size += new Vector3(PlayerPrefs.GetInt("hornLength", 1) * 0.1f, 0, 0);
    }
   
}
