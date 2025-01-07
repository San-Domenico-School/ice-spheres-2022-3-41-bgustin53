using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Fields
    public Rigidbody playerRB;
    public SphereCollider playerCollider;
    public Light powerUpIndicator;
    public PlayerInputActions inputAction;
    public Transform focalpoint;
    public float moveForceMagnitude;

    // Properties
    public bool hasPowerUp { get; private set; }

    // Methods
    private void Awake() { }
    private void Start() { }
    private void OnEnable() { }
    private void OnDisable() { }
    private void FixedUpdate() { }
    public void SetMoveDirection(Vector2 value) { }
    public void AssignLevelValues() { }
    private void Move() { }
    private void OnCollisionEnter(Collision collision) { }
    private void OnTriggerEnter(Collider other) { }
    private void OnTriggerExit(Collider other) { }
    private IEnumerator PowerUpCooldown(float cooldown) { }
}
