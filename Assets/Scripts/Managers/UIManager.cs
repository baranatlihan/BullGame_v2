using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject currentScreen;

    
    public GameObject gameScreen;
    public GameObject menuScreen;
    public GameObject rewardScreen;



    [SerializeField]
    private Button hornLengthButton;
    [SerializeField]
    private Button offlineButton;
    [SerializeField]
    private Button speedButton;

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


    public static UIManager instance;


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

        currentScreen = menuScreen;
    }

    private void Start()
    {
        refreshUI();
        currentScreen = menuScreen;
        gameScreen.SetActive(false);
        Time.timeScale = 0;
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

        if(hornLenght*10 <= wallet)
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

}
