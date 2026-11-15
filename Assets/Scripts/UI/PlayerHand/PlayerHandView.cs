using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the visual state of the Player's hand UI.
/// </summary>
/// <remarks>
/// Maintained by: Miguel Jesus
/// </remarks>
public class PlayerHandView : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private PlayerHandCardView cardPrefab;
    [SerializeField] private Button playCardButton;

    private readonly List<PlayerHandCardView> cards = new();

    /// <summary>
    /// The currently selected card in the hand. `null` if no card is selected.
    /// To select a card, see `SelectCard()`
    /// </summary>
    public PlayerHandCardView SelectedCard { get; private set; }

    /// <summary>
    /// Fires whenever the currently selected card changes.
    /// </summary>
    public event Action<PlayerHandCardView> SelectedCardChanged;

    private void Awake()
    {
        // Register any initial cards
        if (content != null)
        {
            foreach (Transform child in content)
            {
                if (child.TryGetComponent(out PlayerHandCardView card))
                    Register(card);
            }
        }
        
        UpdateSelectedCardUI();
    }

    /// <summary>
    /// Adds a new placeholder card at the end of the hand.
    /// </summary>
    /// <todo>
    /// Instantiate the card prefab based on the given card data.
    /// </todo>
    public PlayerHandCardView AddCard(CardData cardData)
    {
        if (content == null || cardPrefab == null)
        {
            Debug.LogError("Assign the player hand Content and card prefab before adding cards.", this);
            return null;
        }

        PlayerHandCardView card = Instantiate(cardPrefab, content, false);
        Register(card);
        return card;
    }

    /// <summary>
    /// Removes only this instance; unknown or null cards are ignored.
    /// </summary>
    /// <returns>
    /// Whether the call to this function actually resulted in a card being removed.
    /// e.g. This could return false if the card given wasn't in the hand in the first place.
    /// </returns>
    public bool RemoveCard(PlayerHandCardView card)
    {
        if (card == null || !cards.Contains(card))
            return false;

        Unregister(card);

        Destroy(card.gameObject);
        return true;
    }

    /// <summary>
    /// Changes the currently selected card in the hand.
    /// `SelectCard(null)` to deselect the currently selected card.
    /// </summary>
    /// <param name="card">The card to select. `null` deselects the currently selected card.</param>
    public void SelectCard(PlayerHandCardView card)
    {
        if (SelectedCard == card || (card != null && !cards.Contains(card)))
            return;

        if (SelectedCard != null)
            SelectedCard.UpdateSelectionVisual(false);

        SelectedCard = card;

        if (SelectedCard != null)
            SelectedCard.UpdateSelectionVisual(true);
            
        UpdateSelectedCardUI();
        SelectedCardChanged?.Invoke(SelectedCard);
    }

    private void Register(PlayerHandCardView card)
    {
        if (cards.Contains(card))
            return;

        cards.Add(card);
        card.UpdateSelectionVisual(false);
        card.Clicked += OnCardClicked;
        card.Destroyed += OnCardDestroyed;
    }

    private void Unregister(PlayerHandCardView card)
    {
        cards.Remove(card);
        card.Clicked -= OnCardClicked;
        card.Destroyed -= OnCardDestroyed;

        if (SelectedCard == card)
            SelectCard(null);
    }

    private void OnCardClicked(PlayerHandCardView card)
    {
        if (!isActiveAndEnabled || !cards.Contains(card))
            return;

        SelectCard(SelectedCard == card ? null : card);
    }

    private void UpdateSelectedCardUI()
    {
        if (playCardButton != null)
            playCardButton.gameObject.SetActive(SelectedCard != null);
    }

    private void OnCardDestroyed(PlayerHandCardView card)
    {
        Unregister(card);
    }

    private void OnDestroy()
    {
        foreach (PlayerHandCardView card in cards)
        {
            if (card == null) continue;

            card.Clicked -= OnCardClicked;
            card.Destroyed -= OnCardDestroyed;
        }
    }
}
