using UnityEngine;
using UnityEngine.UI;

public class PlayerHandAnimation : MonoBehaviour
{
    [SerializeField] Button playCardButton;
    [SerializeField] PlayerHandView playerHandView;
    private PlayerHandCardView selectedCard;

    /// <summary>
    /// Sets up the listener to check if player button is clicked 
    /// </summary>
    private void Awake()
    {
        playCardButton.onClick.AddListener(playCard);
    }

    /// <summary>
    /// Animation played when card is played
    /// Calls RemoveCard after animation is complete, as leantween has setOnComplete to time removal of card
    /// </summary>
    private void AnimatePlayCard()
    {   
        // Moves and scales up the cards at the same time to the middle  
        const float ANIMATION_1_DURATION = 0.25f;
        
        selectedCard.gameObject.LeanMoveLocal(new Vector2(0.0f, -200.0f), ANIMATION_1_DURATION)
            .setEaseInBack();
        selectedCard.gameObject.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), ANIMATION_1_DURATION)
            .setEaseInQuad();
        
        // Moves, shrinks and spins card to a position
        const float ANIMATION_2_DURATION = 1.0f;
        // Moves card to left side of player hand
        selectedCard.gameObject.LeanMoveLocal(new Vector2(-420.0f, -600.0f), ANIMATION_2_DURATION)
            .setEaseInBack().setDelay(ANIMATION_1_DURATION);
        // Spins the card
        selectedCard.gameObject.LeanRotateZ(360.0f * 3, 1.0f)
            .setEaseInOutBack()
            .setDelay(ANIMATION_1_DURATION);
        // Shrinks the card
        selectedCard.gameObject.LeanScale(new Vector3(0.1f, 0.1f, 0.0f), ANIMATION_2_DURATION)
            .setDelay(ANIMATION_1_DURATION)
            .setEaseOutQuad()
            .setOnComplete(() => playerHandView.RemoveCard(selectedCard)); 
            // Removes card after completion of animation
    }

    /// <summary>
    /// When play button is clicked this method is called
    /// Gets the selected card and animates the card, with removal
    /// </summary>
    private void playCard()
    {
        selectedCard = playerHandView.SelectedCard;

        if (selectedCard != null)
        {
            selectedCard.transform.SetParent(playerHandView.transform.parent, true);
            AnimatePlayCard();
        }
    }

    /// <summary>
    /// Removes listener when not used
    /// </summary>
    private void OnDestroy()
    {
        playCardButton.onClick.RemoveListener(AnimatePlayCard);
    }
}
