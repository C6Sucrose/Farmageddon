using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAI : MonoBehaviour
{
    public float speed;
    private Transform target;
    public string targetTag = "Farm";
   // public float detectionRadius;
    public float fireRadius;
    public GameObject ammo;
    public Transform ammoSpawn;
    public float fireRate;
    private float nextFire;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        fireRadius = Random.Range(fireRadius, fireRadius - 10);
    }
    void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance <= fireRadius && nextFire < Time.time)
        {
            GameObject ammoSpawned = Instantiate(ammo, ammoSpawn.position, Quaternion.identity);
            nextFire = Time.time + fireRate;  
        }
        else if (distance > fireRadius)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
       // Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.DrawWireSphere(transform.position, fireRadius);
    }

   
}
