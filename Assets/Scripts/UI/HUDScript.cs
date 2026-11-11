using System;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pause the game by setting the time scale to 0 and deactivate the UI panel
    public void PauseButtonClicked()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
}
