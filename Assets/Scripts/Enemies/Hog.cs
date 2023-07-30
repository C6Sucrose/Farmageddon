using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hog : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;
    
    private Rigidbody2D rb;
    

    void Start()
    {
        currentHealth = totalHealth;
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
        {
            

           
        }



    //damage logic
    public void TakeDamage(int damageAmount)
    {

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Handle enemy death logic here
    void Die()
    {
        
        Destroy(gameObject);
    }


    //check if the hog is hit
    void OnTriggerEnter2D(Collider2D other)
    {
            // Check if the hog is hit by a bullet
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Hit");
            // Get the bullet component from the other object
            Bullet bullet = other.GetComponent<Bullet>();

            // Damage the hog based on the bullet's damage value
            TakeDamage(bullet.damage);

            // Destroy the bullet
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Aoe"))                           // Check if collider is triggered by an area of effect attack
        {
            Debug.Log("Explosive Hit");
            Bullet aoe = other.GetComponent<Bullet>();
            TakeDamage(aoe.damage);                              // Do not destroy aoe objects as their function depends on their
                                                                    // lifetime.
        }
        else{
            Debug.Log("Miss");

        }
    }   
           
}




