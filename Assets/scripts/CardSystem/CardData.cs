using UnityEngine;

[System.Serializable]
public class CardData
{
    public string cardName;
    public string description;
    public int attack;
    public int defense;
    public int cost;
    public Sprite image; // Si usas imágenes en las cartas

    // Constructor que inicializa los datos
    public CardData(string cardName, string description, int attack, int defense, int cost)
    {
        this.cardName = cardName;
        this.description = description;
        this.attack = attack;
        this.defense = defense;
        this.cost = cost;
    }
}

