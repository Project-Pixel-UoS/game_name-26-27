using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject hpBar;
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private float SHAKE_MAGNITUDE = 10.0f;

    /// <summary>
    /// Stores the orignal position of healthBar
    /// </summary>
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    /// <summary>
    /// Animates whenever possible
    /// </summary>
    void Update()
    {
        Animate();
    }

    /// <summary>
    /// Makes the healthBar jitter randomly
    /// </summary>
    public void Animate()
    {
        if (!hpBar.LeanIsTweening())
        {
            Vector2 offsett = UnityEngine.Random.insideUnitCircle * SHAKE_MAGNITUDE;
            Vector2 newPosition = originalPosition + offsett;
            hpBar.LeanMoveLocal(newPosition, 0.05f)
                .setOnComplete(() => rectTransform.anchoredPosition = originalPosition);
        }
    }
}
