using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Fire();
        }
    }

    public void Fire()
    {
        nextFireTime = Time.time + fireRate;
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }
}
