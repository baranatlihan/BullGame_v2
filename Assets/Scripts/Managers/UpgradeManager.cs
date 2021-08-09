using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public GameObject NotEnoughGoldText;
    public GameObject BullSkin;
    public GameObject BullHornSkin;
    public Material[] mats;


    private string gameAndroidId = "4243503";
    private string placement = "rewardedVideo";
    private bool testMode = true;

    private PlayerController playerCont;
    private Player player;
    Scene scene;


    public static UpgradeManager instance;


    private void Awake()
    {
        if (UpgradeManager.instance)
        {
            //UnityEngine.Object.Destroy(gameObject);
        }
        else
        {
            UpgradeManager.instance = this;
        }

        hornLength = PlayerPrefs.GetInt("hornLength", 1);

        offline = PlayerPrefs.GetInt("offline", 1);

        speed = PlayerPrefs.GetInt("speed", 1);

        wallet = PlayerPrefs.GetInt("wallet", 0);



        BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 0)]; 
        BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 0)]; 

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
                    if (scene.name != "ScoreScene") {
                    UIManager.instance.refreshUI();
                    UIManager.instance.changeScreen(UIManager.instance.menuScreen);
                    }
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
            playerCont.speed = 3 + speed;
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


    public void DefaultSkinButton()
    {
        PlayerPrefs.SetInt("currentSkin", 0);
        BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 0)];
        BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 0)];
        UIManager.instance.refreshUI();
    }

    public void BlueSkinButton()
    {
        if (PlayerPrefs.GetString("blueSkin", "false") == "true")
        {
            PlayerPrefs.SetInt("currentSkin", 1);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 1)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 1)];
            UIManager.instance.refreshUI();
        }
        else if (wallet >= 50)
        {
            wallet -= 50;
            PlayerPrefs.SetInt("wallet", wallet);
            PlayerPrefs.SetInt("currentSkin", 1);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 1)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 1)];
            PlayerPrefs.SetString("blueSkin", "true");
            UIManager.instance.refreshUI();
        }
        else
        {
            NotEnoughGoldText.SetActive(true);
        }

    }

    public void CowSkinButton()
    {
        if (PlayerPrefs.GetString("cowSkin", "false") == "true")
        {
            PlayerPrefs.SetInt("currentSkin", 2);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 2)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 2)];
            UIManager.instance.refreshUI();
        }
        else if (wallet >= 125)
        {
            wallet -= 125;
            PlayerPrefs.SetInt("wallet", wallet);
            PlayerPrefs.SetInt("currentSkin", 2);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 2)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 2)];
            PlayerPrefs.SetString("cowSkin", "true");
            UIManager.instance.refreshUI();
        }
        else
        {
            NotEnoughGoldText.SetActive(true);
        }

    }

    public void KitsuneSkinButton()
    {
        if (PlayerPrefs.GetString("kitsuneSkin", "false") == "true")
        {
            PlayerPrefs.SetInt("currentSkin", 3);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 3)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 3)];
            UIManager.instance.refreshUI();
        }
        else if (wallet >= 150)
        {
            wallet -= 150;
            PlayerPrefs.SetInt("wallet", wallet);
            PlayerPrefs.SetInt("currentSkin", 3);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin",3)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 3)];
            PlayerPrefs.SetString("kitsuneSkin", "true");
            UIManager.instance.refreshUI();
        }
        else
        {
            NotEnoughGoldText.SetActive(true);
        }
    }

    public void PinkSkinButton()
    {
        if(PlayerPrefs.GetString("pinkSkin", "false") == "true")
        {
            PlayerPrefs.SetInt("currentSkin", 4);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 4)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 4)];
            UIManager.instance.refreshUI();
        }
        else if (wallet >= 100)
        {
            wallet -= 100;
            PlayerPrefs.SetInt("wallet", wallet);
            PlayerPrefs.SetInt("currentSkin", 4);
            BullSkin.GetComponent<SkinnedMeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 4)];
            BullHornSkin.GetComponent<MeshRenderer>().material = mats[PlayerPrefs.GetInt("currentSkin", 4)];
            PlayerPrefs.SetString("pinkSkin", "true");
            UIManager.instance.refreshUI();

        }
        else
        {
            NotEnoughGoldText.SetActive(true);
        }
    }
}
