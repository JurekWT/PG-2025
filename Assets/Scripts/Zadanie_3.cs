using UnityEngine;

public class Zadanie3 : MonoBehaviour
{

    public float speed = 5.0f;
    private int _range = 10;
    private Vector3 _startPosition;
    private Vector3 _direction = Vector3.forward;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * (speed * Time.deltaTime));
        if (Vector3.Distance(_startPosition, transform.position) > _range)
        {
            transform.RotateAround(transform.position, Vector3.up, 90);
            _startPosition = transform.position;
        }

    }
} 
