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
    public variables_script variables;






    //FOR PC

    public void Start()
    {
        
    }


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
    }


    //FOR MOBILE
//     public void Update()
// {
//     if (Input.touchCount > 0 && Time.time >= nextFireTime)
//     {
//         Fire();
    
//     }


//         // Get the touch position
//         Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

//         // Get the direction from the rifle to the touch position
//         Vector2 direction = touchPosition - (Vector2)transform.position;

//         // Calculate the angle from the direction
//         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
   
//         if(angle >= minRotation && angle <= maxRotation)
//         {
//             // Rotate the rifle to point towards the touch position
//             transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), aimSpeed * Time.deltaTime);
//         }
        
// }

// public void Fire()
// {
//     nextFireTime = Time.time + fireRate;

//     // Instantiate a bullet at the rifle's position
//     GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
// }






}



