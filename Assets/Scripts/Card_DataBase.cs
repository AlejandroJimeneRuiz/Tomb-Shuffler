using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Card_DataBase : MonoBehaviour
{

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, 0, "None", Resources.Load<Sprite>("Placeholder")));
        cardList.Add(new Card(1, "Test", 1, 1, 1, "This is a test card.", Resources.Load<Sprite>("Placeholder")));
        cardList.Add(new Card(2, "Human", 1, 1, 1, "This is a Human.", Resources.Load<Sprite>("Placeholder")));
        cardList.Add(new Card(3, "Elf", 1, 1, 1, "This is a Elf.", Resources.Load<Sprite>("Placeholder")));
        cardList.Add(new Card(4, "Dwarf", 2, 2, 1, "This is a Dwarf.", Resources.Load<Sprite>("Placeholder")));
        cardList.Add(new Card(5, "Troll", 3, 3, 3, "This is a Troll.", Resources.Load<Sprite>("Placeholder")));

    }
}
