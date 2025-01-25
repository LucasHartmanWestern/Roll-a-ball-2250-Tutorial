using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupGenerator : MonoBehaviour
{
    // Get all the pickup prefabs
    [Header("Pickup Prefabs")]
    public GameObject commonPickup;
    public GameObject uncommonPickup;
    public GameObject rarePickup;
    public GameObject legendaryPickup;
    public GameObject exoticPickup;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPickups(Random.Range(1,4));
    }

    // Return the pickup associated to it's index
    public GameObject GetPickup(int pickupIndex)
    {
        switch(pickupIndex)
        {
            case 1: return commonPickup;
            case 2: return uncommonPickup;
            case 3: return rarePickup;
            case 4: return legendaryPickup;
            case 5: return exoticPickup;
            default: return commonPickup;
        }
    }

    // Spawn the objects according to their randomized layout
    void SpawnPickups(int spawnLayoutIndex)
    {
        switch(spawnLayoutIndex)
        {
            case 1: // Circle
                for(int i = 0; i < 10; i++) // Make 10 pickups
                {
                    int gemNum = Random.Range(1, 6); // Select a random pickup
                    GameObject pickup = Instantiate(GetPickup(gemNum), new Vector3(4* Mathf.Sin(2*i/Mathf.PI), 2, 4* Mathf.Cos(2*i/Mathf.PI)), new Quaternion(), this.GetComponent<Transform>()); // Create the pickup
                    pickup.transform.eulerAngles = new Vector3(270, Random.Range(0, 90), 0); // Rotate the pickup
                    pickup.transform.name = gemNum + " - " + pickup.transform.name.Replace("(Clone)", ""); // Rename the pickup
                }
                break;
            case 2: // Square
                for(int i = 0; i < 10; i++) // Make 10 (but really 8) pickups
                {
                    if (i == 2 || i == 7) continue; // Dont make the 2nd or 7th pickup (to avoid overlapping pickups)
                    int gemNum = Random.Range(1, 6);  // Select a random pickup
                    GameObject pickup = Instantiate(GetPickup(gemNum), new Vector3(4*Mathf.RoundToInt(Mathf.Cos(2*i/Mathf.PI)), 2, 4* Mathf.RoundToInt(Mathf.Sin(2*i/Mathf.PI))), new Quaternion(), this.GetComponent<Transform>()); // Create the pickup
                    pickup.transform.eulerAngles = new Vector3(270, Random.Range(0, 90), 0); // Rotate the pickup
                    pickup.transform.name = gemNum + " - " + pickup.transform.name.Replace("(Clone)", ""); // Rename the pickup
                }
                break;
            default: // Random
                int[,] gemLocationArray = new int[8, 8]; // Array to track which random spots are already taken
                gemLocationArray[0, 0] = 1; // Dont create a gem at (0,0)
                for (int i = 0; i < 15; i++) // Make 15 pickups
                {
                    int gemX = 0, gemY = 0; // Track where to place the gems int he 2d array
                    while (gemLocationArray[gemX, gemY] > 0) // Make sure the position isn't already taken
                    {
                        gemX = Random.Range(0, 8);
                        gemY = Random.Range(0, 8);
                    }
                    gemLocationArray[gemX, gemY]++; // Mark the position as taken
                    int gemNum = Random.Range(1, 6); // Select a random pickup
                    GameObject pickup = Instantiate(GetPickup(gemNum), new Vector3(2*((gemX/2f)-2), 2, 2*((gemY/2f)-2)), new Quaternion(), this.GetComponent<Transform>()); // Create the pickup
                    pickup.transform.eulerAngles = new Vector3(270, Random.Range(0, 90), 0); // Rotate the pickup
                    pickup.transform.name = gemNum + " - " + pickup.transform.name.Replace("(Clone)", ""); // Rename the pickup
                }
                break;
        }

    }
}
