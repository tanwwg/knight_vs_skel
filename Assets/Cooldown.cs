using UnityEngine;
using UnityEngine.Events;

public class Cooldown : MonoBehaviour
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;    
    
    public bool isActivated;
    
    public void Activate()
    {
        onActivate.Invoke();
        isActivated = true;
    }

    public void Deactivate()
    {
        onDeactivate.Invoke();
        isActivated = false;
    }
}
