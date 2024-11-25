using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI; // Assign the inventory panel here
    public GameObject inventoryButton; // UI button for inventory open
    public Transform flowersContent; // Scroll View Content for Flowers
    public Transform potionsContent; // Scroll View Content for Potions
    public Transform gearContent; // Scroll View Content for Potions
    public GameObject itemPrefab; // UI prefab for displaying items

    public GameObject flowersScrollView;
    public GameObject potionsScrollView;
    public GameObject gearsScrollView;
    public VideoManager videoManager;

    private List<GameObject> flowers = new List<GameObject>();
    private List<GameObject> potions = new List<GameObject>();
    private List<GameObject> gears = new List<GameObject>();
    private bool isStoryTriggered = false;


    void Start()
    {
        inventoryUI.SetActive(false); // Hide inventory at start
        inventoryButton.SetActive(true);
    }

    void Update()
    {
        if(flowers.Count == 5 && !isStoryTriggered){
            isStoryTriggered = true;
            videoManager.PlayVideoByTrigger(9);
        }
        if (Input.GetKeyDown(KeyCode.I)) // Press 'I' to toggle inventory
        {
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf); // Open/Close inventory
        inventoryButton.SetActive(!inventoryButton.activeSelf); //close/open inventory
    }

    public void AddFlower(GameObject flowerPrefab)
    {
        flowers.Add(flowerPrefab);
        UpdateFlowersUI();
    }

    public void AddPotion(GameObject potionPrefab)
    {
        potions.Add(potionPrefab);
        UpdatePotionsUI();
    }

    void UpdateFlowersUI()
    {
        foreach (Transform child in flowersContent)
        {
            Destroy(child.gameObject); // Clear existing UI
        }

        foreach (GameObject flower in flowers)
        {
            GameObject item = Instantiate(itemPrefab, flowersContent);
            item.GetComponentInChildren<TextMeshProUGUI>().text = flower.GetComponentInChildren<TextMeshProUGUI>().text; // Display prefab name
            item.GetComponentInChildren<Image>().sprite = flower.GetComponentInChildren<Image>().sprite; // Use the sprite, if available
        }
    }

    void UpdatePotionsUI()
    {
        foreach (Transform child in potionsContent)
        {
            Destroy(child.gameObject); // Clear existing UI
        }

        foreach (GameObject potion in potions)
        {
            GameObject item = Instantiate(itemPrefab, potionsContent);
            item.GetComponentInChildren<Text>().text = potion.name; // Display prefab name
            item.GetComponentInChildren<Image>().sprite = potion.GetComponent<SpriteRenderer>()?.sprite; // Use the sprite, if available
        }
    }

    public void ShowFlowers()
    {
        flowersScrollView.SetActive(true);
        potionsScrollView.SetActive(false);
        gearsScrollView.SetActive(false);
    }

    public void ShowPotions()
    {
        flowersScrollView.SetActive(false);
        potionsScrollView.SetActive(true);
        gearsScrollView.SetActive(false);
    }

    public void ShowGears()
    {
        flowersScrollView.SetActive(false);
        potionsScrollView.SetActive(false);
        gearsScrollView.SetActive(true);
    }

    public bool collectedFlowers(){
        return flowers.Count == 5;
    }
}


