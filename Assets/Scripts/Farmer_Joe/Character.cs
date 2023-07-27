using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health = 100;

    public Weapon weapon;
    public Grenade grenade;
    public SpecialAbility specialAbility;

    private void Start()
    {
        weapon = new Weapon();
        grenade = new Grenade();
        specialAbility = new SpecialAbility();
    }
}

public class Weapon
{
    public void Use()
    {
        Debug.Log("Using weapon");
        // Add weapon logic here
    }
}

public class Grenade
{
    public void Use()
    {
        Debug.Log("Using grenade");
        // Add grenade logic here
    }
}

public class SpecialAbility
{
    public void Use()
    {
        Debug.Log("Using special ability");
        // Add special ability logic here
    }
}