using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public bool turn90 = false;
    public int numberOfToSpawn = 0;
    [SerializeField]
    public GameObject[] humanTypes;
    private Transform objPos;
    System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        spawnHumans();
    }

    void Update()
    {

    }

    void spawnHumans()
    {  
        int instanceNumber = 0;
        for (int i = 0; i < numberOfToSpawn; i++)
        {
            if (!turn90) {
                if (i == 10)
                {
                    transform.localPosition = transform.localPosition + new Vector3(2, 0, -30);
                }

                if (i == 20)
                {
                    transform.localPosition = transform.localPosition + new Vector3(2, 0, -30);
                }
                transform.localPosition = transform.localPosition + new Vector3(0, 0, 3);
            }

            if (turn90)
            {
                if (i == 10)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-30, 0, 3);
                }

                if (i == 20)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-30, 0, 3);
                }
                transform.localPosition = transform.localPosition + new Vector3(3, 0, 0);
            }


            int j = random.Next(0, humanTypes.Length);  //rastgele insan tipi 
            GameObject currentAudience = Instantiate(humanTypes[j], transform.localPosition, Quaternion.Euler(0, 90, 0));
            currentAudience.name = humanTypes[j].name + instanceNumber; //oluþan insanýn ismi
            instanceNumber++;
        }
    }
}
