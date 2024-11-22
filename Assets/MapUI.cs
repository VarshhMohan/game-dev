using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    public GameObject mapPanel; // Assign the UI Map Panel in the Inspector

    public void ToggleMap()
    {
        bool isActive = mapPanel.activeSelf;
        mapPanel.SetActive(!isActive); // Toggle the map panel's visibility
        Debug.Log("Map Display Toggled: " + !isActive);
    }
}
