using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pickup : MonoBehaviour {
    [SerializeField]
    public GameObject lightningPrefab;
    private ParticleSystem lightningParticles; //refernce to loightning prefab and particle system
    private int pickupCounter = 0;
    [SerializeField]
    public bool isDestroyed; //boolean to determine if pickup has been destroyed
    [SerializeField]
    private Text PickupText; //UI pickup text
    GameObject waypoint; //this will reference the second platform object in level 3 to alter its speed

    private void Start()
    {
        
        waypoint = GameObject.Find("secondPlatform");
    }

    private void Update()
    {
        PickupText.text = "Pickups: " + pickupCounter + " /1"; //constantly check pickup counter value and set pickup text to it
    }
    private void OnEnable()
    {
        // Instantiate the lightning prefab and get reerence to it
        lightningParticles = Instantiate(lightningPrefab).GetComponent<ParticleSystem>();

        // Disable the prefab so it can be activated when it's required.
        lightningParticles.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (LevelTracker.levelCount == 3)
            {
              waypoint.GetComponent<Waypoint>().speed = 8;
            }

            pickupCounter++; 
            isDestroyed = true;
            DistanceToPickup.isPickupDestroyed = true; //set isPickupDestroyed bolean to true so distance to pickup is changed to exit
            // Move the instantiated explosion prefab to the pickups position and turn it on.
            lightningParticles.transform.position = transform.position;
            lightningParticles.gameObject.SetActive(true);

            // Play the particle system of the tank exploding.
            lightningParticles.Play();

            PickupText.text = "Pickups: " + pickupCounter + " /1";

            Destroy(this.gameObject.GetComponent<MeshRenderer>());
            Destroy(this.gameObject.GetComponent<ParticleSystem>());
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            // if we just call Destroy(this.gameComponent) then all components including the script holding
            // the value we need will also be destroyed, to get around this we destoy only the components that are not needed after destruction.
        }

        
    }

    public int getPickupCounter()
    {
        return pickupCounter;
    }

}
