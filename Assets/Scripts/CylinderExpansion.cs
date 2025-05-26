using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderExpansion : MonoBehaviour
{
    public float startRadius = 1f;
    public float maxRadius = 5f;
    public float growthSpeed = 1f;

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
        transform.localScale = new Vector3(startRadius, initialScale.y, startRadius);
    }

    void Update()
    {
        Vector3 scale = transform.localScale;
        
        if (scale.x < maxRadius)
        {
            float newRadius = Mathf.Min(scale.x + growthSpeed * Time.deltaTime, maxRadius);
            transform.localScale = new Vector3(newRadius, initialScale.y, newRadius);
        }
    }
}
