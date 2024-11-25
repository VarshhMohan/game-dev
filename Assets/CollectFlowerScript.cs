using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFlowerScript : MonoBehaviour
{
    public Light highlightLight;
    public Transform flowerTransform;
    public GameObject player;
    public InventoryManager inventoryManager;
    public GameObject flower;
    public GameObject nextFlower;
    public Compass compass;
    public VideoManager videoManager;
    private bool isStoryTellingTriggered = false;
    private bool isPlayerNearby = false;
    private bool isFlowerEquipped = false;

    void Start()
    {
        if (highlightLight != null)
        {
            highlightLight.intensity = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearby = true;
            if(!isStoryTellingTriggered && videoManager != null)
            {
                isStoryTellingTriggered = true;
                videoManager.PlayVideoByTrigger(7); // play i-press intro
            }
            if (highlightLight != null)
            {
                highlightLight.intensity = 2;
            }
            if (flowerTransform!=null)
            {
                flowerTransform.position += new Vector3(0, 1.0f, 0);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearby = false;
            if (highlightLight != null)
            {
                highlightLight.intensity = 0;
            }
            if (flowerTransform!=null)
            {
                flowerTransform.position -= new Vector3(0, 1.0f, 0);
            }
        }
    }

    void Update()
    {
        if (isPlayerNearby && !isFlowerEquipped && Input.GetKeyDown(KeyCode.E))
        {
            CollectFlower();
        }
    }

    void CollectFlower()
    {
        isFlowerEquipped = true;
        Debug.Log("Flower Equipped!");
        inventoryManager.AddFlower(flower);
        compass.setFlower(nextFlower);
        Destroy(gameObject);        // remove map object from game
    }
}
