using UnityEngine;

/// <summary>
/// Make an object wobble slowly
/// </summary>
public class UIWobble : MonoBehaviour
{
    [SerializeField] GameObject objectToAnimate;
    private float TIME = 0.5f;
    private float WOBBLE_ANGLE = 15.0f;

    void Update()
    {
        Animate();
    }

    /// <summary>
    /// Animates the object to wobble
    /// </summary>
     private void Animate()
    {
        if (!objectToAnimate.LeanIsTweening())
        {
            objectToAnimate.LeanRotateZ(WOBBLE_ANGLE, TIME);
            objectToAnimate.LeanRotateZ(-WOBBLE_ANGLE, TIME * 2).setDelay(TIME);
            objectToAnimate.LeanRotateZ(0.0f, TIME).setDelay(TIME * 3);
        }
    }
}
