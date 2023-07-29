using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public WeaponController weaponController;
   
    
    private void Update()
    {
        // Check for input to fire the rifle
        if (Input.GetButtonDown("Fire1"))
        {
            // Call the Fire() method from the weapon controller script
            weaponController.Update();
        }
    }
}
