using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour {

    public Transform player; //get playersTransform 

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 newPosition = player.position; //get players postion, store in new position
        newPosition.y = transform.position.y; //set the y axis of new position of player
        transform.position = newPosition; //set position of minimap to players new y posiiton 
    }
}
