using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Main : MonoBehaviour
{
    
    public static float health;
    public GameObject deathObject;
    public float coef = 1.0f;
    public Text deathText;
    [SerializeField]
    private Text healthText;

    public Slider healthSlider;

    private void Awake()
    {
        Time.timeScale = 1f; //reset time to normal if reset from death
        health = 100f;
        ThirdPersonCharacter.m_JumpPower = 12f;
    }
    void Update()
    {
        healthSlider.value = health -= coef * Time.deltaTime;
        healthText.text = "Health: " + (int)health;
        if ((int)health == 0)
        {
            health = 0;  //to stop health going into minus values
            deathText.text = "Game Over " +
               "  Time ran out";
            deathObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}