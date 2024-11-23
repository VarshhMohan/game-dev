using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFlowerScript : MonoBehaviour
{
    public Light highlightLight;
    public Transform flowerTransform;
    public GameObject player;
    public InventoryManager inventoryManager;
    public GameObject flower1;
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
        inventoryManager.AddFlower(flower1);
        Destroy(gameObject);        // remove map object from game
    }
}
