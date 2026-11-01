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
    private void LoadScene()
    {
        SceneManager.LoadScene(transitionTarget);

        Debug.Log("Scene Changed to " + transitionTarget);
    }

    /// <summary>
    /// public method to be triggered by button press that triggers fade if target
    /// scene is present.
    /// </summary>
    public void TransitionScene()
    {
        Debug.Log("Transition Called");

        // Check scene is in build profiles
        if (SceneUtility.GetBuildIndexByScenePath(transitionTarget) == -1)
        {
            Debug.LogWarning("There is no Scene with the name " + transitionTarget + " in the build profile");
            // Do not fade out if there is no scene
            return; 
        }

        FadeOut();
    }

    /// <summary>
    /// Fades to black before transition
    /// </summary>
    private void FadeOut()
    {
        LeanTween.alphaCanvas(canvasGroup, 1, fadeOutSpeed).setOnComplete(LoadScene);

        Debug.Log("Fade Completed");
    }

    /// <summary>
    /// Fades back in from black to the new scene
    /// </summary>
    private void FadeIn()
    {
        LeanTween.alphaCanvas(canvasGroup, 0, fadeInSpeed);
    }

}
