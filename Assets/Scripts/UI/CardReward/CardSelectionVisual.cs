using UnityEngine;
using UnityEngine.UI;

public class CardSelectionVisual : MonoBehaviour
{
    // Must connect to the card prefab not the wrapper
    [SerializeField] Transform card;

    // How high the card moves when selected
    private float selectedYOffsett = 30.0f;
    private Toggle toggle;
    private Vector2 defaultPosition;
    private Vector2 selectedPosition;

    /// <summary>
    /// Loads up necessary variable and object before game even starts
    /// </summary>
    void Awake()
    {
        toggle = GetComponent<Toggle>();
        if (card != null)
        {
            defaultPosition = card.localPosition;
            selectedPosition = defaultPosition + new Vector2(0.0f, selectedYOffsett);
        }

        toggle.onValueChanged.AddListener(Animate);

        Animate(toggle.isOn);
    }

    /// <summary>
    /// Animates the card to bob if it is selected
    /// else returns back to default position smoothly
    /// </summary>
    /// <param name="isSelected">The state of if card is selected or not</param>
    private void Animate(bool isSelected)
    {
        if (card != null)
        {
            if (isSelected)
            {
                // Makes sure that animation is not stacking
                if (!LeanTween.isTweening(card.gameObject))
                {
                    card.LeanMoveLocal(selectedPosition, 1.0f)
                    .setEaseInOutSine()
                    .setLoopPingPong();
                }
            } else
            {
                // Cancel any tweens from any the gameObject that holds the script is teening
                LeanTween.cancel(card.gameObject);
                // Returns back to default position
                card.LeanMoveLocal(defaultPosition, 0.2f)
                    .setEaseOutQuad();
            }
        }
    }

    /// <summary>
    /// Removes listener after being destroyed
    /// </summary>
    public void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(Animate);
    }
}
