using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Click and selection feedback for one card instance.</summary>
[RequireComponent(typeof(Button), typeof(Image))]
public class HandCardView : MonoBehaviour
{
    [SerializeField] private Color selectedColour = new Color(1f, 0.85f, 0.25f, 1f);
    private Button button;
    private Image image;
    private Color originalColour;

    public event Action<HandCardView> Clicked;
    public event Action<HandCardView> Destroyed;

    private void Awake() => Initialize();

    private void Initialize()
    {
        if (image != null)
            return;
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        originalColour = image.color;
        // Persistent selection is independent of focus and hover transitions.
        button.transition = Selectable.Transition.None;
    }

    private void OnEnable()
    {
        Initialize();
        button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClicked);
    }

    public void SetSelected(bool selected)
    {
        Initialize();
        image.color = selected ? selectedColour : originalColour;
    }

    private void OnClicked() => Clicked?.Invoke(this);
    private void OnDestroy() => Destroyed?.Invoke(this);
}
