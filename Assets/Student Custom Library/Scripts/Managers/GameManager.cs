using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Player Fields
    public Vector3 playerScale;
    public float playerMass;
    public float playerDrag;
    public float playerMoveForce;
    public float playerRepelForce;
    public float playerBounce;

    // Scene Fields
    public GameObject[] waypoints;

    // Debug Fields
    public bool debugSpawnWaves;
    public bool debugSpawnPortal;
    public bool debugSpawnPowerUp;
    public bool debugPowerUpRepel;

    // Properties
    public bool switchLevels { get; set; }
    public bool gameOver { get; set; }
    public bool playerHasPowerUp { get; set; }

    private void Awake()
    {
        // Awake is called before any Start methods are called
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
        }
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(switchLevels)
        {
            SwitchLevels();
        }
    }

    private void EnablePlayer() { }

    private void SwitchLevels()
    {
        // Stops class from calling this method again
        switchLevels = false;

        // Get the name of the currently active scene
        string currentScene = SceneManager.GetActiveScene().name;

        // Extract the level number from the scene name
        int nextLevel = int.Parse(currentScene.Substring(5)) + 1;

        // Checks to see if you're at the last level
        if (nextLevel <= SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene("Level" + nextLevel.ToString());

        }
        //If you are at the last level, ends the game.
        //*****   More will go here after Prototype  ***** //
        else
        {
            gameOver = true;
            Debug.Log("You won");
        }
    }
}
