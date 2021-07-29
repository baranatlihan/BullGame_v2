using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadHumanSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject deadHuman;
    [SerializeField]
    private GameObject humanParent;
    [SerializeField]
    private Transform spawnPos;

    [SerializeField]
    private Image bgFillImg;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnHumans(150,170));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator spawnHumans(float totalDeadHuman,float totalHuman)
    {
        float totalSpawned = 0;
        float totalFillAmount = (totalDeadHuman / totalHuman) *100 ;
        while(totalSpawned <= totalDeadHuman)
        {
            Instantiate(deadHuman, spawnPos.position, Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)),humanParent.transform);
            totalSpawned++;
            bgFillImg.fillAmount = (totalSpawned * totalFillAmount*0.01f) / totalDeadHuman; 
            yield return new WaitForSeconds(0.1f);
        }
    }
}
