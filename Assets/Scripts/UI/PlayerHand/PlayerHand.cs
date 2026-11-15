using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private HandCardView cardPrefab;
    [SerializeField] private Button playCardButton;

    private readonly List<HandCardView> cards = new List<HandCardView>();
    private bool layoutDirty;
    private bool clampScroll;

    public HandCardView SelectedCard { get; private set; }
    public event Action<HandCardView> SelectionChanged;

    private void Awake()
    {
        if (content != null)
        {
            foreach (Transform child in content)
            {
                if (child.TryGetComponent(out HandCardView card))
                    Register(card);
            }
        }
        UpdateSelectionUI();
    }

    /// <summary>Adds a new placeholder card at the end of the hand.</summary>
    public HandCardView AddCard()
    {
        if (content == null || cardPrefab == null)
        {
            Debug.LogError("Assign the hand Content and card prefab before adding cards.", this);
            return null;
        }
        HandCardView card = Instantiate(cardPrefab, content, false);
        Register(card);
        layoutDirty = true;
        return card;
    }

    /// <summary>Removes only this instance; unknown or null cards are ignored.</summary>
    public bool RemoveCard(HandCardView card)
    {
        if (card == null || !cards.Contains(card))
            return false;

        Unregister(card);
        // Destroy is deferred, so remove the object from layout immediately.
        card.gameObject.SetActive(false);
        card.transform.SetParent(null, false);
        Destroy(card.gameObject);
        return true;
    }

    private void Register(HandCardView card)
    {
        if (cards.Contains(card))
            return;

        cards.Add(card);
        card.SetSelected(false);
        card.Clicked += SelectCard;
        card.Destroyed += OnCardDestroyed;
    }

    private void Unregister(HandCardView card)
    {
        cards.Remove(card);
        card.Clicked -= SelectCard;
        card.Destroyed -= OnCardDestroyed;
        if (SelectedCard == card)
        {
            card.SetSelected(false);
            SelectedCard = null;
            UpdateSelectionUI();
            SelectionChanged?.Invoke(null);
        }
        layoutDirty = true;
        clampScroll = true;
    }

    private void SelectCard(HandCardView card)
    {
        if (!isActiveAndEnabled || !cards.Contains(card))
            return;

        bool deselect = SelectedCard == card;
        if (SelectedCard != null)
            SelectedCard.SetSelected(false);
        SelectedCard = deselect ? null : card;
        if (SelectedCard != null)
            SelectedCard.SetSelected(true);
        UpdateSelectionUI();
        SelectionChanged?.Invoke(SelectedCard);
    }

    private void UpdateSelectionUI()
    {
        playCardButton?.gameObject.SetActive(SelectedCard != null);
        // Play Card intentionally has no action until gameplay is implemented.
    }

    private void OnCardDestroyed(HandCardView card)
    {
        Unregister(card);
    }

    private void LateUpdate()
    {
        if (!layoutDirty || content == null)
            return;

        layoutDirty = false;
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        Canvas.ForceUpdateCanvases();
        if (clampScroll && scrollRect != null)
        {
            scrollRect.StopMovement();
            RectTransform viewport = scrollRect.viewport ?? (RectTransform)scrollRect.transform;
            scrollRect.horizontalNormalizedPosition = content.rect.width <= viewport.rect.width
                ? 0f : Mathf.Clamp01(scrollRect.horizontalNormalizedPosition);
        }
        clampScroll = false;
    }

    private void OnDestroy()
    {
        foreach (HandCardView card in cards)
        {
            if (card == null)
                continue;
            card.Clicked -= SelectCard;
            card.Destroyed -= OnCardDestroyed;
        }
    }
}
