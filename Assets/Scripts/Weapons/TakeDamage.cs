using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int totalHealth = 100;                                     // Health and taking damage functionality for a fence/barbed wire
    public int currentHealth = 0;

    private Rigidbody2D rigidBody;

    void Start()
    {
        currentHealth = totalHealth;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void GetDamaged(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy attacks the fence");
            Hog attack = other.GetComponent<Hog>();
            GetDamaged(attack.hogdamage);
        }
    }
}
