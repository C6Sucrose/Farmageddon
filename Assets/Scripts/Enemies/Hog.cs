using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hog : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;
    public float moveSpeed = 5f;
    public Transform target; // Reference to the object the hog should move towards
    private Rigidbody2D rb;
    

    void Start()
    {
        currentHealth = totalHealth;
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
        {
            if (target != null) // Check if a target is assigned
            {
                Vector2 direction = target.position - transform.position; // Calculate the direction towards the target
                direction.Normalize(); // Normalize the direction to a unit vector
                rb.velocity = direction * moveSpeed; // Apply movement towards the target
            }

           
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
        else{
            Debug.Log("Miss");

        }
    }   
           
}



