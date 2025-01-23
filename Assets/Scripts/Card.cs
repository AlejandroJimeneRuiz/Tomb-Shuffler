using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 [System.Serializable]

public class Card
{
    public int id;
    public TextMeshProUGUI cardName;
    public int cardHp;
    public int cost;
    public int power;
    public TextMeshProUGUI cardDescription;


    public Card(int Id, TextMeshProUGUI CardName, int CardHp, int Cost, int Power, TextMeshProUGUI CardDescription)
    {
        id = Id;
        cardName = CardName;
        cardHp = CardHp;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;



    }

    public Card(int v1, string v2, int v3, int v4, int v5, string v6)
    {
    }
}
