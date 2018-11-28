using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 3.0f;
    public float height = 3.0f;
    public float damping = 5.0f;  // decalre a distance,height,and damping variable for the camera
    public bool followBehind = true;
   
    public float rotationDamping = 10.0f;

    void Update()
    {
        Vector3 wantedPosition;
        if (followBehind)
            wantedPosition = target.TransformPoint(0, height, -distance); //follow behind the character
        else
            wantedPosition = target.TransformPoint(0, height, distance); //above the player

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping); //transform coordinates from local to world space

         transform.LookAt(target, target.up);
    }
}


