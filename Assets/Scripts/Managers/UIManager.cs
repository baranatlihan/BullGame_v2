using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject currentScreen;

    
    public GameObject gameScreen;
    public GameObject menuScreen;
    public GameObject rewardScreen;
    public GameObject deadScreen;
    public GameObject skinsScreen;



    [SerializeField]
    private Button hornLengthButton;
    [SerializeField]
    private Button offlineButton;
    [SerializeField]
    private Button speedButton;
    [SerializeField]
    private Button skinsButton;


    [SerializeField]
    private TextMeshProUGUI hornLengthText;
    [SerializeField]
    private TextMeshProUGUI offlineText;
    [SerializeField]
    private TextMeshProUGUI offlinePerHourText;
    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI gainedGoldText;
    [SerializeField]
    private TextMeshProUGUI skinsGoldText;
    [SerializeField]
    private TextMeshProUGUI pinkSkinText;
    [SerializeField]
    private TextMeshProUGUI cowSkinText;
    [SerializeField]
    private TextMeshProUGUI blueSkinText;
    [SerializeField]
    private TextMeshProUGUI kitsuneSkinText;
    [SerializeField]
    private GameObject NotEnoughGoldText;

    private int wallet;
    Scene scene;

    public static UIManager instance;
    [SerializeField]
    private bool checkUI = true;

    private void Awake()
    {
        if (UIManager.instance)
        {
            UnityEngine.Object.Destroy(gameObject);
        }
        else
        {
            UIManager.instance = this;
        }

        wallet = PlayerPrefs.GetInt("wallet", 0);
        currentScreen = menuScreen;

    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name != "ScoreScene") {
            

            if (checkUI)
            {
            refreshUI();
            currentScreen = menuScreen;
            gameScreen.SetActive(false);
            Time.timeScale = 0;
            }
        }
    }

    public void refreshUI()
    {
        int hornLenght = UpgradeManager.instance.hornLength;
        int offline = UpgradeManager.instance.offline;
        int speed = UpgradeManager.instance.speed;
        int wallet = UpgradeManager.instance.wallet;

        goldText.text = "Gold: " + wallet;
        hornLengthText.text = "Horn Length\n" + "Lvl. " + hornLenght + "\n" + hornLenght * 10;
        speedText.text = "Speed\n" + "Lvl. " + speed + "\n" + speed * 10;
        offlineText.text = "Offline\nEarnings\n" + "Lvl. " + offline + "\n" + offline * 10;
        offlinePerHourText.text = (offline * 6) + "/hour";
        gainedGoldText.text = "Earned " + UpgradeManager.instance.totalGain + "Gold";
        skinsGoldText.text = "Gold: " + wallet;


        if (hornLenght * 10 <= wallet)
        {
            hornLengthButton.interactable = true;
        }
        else
        {
            hornLengthButton.interactable = false;
        }

        if (speed * 10 <= wallet)
        {
            speedButton.interactable = true;
        }
        else
        {
            speedButton.interactable = false;
        }

        if (offline * 10 <= wallet)
        {
            offlineButton.interactable = true;
        }
        else
        {
            offlineButton.interactable = false;
        }

        if (PlayerPrefs.GetString("pinkSkin", "false") == "true")
        {
            pinkSkinText.text = "Pink";
        }

        if (PlayerPrefs.GetString("cowSkin", "false") == "true")
        {
            cowSkinText.text = "Cow";
        }

        if (PlayerPrefs.GetString("blueSkin", "false") == "true")
        {
            blueSkinText.text = "Blue";
        }
        if (PlayerPrefs.GetString("kitsuneSkin", "false") == "true")
        {
            kitsuneSkinText.text = "Kitsune";
        }


    }

    public void tapStartButton()
    {
        changeScreen(gameScreen);
        Time.timeScale = 1;
    }

    public void changeScreen(GameObject screen)
    {

        currentScreen.SetActive(false);
        screen.SetActive(true);
        currentScreen = screen;
 

    }

    public void rewardScreenMoney(int deadCount)
    {
       
        UpgradeManager.instance.totalGainFromKills = deadCount;
        gainedGoldText.text = ("Earned " + deadCount + " gold");

    }


    public void collectMoney()
    {
        
        UpgradeManager.instance.wallet += UpgradeManager.instance.totalGainFromKills + UpgradeManager.instance.totalGain;
        PlayerPrefs.SetInt("wallet", UpgradeManager.instance.wallet);
        UpgradeManager.instance.totalGainFromKills = 0;
        if (checkUI)
        {
            refreshUI();
            PlayerPrefs.SetInt("sceneCounter", PlayerPrefs.GetInt("sceneCounter", 2) + 1); 
        }
        
        
        SceneManager.LoadScene("Level1");       
    }
    public void collectMoney2x()
    {
        UpgradeManager.instance.ShowAd();
        UpgradeManager.instance.wallet += 2 * (UpgradeManager.instance.totalGainFromKills + UpgradeManager.instance.totalGain);
        PlayerPrefs.SetInt("wallet", UpgradeManager.instance.wallet);
        UpgradeManager.instance.totalGainFromKills = 0;
        if(checkUI)
        {
            refreshUI();
            PlayerPrefs.SetInt("sceneCounter", PlayerPrefs.GetInt("sceneCounter", 2) + 1);
        }
        
        SceneManager.LoadScene("Level1");
    }


    public void openDeadScreen()
    {
        Time.timeScale = 0;
        changeScreen(deadScreen);
    }

    public void tryAgainButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void openSkinsScreen()
    {
        Time.timeScale = 0;
        changeScreen(skinsScreen);
        refreshUI();
    }

    public void backButton()
    {
        NotEnoughGoldText.SetActive(false);
        refreshUI();
        changeScreen(menuScreen);
    }
}
