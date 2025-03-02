using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<CardData> playerDeck = new List<CardData>();  // Mazo del jugador

    void Start()
    {
        LoadPlayerDeck(); // Cargar mazo al iniciar
    }

    void LoadPlayerDeck()
    {
        Card_DataBase cardDatabase = FindObjectOfType<Card_DataBase>(); // Buscar el objeto en la escena

        if (cardDatabase != null)
        {
            // Añadir algunas cartas al mazo del jugador
            playerDeck.Add(cardDatabase.GetCardByName("Fireball"));
            playerDeck.Add(cardDatabase.GetCardByName("Goblin"));
            playerDeck.Add(cardDatabase.GetCardByName("Knight"));

            Debug.Log("Mazo del jugador cargado con " + playerDeck.Count + " cartas.");
        }
        else
        {
            Debug.LogError("No se encontró el Card_DataBase en la escena.");
        }
    }

    public void AddCardToDeck(string cardName)
    {
        Card_DataBase cardDatabase = FindObjectOfType<Card_DataBase>();

        if (cardDatabase != null)
        {
            CardData newCard = cardDatabase.GetCardByName(cardName);

            if (newCard != null)
            {
                playerDeck.Add(newCard);
                Debug.Log("Se agregó la carta: " + cardName);
            }
            else
            {
                Debug.LogError("No se encontró la carta: " + cardName);
            }
        }
    }

    public void ShowDeck()
    {
        Debug.Log("Mazo del jugador:");
        foreach (CardData card in playerDeck)
        {
            Debug.Log("- " + card.cardName);
        }
    }
}

