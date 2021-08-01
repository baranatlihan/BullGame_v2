using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextRageLevelScript : MonoBehaviour
{
    public float LevelTime = 60f;



    public void Update()
    {
        if (Time.time > LevelTime)
        {
            SceneManager.LoadScene("RageAttackLevel");
        }
    }
}
