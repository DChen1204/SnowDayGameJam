using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] private float speedX = 10f;
    [SerializeField] private float speedY = 5f;
    [SerializeField] private GameObject player;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 playerDirection) {
        rb.AddForce(playerDirection * speedX, ForceMode.Impulse);
        rb.AddForce(Vector3.up * speedY, ForceMode.Impulse);
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
