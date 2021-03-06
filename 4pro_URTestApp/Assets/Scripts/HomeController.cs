﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HomeController : MonoBehaviour
{
    DateTime TodayNow;

    public Button button_option;
    private bool optionFlag;
    private Sprite s_option, s_back;
    public GameObject panel_option;
    public InputField inputField;//pass入力
    private string password = "g17916im"; //設定画面に入るためのパスワード
    public Text text_alert;
    public Text text_pass;
    public InputField iF_name;
    public Dropdown dD_handSelector;

    private static bool isLeftHanded = false;

    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 30;
        PlayerPrefs.DeleteKey("buttonSize");
        TodayNow = DateTime.Now;
        optionFlag = false;
        panel_option.SetActive(false);
        s_option = Resources.Load<Sprite>("icon_options");
        s_back = Resources.Load<Sprite>("icon_back");
        text_alert.text = "";
        text_pass.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool getIsLeftHanded()
    {
        return isLeftHanded;
    }

    public void startButtonClicked()
    {
        if(iF_name.text == "")
        {
            text_alert.text = "お名前を入力してください";
        }else
        {
            string s = PlayerPrefs.GetString("data2", "") + "\n--------\n" + TodayNow.Year.ToString() + "/" + TodayNow.Month.ToString() + "/" + TodayNow.Day.ToString() + " " + DateTime.Now.ToLongTimeString() + "\n" + "NAME: " + iF_name.text + "\n";
            PlayerPrefs.SetString("data2", s);
            PlayerPrefs.Save();
            SceneManager.LoadScene("URTest1");
        }
    }


    public void developerOptionsButtonClicked()
    {
        if (optionFlag == false)
        {
            var image = button_option.GetComponent<Image>();
            image.sprite = s_back;
            panel_option.SetActive(true);
            optionFlag = true;
        }
        else
        {
            var image = button_option.GetComponent<Image>();
            image.sprite = s_option;
            panel_option.SetActive(false);
            optionFlag = false;
        }
    }

    public void inputText()
    {
        if (inputField.text == password)
        {
            SceneManager.LoadScene("Data");
        }
        else
        {
            text_pass.text = "パスワードが違います";
            inputField.text = "";
        }
    }


    public void subButtonClicked()
    {
        SceneManager.LoadScene("Sub");
    }

    public void changeHand()
    {
        if (dD_handSelector.value == 0)
        {
            isLeftHanded = false;
        }
        else if (dD_handSelector.value == 1)
        {
            isLeftHanded = true;
        }
    }
}
