using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This class is a MonoBehaviour script to read data from a
/// CardData ScriptableObject and display it on the card
/// </summary>
/// <remarks>
/// Maintained by: Logan Lambert
/// </remarks>
public class DisplayCardData : MonoBehaviour
{

    [SerializeField] private CardData displayedData;
    private TMP_Text cardTitle;
    private TMP_Text cardDescription;
    private TMP_Text energyCost;
    private TMP_Text effectValue;
    private Image cardBackground;

    /// <summary>
    /// Gets a reference to each part of the card to change.
    /// Awake is called before any script's Start function.
    /// </summary>
    void Awake()
    {
        cardTitle = transform.Find("Wrapper/Card Title").GetComponent<TMP_Text>();
        cardDescription = transform.Find("Wrapper/Description").GetComponent<TMP_Text>();
        energyCost = transform.Find("Wrapper/Energy Cost").GetComponent<TMP_Text>();
        effectValue = transform.Find("Wrapper/Effect Value").GetComponent<TMP_Text>();
        cardBackground = transform.Find("Wrapper/CardBackground").GetComponent<Image>();
    }

    /// <summary>
    /// Runs the function to update the displayed data.
    /// </summary>
    void Start()
    {
        DisplayData();
    }

    /// <summary>
    /// Sets the displayed fields to the values configured by the CardData ScriptableObject.
    /// </summary>
    private void DisplayData()
    {
        cardTitle.text = displayedData.cardName;
        cardDescription.text = displayedData.cardDescription;
        energyCost.text = displayedData.EnergyCost.ToString();
        effectValue.text = displayedData.effectValue.ToString();
        
        SetBackgroundColour(); // Background colour is inferred from effectType
    }

    /// <summary>
    /// Chooses a colour for the background of the card based on the effectType
    /// </summary>
    private void SetBackgroundColour()
    {
        switch (displayedData.effectType)
        {
            case CardEffectType.Heal:
                cardBackground.color = Color.green;
            break;
            case CardEffectType.Attack:
                cardBackground.color = Color.red;
            break;
            case CardEffectType.Defend:
                cardBackground.color = Color.blue;
            break;
            case CardEffectType.Spirit:
                cardBackground.color = Color.yellow;
            break;
        }
    }
}
