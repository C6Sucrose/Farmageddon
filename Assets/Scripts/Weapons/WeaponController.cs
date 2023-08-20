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
    public AmmoSystem ammoSystem;
    Vector2 mousePosition;
    Vector2 direction;
    float angle;
    Animator animation;
    bool reload_3 = true;




    //FOR PC

    public void Start()
    {

        
            if(fireRate != 0.5f){
            animation = GetComponent<Animator>();
            }

            // Get the mouse position
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get the direction from the rifle to the mouse
             direction = mousePosition - (Vector2)transform.position;

            // Calculate the angle from the direction
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }


    public void Update()
    {
        //for rifle_3 reload
        if(ammoSystem.currentAmmo == 0 && reload_3 == false && ammoSystem.maxAmmo == 20 && fireRate != 0.5f){
            animation.SetTrigger("rifle_3_reload");
            reload_3 = true;
        }
        //fire only for NukeWeapon
        if(Input.GetButtonUp("Fire1") && Time.time >= nextFireTime  && (ammoSystem.currentAmmo > 0) && fireRate == 0.5f)
        {
            Fire();
        }

        //Fire for all the other weapons
        if (Input.GetButtonUp("Fire1") && Time.time >= nextFireTime  && (ammoSystem.currentAmmo > 0) && angle >= minRotation && angle <= maxRotation)
        {
            Fire();

            
        }
        

            // Get the mouse position
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get the direction from the rifle to the mouse
            direction = mousePosition - (Vector2)transform.position;

            // Calculate the angle from the direction
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

       
            if(angle >= minRotation && angle <= maxRotation)
            {
                // Rotate the rifle to point towards the mouse
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), aimSpeed * Time.deltaTime);
            }
        

    }

    public void Fire()
    {

        nextFireTime = Time.time + fireRate;
        ammoSystem.UseAmmo();
        // Instantiate a bullet at the rifle's position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        //play reload animation
        if(fireRate != 0.5f){
        animation.SetTrigger("reload");
        reload_3 = false;
        }
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



