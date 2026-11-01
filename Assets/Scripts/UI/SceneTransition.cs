using UnityEngine;

/// <summary>
/// Script to attach to a button object to transition to a new scene with fade
/// in and out 
/// </summary>
/// <remarks>
/// Maintained by: Bailey Stewart
/// </remarks>
public class SceneTransition : MonoBehaviour
{
    // String name of target scene
    [SerializeField] private string transitionTarget;

    // Speed to fade to black
    public float fadeOutSpeed;
    // Speed to fade in to new scene
    public float fadeInSpeed;

    /// <summary>
    /// Transitions to the new scene
    /// </summary>
    private void loadScene()
    {

    }

    /// <summary>
    /// public method to be triggered by button press
    /// </summary>
    public void transitionScene()
    {
        // Transition order
        fadeOut();
        loadScene();
        fadeIn();
    }

    /// <summary>
    /// Fades to black before transition
    /// </summary>
    private void fadeOut()
    {

    }

    /// <summary>
    /// Fades back in from black to the new scene
    /// </summary>
    private void fadeIn()
    {

    }

}
