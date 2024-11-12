using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {

  private Rigidbody _rb;
  [SerializeField] private float speedX = 10f;
  [SerializeField] private float speedY = 5f;

  private void Awake() {
      _rb = GetComponent<Rigidbody>();
      _rb.velocity = new Vector3(speedX, speedY, 0);
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
