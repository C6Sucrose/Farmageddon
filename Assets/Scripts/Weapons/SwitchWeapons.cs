using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject[] GrenadeUpgrades;
    
    public GameObject[] RifleUpgrades;
    public Switch_upgrade su;
    public Transform weaponSpawnPoint;
    public int current_index;//the weapon to be upgraded
    public int replace_index;//the upgrade index


    void Start()                                                            // Spawn the weapons when the scene first starts
    {
        ReplaceWeapon(su.w1ul, 0);
        ReplaceWeapon(su.w2ul, 1);
        for (int i = 0; i < weapons.Length; i++)
        {
            Debug.Log(weapons[i].name);
            weapons[i] = Instantiate(weapons[i], weaponSpawnPoint.position, weaponSpawnPoint.rotation);
            weapons[i].SetActive(false);
        }
        weapons[0].SetActive(true);
    }

    public void SwitchWeapon(int index)                                     // Functionality to switch between different weapons
    {
        weapons[index].SetActive(true);
        for (int i = 0; i < weapons.Length; i++)
        {
           if (i != index)
            {
                weapons[i].SetActive(false);
            }
        }
    }

    //Replaced is the index of the WeaponType we need to replace.
    //Replacer is the index of the Upgrade we need to replace it with.
    public void ReplaceWeapon(int replacer, int replaced)
    {
        Debug.Log("Called");
        if ((replacer >= 0 && replacer < weapons.Length) && (replaced >= 0 && replaced < RifleUpgrades.Length))
        {
            Debug.Log("Inside If");
            if(replaced == 0){
                Debug.Log("Rifle replaced with " + replacer);
                weapons[replaced] = RifleUpgrades[replacer];
            }
            else if(replaced == 1)
            {
                Debug.Log("Grenade replaced with " + replacer);
                weapons[replaced] = GrenadeUpgrades[replacer];
            }
        }
        else
        {
            Debug.LogError("Invalid Index");
        }
    }
}
 