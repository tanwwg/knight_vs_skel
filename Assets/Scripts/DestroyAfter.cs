using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float delay;
    public GameObject target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Invoke(nameof(DestroyTarget), delay);
    }

    public void DestroyTarget()
    {
        Destroy(target);
    }
}
