using UnityEngine;


/// <summary>
/// Allows user to go back to Main Menu from the Game Over Screen
/// </summary>

/// <remarks>
/// Maintained by: Dana Aljamal
/// </remarks>
public class GameOver : MonoBehaviour
{
    /// <summary>
    /// Navigates back to the Main Menu scene
    /// </summary>
    public void BackToMainMenu()
    {
        SceneTransition.instance.TransitionScene("Main Menu");
    }
}
