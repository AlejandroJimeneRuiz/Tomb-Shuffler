using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    // Referencias a los elementos del prefab "Carta"
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardDescriptionText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI hpText;
    public Image artImage;

    // Estructura de datos para la carta
    [System.Serializable]
    public class Card
    {
        public string cardName;
        public string description;
        public int power;
        public int cost;
        public int hp;
        public Sprite art;
    }

    private Card currentCard;

    // Método para inicializar la carta con datos
    public void SetupCard(Card cardData)
    {
        if (cardData == null)
        {
            Debug.LogError("❌ ERROR: Datos de la carta nulos en DisplayCard.");
            return;
        }

        currentCard = cardData;

        // Asignar valores a la UI
        if (cardNameText) cardNameText.text = cardData.cardName;
        if (cardDescriptionText) cardDescriptionText.text = cardData.description;
        if (powerText) powerText.text = cardData.power.ToString();
        if (costText) costText.text = cardData.cost.ToString();
        if (hpText) hpText.text = cardData.hp.ToString();
        if (artImage) artImage.sprite = cardData.art;

        Debug.Log("✅ Carta mostrada: " + cardData.cardName);
    }
}