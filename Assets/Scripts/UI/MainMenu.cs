using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Exposes functionality for the main menu buttons. (Completed by Miguel)
/// Allows user to continue an existing run or start a new run (Completed by Ayaan)
/// </summary>
/// <remarks>
/// Run/Select Panel and functions maintained by: Ayaan H
/// </remarks> 
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject runSelectPanel;   
    [SerializeField] private Button resumeRunButton;      
    [SerializeField] private bool hasSaveData; // Flag to check if there is an existing run

    public void Play()
    {
        // Show the run select panel instead of loading the scene directly
        mainMenuPanel.SetActive(false);
        runSelectPanel.SetActive(true);
        resumeRunButton.interactable = HasSaveData(); // Button is greyed out/unclickable if there is no existing run
    }

    /// <summary>
    /// Closes the run/select panel, reopens main menu panel
    /// </summary>
    public void CloseRunSelect()
    {
        runSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    /// <summary>
    /// Transitions to scene 1 (main gameplay)
    /// </summary>
    public void StartNewRun()
    {
        SceneTransition.instance.TransitionScene("Scene 1");
    }

    /// <summary>
    /// Transitions to main gameplay contuining on from previous run
    /// </summary>
    public void ResumeRun()
    {
        // For now this does the same as Start New Run
        SceneTransition.instance.TransitionScene("Scene 1");
    }

    public void Settings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();

        // Exit play mode in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Credits()
    {
        //Transitions to credit scene
        SceneTransition.instance.TransitionScene("Credits");
    }

    /// <summary>
    /// Returns a bool value (true/false) on whether there is an existing run.
    /// </summary>
    private bool HasSaveData()
    {
        return hasSaveData; // later: check the save file exists
    }

}