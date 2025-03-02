using System.Collections.Generic;
using UnityEngine;

public class Card_DataBase : MonoBehaviour
{
    public static Card_DataBase Instance;
    public List<CardData> CardList = new List<CardData>();

    private void Awake()
    {
        // Agregar algunas cartas de prueba
        CardList.Add(new CardData("Guerrero", "Carta básica de ataque", 5, 2, 3));
        CardList.Add(new CardData("Mago", "Usa magia poderosa", 7, 1, 4));
    }

    void Start()
    {
        LoadCards();
    }

    void LoadCards()
    {
        CardList.Add(new CardData("Fireball", "Lanza una bola de fuego", 5, 10, 3));
        CardList.Add(new CardData("Goblin", "Pequeño y veloz", 3, 4, 2));
        CardList.Add(new CardData("Healing Potion", "Recupera vida", 0, 0, 2));
    }

    public CardData GetCardByName(string name)
    {
        return CardList.Find(card => card.cardName == name);
    }
}




