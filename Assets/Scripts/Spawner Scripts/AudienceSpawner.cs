using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public bool turn90 = false;
    public bool turn180 = false;
    public bool turn45 = false;
    public bool turn135 = false;
    public int numberOfToSpawn = 0;
    [SerializeField]
    public GameObject[] humanTypes;
    System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        spawnHumans();
    }

    void spawnHumans()
    {  
        int instanceNumber = 0;
        for (int i = 0; i < numberOfToSpawn; i++)
        {
            if (!turn90 && !turn180 && !turn45 && !turn135) {
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

            if (turn180)
            {
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

            if (turn135)
            {
                if (i == 5)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-5, 0, 2);
                }
                if (i == 10)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-10, 0, 2);
                }
                if (i == 15)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-15, 0, 2);
                }
                if (i == 20)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-10, 0, 2);
                }
                if (i == 25)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-10, 0, 2);
                }

                transform.localPosition = transform.localPosition + new Vector3(2, 0, 0);
            }

            if (turn45)
            {
                if (i == 5)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-5, 0, 2);
                }
                if (i == 10)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-10, 0, 2);
                }
                if (i == 15)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-15, 0, 2);
                }
                if (i == 20)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-10, 0, 2);
                }
                if (i == 25)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-10, 0, 2);
                }

                transform.localPosition = transform.localPosition + new Vector3(2, 0, 0);
            }


            int j = random.Next(0, humanTypes.Length);  //rastgele insan tipi 
            int control = random.Next(0, 2);
            if (!turn90 && !turn180 && !turn45 && !turn135 && control ==0) { 
                GameObject currentAudience = Instantiate(humanTypes[j], transform.localPosition, Quaternion.Euler(0, 90, 0), transform.parent); //container içine oluþturma
                currentAudience.name = humanTypes[j].name + instanceNumber; //oluþan insanýn ismi
                instanceNumber++;
            }
            else if (turn90 && control == 0)
            { 
                GameObject currentAudience = Instantiate(humanTypes[j], transform.localPosition, Quaternion.Euler(0,180,0), transform.parent); //container içine oluþturma
                currentAudience.name = humanTypes[j].name + instanceNumber; //oluþan insanýn ismi
                instanceNumber++;
            }
            else if(turn180 && control == 0)
            {
                GameObject currentAudience = Instantiate(humanTypes[j], transform.localPosition, Quaternion.Euler(0, 270, 0), transform.parent); //container içine oluþturma
                currentAudience.name = humanTypes[j].name + instanceNumber; //oluþan insanýn ismi
                instanceNumber++;
            }
            else if (turn135 && control == 0)
            {
                GameObject currentAudience = Instantiate(humanTypes[j], transform.localPosition, Quaternion.Euler(0, 135, 0), transform.parent); //container içine oluþturma
                currentAudience.name = humanTypes[j].name + instanceNumber; //oluþan insanýn ismi
                instanceNumber++;
            }
            else if(turn45 && control == 0)
            {
                GameObject currentAudience = Instantiate(humanTypes[j], transform.localPosition, Quaternion.Euler(0, -135, 0), transform.parent); //container içine oluþturma
                currentAudience.name = humanTypes[j].name + instanceNumber; //oluþan insanýn ismi
                instanceNumber++;
            }
        }
    }
}
