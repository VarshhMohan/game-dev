using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player;           // The player's transform
    public Transform targetFlower;     // The target flower's transform
    public RectTransform compassNeedle; // The UI element representing the compass needle

    void Update()
    {
        if (player != null && targetFlower != null)
        {
            // Calculate direction to the flower
            Vector3 directionToFlower = targetFlower.position - player.position;

            // Calculate angle between player's forward direction and the direction to the flower
            float angle = Vector3.SignedAngle(player.forward, directionToFlower, Vector3.up);

            // Rotate the compass needle
            compassNeedle.localEulerAngles = new Vector3(0, 0, -angle);
        }
    }
}
