using UnityEngine;
using UnityEngine.UI;

public class FuseCardsSelect : MonoBehaviour
{

    [SerializeField] private Image targetSlot;
    [SerializeField] private GameObject cardToMove;

    public void MoveToSlot()
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
