using UnityEngine;
using UnityEngine.Events;

public class Cooldown : MonoBehaviour
{
    /**
     * Set to non zero to have the cooldown automatically deactivate
    */
    public float timer;

    public UnityEvent onActivate;
    public UnityEvent onDeactivate;
    
    [Header("Read Only")]
    public bool isActivated;
    
    public void Activate()
    {
        if (isActivated)
        {
            Debug.LogWarning("Tried to activate an already activated cooldown");
            return;
        }
        
        isActivated = true;
        if (timer > 0) Invoke(nameof(Deactivate), timer);
        onActivate.Invoke();
        
    }

    public void Deactivate()
    {
        if (!isActivated)
        {
            Debug.LogWarning("Tried to deactivate an already deactivated cooldown");
            return;
        }
        
        isActivated = false;
        onDeactivate.Invoke();
    }
}
