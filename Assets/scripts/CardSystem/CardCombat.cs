using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this for TextMeshProUGUI

public class CardCombat : MonoBehaviour
{
    public UnityEngine.UI.Button[] attackButtons; // Array to hold button references
    public GameObject[] slots; // Array to hold slot references
    public UnityEngine.UI.Button[] hitButtons; // Array to hold placement button references
    public GameObject[] enemySlots; // Array to hold enemy slot references
    public GameObject enemyCemetery; // Reference to the cemetery GameObject
    public UnityEngine.UI.Button CancelAttackButton; // Button to cancel attack


    // Start is called before the first frame update
    void Start()
    {
        // Set all buttons to inactive at the start
        foreach (UnityEngine.UI.Button button in attackButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
        foreach (UnityEngine.UI.Button button in hitButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
        CancelAttackButton.gameObject.SetActive(false);
        CancelAttackButton.interactable = false; // Ensure buttons are not interactable
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttackButtonStates();
    }

    void CheckAttackButtonStates() 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount > 0 && slots[i].transform.GetChild(0).CompareTag("Placed"))
            {            
                attackButtons[i].gameObject.SetActive(true);
                attackButtons[i].interactable = true; // Enable button if there is a card in the slot
                attackButtons[i].onClick.AddListener(() => CheckHitButtonStates()); // Add listener to show hit buttons
                attackButtons[i].onClick.AddListener(() => CancelAttackButtonStates()); // Add listener to show cancel button
            }
            else
            {
                attackButtons[i].gameObject.SetActive(false);
                attackButtons[i].interactable = false; // Disable button if there is no card in the slot
            }
        }
    }

    void CheckHitButtonStates() 
    {
        for (int i = 0; i < enemySlots.Length; i++)
        {
            if (enemySlots[i].transform.childCount > 0 && enemySlots[i].transform.GetChild(0).CompareTag("Placed"))
            {
                hitButtons[i].gameObject.SetActive(true);
                hitButtons[i].interactable = true; // Enable button if there is a card in the slot
                // Find the attacking card's index
                int attackingCardIndex = -1;
                for (int j = 0; j < slots.Length; j++)
                {
                    if (slots[j].transform.childCount > 0 && slots[j].transform.GetChild(0).CompareTag("Placed"))
                    {
                        attackingCardIndex = j;
                        break;
                    }
                }
                
                if (attackingCardIndex >= 0)
                {
                    int enemyCardIndex = i; // Store the index of the enemy card
                    hitButtons[i].onClick.AddListener(() => HandleAttack(attackingCardIndex, enemyCardIndex)); // Add listener to handle attack
                }
                else
                {
                    Debug.LogWarning("No attacking card found in slots");
                }
            }
            else
            {
                hitButtons[i].gameObject.SetActive(false);
                hitButtons[i].interactable = false; // Disable button if there is no card in the slot
            }
        }
    }

    void HandleAttack(int attackingCardIndex, int enemyCardIndex)
    {
        // Add bounds checking
        if (attackingCardIndex < 0 || attackingCardIndex >= slots.Length ||
            enemyCardIndex < 0 || enemyCardIndex >= enemySlots.Length)
        {
            Debug.LogError($"Invalid indices: attackingCardIndex={attackingCardIndex}, enemyCardIndex={enemyCardIndex}");
            return;
        }

        // Check if slots have cards
        if (slots[attackingCardIndex].transform.childCount == 0 ||
            enemySlots[enemyCardIndex].transform.childCount == 0)
        {
            Debug.LogError($"No card found in slot: attackingSlot={attackingCardIndex}, enemySlot={enemyCardIndex}");
            return;
        }

        // Get card data from the card objects
        GameObject attackingCardObj = slots[attackingCardIndex].transform.GetChild(0).gameObject;
        GameObject enemyCardObj = enemySlots[enemyCardIndex].transform.GetChild(0).gameObject;

        // Access card data from DisplayCard component
        Display_Card attackingCardDisplay = attackingCardObj.transform.GetChild(0).GetComponent<Display_Card>();
        Display_Card enemyCardDisplay = enemyCardObj.transform.GetChild(0).GetComponent<Display_Card>();


        if (attackingCardDisplay != null && enemyCardDisplay != null)
        {
            int attackingPower = attackingCardDisplay.power; // Assuming power is a public field in DisplayCard
            int enemyHp = enemyCardDisplay.hp; // Assuming HP is a public field in DisplayCard

            // Calculate new HP
            int newHp = enemyHp - attackingPower;
            if (newHp <= 0)
            {
                // Move enemy card to cemetery
                MoveToCemetery(enemyCardObj);

            }
            else
            {
                // Update enemy HP display
                enemyCardDisplay.hp = newHp; // Update the HP in DisplayCard
            }
        }
        else
        {
            Debug.LogError("Failed to get DisplayCard component from one or both cards");
        }
    }

    void MoveToCemetery(GameObject card)
    {
        card.transform.SetParent(enemyCemetery.transform); // Set the parent to the cemetery
        card.transform.position = enemyCemetery.transform.position;
        card.tag = "EnemyDead"; // Change the tag to Dead
        card.transform.localScale = new Vector3(enemyCemetery.transform.localScale.x, enemyCemetery.transform.localScale.y, -0.12f); // Match the scale of the slot and set Z to -0.12
        card.transform.rotation = Quaternion.Euler(90, 180, 270); // Set the rotation to (270, 180, 270)
    }

    void CancelAttackButtonStates()

    {
        CancelAttackButton.gameObject.SetActive(true);
        CancelAttackButton.interactable = true; // Enable button to cancel attack
        CancelAttackButton.onClick.AddListener(() => ResetAttackButtonStates()); // Add listener to reset attack buttons
        CancelAttackButton.onClick.AddListener(() => ResetHitButtonStates()); // Add listener to reset hit buttons
        CancelAttackButton.onClick.AddListener(() => CancelAttackButtonReset()); // Add listener to reset cancel button
    }

    void ResetAttackButtonStates()
    {
        foreach (UnityEngine.UI.Button button in attackButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
    }

    void ResetHitButtonStates()
    {
        foreach (UnityEngine.UI.Button button in hitButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
    }

    void CancelAttackButtonReset()
    {
        CancelAttackButton.gameObject.SetActive(false);
        CancelAttackButton.interactable = false; // Ensure buttons are not interactable
    }
}
