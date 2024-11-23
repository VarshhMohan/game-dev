using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Light highlightLight;
    public GameObject player;
    public GameObject mapIcon;
    public GameObject mapPanel;
    private bool isPlayerNearby = false;
    private bool isMapEquipped = false;

    void Start()
    {
        mapIcon.SetActive(false);
        mapPanel.SetActive(false);
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
        }
    }

    void Update()
    {
        if (isPlayerNearby && !isMapEquipped && Input.GetKeyDown(KeyCode.E))
        {
            EquipMap();
        }
    }

    void EquipMap()
    {
        isMapEquipped = true;
        mapIcon.SetActive(true);  // Show the map icon on the UI
        Debug.Log("Map Equipped!");
        Destroy(gameObject);        // remove map object from game
    }
}