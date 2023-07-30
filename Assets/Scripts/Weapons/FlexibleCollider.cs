using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleCollider : MonoBehaviour
{
    public float timeToMaxSize = 5f; // Duration in seconds to reach maximum size
    public float maxSize = 10f; // Maximum size of the collider

    private float currentSize = 0f;
    private float sizeSpeed;

    private CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        sizeSpeed = maxSize / timeToMaxSize;
    }

    private void Update()
    {
        currentSize += sizeSpeed * Time.deltaTime;
        currentSize = Mathf.Clamp(currentSize, 0f, maxSize);

        circleCollider.radius = currentSize / 2f;
    }
}
