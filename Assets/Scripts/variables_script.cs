using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variables_script : MonoBehaviour
{
    public float rifle_firerate;
    public float rifle_damage;
    public float grenade_firerate;
    public float grenade_damage;
    public float farm_health;
    public float grenade_ammo;
    public float nuclear_ammo;

    void Start()
    {

        this.rifle_firerate = 2f;
        this.rifle_damage = 40f;
        this.grenade_firerate = 0.5f;
        this.grenade_damage = 100f;
        this.farm_health = 100f;
        this.grenade_ammo = 5f;
        this.nuclear_ammo = 1f; 
    }
}
