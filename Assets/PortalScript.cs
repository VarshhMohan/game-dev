using UnityEngine;

public class Portal : MonoBehaviour
{
    public InventoryManager inventoryManager;  // Reference to the InventoryManager
    public VideoManager videoManager;
    public GameUIManager gameUIManager;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the portal's collider
        if (other.CompareTag("Player"))
        {
            // Check if all required flowers are collected
            if (inventoryManager.collectedFlowers())
            {
                EndGame();
            }
            else
            {
                Debug.Log("Not all flowers collected!");
                // You can show a message to the player here (e.g., "Collect all flowers to finish the game.")
            }
        }
    }

    private void EndGame()
    {
        videoManager.PlayVideoByTrigger(10);
        gameUIManager.ShowVictoryScreen();
    }
}
