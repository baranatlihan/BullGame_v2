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


    [HideInInspector]
    public int wallet;
    [HideInInspector]
    public int totalGain;


    private string gameAndroidId = "4243503";
    private string placement = "rewardedVideo";
    private bool testMode = true;

   


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
                UIManager.instance.changeScreen("return");
            }
            else
            {
                UIManager.instance.changeScreen("game");
                UIManager.instance.changeScreen("main");
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
            UIManager.instance.checkUI();
        }
    }

    public void BuySpeed()
    {
        if (wallet >= speed * 10)
        {
            wallet -= speed * 10;
            PlayerPrefs.SetInt("wallet", wallet);

            speed++;
            PlayerPrefs.SetInt("speed", hornLength);
            UIManager.instance.checkUI();
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
            UIManager.instance.checkUI();
        }
    }

    public void collectMoney()
    {
        wallet += totalGain;
        PlayerPrefs.SetInt("Wallet", wallet);
        UIManager.instance.changeScreen("game");
        UIManager.instance.changeScreen("main");
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

                Debug.Log("ba�ar�l�");

                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped ad only 1x money awarded to you");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad video failed to play");
                break;
        }
    }

    public void collectMoney2x()
    {
        ShowAd();
        wallet += (2 * totalGain);
        PlayerPrefs.SetInt("Wallet", wallet);
        UIManager.instance.changeScreen("game");
        UIManager.instance.changeScreen("main");

    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

   
}