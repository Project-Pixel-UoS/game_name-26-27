using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is a MonoBehaviour script that allows the player to select cards to fuse and move them back to their hand.
/// </summary>
/// <remarks>
/// Maintained by: Logan Lambert
/// </remarks>

public class FuseCardsSelect : MonoBehaviour
{

    public Image targetSlot; // Slot to move the card to
    public GameObject cardToMove;
    public GameObject hand; // Where to move the card back to
    public GameObject fuseMenu; // For checking if the fuse menu is active before allowing card movement
    public FuseCardsResult fusionManager; // Deals with the fusion logic and result display


    /// <summary>
    /// This method is called when the card is clicked. It checks if the fuse menu is
    /// active and moves the card to the target slot or back to the hand accordingly.
    /// </summary>
    public void CardClicked()
    {
        if (!fuseMenu.activeSelf)
            return;

        if (cardToMove.transform.parent == hand.transform)
        {
            MoveSlottedCardToHand(); // If there is a card already in the slot
            MoveCardToSlot();
            fusionManager.CheckFusion();
        }
        else if (cardToMove.transform.parent == targetSlot.transform)
        {
            MoveCardBackToHand(cardToMove);
        }
    }

    /// <summary>
    /// Moves the card to the target slot and adjusts its RectTransform properties.
    /// </summary>
    private void MoveCardToSlot()
    {
        cardToMove.transform.SetParent(targetSlot.transform);

        RectTransform cardRectTransform = cardToMove.GetComponent<RectTransform>();
        cardRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        cardRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        cardRectTransform.pivot = new Vector2(0.5f, 0.5f);

        cardRectTransform.anchoredPosition = Vector2.zero;
        cardRectTransform.localScale = Vector3.one;
    }

    /// <summary>
    /// Moves the card back to the player's hand and adjusts its RectTransform properties.
    /// </summary>
    /// <param name="slottedCard">The card to move back to the hand.</param>
    private void MoveCardBackToHand(GameObject slottedCard)
    {
        slottedCard.transform.SetParent(hand.transform);

        RectTransform cardRectTransform = slottedCard.GetComponent<RectTransform>();
        cardRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        cardRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        cardRectTransform.pivot = new Vector2(0.5f, 0.5f);

        cardRectTransform.anchoredPosition = Vector2.zero;
        cardRectTransform.localScale = Vector3.one;
    }

    /// <summary>
    /// Checks if there is a card already in the target slot and moves it back to the
    /// hand if there is one. This ensures that only one card can be in the slot at a time.
    /// </summary>
    private void MoveSlottedCardToHand()
    {
        foreach (Transform child in targetSlot.transform)
        {
            if (child.CompareTag("Card"))
            {
                MoveCardBackToHand(child.gameObject);
                return; // Assuming only one card can be slotted at a time
            }
        }
    }
}
