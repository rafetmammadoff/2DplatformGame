using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
            Destroy(other.gameObject);
            // other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Obstacle") || other.CompareTag("Collectable")) {
            Destroy(other.gameObject);
            // other.gameObject.SetActive(false);
        }
    }
}
