using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmoSystem : MonoBehaviour
{
    public bool isLimited = true;    // Flag to control whether ammo is limited or unlimited
    public float refillTime = 5f;    // The time it takes for the ammo to refill completely
    public int maxAmmo = 10;         // The maximum amount of ammo

    public float currentRefillTime; // The current time for ammo refill
    public int currentAmmo;         // The current ammo count

    private void Start()
    {
        if (isLimited)
        {
            currentAmmo = maxAmmo;   // Set the starting ammo count to max if ammo is limited
            currentRefillTime = refillTime; // Set the refill time to max initially
        }
        else
        {
            currentAmmo = maxAmmo; // Set the current ammo count to max if ammo is unlimited
            currentRefillTime = 0; // Set the refill time to 0 if ammo is unlimited
        }
    }

    public void Update()
    {
        
        if (!isLimited && currentAmmo < maxAmmo)
        {
            currentRefillTime -= Time.deltaTime;
            Debug.Log(currentRefillTime);
            if (currentRefillTime <= 0f)
            {
                currentAmmo++;
                Debug.Log("Ammo:" + currentAmmo);
                currentRefillTime = refillTime;
            }
        }
    }

    public bool UseAmmo()
    {
        if (currentAmmo > 0)
        {
            Debug.Log("Ammo Left: " + currentAmmo);
            currentAmmo--;
            return true;
        }

        return false;
    }
}
