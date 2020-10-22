using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopMusic : MonoBehaviour
{
    private bool m_IsQuitting;

    public GameObject audioSource;

    public TextMeshProUGUI eventOutcome;

    void OnEnable()
    {
        EventBus.StartListening("Stop", Stop);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Stop", Stop);
        }
    }

    void Stop()
    {
        audioSource.SetActive(false);
        eventOutcome.text = "Received a music event : stopping music!";
    }
}
