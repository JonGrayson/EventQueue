using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolleyballMotto : MonoBehaviour
{
        private bool m_IsQuitting;

        public TextMeshProUGUI eventOutcome;

        void OnEnable()
        {
            EventBus.StartListening("Motto", Motto);
        }

        void OnApplicationQuit()
        {
            m_IsQuitting = true;
        }

        void OnDisable()
        {
            if (m_IsQuitting == false)
            {
                EventBus.StopListening("Motto", Motto);
            }
        }

        void Motto()
        {
            eventOutcome.text = "Received a motto event : It's Evan's fault!";
        }
}
