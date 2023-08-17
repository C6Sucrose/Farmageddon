using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;  // The target for the enemy to go towards
    public string targetTag = "Farm";
    public float speed = 5f;  // The movement speed of the enemy


    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction towards the target
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            // Move towards the target
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}