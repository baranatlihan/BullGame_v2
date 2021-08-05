using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamFollowScript : MonoBehaviour
{


    public GameObject tPlayer;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
        }
        tFollowTarget = tPlayer.transform;
        vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;
    }
 }