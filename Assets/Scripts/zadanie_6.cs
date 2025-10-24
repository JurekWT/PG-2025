using System;
using UnityEngine;

public class zadanie_6 : MonoBehaviour
{
    public Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.5f;
    private float wobbleMin = -3.0f;
    private float wobbleMax = 3.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        transform.position = new Vector3(Mathf.Lerp(wobbleMin, wobbleMax, yVelocity), transform.position.y, transform.position.z);
    }
}
