using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            //EventBus.TriggerEvent("Shoot");
            EventBus.Instance.addToQueue("Shoot");
        }

        if (Input.GetKeyDown("l"))
        {
            //EventBus.TriggerEvent("Launch");
            EventBus.Instance.addToQueue("Launch");
        }

        if(Input.GetKeyDown("e"))
        {
            //EventBus.TriggerEvent("Motto");
            EventBus.Instance.addToQueue("Motto");
        }

        if(Input.GetKeyDown("p"))
        {
            //EventBus.TriggerEvent("Play");
            EventBus.Instance.addToQueue("Play");
        }

        if(Input.GetKeyDown("s"))
        {
            //EventBus.TriggerEvent("Stop");
            EventBus.Instance.addToQueue("Stop");
        }

        if(Input.GetKeyDown("r"))
        {
            //EventBus.TriggerEvent("LetsGetAtEr");
            EventBus.Instance.addToQueue("LetsGetAtEr");
        }
    }
}