using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int x;
    public int deckSize;
    public List<Card> container = new List<Card>();

    public GameObject DrawPileCard1;
    public GameObject DrawPileCard2;
    public GameObject DrawPileCard3;
    public GameObject DrawPileCard4;
    public GameObject DrawPileCard5;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;

        for(int i = 0; i < 40; i++)
        {
            x = Random.Range(1, 4);
            deck[i] = Card_DataBase.cardList[x];

        }


    }


        public void Shuffle()
        {
            for(int i = 0; i < deckSize; i++)
            {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
            Debug.Log("Deck Shuffled");

            }


        }

    // Update is called once per frame
    void Update()
    {
        if(deckSize < 40)
        {
            DrawPileCard1.SetActive(false);
        }
        if(deckSize < 30)
        {
            DrawPileCard2.SetActive(false);
        }
        if(deckSize < 20)
        {
            DrawPileCard3.SetActive(false);
        }
        if(deckSize < 10)
        {
            DrawPileCard4.SetActive(false);
        }
        if(deckSize < 1)
        {
            DrawPileCard5.SetActive(false);
        }
    }
}
