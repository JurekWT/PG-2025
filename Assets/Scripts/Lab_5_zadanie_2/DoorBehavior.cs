using System;
using System.Collections;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public GameObject gate;
    private Vector3 startPos;
    private Vector3 endPos;
    public float speed = 3.0f;
    private bool isOpen = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gracz przy drzwiach");
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isOpen)
            {
                Debug.Log("Gracz odszedł od drzwi");
                StartCoroutine(CloseDoor());
            }
        }
    }
    
    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(1.0f);
        isOpen = false;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = gate.transform.position;
        endPos = new Vector3(-3.0f, startPos.y, startPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isOpen)
        {
            gate.transform.position = Vector3.Lerp(gate.transform.position, endPos, speed * Time.deltaTime);
        }
        else
        {
            gate.transform.position = Vector3.Lerp(gate.transform.position, startPos, speed * Time.deltaTime);
        }
    }
}
