using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the visual state of a card in the Player's hand UI.
/// </summary>
/// <remarks>
/// Maintained by: Miguel Jesus
/// </remarks>
[RequireComponent(typeof(Button))]
public class PlayerHandCardView : MonoBehaviour
{
    private Button button;

    public event Action<PlayerHandCardView> Clicked;
    public event Action<PlayerHandCardView> Destroyed;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClicked);
    }

    /// <summary>
    /// Updates the card's visual state to be selected, or not selected.
    /// </summary>
    /// <todo>
    /// Once the card prefab is fixed for use in canvas, write this method.
    /// </todo>
    internal void UpdateSelectionVisual(bool selected) {}

    private void OnClicked() => Clicked?.Invoke(this);
    private void OnDestroy() => Destroyed?.Invoke(this);
}
