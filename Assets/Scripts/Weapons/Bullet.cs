using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    void Start()
    {
        // Destroy the bullet after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with an enemy or any other objects you want
        if (other.CompareTag("Enemy"))
        {
            // Do something when the bullet hits an enemy
            Destroy(other.gameObject);
        }

        // Destroy the bullet when it collides with any object
        Destroy(gameObject);
    }
}