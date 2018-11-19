using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pickup : MonoBehaviour {
    [SerializeField]
    public GameObject lightningPrefab;
    private ParticleSystem lightningParticles;
    private int pickupCounter = 0;
    [SerializeField]
    public bool isDestroyed;
    [SerializeField]
    private Text PickupText;

    private void Update()
    {
        PickupText.text = "Pickups: " + pickupCounter + " /1";
    }
    private void OnEnable()
    {
        // Instantiate the explosion prefab and get a reference to the particle system on it.
        lightningParticles = Instantiate(lightningPrefab).GetComponent<ParticleSystem>();

        // Disable the prefab so it can be activated when it's required.
        lightningParticles.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            pickupCounter++;
            isDestroyed = true;
            DistanceToPickup.isPickupDestroyed = true; 
            // Move the instantiated explosion prefab to the tank's position and turn it on.
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
