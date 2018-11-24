using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroAndExitManager : MonoBehaviour {

    float TmStart;
    float TmLen = 3f; //declare length of time for text to show
    public static int introOrExit = 0; //integer binary to say what scene gets loaded after time differnece 
    void Start()
    {
        TmStart = Time.time; //assign TmStart the current time in seconds
    }

    // Update is called once per frame
    void Update () {
       
            if (Time.time > TmStart + TmLen * 3) //if current time is greater than current time + 9 seconds
            {

            if (introOrExit == 0) //load scene 1
            {
                SceneManager.LoadScene("Level 1");
            }
            else
            {   //go back to menu
                SceneManager.LoadScene("StartMenu");
            }

        }
        
    }
}
