using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Keep track of points
    [Header("Score Variables")]
    public int score = 0;
    private Text _scoreText;

    private static GameController instance = null;
    public static GameController Instance
    {
        get { return instance; }
    }

    // Call when script is instantiated
    void Awake()
    {
        // Delete any duplicates of this instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject); // Keep control between scenes
    }

    // Get new canvas's and update score
    private void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene") && GameObject.Find("Player Score") != null)
        {
            _scoreText = GameObject.Find("Player Score").GetComponent<Text>(); // Get the player score text
            _scoreText.text = "Player Score: " + score;
        }
    }

    // Increase points
    public void AddPoints(int points)
    {
        score += points;
        _scoreText.text = "Player Score: " + score;
    }
}
