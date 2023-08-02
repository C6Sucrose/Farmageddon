using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    private GameObject[] weapon;
    public Transform weaponSpawnPoint;

    void Start()                                                            // Spawn the weapons when the scene first starts
    {
        for (int i = 0; i < weapons.Length; i++)
        {
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
}
