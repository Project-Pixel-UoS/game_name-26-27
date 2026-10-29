using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] public GameObject PauseButton;

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;

    } 

    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    } 

    public void ReturnMainMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
