using UnityEngine;
using UnityEngine.UI;

public class FuseCardsSelect : MonoBehaviour
{

    public Image targetSlot;
    public GameObject cardToMove;
    public GameObject hand;
    public GameObject fuseMenu;
    public FuseCardsResult fusionManager;

    public void CardClicked()
    {
        if (!fuseMenu.activeSelf)
            return;

        if (cardToMove.transform.parent == hand.transform)
        {
            MoveSlottedCardToHand();
            MoveCardToSlot();
            fusionManager.CheckFusion();
        }
        else if (cardToMove.transform.parent == targetSlot.transform)
        {
            MoveCardBackToHand(cardToMove);
        }
    }

    private void MoveCardToSlot()
    {
        Debug.Log("Card moved");
        cardToMove.transform.SetParent(targetSlot.transform);

        RectTransform cardRectTransform = cardToMove.GetComponent<RectTransform>();
        cardRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        cardRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        cardRectTransform.pivot = new Vector2(0.5f, 0.5f);

        cardRectTransform.anchoredPosition = Vector2.zero;
        cardRectTransform.localScale = Vector3.one;

        Debug.Log("Card moved to slot: " + targetSlot.name);
    }

    private void MoveCardBackToHand(GameObject slottedCard)
    {
        Debug.Log("Card moved back to hand");
        slottedCard.transform.SetParent(hand.transform);

        RectTransform cardRectTransform = slottedCard.GetComponent<RectTransform>();
        cardRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        cardRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        cardRectTransform.pivot = new Vector2(0.5f, 0.5f);

        cardRectTransform.anchoredPosition = Vector2.zero;
        cardRectTransform.localScale = Vector3.one;

        Debug.Log("Card moved back to hand: " + hand.name);
    }

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
