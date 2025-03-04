using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int x;
    public static int deckSize;
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public GameObject DrawPileCard1;
    public GameObject DrawPileCard2;
    public GameObject DrawPileCard3;
    public GameObject DrawPileCard4;
    public GameObject DrawPileCard5;

    public GameObject CardToHand;
    public GameObject[] Clones;
    public GameObject Hand;


    // Start is called before the first frame update
    void Start()
    {
        
        x = 0;
        deckSize = 40;

        for(int i = 0; i < 40; i++)
        {
            x = Random.Range(1, 4);
            deck[i] = Card_DataBase.cardList[x];

        }

        StartCoroutine(StartGame());

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
        staticDeck = deck;

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

        if (TurnSystem.drawCard == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.drawCard = false;
        }

    }

    IEnumerator StartGame()
    {
        float offset = 0.5f; // Adjust this value to change the spacing between cards
        int totalCards = 5; // Total number of cards to instantiate
        Vector3 startPosition = Hand.transform.position - new Vector3((totalCards - 1) * offset / 2, 0, 0); // Centering the cards

        for (int i = 0; i < totalCards; i++)
        {
            yield return new WaitForSeconds(1);
            Vector3 cardPosition = startPosition + new Vector3(i * offset, 0, 0); // Adjust the x position
            Instantiate(CardToHand, cardPosition, Hand.transform.rotation);
        }
    }

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, Hand.transform.position, Hand.transform.rotation);
        }
    }
}
