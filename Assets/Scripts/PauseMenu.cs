using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> 
/// Allows user to pause gameplay, resume gameplay, or return to the main menu.
/// </summary>

/// <remarks>
/// Maintained by: Ayaan Hossain
/// </remarks>
public class PauseMenu : MonoBehaviour
{
    //SerializeField makes private variable visible in Unity Inspector 
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject pauseButton;

    /// <summary> 
    /// Pauses game by setting timeScale = 0, displays pause menu overlay and removes the original pause button 
    /// </summary>
    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;

    } 

    /// <summary> 
    /// Unpauses game by setting timeScale = 1, deactivates pause menu overlay and displays the original pause button 
    /// </summary>
    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    } 

    /// <summary> 
    /// Unpauses game time and transitions to Scene 1 (Main Menu)
    /// </summary>
    public void ReturnMainMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}