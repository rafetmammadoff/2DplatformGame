using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToJump : MonoBehaviour
{
    private PlayerController playerController;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Jump() {
        playerController.PlayerJump();
    }
}
