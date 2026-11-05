using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// Settings Panel Script to adjust volumes.
/// </summary>
/// <remarks>
/// Maintained by: Alvin Michael Bijo
/// </remarks>
public class SettingsScript : MonoBehaviour
{
    // Instances of respective sliders
    public Slider musicSlider;
    public Slider sFXSlider;
    public Slider masterSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the volumes according to Player Prefs on start
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        sFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Method to allow user to change the Master volume
    /// </summary>
    /// <param name="volume">The volume set by user</param>
    public void SetMasterSlider(float volume)
    {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
        AudioListener.volume = volume;
    }

    /// <summary>
    /// Method to allow user to change the SFX volume
    /// </summary>
    /// <param name="volume">The volume set by user</param>
    public void SetSFXSlider(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
        // TODO: Connect SFX 
        AudioListener.volume = volume;
    }

    /// <summary>
    /// Method to allow user to change the Music volume
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicSlider(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
        // TODO: Connect Music
        AudioListener.volume = volume;
    }

    /// <summary>
    /// Method to close the settings panel
    /// </summary>
    public void CloseSettings()
    {
        gameObject.SetActive(false);
    }

}
