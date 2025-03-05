using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TurnSystem : MonoBehaviour {
    public int currentRound = 1;
    public int maxMana = 1;
    public int currentMana = 0;
    public bool isPlayerTurn = true;

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI manaText;
    public Button endTurnButton;

    public static bool drawCard; 

    void Start()
    {
        //endTurnButton.onClick.AddListener(EndTurn);
        StartRound();

        drawCard = false;
    }

    void StartRound() {
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
        
        // Enable card playing logic here
        // For example, you can enable UI elements for card selection
    }

    void EnemyTurn() {
        Debug.Log("Enemy's turn.");
        // Implement enemy logic here (e.g., play a card, attack, etc.)
        // For simplicity, we'll just end the enemy turn immediately
        EndTurn();
    }

    void UpdateUI() {
        roundText.text = "Round: " + currentRound;
        manaText.text = "Mana: " + currentMana;
    }

    public void PlayCard(Card card) {
        if (card.cost <= currentMana) {
            currentMana -= card.cost;
            Debug.Log("Played card: " + card.cardName);
            // Add logic to apply card effects here
        } else {
            Debug.Log("Not enough mana to play this card!");
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
}