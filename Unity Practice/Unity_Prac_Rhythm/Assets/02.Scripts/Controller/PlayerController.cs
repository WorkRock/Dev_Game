﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TimingManager theTimingManager;

    void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 판정체크
            theTimingManager.CheckTiming();
        }
    }
}
