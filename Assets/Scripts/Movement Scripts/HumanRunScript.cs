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
    public GameObject[] ExitPoint;
    private NavMeshAgent nmagent = null;
    private int CurrentRandom, PreviousRandom;
    private int k = 1;
    private float controlTime = 0f;


    private void Start()
    {
        nmagent = GetComponent<NavMeshAgent>();
        nmagent.speed = HumanSettings.speed;
        CurrentRandom = Random.Range(0, Points.Length);
        nmagent.SetDestination(Points[CurrentRandom].transform.position);

        
    }
    private void Update()
    {
        controlTime += Time.deltaTime;
        Debug.Log(PlayerPrefs.GetInt("sceneCounter", 0));
        if (PlayerPrefs.GetInt("sceneCounter", 0) > 10 * k)
        {
            EscapeStartTime -= 5;
            if (EscapeStartTime <= 0)
            {
                EscapeStartTime = 1;
            }
            k++;
        }
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

        //Time.deltaTime
        if (controlTime > EscapeStartTime && gameObject.CompareTag("Enemy") && nmagent.isActiveAndEnabled)
        {         
            gameObject.tag = "Escaper";
            nmagent.SetDestination(ExitPoint[Random.Range(0, 2)].transform.position);   
        }

        if ((gameObject.tag == "Enemy") && !nmagent.isActiveAndEnabled)
        {
            nmagent.GetComponent<NavMeshAgent>().enabled = true;//sýrt kýsmýna çarpýp durmamasý için
        }

        if (gameObject.tag == "Escaper" && !nmagent.isActiveAndEnabled)
        {
            nmagent.GetComponent<NavMeshAgent>().enabled = true;//sýrt kýsmýna çarpýp durmamasý için
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
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            //gameObject.tag = "Dead"; Bu iþlem DeadCounterScript'te yapýlýyor.
        }

        if (other.gameObject.tag == "Enemy" && nmagent.enabled == true) //birbirlerine dokunduklarýnda yeni destination, birikmeyi engelliyor
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
            nmagent.acceleration = 14;
            nmagent.speed *= 1.8f;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        nmagent.speed = HumanSettings.speed;
    }

    
}
