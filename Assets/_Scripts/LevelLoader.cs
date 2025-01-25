using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Scene Transition Variables")]
    // Get the objects to make the transition between scenes
    public Animator transition;
    public GameObject pickupGenerator;
    public float transitionTime = 3f;
    public CanvasGroup pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (pickupGenerator.transform.childCount == 0)
            LoadMainScene(); // Reload the current level if the pickups are all picked up
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseMenu(); // Pull up pause menu if user enters escape
    }

    // Pull up the pause menu
    public void PauseMenu()
    {
        // Show if hidden
        if (pauseMenu.alpha != 1)
        {
            pauseMenu.alpha = 1;
            Time.timeScale = 0;
        }
        // Hide if shown
        else if (pauseMenu.alpha == 1)
        {
            pauseMenu.alpha = 0;
            Time.timeScale = 1;
        }
            
    }

    // Load the main scene
    public void LoadMainScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    // Load menu scene
    public void LoadMenuScene()
    {
        // Destroy all of the pickups before loading the menu to avoid errors
        for (int i = 0; i < pickupGenerator.transform.childCount; i++)
            Destroy(pickupGenerator.transform.GetChild(i).gameObject);

        StartCoroutine(LoadLevel(0));
    }

    // Load level with transition
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start"); // Play the animation
        yield return new WaitForSeconds(transitionTime); // Wait
        SceneManager.LoadScene(levelIndex); // Load the scene
    }

    // Quit the application
    public void ExitGame()
    {
        Application.Quit();
    }
}
