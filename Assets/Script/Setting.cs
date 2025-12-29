using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Dropdown screenResolutionDropdown;
    public Toggle fullscreenToggle;

    public Slider volumeSlider;
    public Text volumeText;
    public Button exitButton;

    ScreenSettingData savedSsd = new ScreenSettingData();

    List<ScreenSettingData> deviceScreenSettingDataList = new List<ScreenSettingData>();
    List<string> deviceScreenSettingDataTextList = new List<string>();


    void Start()
    {
        //savessd load
        savedSsd = ScreenSettingMethod.LoadData();

        //dropdown text add
        foreach (Resolution a in Screen.resolutions)
        {
            if (deviceScreenSettingDataList.Exists(x => x.width == a.width && x.height == a.height))
            {
                continue;
            }
            deviceScreenSettingDataTextList.Add(a.width + "¡¿" + a.height);
            deviceScreenSettingDataList.Add(new ScreenSettingData(a.width, a.height));
        }
        screenResolutionDropdown.AddOptions(deviceScreenSettingDataTextList);

        //dropdown set
        ScreenSettingData currentSsd = new ScreenSettingData
        (
        Screen.width,
        Screen.height,
        Screen.fullScreenMode == FullScreenMode.FullScreenWindow,
        AudioListener.volume
        );

        for (int i = 0; i < deviceScreenSettingDataTextList.Count; i++)
        {
            if (deviceScreenSettingDataList[i].IsResolutionSame(currentSsd))
            {
                screenResolutionDropdown.value = i;
                break;
            }
        }

        //fullscreen toggle set
        fullscreenToggle.isOn = currentSsd.isFullscreen;

        //volume set
        volumeSlider.value = currentSsd.volume;
    }

    public void ResolutionChanged()
    {
        savedSsd.width = deviceScreenSettingDataList[screenResolutionDropdown.value].width;
        savedSsd.height = deviceScreenSettingDataList[screenResolutionDropdown.value].height;
        ScreenSettingMethod.SaveData(savedSsd);
        ScreenSettingMethod.ConfirmScreenData(savedSsd);
    }

    public void FullscreenChanged()
    {
        if (fullscreenToggle.isOn == true)
        {
            savedSsd.isFullscreen = true;
        }
        else if (fullscreenToggle.isOn == false)
        {
            savedSsd.isFullscreen = false;
        }
        ScreenSettingMethod.SaveData(savedSsd);
        ScreenSettingMethod.ConfirmScreenData(savedSsd);
    }
    
    public void VolumeChanged()
    {
        volumeText.text = (volumeSlider.value * 100).ToString("F0") + "%";
        savedSsd.volume = volumeSlider.value;
        ScreenSettingMethod.SaveData(savedSsd);
        ScreenSettingMethod.ConfirmVolumeData(savedSsd);
    }

    public void SettingExitClicked()
    {
        exitButton.GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }

    void Update()
    {

    }
}

public class ScreenSettingData
{
    public int width;
    public int height;
    public bool isFullscreen;
    public float volume;

    public ScreenSettingData()
    {

    }
    public ScreenSettingData(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public ScreenSettingData(int width, int height, bool isFullscreen, float volume)
    {
        this.width = width;
        this.height = height;
        this.isFullscreen = isFullscreen;
        this.volume = volume;
    }

    public bool IsResolutionSame(ScreenSettingData ssd)
    {
        if (
            ssd.width == width &&
            ssd.height == height
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsScreenSame(ScreenSettingData ssd)
    {
        if (
            ssd.width == width &&
            ssd.height == height &&
            ssd.isFullscreen == isFullscreen
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public static class ScreenSettingMethod
{
    public static ScreenSettingData LoadData()
    {
        if (PlayerPrefs.HasKey("setting_width") && PlayerPrefs.HasKey("setting_height") && PlayerPrefs.HasKey("setting_isFullscreen") && PlayerPrefs.HasKey("setting_volume"))
        {
            int width = PlayerPrefs.GetInt("setting_width");
            int height = PlayerPrefs.GetInt("setting_height");
            bool isFullscreen = bool.Parse(PlayerPrefs.GetString("setting_isFullscreen"));
            float volume = PlayerPrefs.GetFloat("setting_volume");
            return new ScreenSettingData(width, height, isFullscreen, volume);
        }
        else
        {
            return null;
        }
    }

    public static void ConfirmScreenData(ScreenSettingData ssd)
    {
        FullScreenMode fullScreenMode = FullScreenMode.Windowed;
        if (ssd.isFullscreen == true)
        {
            fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            fullScreenMode = FullScreenMode.Windowed;
        }   
        Screen.SetResolution(ssd.width, ssd.height, fullScreenMode);
    }

    public static void ConfirmVolumeData(ScreenSettingData ssd)
    {
        AudioListener.volume = ssd.volume;
    }

    public static void SaveData(ScreenSettingData ssd)
    {
        PlayerPrefs.SetInt("setting_width", ssd.width);
        PlayerPrefs.SetInt("setting_height", ssd.height);
        PlayerPrefs.SetString("setting_isFullscreen", ssd.isFullscreen.ToString());
        PlayerPrefs.SetFloat("setting_volume", ssd.volume);
        PlayerPrefs.Save();
    }
}