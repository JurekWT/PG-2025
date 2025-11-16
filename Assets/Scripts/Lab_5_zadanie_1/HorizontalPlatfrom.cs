using System;
using UnityEngine;

public class HorizontalPlatfrom : MonoBehaviour
{

    public GameObject platform;
    private GameObject player;
    private CharacterController playerCon;
    private Vector3 startPos;
    private Vector3 endPos;
    public GameObject waypoint1;
    public float speed = 1.0f;
    private bool isMoving = false;
    private bool movingToWaypoint1 = true;
    private bool isPlayerOnPlatform = false;
    Vector3 platformLastPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.unityLogger.Log("Gracz na platformie");
            //other.transform.parent = platform.transform;
            isMoving = true;
            isPlayerOnPlatform = true;
        }
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.unityLogger.Log("Gracz zszedl z platformy");
            //other.transform.parent = null;
            //isMoving = false;
            isPlayerOnPlatform = false;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = player.GetComponent<CharacterController>();
        startPos = platform.transform.position;
        endPos = waypoint1.transform.position;
        platformLastPos = platform.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(platform.transform.position, waypoint1.transform.position) <= 0.05f && movingToWaypoint1)
        {
            endPos = startPos;
            startPos = platform.transform.position;
            movingToWaypoint1 = false;
        }

        if (Vector3.Distance(platform.transform.position, endPos) <= 0.05f && !movingToWaypoint1)
        {
            endPos = waypoint1.transform.position;
            startPos = platform.transform.position;
            movingToWaypoint1 = true;
            isMoving = false;
        }
        
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, endPos, speed * Time.deltaTime);
            if (isPlayerOnPlatform)
            {
                var platfromMovement = platform.transform.position - platformLastPos;
                playerCon.Move(platfromMovement);
            }
            platformLastPos = platform.transform.position;
        }
    }
}
