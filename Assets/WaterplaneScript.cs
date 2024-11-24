using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneTrigger : MonoBehaviour
{
    public List<CrocodileBehavior> crocodiles; // List of all crocodiles to notify

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Use tag to identify the player
        {
            foreach (var crocodile in crocodiles)
            {
                crocodile.PlayerEnteredWater(); // Notify each crocodile
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var crocodile in crocodiles)
            {
                crocodile.PlayerExitedWater(); // Notify each crocodile
            }
        }
    }
}
