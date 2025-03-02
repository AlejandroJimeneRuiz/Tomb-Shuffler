using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFilter : MonoBehaviour
{
    public List<GameObject> allCards = new List<GameObject>(); // Lista con todas las cartas
    public Transform contentTransform; // El contenedor donde están las cartas

    void Start()
    {
        // Obtiene todas las cartas ya generadas
        foreach (Transform card in contentTransform)
        {
            allCards.Add(card.gameObject);
        }
    }

    public void FilterCards(string category)
    {
        foreach (GameObject card in allCards)
        {
            CardData cardData = card.GetComponent<CardData>(); // Accede a los datos de la carta

            if (cardData != null)
            {
                // Muestra solo las cartas que coincidan con la categoría
                card.SetActive(cardData.category == category);
            }
        }
    }

    public void ShowAllCards()
    {
        foreach (GameObject card in allCards)
        {
            card.SetActive(true);
        }
    }
}

