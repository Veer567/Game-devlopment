using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Follower : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints; 
   private int currentWaypointiIndex = 0;
   [SerializeField] private float speed = 2f;
   private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointiIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointiIndex++;
            if(currentWaypointiIndex >= waypoints.Length)
            {
                currentWaypointiIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position,waypoints[currentWaypointiIndex].transform.position,Time.deltaTime * speed); 
    }
}
