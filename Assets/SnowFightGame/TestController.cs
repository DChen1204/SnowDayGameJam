using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestController : MonoBehaviour
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
    public Transform firepoint;
    public GameObject snowballPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        Debug.Log(moveInputValue);
    }

    private void OnLook(InputValue value)
    {
        lookInputValue = value.Get<Vector2>();
        Debug.Log(lookInputValue);
    }

    private void OnButtonA()
    {
        // Shoot Snowball
        Instantiate(snowballPrefab, firepoint.position, transform.rotation);
        Debug.Log("Button A Pressed");
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

    private void Update()
    {
        CameraRotation();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
