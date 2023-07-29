using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float aimSpeed = 1f;
    public float fireRate = 0.5f;
    public float nextFireTime = 0f;
    public float minRotation = 45f;
    public float maxRotation = 135f;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Fire();
        
        }

        // Get the mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the direction from the rifle to the mouse
        Vector2 direction = mousePosition - (Vector2)transform.position;

        // Calculate the angle from the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

       
        if(angle >= minRotation && angle <= maxRotation)
        {
        // Rotate the rifle to point towards the mouse
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), aimSpeed * Time.deltaTime);
        }

    }

    public void Fire()
    {

        nextFireTime = Time.time + fireRate;

        // Instantiate a bullet at the rifle's position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        
        //Trying to get the below snippet to work, current WIP
        // Get the bullet's rigidbody component
        // Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        
        // Set the velocity of the bullet to the direction the rifle is pointing
        // bulletRB.velocity = transform.right * bulletSpeed;
    }
}

