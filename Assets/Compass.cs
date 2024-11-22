using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public RectTransform compass;  // Reference to the compass image RectTransform

    public float initialAngle = 0f;  // Set the initial angle for the compass

    void Start()
    {
        // Set the initial angle of the compass (before any player movement)
        compass.rotation = Quaternion.Euler(0, 0, initialAngle);
    }

    void Update()
    {
        // Get the player's Y rotation (yaw)
        float playerRotationY = player.eulerAngles.y;

        // Adjust the compass rotation based on the player's rotation, and add the initial angle
        compass.rotation = Quaternion.Euler(0, 0, -(playerRotationY + initialAngle));
    }
}

