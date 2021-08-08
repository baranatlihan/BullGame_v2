using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextNormalLevelScript : MonoBehaviour
{
    Scene scene;
    public float LevelTime;
    private bool ScreenChange = false;
    private void Start()
    {

        scene = SceneManager.GetActiveScene();

        if (scene.name == "RageAttackCinema")
        {
            Time.timeScale = 1;        
        }

        /* if (scene.name == "ScoreScene")
         {
             Debug.Log("Scene name: " + scene.name);
         }
         else if (scene.name == "Level1")
         {
             Debug.Log("Scene name: " + scene.name);
         }
         else if (scene.name == "RageAttackLevel")
         {
             Debug.Log("\nScene name: " + scene.name);
         }
         else
         {
             Time.timeScale = 1;
             Debug.Log("\nScene name: " + scene.name);
         }*/

    }

    public void Update()
    {
        //Debug.Log("Time Scale: " + Time.timeScale);

        if (Time.timeSinceLevelLoad >= LevelTime)
        {
           if (scene.name == "RageAttackCinema")
            { 
                SceneManager.LoadScene("RageAttackLevel");
                
            }

            else if (scene.name == "ScoreScene")
            {
                GameManager.instance.openRewardScreen();
                GameManager.instance.deadCount = PlayerPrefs.GetInt("totalKillRage", 1);

            }
            else if (scene.name == "RageAttackLevel")
            {
                PlayerPrefs.SetInt("sceneCounter", PlayerPrefs.GetInt("sceneCounter", 2) + 1);
                PlayerPrefs.SetInt("totalKillRage", GameManager.instance.deadCount);
                SceneManager.LoadScene("ScoreScene");
            }

            else if ((PlayerPrefs.GetInt("sceneCounter", 2) != 0) && (PlayerPrefs.GetInt("sceneCounter", 2) % 7 == 0))
           {
                PlayerPrefs.SetInt("totalKillBeforeRage", GameManager.instance.deadCount);
                SceneManager.LoadScene("RageAttackCinema");
           }                

            else if (scene.name == "Level1" && !ScreenChange)
            {
                ScreenChange = true;
                GameManager.instance.openRewardScreen();
            }

            

        }
    }

}
 