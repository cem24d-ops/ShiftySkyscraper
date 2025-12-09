using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider VolumeSlider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("soundVolume"))
        {
            LoadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 0.8f);
            LoadVolume();
        }
    }

    // Update is called once per frame
    public void SetVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", VolumeSlider.value);
    }

    public void LoadVolume()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
}
