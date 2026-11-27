using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandAnimation : MonoBehaviour
{
    [SerializeField] Button playCardButton;
    [SerializeField] Button addCardButton;
    [SerializeField] PlayerHandView playerHandView;
    [SerializeField] GameObject testCard;
    [SerializeField] GameObject context;
    private PlayerHandCardView selectedCard;

    /// <summary>
    /// Sets up the listener to check if button is clicked 
    /// </summary>
    private void Awake()
    {
        playCardButton.onClick.AddListener(playCard);
        addCardButton.onClick.AddListener(AnimateAddCard);
    }

    /// <summary>
    /// Animation played when card is played or discarded but test uses play button, 
    /// 
    /// Calls RemoveCard after animation is complete, as leantween has setOnComplete to time removal of card
    /// </summary>
    private void AnimatePlayCard()
    {   
        if (!selectedCard.gameObject.LeanIsTweening())
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
            selectedCard.gameObject.LeanScale(new Vector3(0.1f, 0.1f, 1.0f), ANIMATION_2_DURATION)
                .setDelay(ANIMATION_1_DURATION)
                .setEaseOutQuad()
                .setOnComplete(() => playerHandView.RemoveCard(selectedCard)); 
                // Removes card after completion of animation
        }
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
    /// Called when add card is pressed for testing, 
    /// Notice this is one time animation per added card so multiple clicks from add button will not self align
    /// Moves and scale card up from left side of the player hand to centre of player hand
    /// Then sets parent to where all card prefab are held which auto alignes the new card
    /// </summary>
    private void AnimateAddCard()
    {   
        if (!testCard.LeanIsTweening())
        {
            // Default position and size, which is off screen
            testCard.gameObject.LeanMoveLocal(new Vector2(-800.0f, 182.0f), 0.0f);
            testCard.gameObject.LeanScale(new Vector3(0.1f, 0.1f, 1.0f), 0.01f);

            // Moves and scales the card to centre of player hand
            const float ANIMATION_1_DURATION = 0.5f;
            testCard.gameObject.LeanMoveLocal(new Vector2(0.0f, 182.0f), ANIMATION_1_DURATION)
                .setEaseInBack();
            testCard.gameObject.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), ANIMATION_1_DURATION)
                // To make the card self align with other cards in hand
                .setOnComplete(() => testCard.transform.SetParent(context.transform, true)); 
        }   
    }

    /// <summary>
    /// Removes listener when not used
    /// </summary>
    private void OnDestroy()
    {
        playCardButton.onClick.RemoveListener(AnimatePlayCard);
        addCardButton.onClick.RemoveListener(AnimateAddCard);
    }
}
