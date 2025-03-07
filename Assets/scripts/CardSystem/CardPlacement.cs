using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlacement : MonoBehaviour 
{
    private TurnSystem turnSystem; // Reference to the TurnSystem
    public GameObject cardPrefab; // Reference to the card prefab
    public GameObject canvas; // Reference to the Canvas with buttons
    public Button[] placementButtons; // Array of buttons for placement
    private GameObject selectedCard; // Currently selected card clone
    public GameObject[] slots; // Array to hold references to the slot GameObjects

    void Start()
    {
        turnSystem = FindObjectOfType<TurnSystem>(); // Initialize TurnSystem reference
        // Hide the canvas at the start
        canvas.SetActive(false);

        // Add listeners to buttons
        foreach (Button button in placementButtons)
        {
            button.onClick.AddListener(() => PlaceCard(button));
        }

        // Update button states at the start
        UpdateButtonStates();
    }

    void Update()
    {
        // Detect clicks on card clones
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Clone")) // Check if the clicked object is a card clone
                {
                    selectedCard = hit.collider.gameObject; // Store the selected card
                    canvas.SetActive(true); // Show the canvas with buttons
                }
            }
        }

        UpdateButtonStates(); //Checks card slots for cards and updates button states
    }

    void PlaceCard(Button button)
    {
        int index = System.Array.IndexOf(placementButtons, button); // Get the index of the button pressed
        Display_Card displayCard = selectedCard.GetComponentInChildren<Display_Card>(); // Get the Display_Card component from the child


        if (displayCard == null) // Check if the Display_Card component is null
        {
            Debug.LogError("Display_Card component is missing on the selected card!");
            return; // Exit the method if the Display_Card is null
        }

        Card card = displayCard.displayCard[0]; // Access the Card object from the Display_Card
        int cardCost = card.cost; // Access the cost from the Card object


        if (turnSystem.PlayCard(card)) { // Check if the card can be played

            selectedCard.transform.SetParent(slots[index].transform);
            selectedCard.transform.position = slots[index].transform.position; // Move the card to the slot's position
            selectedCard.tag = "Placed"; // Change the tag to "Placed"
            selectedCard.transform.localScale = new Vector3(slots[index].transform.localScale.x, slots[index].transform.localScale.y, -0.12f); // Match the scale of the slot and set Z to -0.12
            selectedCard.transform.rotation = Quaternion.Euler(270, 180, 270); // Set the rotation to (270, 180, 270)
        } else {
            Debug.Log("Not enough mana to place this card!"); // Log message if not enough mana
        }

        canvas.SetActive(false);
    }

    void UpdateButtonStates()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // Check if the slot has a card with the tag "Placed"
            if (slots[i].transform.childCount > 0 && slots[i].transform.GetChild(0).CompareTag("Placed"))
            {
                placementButtons[i].interactable = false; // Deactivate the button
            }
            else
            {
                placementButtons[i].interactable = true; // Activate the button
            }
        }
    }
}
