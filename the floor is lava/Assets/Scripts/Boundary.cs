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
        pickupCounter = GameObject.Find("Pickup").GetComponent<Pickup>().getPickupCounter(); //pickup counter is equal to pickupcounter from Pickup class
    }

    void OnTriggerEnter(Collider other) //on Boundary enter
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if ((pickupCounter == 1 && LevelTracker.levelCount==1))
            {
                SceneManager.LoadScene("Level 2");
                
            }
            else if ((pickupCounter == 1 && LevelTracker.levelCount == 2))  //check level and pickup count and load relevant scenes 
            {
                SceneManager.LoadScene("Level 3");
                
            }
            else if ((pickupCounter == 1 && LevelTracker.levelCount == 3))
            {
                IntroAndExitManager.introOrExit = 1; //set variable to determine what scene to go to in End 
                SceneManager.LoadScene("End");
                
            }
            else
            {
                TextObj.SetActive(true); //set object holding scene text to on
                info.text = "You have to retrieve the pickup before proceeding";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextObj.SetActive(false); //on exit of boundary disable scene text
        }

        
    }
}
    



