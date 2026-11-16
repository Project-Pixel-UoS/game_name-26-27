using UnityEngine;

public class BobAndSpin : MonoBehaviour
{
    [SerializeField] GameObject objectToAnimate;
    private Vector2 originalPosition;

    void Start()
    {   
        RectTransform rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        Animate();
    }
    /// <summary>
    /// Animates the object to bob up and down and spins around y axis at the same time
    /// Only needs to be called one time
    /// </summary>
    private void Animate()
    {
        Vector2 offset = new Vector2(0.0f, 15.0f);
        Vector2 newPosition = originalPosition + offset;

        const float DURATION = 1.0f;
        objectToAnimate.LeanMoveLocal(newPosition, DURATION)
            .setEaseInOutSine()
            .setLoopPingPong();
        
        Vector3 rotationDestination = new Vector3(0.0f, 180.0f, 0.0f);    
        objectToAnimate.LeanRotate(rotationDestination, DURATION)
            .setLoopClamp()
            .setLoopPingPong();
    }
}
