using UnityEngine;

/// <summary>
/// Controls opening and closing of the tutorial panel.
/// </summary>
/// <remarks>
/// Maintained by: Logan Lambert
/// </remarks>
public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialOverlay;

    /// <summary>
    /// Run by the tutorial button's onClick() function,
    /// shows the tutorial panel and close button.
    /// </summary>
    public void OpenTutorial()
    {
        tutorialOverlay.SetActive(true);
    }

    /// <summary>
    /// Run by the close button's OnClick() function,
    /// hides the tutorial panel and close button.
    /// </summary>
    public void CloseTutorial()
    {
        tutorialOverlay.SetActive(false);
    }

}
