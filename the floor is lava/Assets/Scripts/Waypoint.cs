using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public GameObject[] waypoints; //create array of waypoints 
    int current = 0; //current waypoint index = 0
    public float speed;
    float WPradius = 1; //radius of waypoint

    void Update() 
    {   //if distance between the waypoint and the players position is less than 1
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius) 
        {//do this
            current = Random.Range(0, waypoints.Length); //generate random number between waypoints in array
            if (current >= waypoints.Length) //if value is greater or equal to last waypoint
            {
                current = 0; //go back to start
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        //move object towards waypoint at speed
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.SetParent(transform); //set collision object as parent of platform so character doesent fall off while moving
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);//detach as parent of platform on exit so we can freely move again
    }
}