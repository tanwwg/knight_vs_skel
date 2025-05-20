using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public void KillPlayer()
    {
        var player = FindFirstObjectByType<Player>();
        player.GetComponent<Hittable>().onDie.Invoke();
    }

}
