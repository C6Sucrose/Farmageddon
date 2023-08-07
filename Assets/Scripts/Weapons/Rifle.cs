using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//FOR PC
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


//FOR MOBILE
// public class Rifle : MonoBehaviour
// {
//     public WeaponController weaponController;
//     public AmmoSystem ammoSystem;
    
//     private void Update()
//     {
//         if (Input.touchCount > 0 && (ammoSystem.UseAmmo() == true))
//         {
//             weaponController.Update();
//         }
//     }
// }