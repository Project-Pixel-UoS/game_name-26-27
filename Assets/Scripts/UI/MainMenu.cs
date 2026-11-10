using UnityEngine;

/// <summary>
/// Exposes functionality for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    public void Play()
    {
        SceneTransition.instance.TransitionScene("Scene 1");
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

    public void Credits()
    {
        //Transitions to credit scene
        SceneTransition.instance.TransitionScene("Credits");
    }
}
