using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Dropdown screenResolution;
    public Toggle fullscreen;

    public Slider volumeSlider;
    public Text volumeText;

    public SettingData settingData = new SettingData();

    void Awake()
    {
        VolumeChanged();
        FullscreenChanged();
        VolumeChanged();

        List<string> buffer = new List<string>();
        foreach (Resolution a in Screen.resolutions)
        {
            buffer.Add(a.width + "¡¿" + a.height + " " + a.refreshRateRatio + "Hz");
        }
        screenResolution.AddOptions(buffer);

        Debug.Log(Screen.currentResolution);
    }

    public void ResolutionChanged()
    {
        settingData.resolutionData = Screen.currentResolution;
        Screen.SetResolution(settingData.resolutionData.width, settingData.resolutionData.height, settingData.fullscreenMode, settingData.resolutionData.refreshRateRatio);
        Debug.Log(Screen.currentResolution);

    }

    public void FullscreenChanged()
    {
        if (fullscreen.enabled == true)
        {
            settingData.fullscreenMode = FullScreenMode.FullScreenWindow;
        }
        else if (fullscreen.enabled == false)
        {
            settingData.fullscreenMode = FullScreenMode.Windowed;
        }
        Screen.SetResolution(settingData.resolutionData.width, settingData.resolutionData.height, settingData.fullscreenMode, settingData.resolutionData.refreshRateRatio);
        Debug.Log(Screen.currentResolution);
    }

    public void VolumeChanged()
    {
        volumeText.text = (volumeSlider.value * 100).ToString("F0") + "%";
        //change volume
    }

    public void SettingExitClicked()
    {
        Destroy(gameObject);
    }

    public void DataSave()
    {

    }

    public void DataLoad()
    {

    }

    public class SettingData
    {
        public Resolution resolutionData;
        public FullScreenMode fullscreenMode;
        public float volume;
    }
}
