using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour, IUnityAdsListener
{

    [HideInInspector]
    public int hornLength;

    [HideInInspector]
    public int speed;

    [HideInInspector]
    public int offline;


    //[HideInInspector]
    public int wallet;
    //[HideInInspector]
    public int totalGain = 0;
    //[HideInInspector]
    public int totalGainFromKills = 0;

    private string gameAndroidId = "4243503";
    private string placement = "rewardedVideo";
    private bool testMode = true;

    private PlayerController playerCont;
    private Player player;



    public static UpgradeManager instance;


    private void Awake()
    {
        if (UpgradeManager.instance)
        {
            UnityEngine.Object.Destroy(gameObject);
        }
        else
        {
            UpgradeManager.instance = this;
        }

        hornLength = PlayerPrefs.GetInt("hornLength", 1);

        offline = PlayerPrefs.GetInt("offline", 1);

        speed = PlayerPrefs.GetInt("speed", 1);

        wallet = PlayerPrefs.GetInt("wallet", 0); 

    }

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameAndroidId, testMode);
        playerCont = FindObjectOfType<PlayerController>();
        player = FindObjectOfType<Player>();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            DateTime now = DateTime.Now;
            PlayerPrefs.SetString("Date", now.ToString());

        }
        else
        {
            string @string = PlayerPrefs.GetString("Date", string.Empty);
            if (@string != string.Empty)
            {
                DateTime d = DateTime.Parse(@string);
                totalGain = (int)(((DateTime.Now - d).TotalMinutes * offline)/10);
                if(totalGain > 0)
                {
                    UIManager.instance.changeScreen(UIManager.instance.rewardScreen);
                }
                else
                {
                    UIManager.instance.refreshUI();
                    UIManager.instance.changeScreen(UIManager.instance.menuScreen);
                }
               
            }
            else
            {
                UIManager.instance.refreshUI();
                UIManager.instance.changeScreen(UIManager.instance.menuScreen);

            }
        }
    }

    private void OnApplicationQuit()
    {
        OnApplicationPause(true);
    }



    public void BuyHornLenght()
    {
        if (wallet >= hornLength * 10)
        {
            wallet -= hornLength * 10;
            PlayerPrefs.SetInt("wallet", wallet);

            hornLength++;
            PlayerPrefs.SetInt("hornLength", hornLength);
            UIManager.instance.refreshUI();
            player.hornUpdate();
        }
    }

    public void BuySpeed()
    {
        if (wallet >= speed * 10)
        {
            wallet -= speed * 10;
            PlayerPrefs.SetInt("wallet", wallet);

            speed++;
            PlayerPrefs.SetInt("speed", speed);
            playerCont.speed += speed;
            UIManager.instance.refreshUI();
        }
    }

    public void BuyOffline()
    {
        if (wallet >= offline * 10)
        {
            wallet -= hornLength * 10;
            PlayerPrefs.SetInt("wallet", wallet);

            offline++;
            PlayerPrefs.SetInt("offline", offline);
            UIManager.instance.refreshUI();
        }
    }

    

    public void ShowAd()
    {
        Advertisement.Show(placement);
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:

                Debug.Log("baþarýlý");

                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped ad only 1x money awarded to you");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad video failed to play");
                break;
        }
    }
    

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

   
}
