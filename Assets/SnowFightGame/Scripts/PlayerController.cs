using System.Collections;
using System.Collections.Generic;
using Game.MinigameFramework.Scripts.Framework.Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Pawn
{
    // Player Movement
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private Rigidbody rb;
    private Vector2 moveInputValue;

    // Camera Rotation
    [SerializeField] private float sensitivityX = 1f;
    [SerializeField] private float sensitivityY = 1f;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private Vector2 lookInputValue;

    // Shooting Snowball
    public Transform firePoint;
    public GameObject snowballPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void OnActionPressed(InputAction.CallbackContext context)
    {
        // Player Movement
        if (context.action.name == "Move")
        {
            moveInputValue = context.ReadValue<Vector2>();
            Debug.Log(moveInputValue);
        }

        // Camera Rotation
        if (context.action.name == "Look")
        {
            lookInputValue = context.ReadValue<Vector2>();
            CameraRotation();
        }

        // Shooting Snowball
        if(context.action.name == "ButtonR")
        {
            LaunchSnowball();
            Debug.Log("Button R Pressed");
        }
    }

    private void CameraRotation()
    {
        rotationX += lookInputValue.x * sensitivityX;
        rotationY += lookInputValue.y * sensitivityY;

        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0f);
    }

    private void Move()
    {
        Vector3 movement = new Vector3(moveInputValue.x, 0, moveInputValue.y);
        rb.velocity = movement * moveSpeed;
    }

    private void LaunchSnowball()
    {
        GameObject snowball = Instantiate(snowballPrefab, firePoint.position, firePoint.rotation);
        snowball.GetComponent<Snowball>().Shoot(transform.forward);
    }

    private void Update()
    {
        CameraRotation();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
