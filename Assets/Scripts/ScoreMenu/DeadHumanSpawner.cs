using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadHumanSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject deadHuman;
    [SerializeField]
    private GameObject deadHuman1;
    [SerializeField]
    private GameObject deadHuman2;

    [SerializeField]
    private GameObject humanParent;
    [SerializeField]
    private Transform spawnPos;

    [SerializeField]
    private Image bgFillImg;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnHumans((PlayerPrefs.GetInt("totalKillRage", 0) + PlayerPrefs.GetInt("totalKillBeforeRage", 0)) * 5,100));
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator spawnHumans(float totalDeadHuman,float totalHuman)
    {
        GameObject human = deadHuman;
        float totalSpawned = 0;
        float totalFillAmount = (totalDeadHuman / totalHuman) *100 ;
        while(totalSpawned <= totalDeadHuman)
        {
            int humanChoice = Random.Range(0, 10);
            if(humanChoice <4)
            {
                human = deadHuman;
            }
            else if(humanChoice<8)
            {
                human = deadHuman1;
            }
            else
            {
                human = deadHuman2;
            }
            Instantiate(human, spawnPos.position, Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)),humanParent.transform);
            totalSpawned++;
            bgFillImg.fillAmount = (totalSpawned * totalFillAmount*0.01f) / totalDeadHuman; 
            yield return new WaitForSeconds(0.1f);
        }
    }
}
