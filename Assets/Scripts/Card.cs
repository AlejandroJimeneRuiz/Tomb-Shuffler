using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 [System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int cardHp;
    public int cost;
    public int power;
    public string cardDescription;


    public Card(int Id, string CardName, int CardHp, int Cost, int Power, string CardDescription)
    {
        id = Id;
        cardName = CardName;
        cardHp = CardHp;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;



    }

}
