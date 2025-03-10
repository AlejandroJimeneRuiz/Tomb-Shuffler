using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TurnSystem : MonoBehaviour 
{
    public int currentRound = 1;
    public int maxMana = 1;
    public int currentMana = 0;
    public bool isPlayerTurn = true;

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI manaText;
    public Button endTurnButton;

    public static bool drawCard;
    public int maxEnemyMana = 1; // Maximum mana for the enemy
    public int currentEnemyMana = 0; // Current mana for the enemy

    public GameObject[] enemySlots;
    public GameObject enemyHand;
    public static bool enemyFirstRound;

    void Start()
    {
        maxEnemyMana = 0;
        StartRound();
        enemyFirstRound = true;
        drawCard = false;
    }

    void StartRound() 
    {   
        Debug.Log("Round " + currentRound + " begins!");
        maxMana = currentRound; // Increase max mana by 1 each round
        currentMana = maxMana; // Reset current mana to max mana
        UpdateUI();
        
        if (isPlayerTurn) {
            PlayerTurn();
        } else {
            EnemyTurn();
        }
    }

    void PlayerTurn() {
        Debug.Log("Player's turn. Current Mana: " + currentMana);
    }

void EnemyTurn() 
{
    Debug.Log("Enemy's turn.");
    maxEnemyMana += 1; // Increase enemy's max mana by 1 each round
    currentEnemyMana = maxEnemyMana; // Reset enemy's current mana to max at the start of the round
    
    GameObject playerHand = GameObject.Find("Hand"); // Assuming the player's hand is named "Hand"
    if (enemyFirstRound) 
    {
        foreach (Transform card in playerHand.transform) {
            GameObject cardClone = Instantiate(card.gameObject, enemyHand.transform);
            cardClone.transform.position = enemyHand.transform.position; // Maintain the position of the card
            cardClone.tag = "EnemyCard"; // Change the tag to "EnemyCard"
        }
        enemyFirstRound = false;
    }
    if (!enemyFirstRound)
    {
        int randomIndex = Random.Range(0, playerHand.transform.childCount);
        GameObject cardClone = Instantiate(playerHand.transform.GetChild(randomIndex).gameObject, enemyHand.transform);
        cardClone.transform.position = enemyHand.transform.position; // Align position
    }

    // Check the cards in the enemy's hand and play them based on current mana
    foreach (Transform card in enemyHand.transform) 
    {
        Display_Card displayCard = card.GetComponent<Display_Card>();
        if (displayCard != null) 
        {
            bool slotAvailable = false;
            foreach (GameObject slot in enemySlots) 
            {
                if (slot.transform.childCount == 0) 
                { // Check if the slot is free
                    slotAvailable = true;
                    break;
                }
            }
            if (slotAvailable) {
                // Play the card
                EnemyPlayCard();
            } else {
                // Execute enemy attack function
                EnemyAttack(); // Call the function to handle enemy attack
            }
                
            EndTurn();
            }
        }
    }


    public void UpdateUI() 
    {
        roundText.text = "Round: " + currentRound;
        manaText.text = "Mana: " + currentMana;
    }

    public bool PlayCard(Card card) 
    {
        if (card.cost <= currentMana) {
            currentMana -= card.cost;
            Debug.Log("Played card: " + card.cardName);
            UpdateUI(); // Update the UI after playing the card

            return true; // Card played successfully
        } else {
            Debug.Log("Not enough mana to play this card!");
            return false; // Not enough mana
        }
    }

    public void EndTurn() {
        if (isPlayerTurn) {
            Debug.Log("Ending player's turn...");
        } else {
            Debug.Log("Ending enemy's turn...");
            drawCard = true;
        }
        isPlayerTurn = !isPlayerTurn; // Switch turns
        currentRound += isPlayerTurn ? 0 : 1; // Increment round only if it's the player's turn
        StartRound(); // Start the next round
    }


    void EnemyPlayCard() 
    {
        // Select a card from the enemy's hand that meets the criteria
        foreach (Transform card in enemyHand.transform) 
        {
            Display_Card displayCard = card.GetComponent<Display_Card>();
            if (displayCard != null && displayCard.cost <= currentEnemyMana && card.CompareTag("EnemyCard")) 
            {
                // Check for free slots
                foreach (GameObject slot in enemySlots) 
                {
                    if (slot.transform.childCount == 0) // Check if the slot is free
                    {
                        // Place the card in the free slot and log the action
                        Debug.Log("Placing card: " + displayCard.cardName + " in slot.");
                        card.transform.SetParent(slot.transform); // Move the card to the slot

                        card.transform.position = slot.transform.position; // Align position
                        Debug.Log("Enemy played card: " + displayCard.cardName);
                        return; // Exit after playing one card
                    }
                }
                // If no slots are free, log the action and execute enemy attack
                Debug.Log("No free slots available for card: " + displayCard.cardName);
                EnemyAttack();
                return; // Exit if no card was played
            }
        }
    }    
    
    void EnemyAttack() 
    {
        // Implement enemy attack logic here
    }
}
