using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTracker : MonoBehaviour {

    public Text levelText;
    public static int levelCount; //static level counter to carry over scenes
    Scene scene;
	// Use this for initialization
	void Start () {
        
                                                  //Return the current Active Scene in order to get the current Scene's name
        scene = SceneManager.GetActiveScene();

        //Check if the current Active Scene's name is your first Scene
        if (scene.name == "level 1")
        {
            levelCount = 1;
        }
        else if (scene.name == "Level 2")
        {
            levelCount = 2;
        }
        else
        {
            levelCount = 3;
        }
        levelText.text = "Level:  " + levelCount; //set the text of the level to the current level
    }

}
