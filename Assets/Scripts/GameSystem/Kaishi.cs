﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kaishi : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 15"))
        {
            SceneManager.LoadScene("Prologue");
        }
    }
    public void Yobidashi()
    {
        SceneManager.LoadScene("Prologue");
    }
}
