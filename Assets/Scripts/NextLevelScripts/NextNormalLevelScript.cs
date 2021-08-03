using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextNormalLevelScript : MonoBehaviour
{
    Scene scene;
    public float LevelTime;
    private void Start()
    {
        
        scene = SceneManager.GetActiveScene();

        if (scene.name == "ScoreScene")
        {
            Debug.Log("Scene name:" + scene.name);
        }
        else if (scene.name == "Level1")
        {
            Debug.Log("Scene name:" + scene.name);
        }
        else if (scene.name == "RageAttackLevel")
        {
            Debug.Log("\nScene name:" + scene.name);
        }
        else
            Debug.Log("YENI SCENE__________________");
    }

    public void Update()
    {
        //Debug.Log("time:" + Time.timeSinceLevelLoad);

        if (Time.timeSinceLevelLoad >= LevelTime)
        {
            if (scene.name == "ScoreScene")
            {
                if (PlayerPrefs.GetInt("sceneCounter", 1) % 5 == 0)
                {
                    PlayerPrefs.SetInt("sceneCounter", PlayerPrefs.GetInt("sceneCounter", 1) + 1);
                    Debug.Log("SCENE NAME:" + scene.name);
                    SceneManager.LoadScene("RageAttackCinema");
                }
                else
                {
                    PlayerPrefs.SetInt("sceneCounter", PlayerPrefs.GetInt("sceneCounter", 1) + 1);
                    Debug.Log("SCENE NAME:" + scene.name);
                    SceneManager.LoadScene("Level1");
                }
            }

            else if (scene.name == "RageAttackCinema")
            {
                SceneManager.LoadScene("RageAttackLevel");
            }

            else if (scene.name == "Level1")
            {
                SceneManager.LoadScene("ScoreScene");
            }

            else if (scene.name == "RageAttackLevel")
            {
                SceneManager.LoadScene("ScoreScene");
            }


        }

    }
}
 