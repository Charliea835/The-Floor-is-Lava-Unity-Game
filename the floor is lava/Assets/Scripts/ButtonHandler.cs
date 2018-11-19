using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

	public void restart()
    {
        SceneManager.LoadScene("Level 1");
        LevelTracker.levelCount = 1; //set level back to 1 if restart pressed
    }


    public void exit()
    {
        Application.Quit();
    }
}
