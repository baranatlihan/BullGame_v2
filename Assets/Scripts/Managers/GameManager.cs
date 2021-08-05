using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int deadCount = 0;
    private void Awake()
    {
        if (GameManager.instance)
        {
            UnityEngine.Object.Destroy(gameObject);
        }
        else
        {
            GameManager.instance = this;
        }
    }    
    
    public void openRewardScreen()
    {
        UIManager.instance.rewardScreenMoney(deadCount);
        UIManager.instance.changeScreen(UIManager.instance.rewardScreen);
        Time.timeScale = 0;
    }



}
