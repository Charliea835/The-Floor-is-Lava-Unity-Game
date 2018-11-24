using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Main : MonoBehaviour
{
    
    public static float health;
    public GameObject deathObject;
    public float coef = 1.0f; //amount of health to reduce by per second
    public Text deathText; //variable to ref death text 
    [SerializeField]
    private Text healthText;

    public Slider healthSlider;

    private void Awake()
    {
        Time.timeScale = 1f; //reset time to normal if reset from death
        health = 100f;
        
    }
    void Update()
    {
        healthSlider.value = health -= coef * Time.deltaTime;
        healthText.text = "Health: " + (int)health;   //decrease health over time
        if ((int)health == 0)
        {
            health = 0;  //to stop health going into minus values
            deathText.text = "Game Over " +
               "  Time ran out";
            deathObject.SetActive(true);  //if health is 0 then show the death canvas with buttons
            Time.timeScale = 0; //set the time scale to 0 so time freezes
        }
    }
}