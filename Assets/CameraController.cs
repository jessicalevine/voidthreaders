using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float speed;

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position = transform.position + Vector3.up * speed;
        } else if (Input.GetKey(KeyCode.A)) {
            transform.position = transform.position + Vector3.left * speed;
        } else if (Input.GetKey(KeyCode.S)) {
            transform.position = transform.position + Vector3.down * speed;
        } else if (Input.GetKey(KeyCode.D)) {
            transform.position = transform.position + Vector3.right * speed;
        }
    }
}
