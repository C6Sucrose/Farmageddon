using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Calls WeaponController which controls the whole shooting thing
public class Rifle : MonoBehaviour
{
    public WeaponController weaponController;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weaponController.Update();
        }
    }
}