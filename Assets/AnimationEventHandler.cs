using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventItem
{
    public string name;
    public UnityEvent action;
}

public class AnimationEventHandler : MonoBehaviour
{
    public EventItem[] events;
    
    public void FireEvent(string eventName)
    {
        this.events.First(e => e.name == eventName).action.Invoke();
    }
}
