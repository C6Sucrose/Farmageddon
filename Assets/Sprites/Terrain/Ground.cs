using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void Start()
    {
        // Get the rigidbody component and set its gravity scale to 0
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;

        // Add a non-trigger collider to the ground object
        Collider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the other object has a rigidbody component
        Rigidbody2D rigidbody = other.collider.GetComponent<Rigidbody2D>();

        if (rigidbody != null)
        {
            // Make the other object a child of this ground object
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // Check if the other object has a rigidbody component
        Rigidbody2D rigidbody = other.collider.GetComponent<Rigidbody2D>();

        if (rigidbody != null)
        {
            // Remove the other object as a child of this ground object
            other.transform.SetParent(null);
        }
    }
}