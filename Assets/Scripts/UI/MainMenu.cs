using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Exposes functionality for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject runSelectPanel;   // new
    [SerializeField] private Button resumeRunButton;      // new
    [SerializeField] private bool hasSaveData;            // new: temporary flag

    public void Play()
    {
        // Show the run select panel instead of loading the scene directly
        mainMenuPanel.SetActive(false);
        runSelectPanel.SetActive(true);
        resumeRunButton.interactable = HasSaveData();
    }

    public void CloseRunSelect()
    {
        runSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartNewRun()
    {
        SceneTransition.instance.TransitionScene("Scene 1");
    }

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

    private bool HasSaveData()
    {
        return hasSaveData; // later: check the save file exists
    }

}