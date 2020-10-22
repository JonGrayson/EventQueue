﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rocket : MonoBehaviour
{
    public TextMeshProUGUI eventOutcome;

    private bool m_IsQuitting;

    private bool m_IsLaunched = false;

    void OnEnable()
    {
        EventBus.StartListening("Launch", Launch);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Launch", Launch);
        }
    }

    void Launch()
    {
        if (m_IsLaunched == false)
        {
            m_IsLaunched = true;
            eventOutcome.text = "Received a launch event : rocket launching!";
            Invoke("Explosion", 5.0f);
        }
    }

    void Explosion()
    {
        eventOutcome.text = "Rocket has hit the target!";
        m_IsLaunched = false;
    }
}
