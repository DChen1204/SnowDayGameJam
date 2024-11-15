using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] private float speedX = 10f;
    [SerializeField] private float speedY = 5f;
    [SerializeField] private GameObject player;
    public int team; // Add this line

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 playerDirection, int playerTeam) {
        rb.AddForce(playerDirection * speedX, ForceMode.Impulse);
        rb.AddForce(Vector3.up * speedY, ForceMode.Impulse);
        team = playerTeam; // Set the team of the snowball
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null && playerController.team != team) {
                playerController.TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (transform.position.y < 2) {
            Destroy(gameObject);
        }
    }
}
