﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Use this for initialization
    void Start() {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }
}
