using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sFXSlider;
    public Slider masterSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMasterSlider(float volume)
    {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
        AudioListener.volume = volume;
    }

    public void SetSFXSlider(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
        // TODO: Connect SFX 
        AudioListener.volume = volume;
    }

    public void SetMusicSlider(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
        // TODO: Connect Music
        AudioListener.volume = volume;
    }

    public void CloseSettings()
    {
        gameObject.SetActive(false);
    }

}
