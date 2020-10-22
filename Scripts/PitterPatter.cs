using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PitterPatter : MonoBehaviour
{
    private bool m_IsQuitting;

    public TextMeshProUGUI eventOutcome;

    void OnEnable()
    {
        EventBus.StartListening("LetsGetAtEr", LetsGetAtEr);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("LetsGetAtEr", LetsGetAtEr);
        }
    }

    void LetsGetAtEr()
    {
        eventOutcome.text = "Received a Pitter Patter event : Let's get at 'er";
    }
}
