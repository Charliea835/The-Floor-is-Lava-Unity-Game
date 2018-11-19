using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private float health = Main.health;
    [SerializeField]
    private Text healthText;
    public GameObject deathObject;
    public Slider healthSlider;
    GameObject healthScript;

    private void Start()
    {
        healthScript = GameObject.Find("HealthSlider");
        health = 100;
    }

    private void Update()
    {
        if ((int)health == 0)
        {
            health = 0;
            healthText.text = "Health: " + health;
 
        
        }
    }
    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                healthScript.GetComponent<Main>().enabled = false;
                health -= 100;
                healthSlider.value = health;
            deathObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        

   }
    
}
 