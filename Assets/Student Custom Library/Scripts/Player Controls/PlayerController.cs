using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Fields
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerUpIndicator;
    private PlayerInputActions inputAction;
    private Transform focalpoint;
    private float moveForceMagnitude;
    private float moveDirection;

    // Properties
    public bool hasPowerUp { get; private set; }

    // Methods
    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }
        
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        powerUpIndicator = GetComponent<Light>();
        playerCollider.material.bounciness = 0.4f;
        powerUpIndicator.intensity = 0;
        
    }

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.Player.Movement.performed += ctx => SetMoveDirection(ctx.ReadValue<Vector2>());
        inputAction.Player.Movement.canceled += ctx => moveDirection = 0;

    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void FixedUpdate()
    {
        Move();
        if(transform.position.y < -10)
        {
            GameManager.Instance.gameOver = true;
        }

    }

    private void SetMoveDirection(Vector2 value)
    {
        moveDirection = value.y;
    }

    private void AssignLevelValues()
    {
        transform.localScale = GameManager.Instance.playerScale;
        playerRB.mass = GameManager.Instance.playerMass;
        playerRB.drag = GameManager.Instance.playerDrag;
        moveForceMagnitude = GameManager.Instance.playerMoveForce;
        focalpoint = GameObject.Find("Focal Point").transform;
    }

    private void Move()
    {
        if(focalpoint != null)
        {
            playerRB.AddForce(focalpoint.forward.normalized * moveDirection * moveForceMagnitude);
        }

        hasPowerUp = GameManager.Instance.debugPowerUpRepel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Startup"))
        {
            collision.gameObject.tag = "Ground";
            playerCollider.material.bounciness = GameManager.Instance.playerBounce;
            AssignLevelValues();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Portal"))
        {
            gameObject.layer = LayerMask.NameToLayer("Portal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            if(transform.position.y < 0)
            {
                transform.position = Vector3.up * 25;
                GameManager.Instance.switchLevels = true;
            }
        }
    }
    private IEnumerator PowerUpCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
    }
}
