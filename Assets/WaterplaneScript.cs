using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneTrigger : MonoBehaviour
{
    public List<CrocodileBehavior> crocodiles; // List of all crocodiles to notify
    private bool isStoryTriggered = false;
    public  VideoManager videoManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Use tag to identify the player
        {
            if(!isStoryTriggered)
            {
                isStoryTriggered = true;
                videoManager.PlayVideoByTrigger(8); // play enemy npc intro
            }
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
