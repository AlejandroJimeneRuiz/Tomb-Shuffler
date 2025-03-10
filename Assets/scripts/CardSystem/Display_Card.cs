using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
public class Display_Card : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public String cardDescription;
    public int hp;
    public Sprite spriteImage;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI hpText;
    public Image artImage;

    public GameObject Hand;
    public int numberOfCardsInDeck;


    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
        

        displayCard[0] = Card_DataBase.cardList[displayId];

        

    }

    // Update is called once per frame
    void Update()
    {
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        cost = displayCard[0].cost;
        power = displayCard[0].power;
        cardDescription = displayCard[0].cardDescription;
        hp = displayCard[0].cardHp;
        spriteImage = displayCard[0].spriteImage;
    
        nameText.text = " " + cardName;
        costText.text = " " + cost;
        powerText.text = " " + power;
        descriptionText.text = " " + cardDescription;
        hpText.text = " " + hp;
        artImage.sprite = spriteImage;

        Hand = GameObject.Find("Hand");
        if (this.tag == "Clone")
        {
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck -1];
            numberOfCardsInDeck-= 1;
            PlayerDeck.deckSize -= 1;
            this.tag = "Untagged";
        }
    }
}
