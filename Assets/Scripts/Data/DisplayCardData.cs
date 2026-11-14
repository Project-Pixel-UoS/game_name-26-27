using UnityEngine;
using TMPro;

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
    private SpriteRenderer backgroundColour;

    void Awake()
    {
        cardTitle = transform.Find("Wrapper/Card Title").GetComponent<TMP_Text>();
        cardDescription = transform.Find("Wrapper/Description").GetComponent<TMP_Text>();
        energyCost = transform.Find("Wrapper/Energy Cost").GetComponent<TMP_Text>();
        backgroundColour = transform.Find("Wrapper/CardBackground").GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayData();
    }

    private void DisplayData()
    {
        cardTitle.text = displayedData.cardName;
        cardDescription.text = displayedData.cardDescription;
        energyCost.text = displayedData.EnergyCost.ToString();
        
        SetBackgroundColour();
    }

    private void SetBackgroundColour()
    {
        switch (displayedData.effectType)
        {
            case CardEffectType.Heal:
            {   
                backgroundColour.color = Color.green;
                break;
            }
            case CardEffectType.Attack:
            {
                backgroundColour.color = Color.red;
                break;
            }
            case CardEffectType.Defend:
            {
                backgroundColour.color = Color.blue;
                break;
            }
            case CardEffectType.Spirit:
            {
                backgroundColour.color = Color.yellow;
                break;
            }
        }
    }
}
