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
    public float spawnTime = 4.0f;

    private void Start()
    {
        nextSpawn = 0f;
        PlayerPrefs.SetInt("numberOfSpawn", spawnerSettings.numberOfHumanToSpawn);
    }
    void Update()
    {


        nextSpawn += Time.deltaTime;
        
        if (PlayerPrefs.GetInt("sceneCounter", 2) % 7 == 0)
        {

            PlayerPrefs.SetFloat("SpawnTime", PlayerPrefs.GetFloat("SpawnTime", 4) - 1);

            if (PlayerPrefs.GetFloat("SpawnTime", 4) < 2)
            {
                PlayerPrefs.SetFloat("SpawnTime", 1.5f);
            }
        }

        if (PlayerPrefs.GetInt("sceneCounter", 2) % 14 == 0)
        {
            PlayerPrefs.SetInt("numberOfSpawn", PlayerPrefs.GetInt("numberOfSpawn", 1) + 1);
            spawnerSettings.numberOfHumanToSpawn = PlayerPrefs.GetInt("numberOfSpawn", 1);
            if (PlayerPrefs.GetInt("numberOfSpawn", 1) > 5)
            {
                PlayerPrefs.SetInt("numberOfSpawn", 5);
            }
        }

        if (nextSpawn > PlayerPrefs.GetFloat("SpawnTime", 4) && Time.deltaTime <= totalSpawnTime)
        {
            spawnHumans();
            nextSpawn = 0f;
        }

        

    }

    private void spawnHumans()
    {
        int currentSpawnPointIndex = random.Next(0, spawnerSettings.spawnPoints.Length);   

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
