using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 [System.Serializable]

public class Card : MonoBehaviour
{
    public int id;
    public string cardName;
    public int cardHp;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite spriteImage;


    public Card(int Id, string CardName, int CardHp, int Cost, int Power, string CardDescription, Sprite SpriteImage)
    {
        id = Id;
        cardName = CardName;
        cardHp = CardHp;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;
        spriteImage = SpriteImage;


    }

}