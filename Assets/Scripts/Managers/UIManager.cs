using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject currentScreen;

    
    public GameObject gameScreen;
    public GameObject menuScreen;
    public GameObject returnScreen;



    [SerializeField]
    private Button hornLengthButton;
    [SerializeField]
    private Button offlineButton;
    [SerializeField]
    private Button speedButton;

    [SerializeField]
    private Text hornLengthText;
    [SerializeField]
    private Text offlineText;
    [SerializeField]
    private Text speedText;


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
    }

    public void refreshUI()
    {

    }

    public void changeScreen(string screenName)
    {

    }

}
