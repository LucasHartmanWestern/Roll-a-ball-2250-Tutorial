using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Audio clip to play when you hit a pickup
    [Header("Audio")]
    public AudioSource pickupSoundEffect;

    // Variables to adjust player stats
    [Header("Player Variables")]
    public float playerSpeed;

    [Header("UI")]
    public GameObject gameController;

    // Call when script is instantiated
    private void Awake()
    {
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        // Get the user's input using the horizontal and vertical axis inputs (to account for WASD, arrows, and controllers)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Move the player using the rigid body
        this.GetComponent<Rigidbody>().AddForce(move * playerSpeed);
    }

    // Detect collisions with IsTrigger objects
    private void OnTriggerEnter(Collider collider)
    {
        pickupSoundEffect.Play(); // Play the pickup sound
        gameController.GetComponent<GameController>().AddPoints(Int32.Parse(collider.gameObject.name.Substring(0, 1))); // Get the value of the pickup
        Destroy(collider.gameObject); // Destroy the pickup the player collides with
    }
}
