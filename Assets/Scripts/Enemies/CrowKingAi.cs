using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowKingAi : MonoBehaviour
{
    public float speed;
    public GameObject ammo;
    public Transform ammoSpawn;
    public float fireRate;
    private float nextFire;
    Vector3 newPosition;


    void Start()
    {
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(0f, 30f), Random.Range(0f, 30f));
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, newPosition) < 1)
        {
            PositionChange();
        }    
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
        LookAt2D(newPosition);

        if (nextFire < Time.time)
        {
            GameObject ammoSpawned = Instantiate(ammo, ammoSpawn.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;
    }

}
