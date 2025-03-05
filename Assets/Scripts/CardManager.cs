using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    public GameObject cardPrefab; // Asigna el Prefab de la carta en el Inspector
    public Transform contentTransform; // Asigna el Content del Scroll View en el Inspector
    public int numberOfCards = 10; // Número de cartas a generar

    void Start()
    {
        GenerateCards(numberOfCards);
    }

    void GenerateCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, contentTransform); // Instancia la carta
            newCard.name = "Carta " + (i + 1); // Renombra la carta
            newCard.GetComponentInChildren<Text>().text = "Carta " + (i + 1); // Cambia el texto de la carta
        }
    }
}
