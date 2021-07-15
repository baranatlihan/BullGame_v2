using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HumanRunScript : MonoBehaviour
{
    public HumanSettingsSO HumanSettings;
    public GameObject[] Points;
    private NavMeshAgent nmagent = null;
    private int CurrentRandom;
    private void Start()
    {
        nmagent = GetComponent<NavMeshAgent>();
        nmagent.speed = HumanSettings.Speed;
    }
    

    private void Update()
    {
        if (nmagent.hasPath == false && nmagent.enabled == true)
        {
            CurrentRandom = Random.Range(0, Points.Length);
            //Debug.Log("points length:" + Points.Length + "\nCurrent: " + CurrentRandom);
            nmagent.SetDestination(Points[CurrentRandom].transform.position);
        }//if
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            nmagent.GetComponent<NavMeshAgent>().enabled = false;
            //gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            Debug.Log("Hitted");
        }
    }
}
