using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    System.Random random = new System.Random();
    private int instanceNumber = 1;
    public HumanSpawnerSO spawnerSettings;
    [Tooltip("The total work time for spawner")]
    public float totalSpawnTime = 30f; 
    private float nextSpawn = 0f;
    [Tooltip("The time between spawns")]
    public float spawnTime = 5.0f;
    private int k = 1;

    private void Start()
    {
        nextSpawn = 0f;
    }
    void Update()
    {

        nextSpawn += Time.deltaTime;


        if (nextSpawn > spawnTime && Time.deltaTime <= totalSpawnTime)
        {
            spawnHumans();
            nextSpawn = 0f;
        }

        

    }

    private void spawnHumans()
    {
        int currentSpawnPointIndex = random.Next(0, spawnerSettings.spawnPoints.Length);

        if(PlayerPrefs.GetInt("sceneCounter", 0) > 12*k)
        {
            k++;
            spawnerSettings.numberOfHumanToSpawn = k;
            if(k > 5)
            {
                k--;
            }
        }

        for (int i = 0; i < spawnerSettings.numberOfHumanToSpawn; i++)
        {
            int j = random.Next(0, spawnerSettings.humanTypes.Length);  //rastgele insan tipi 

            GameObject currentHuman = Instantiate(spawnerSettings.humanTypes[j], spawnerSettings.spawnPoints[currentSpawnPointIndex].position, Quaternion.identity);
            currentHuman.name = spawnerSettings.humanTypes[j].name + instanceNumber;    //oluþan insanýn ismi
    

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnerSettings.spawnPoints.Length;
            instanceNumber++;
        }//for

    }


}
