using UnityEngine;

/// <summary>
/// Exposes functionality for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneTransition playSceneTransition;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    public void Play()
    {
        playSceneTransition.TransitionScene();
    }

    public void Settings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();

        // Exit play mode in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
