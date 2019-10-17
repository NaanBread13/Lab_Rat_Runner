using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionInt = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionInt = i;
            }
        }
        resolutionDropdown.AddOptions(options);
    }
    public void setVolume(float v)
    {
        Debug.Log(v);
        audioMixer.SetFloat("volume", v);

    }

    public void setResolution(int resolutionInt)
    {
        Resolution resolution = resolutions[resolutionInt];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void setQulity(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void setFullscreen(bool a)
    {
        Screen.fullScreen = a;
    }
}
