﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlreadyPressed : MonoBehaviour
{
    private bool beenPressed = false;
    public GameObject guideTextPanel;

    // Start is called before the first frame update
    void Start()
    {
        beenPressed = (PlayerPrefs.GetInt("Name") == 0);

    }
    public void Pressed()
    {

        if (!beenPressed)
        {
            guideTextPanel.gameObject.SetActive(true);

            PlayerPrefs.SetInt("Name", 1);

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}