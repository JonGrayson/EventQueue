using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EventBus : Singleton<EventBus>
{

    private Dictionary<string, UnityEvent> m_EventDictionary;

    public TextMeshProUGUI queueCounter;

    public int counter;
    public float counterDelay = 1f;
    private Queue<string> eventQueue;
    public bool counterKey = false;

    public override void Awake()
    {
        base.Awake();
        Instance.Init();
    }

    private void Init()
    {
        if (Instance.m_EventDictionary == null)
        {
            Instance.m_EventDictionary = new Dictionary<string, UnityEvent>();
        }

        if(Instance.eventQueue == null)
        {
            Instance.eventQueue = new Queue<string>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public void addToQueue(string eventName)
    {
        Instance.eventQueue.Enqueue(eventName);
        Instance.counter++;
        queueCounter.text = "Events in Queue: " + counter;
    }

    public IEnumerator runEvent()
    {
        yield return new WaitForSeconds(counterDelay);

        while (counter > 0)
        {
            TriggerEvent(Instance.eventQueue.Dequeue());
            Instance.counter--;
            queueCounter.text = "Events in Queue: " + counter;
            yield return new WaitForSeconds(counterDelay);
        }

        counterKey = false;
    }

    void Update()
    {
        if(counterKey == false && counter > 0)
        {
            StartCoroutine("runEvent");
            counterKey = true;
        }
    }
}
