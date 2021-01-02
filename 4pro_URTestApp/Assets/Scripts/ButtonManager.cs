﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons = new GameObject[10];

    private int numOfButtons;
    private int numOfTouchButtons;

    // Start is called before the first frame update
    void Start()
    {
        numOfButtons = buttons.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < Input.touchCount; i++)
        {
            numOfTouchButtons = 0;
            var touch = Input.GetTouch(i);
            for (var j = 0; j < numOfButtons; j++)
            {
                if (buttons[j].GetComponent<ButtonController>() != null)
                {
                    var isTouched = buttons[j].GetComponent<ButtonController>().IsTouched;
                    if (isTouched) numOfTouchButtons++;
                }

                if (buttons[j].GetComponent<ButtonControllerT>() != null)
                {
                    var isTouched = buttons[j].GetComponent<ButtonControllerT>().IsTouched;
                    if (isTouched) numOfTouchButtons++;
                }
            }
        }
    }

    public int NumOfTouchButtons //プロパティ
    {
        get { return this.numOfTouchButtons; }
    }
}