using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelTracker : MonoBehaviour {

    public Text levelText;
    public static int levelCount=1; //static level counter to carry over scenes
	// Use this for initialization
	void Start () {
        levelText.text = "Level:  " + levelCount; //set the text of the level to the current level
	}

}
