using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayMusic : MonoBehaviour
{
        private bool m_IsQuitting;

        public GameObject audioSource;

        public TextMeshProUGUI eventOutcome;

        void OnEnable()
        {
            EventBus.StartListening("Play", Play);
        }

        void OnApplicationQuit()
        {
            m_IsQuitting = true;
        }

        void OnDisable()
        {
            if (m_IsQuitting == false)
            {
                EventBus.StopListening("Play", Play);
            }
        }

        void Play()
        {
            audioSource.SetActive(true);
            eventOutcome.text = "Received a music event : playing music!";
        }
}
