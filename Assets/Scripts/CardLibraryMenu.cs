using System.Collections.Generic;
using UnityEngine;

public class CardLibraryMenu : MonoBehaviour
{
    public Transform content; // <-- Asegúrate de declarar content
    public GameObject cardPrefab; // <-- Asegúrate de declarar cardPrefab
    private List<CardData> displayedCards = new List<CardData>();

    private void Start()
    {
        if (Card_DataBase.Instance != null)
        {
            displayedCards = new List<CardData>(Card_DataBase.Instance.CardList); // Usar Instance
        }
        else
        {
            Debug.LogError("❌ No se encontró la base de datos de cartas.");
        }
    }

    void LoadCards()
    {
        // Limpiamos contenido anterior
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Obtener la lista de cartas del Card_DataBase
        if (Card_DataBase.Instance == null)
        {
            Debug.LogError("❌ Card_DataBase no encontrado en la escena.");
            return;
        }

        List<CardData> allCards = Card_DataBase.Instance.CardList; // Ahora sí debería funcionar

        // Instanciar cada carta dentro del Scroll View
        foreach (CardData card in allCards)
        {
            GameObject newCard = Instantiate(cardPrefab, content);
            DisplayCard display = newCard.GetComponent<DisplayCard>();

            if (display != null)
            {
                display.SetCardData(card); // Llamamos a un método para actualizar la UI
            }
        }
    }
}


