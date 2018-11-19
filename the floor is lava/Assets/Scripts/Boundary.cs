using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    public GameObject TextObj;
    public Text info;

    int pickupCounter;
    private void Update()
    {
        pickupCounter = GameObject.Find("Pickup").GetComponent<Pickup>().getPickupCounter();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (pickupCounter == 1)
            {
                SceneManager.LoadScene("Level 2");
                LevelTracker.levelCount++; //increment level counter
            }
            else
            {
                TextObj.SetActive(true);
                info.text = "You have to retrieve the pickup before proceeding";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextObj.SetActive(false);
        }

        
    }
}
    



