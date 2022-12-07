using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private float offsetX = -6f;
    private Vector3 tempPos;

    void Start()
    {
        playerPos = GameObject.FindObjectOfType<PlayerController>().transform;
    }

    private void Update() {
        FollowPlayer();
    }

    void FollowPlayer() {
        if (!playerPos) {
            return;
        }

        tempPos = transform.position;
        tempPos.x = playerPos.position.x - offsetX;
        transform.position = tempPos;
    }
}
