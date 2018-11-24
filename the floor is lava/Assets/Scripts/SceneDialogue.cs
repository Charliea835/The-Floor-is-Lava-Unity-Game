using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneDialogue : MonoBehaviour {

    public GameObject TextObj; //declare gameObject
    public Text startText; //reference to start text object
    float TmStart;
    float TmLen = 3f; //declare length of time for text to show

    // Use this for initialization
    void Start()
    {
        TmStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelTracker.levelCount == 2)
        {
            startText.text = "              The lava burns hotter";
        }
        if (LevelTracker.levelCount == 3)
        {
            startText.text = "          Make for your escape!";
        }
        if (Time.time > TmStart + TmLen)
        {
            
            TextObj.SetActive(true); //set the textObj object to true if the time is less than time to start displaying text
            if (Time.time > TmStart + TmLen*3)
            {

                TextObj.SetActive(false); //set to false once time has elapsed
                Destroy(this.gameObject); //destroy game object we dont need it anymore
            }
        }

        
    }
}
