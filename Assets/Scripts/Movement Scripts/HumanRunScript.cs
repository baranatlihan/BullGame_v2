using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HumanRunScript : MonoBehaviour
{
    public HumanSettingsSO HumanSettings;
    public GameObject[] Points;
    public float DestroyTime = 5f;
    public float EscapeStartTime = 30f;
    public GameObject ExitPoint;
    private NavMeshAgent nmagent = null;
    private int CurrentRandom, PreviousRandom;


    private void Start()
    {
        nmagent = GetComponent<NavMeshAgent>();
        nmagent.speed = HumanSettings.Speed;
        CurrentRandom = Random.Range(0, Points.Length);
        nmagent.SetDestination(Points[CurrentRandom].transform.position);
    }
    private void Update()
    {
        //Debug.Log("Time: " + Time.time);
        if (nmagent.hasPath == false && nmagent.enabled == true)
        {
            PreviousRandom = CurrentRandom;
            CurrentRandom = Random.Range(0, Points.Length);
            nmagent.SetDestination(Points[CurrentRandom].transform.position);
        }

        if (gameObject.tag == "Dead")
        {
            Destroy(gameObject, DestroyTime);
        }


        if (Time.time > EscapeStartTime && gameObject.tag == "Enemy")
        {
            gameObject.tag = "Escaper";
            nmagent.SetDestination(ExitPoint.transform.position);
        }

        if (gameObject.tag == "Escaper" && nmagent.remainingDistance <= 0.15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            nmagent.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.tag = "Dead";
        }

        if (other.gameObject.tag == "Enemy" && nmagent.enabled == true)
        {
            CurrentRandom = Random.Range(0, Points.Length);
            nmagent.SetDestination(Points[CurrentRandom].transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (nmagent.enabled == true)
        {
            nmagent.SetDestination(Points[PreviousRandom].transform.position);
            nmagent.acceleration = 16;
            nmagent.speed *= 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        nmagent.speed = HumanSettings.Speed;
    }


}
