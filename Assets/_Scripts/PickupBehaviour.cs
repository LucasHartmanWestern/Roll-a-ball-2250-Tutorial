using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupBehaviour : MonoBehaviour
{
    // Track the particle systems and rotation speed
    [Header("Pickup Properties")]
    public float rotationSpeed = 0.2f;

    [Header("Particle Systems")]
    public ParticleSystem commonPS;
    public ParticleSystem uncommonPS;
    public ParticleSystem rarePS;
    public ParticleSystem legendaryPS;
    public ParticleSystem exoticPS;

    // Update is called once per frame
    void Update()
    {
        // Slowly rotate the pickup
        this.transform.eulerAngles += new Vector3(0, rotationSpeed, 0);
    }

    // Call when destroyed
    void OnDestroy()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")) // Don't trigger for main menu pickups
            // Create a particle system when destroyed
            Instantiate(GetPS(Int32.Parse(transform.name.Substring(0, 1))), this.transform.position, new Quaternion()).Play();
    }

    // Return the pickup associated to it's index
    public ParticleSystem GetPS(int psIndex)
    {
        switch (psIndex)
        {
            case 1: return commonPS;
            case 2: return uncommonPS;
            case 3: return rarePS;
            case 4: return legendaryPS;
            case 5: return exoticPS;
            default: return commonPS;
        }
    }
}
