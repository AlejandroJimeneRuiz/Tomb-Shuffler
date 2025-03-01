using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;  // Para usar TextMeshPro

public class CardLibraryMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject cardPrefab;  // Prefab "Carta"
    public Transform cardContainer;  // El Content dentro del ScrollView
    public ScrollRect scrollRect;

    [Header("Filtros")]
    public Button filterAll;
    public Button filterSpells;
    public Button filterMonsters;
    public Button filterEnchantments;

    private List<CardData> allCards = new List<CardData>();  // Lista de cartas

    void Start()
    {
        GameObject newCard = Instantiate(cardPrefab, cardContainer);

        // Obtener el componente DisplayCard en la nueva carta
        DisplayCard display = newCard.GetComponent<DisplayCard>();

        if (display != null)
        {
            display.SetupCard(cardData);  // Llamar a SetupCard con los datos de la carta
        }
        else
        {
            Debug.LogError("❌ ERROR: No se encontró DisplayCard en el prefab de Carta.");
        }
    }

    void LoadCards()
    {
        allCards.Add(new CardData("Bola de Fuego", "Hechizo", "Lanza una bola de fuego", 0, 5, 0, null));
        allCards.Add(new CardData("Dragón Rojo", "Monstruo", "Dragón poderoso", 8, 10, 12, null));
        allCards.Add(new CardData("Escudo Mágico", "Encantamiento", "Aumenta la defensa", 0, 4, 0, null));
    }

    void DisplayCards(string category)
    {
        Debug.Log("▶ Ejecutando DisplayCards con categoría: " + category);

        if (cardPrefab == null) { Debug.LogError("❌ ERROR: 'cardPrefab' no está asignado en el Inspector."); return; }
        if (cardContainer == null) { Debug.LogError("❌ ERROR: 'cardContainer' no está asignado en el Inspector."); return; }

        foreach (Transform child in cardContainer) Destroy(child.gameObject);

        foreach (CardData card in allCards)
        {
            if (category == "All" || card.Type == category)
            {
                GameObject newCard = Instantiate(cardPrefab, cardContainer);
                newCard.transform.localScale = Vector3.one;
                Debug.Log("✅ Instanciando carta: " + card.Name);

                // Verificar existencia de elementos
                Transform canvas = newCard.transform.Find("Canvas");
                if (canvas == null) { Debug.LogError("❌ ERROR: No se encontró 'Canvas' dentro del prefab."); return; }

                TextMeshProUGUI nameText = canvas.Find("CardName")?.GetComponent<TextMeshProUGUI>();
                if (nameText == null) Debug.LogError("❌ ERROR: 'CardName' no encontrado en el prefab.");

                TextMeshProUGUI descText = canvas.Find("CardDescription")?.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI powerText = canvas.Find("Power")?.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI costText = canvas.Find("Cost")?.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI hpText = canvas.Find("HP")?.GetComponent<TextMeshProUGUI>();
                Image artImage = canvas.Find("ArtImg")?.GetComponent<Image>();

                // Asignar valores
                if (nameText) nameText.text = card.Name;
                if (descText) descText.text = card.Description;
                if (powerText) powerText.text = "⚡ " + card.Power;
                if (costText) costText.text = "💰 " + card.Cost;
                if (hpText) hpText.text = "❤️ " + card.HP;
                if (artImage && card.Artwork != null) artImage.sprite = card.Artwork;
            }
        }
    }

    // Estructura de datos de cada carta
    [System.Serializable]
    public class Card
    {
        public string cardName;
        public string description;
        public int power;
        public int cost;
        public int hp;
        public string category;  // Esto es importante para filtrar cartas por tipo
        public Sprite art;
    }
}