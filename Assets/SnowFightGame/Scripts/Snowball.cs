using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {

  private Rigidbody _rb;

  private void Awake() {
    _rb = GetComponent<Rigidbody>();
    _rb.velocity = new Vector3(5,5,0);
  }

  

}
