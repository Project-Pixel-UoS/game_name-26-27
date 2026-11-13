using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents the UI in the game
/// </summary>
/// <remarks>
/// Maintained by: Alvin Michael Bijo
/// </remarks>
public class HUDScript : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    public Image healthBar;
    private int energy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Method to pause the game when clicking the pause button
    /// </summary>
    public void PauseButtonClicked()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Method to fuse two cards when the button is clicked
    /// </summary>
    public void FuseButtonClicked()
    {
        Debug.Log("Fuse button working");
    }
}
