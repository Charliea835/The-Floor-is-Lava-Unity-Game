using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DistanceToPickup : MonoBehaviour {

    // Reference to checkpoint position
    [SerializeField]
    private Transform checkpoint;

    // Reference to UI text that shows the distance value
    [SerializeField]
    private Text distanceText;
    GameObject exit;
    // Calculated distance value
    private float distance;
    [SerializeField]
    private Transform newTransform;

    public static bool isPickupDestroyed;

    private void Start()
    {
        exit = GameObject.Find("Door_01");
      
    }


    // Update is called once per frame
    private void Update()
    {
        if (GameObject.Find("Pickup").GetComponent<Pickup>().isDestroyed)
        {
            
            //point transform checkpoint to new object
            distance = (checkpoint.transform.position - exit.transform.position).magnitude;
            distanceText.text = "Exit: " + distance.ToString("F1") + " meters";
        }
        else
        {
            // Calculate distance value between character and checkpoint
            distance = (checkpoint.transform.position - transform.position).magnitude;

            // Display distance value via UI text
            // distance.ToString("F1") shows value with 1 digit after period
            // so 12.234 will be shown as 12.2 for example
            // distance.ToString("F2") will show 12.23 in this case
            distanceText.text = "Pickup: " + distance.ToString("F1") + " meters";


        }
    }
}
