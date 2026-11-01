using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private CanvasGroup canvasGroup;

    // Speed to fade to black
    public float fadeOutSpeed;
    // Speed to fade in to new scene
    public float fadeInSpeed;

    /// <summary>
    /// Transitions to the new scene
    /// </summary>
    /// <todo>
    /// Add error checking for a bad scene name
    /// </todo>
    private void LoadScene()
    {
        SceneManager.LoadScene(transitionTarget);
        // Add check here


        // Confirm that scene has finished loading
        Debug.Log("Scene Changed to " +  transitionTarget);
    }

    /// <summary>
    /// public method to be triggered by button press
    /// </summary>
    public void TransitionScene()
    {
        Debug.Log("Transition Called");

        // Transition order
        FadeOut();
        FadeIn();
    }

    /// <summary>
    /// Fades to black before transition
    /// </summary>
    private void FadeOut()
    {
        LeanTween.alphaCanvas(canvasGroup, 0, fadeOutSpeed);
    }

    /// <summary>
    /// Fades back in from black to the new scene
    /// </summary>
    private void FadeIn()
    {

    }

}
