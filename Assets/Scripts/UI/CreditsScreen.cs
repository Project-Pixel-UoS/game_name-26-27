using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Allows user to go back to Main Menu from the Credits Screen
/// </summary>

/// <remarks>
/// Maintained by: Dana Aljamal
/// </remarks>

public class CreditsScreen : MonoBehaviour
{
    /// <summary>
    /// Navigates back to the Main Menu scene
    /// </summary>
    public void BackToMainMenu()
    {
        SceneTransition.instance.TransitionScene("Main Menu");
    }
}