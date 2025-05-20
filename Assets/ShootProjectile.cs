using System;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject prefab;
    public float force;

    private Transform target;
    
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Shoot()
    {
        
        var arrow = Instantiate(prefab, prefab.transform.position, Quaternion.identity);
        arrow.gameObject.SetActive(true);
        
        var body = arrow.GetComponent<Rigidbody2D>();
        var direction = target.position - prefab.transform.position;
        Debug.LogFormat("target {0} - prefab {1} = {2}", target.position, prefab.transform.position, direction);
        
        body.linearVelocity = direction.normalized * force;
        
        // body.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
