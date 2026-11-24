using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is a MonoBehaviour script that manages the fusion of two cards and displays the result
/// </summary>
/// <remarks>
/// Maintained by: Logan Lambert
/// </remarks>

public class FuseCardsResult : MonoBehaviour
{
    [SerializeField] private Transform[] inputCardSlots;
    [SerializeField] private Transform resultCardSlot;
    [SerializeField] private GameObject fusedCardPrefab;

    public void CheckFusion()
    {
        // Check if both input card slots are filled
        if (inputCardSlots[0].childCount > 1 && inputCardSlots[1].childCount > 1)
        {
            CardData card1 = inputCardSlots[0].GetChild(1).gameObject.GetComponent<DisplayCardData>().displayedData;
            CardData card2 = inputCardSlots[1].GetChild(1).gameObject.GetComponent<DisplayCardData>().displayedData;

            // Perform fusion logic here (this is just a placeholder)
            FuseCards(card1, card2);
        }
    }

    private void FuseCards(CardData card1, CardData card2)
    {
        // Placeholder fusion logic: create a new card with power increased by the power of the spirit card
        CardData fusedCard = ScriptableObject.CreateInstance<CardData>();
        fusedCard.cardName = card1.cardName;
        fusedCard.cardDescription = card1.cardDescription + " (Fused)";
        fusedCard.EnergyCost = card1.EnergyCost;
        fusedCard.effectType = card1.effectType;
        fusedCard.effectValue = card1.effectValue + card2.effectValue; // Increase the effect value by the spirit card's effect value

        // Display the fused card in the result slot
        DisplayFusedCard(fusedCard);
    }

    private void DisplayFusedCard(CardData fusedCard)
    {
        // Create a new card GameObject and set its data
        GameObject fusedCardGO = Instantiate(fusedCardPrefab, resultCardSlot);

        fusedCardGO.name = "ResultCard";
        // Display the correct data on the fused card
        fusedCardGO.GetComponent<DisplayCardData>().displayedData = fusedCard;

        fusedCardGO.AddComponent<Button>();
        fusedCardGO.AddComponent<Image>();
        fusedCardGO.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f); // Set the image to be transparent

        fusedCardGO.AddComponent<FuseCardsSelect>(); // Add the FuseCardsSelect script so it can be clicked and moved back to the hand

        FuseCardsSelect fuseSelect = fusedCardGO.GetComponent<FuseCardsSelect>();

        // Assign the necessary references to the FuseCardsSelect script
        fuseSelect.targetSlot = resultCardSlot.GetComponent<Image>();
        fuseSelect.cardToMove = fusedCardGO;
        fuseSelect.hand = GameObject.Find("Content");
        fuseSelect.fuseMenu = fusedCardGO.transform.parent.parent.gameObject;
        fuseSelect.fusionManager = this;

        Button button = fusedCardGO.GetComponent<Button>();
        button.onClick.AddListener(fuseSelect.CardClicked); // Add the CardClicked method to the button's onClick event

        // Remove the Canvas component to make the card clickable
        Destroy(fusedCardGO.GetComponent<Canvas>());
    }
}
