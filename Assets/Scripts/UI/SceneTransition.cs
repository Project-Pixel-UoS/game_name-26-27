using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private UnityEvent onFadeComplete;

    // Speed to fade to black
    public float fadeOutSpeed; // Seconds
    // Speed to fade in to new scene 
    public float fadeInSpeed; // Seconds

    public static SceneTransition instance;
    // Track while fading is taking place
    private static bool fading = false; 

    /// <summary>
    /// Ensures the transition for the ScreenTransition object to
    /// the new scene to fade back in properly
    /// </summary>
    private void Awake()
    {
        // Kill other instances of scene transition
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        // Trigger fade back in
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Begin fade in on new scene load
    /// </summary>
    /// <param name="scene"></param> not used
    /// <param name="mode"></param> not used
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Prevents function being called on initial scene load
        if (fading)
        {
            FadeIn();
        }
    }

    /// <summary>
    /// Accessor method for fading variable
    /// </summary>
    /// <returns>
    /// The state of fading attribute
    /// </returns>
    public bool IsFading() { return fading; }

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
        canvasGroup.blocksRaycasts = true;
        fading = true;

        LeanTween.alphaCanvas(canvasGroup, 1, fadeOutSpeed).setOnComplete(LoadScene);

        Debug.Log("Fade Completed");
    }

    /// <summary>
    /// Fades back in from black to the new scene and invokes 
    /// on fade complete function
    /// </summary>
    private void FadeIn()
    {
        LeanTween.alphaCanvas(canvasGroup, 0, fadeInSpeed).setOnComplete(onFadeComplete.Invoke);

        fading = false;
        canvasGroup.blocksRaycasts = false;
    }

}
