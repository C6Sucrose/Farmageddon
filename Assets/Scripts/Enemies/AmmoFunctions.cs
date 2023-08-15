using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoFunctions : MonoBehaviour
{
    public string targetTag = "Farm";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject);
            Debug.Log("Ammo Destroyed");
        }
    }
}
