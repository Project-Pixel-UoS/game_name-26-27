using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class ButtonSwoosh : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject objectToAnimate;
    private bool isHovering = false;

    /// <summary>
    /// Moves Button to centre of canvas
    /// </summary>
    void Start()
    {
        objectToAnimate.LeanMoveLocal(new Vector2(0.0f, 0.0f), 0.5f).setEase(LeanTweenType.easeOutElastic);
    }

    /// <summary>
    /// Animate only when button is hovered on
    /// </summary>
    void Update()
    {
        if (isHovering)
        {
            Animate();
        }
    }

    /// <summary>
    /// Records as varible for when mouse is hovering button
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    /// <summary>
    /// Records as varible for when mouse is not hovering button
    /// Reverts the button back to default scale
    /// </summary>
    public void OnPointerExit (PointerEventData eventData)
    {
        isHovering = false;
        objectToAnimate.LeanScale(new Vector3 (1.0f, 1.0f, 1.0f), 0.2f);
    }

    /// <summary>
    /// Makes buttons grow and shrink in size
    /// </summary>
    private void Animate()
    {
        if (!objectToAnimate.LeanIsTweening())
        {
            objectToAnimate.LeanScale(new Vector3 (1.1f, 1.1f, 1.0f), 1.0f);
            objectToAnimate.LeanScale(new Vector3 (1.0f, 1.0f, 1.0f), 1.0f).setDelay(1.0f);
        }
    }
}

