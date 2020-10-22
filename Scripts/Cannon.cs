using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cannon : MonoBehaviour
{
    private bool m_IsQuitting;

    public TextMeshProUGUI eventOutcome;

    void OnEnable()
    {
        EventBus.StartListening("Shoot", Shoot);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Shoot", Shoot);
        }
    }

    void Shoot()
    {
        eventOutcome.text = "Received a shoot event : shooting cannon!";
    }
}
