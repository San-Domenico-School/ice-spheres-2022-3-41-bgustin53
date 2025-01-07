using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void EnablePlayer() { }
    private void SwitchLevels() { }
}
