using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {

    private Rigidbody _rb;
    [SerializeField] private float speedX = 10f;
    [SerializeField] private float speedY = 5f;
    [SerializeField] private GameObject player;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();

        // Find the player
        player = GameObject.FindGameObjectWithTag("Player 1");
        
        // Get the player direction
        Vector3 direction = player.transform.forward;
        direction.y = 0;

        // Add force to the snowball
        _rb.AddForce(direction * speedX, ForceMode.Impulse);
        _rb.AddForce(Vector3.up * speedY, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (transform.position.y < 2) {
            Destroy(gameObject);
        }
    }

}
