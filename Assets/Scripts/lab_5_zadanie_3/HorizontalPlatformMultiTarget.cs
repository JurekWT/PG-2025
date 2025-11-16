using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HorizontalPlatformMultiTarget : MonoBehaviour
{

    public GameObject platform;
    private GameObject player;
    private CharacterController playerCon;
    private Vector3 startPos;
    private Vector3 endPos;
    public List<GameObject> waypoints = new List<GameObject>();
    public int currentWaypointIndex = 0;
    public float speed = 2.0f;
    private bool isMoving = false;
    private bool isPlayerOnPlatform = false;
    private bool isMovingBackwards = false;
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
        currentWaypointIndex = 0;
        endPos = waypoints[currentWaypointIndex].transform.position;
        platformLastPos = platform.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(platform.transform.position, waypoints[currentWaypointIndex].transform.position) <= 0.05f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex > waypoints.Count - 1)
            {
                if (isMovingBackwards)
                {
                    isMoving = false;
                }
                waypoints.Reverse();
                currentWaypointIndex = 1;
                isMovingBackwards = true;
            }
            endPos = waypoints[currentWaypointIndex].transform.position;
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