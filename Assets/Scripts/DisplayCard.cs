using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardDescriptionText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI hpText;
    public Image artImage;

    public void SetCardData(CardData data)
    {
        cardNameText.text = data.cardName;
        cardDescriptionText.text = "Descripción de la carta"; // Puedes añadir más datos
        powerText.text = data.attack.ToString();
        costText.text = "Coste"; // Agrega el dato correcto
        hpText.text = data.defense.ToString();
        // Si tienes una imagen en CardData, la puedes asignar aquí.
    }
}
