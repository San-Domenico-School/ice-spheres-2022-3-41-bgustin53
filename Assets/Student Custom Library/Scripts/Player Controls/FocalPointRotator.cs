using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocaPointRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private PlayerInputActions inputAction;
    private float moveDirection;

    // Start is called before the first frame update
    void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, moveDirection * rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.Player.Movement.performed += ctx => CameraRotate(ctx.ReadValue<Vector2>());
        inputAction.Player.Movement.canceled += ctx => moveDirection = 0;
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void CameraRotate(Vector2 value)
    {
        moveDirection = value.x;
    }
}
