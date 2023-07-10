using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceMovement : MonoBehaviour
{
    public GameObject[] waypoints;        // The waypoints for the sound movement
    public float distanceThreshold;    // Distance threshold to trigger the next waypoint
    private int currentWaypointIndex;   // Current waypoint index
    private bool isWaiting;             // Flag to indicate if waiting for the player
    private Vector3 currentVelocity; //current speed
    public float smoothTime = 5f;      // Smoothing time for SmoothDamp
    private AudioSource audioRef;


    public float maxVolume = 1f;
    public float minVolume = 0.1f;

    public GameObject playerRef;
    public Transform playerCameraRef;


    private void Start()
    {
        currentWaypointIndex = 0;
        isWaiting = true;
        currentVelocity = Vector3.zero;
        audioRef = GetComponent<AudioSource>();
    }


    private void DistancetoVolume()
    {
        Vector3 toPlayer = playerCameraRef.transform.position - transform.position;
        toPlayer.Normalize();

        float dotProduct = Vector3.Dot(playerCameraRef.forward, toPlayer);

        // Calculate the volume based on the dot product
        float volume = Mathf.Lerp(minVolume, maxVolume, -dotProduct);

        audioRef.volume = volume;


    }

    private void Movement()
    {
        if (isWaiting)
        {
            // Check if the player is within range
            if (Vector3.Distance(transform.position, playerRef.transform.position) < distanceThreshold)
            {
                isWaiting = false;  // Player is in range, stop waiting
                EventManager.current.ObstacleTriggered();
            }
        }
        else
        {
            // Move towards the current waypoint
            transform.position = Vector3.SmoothDamp(transform.position, waypoints[currentWaypointIndex].transform.position, ref currentVelocity, smoothTime);

            // Check if reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < distanceThreshold)
            {
                isWaiting = true;
                currentWaypointIndex++;  // Move to the next waypoint

                // Check if all waypoints have been visited
                if (currentWaypointIndex >= waypoints.Length)
                {
                    // All waypoints visited, do something or reset
                    currentWaypointIndex = 0;
                    isWaiting = true;  // Start waiting for the player again
                }
            }
        }
    }

    private void Update()
    {
        DistancetoVolume();
        Movement();
    }
}
