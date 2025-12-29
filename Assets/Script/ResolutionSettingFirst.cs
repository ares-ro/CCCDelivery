using System.Collections.Generic;
using UnityEngine;

public class ResolutionSettingFirst : MonoBehaviour
{
    void Start()
    {
        //device ssd load
        List<ScreenSettingData> deviceScreenSettingDataList = new List<ScreenSettingData>();
        foreach (Resolution a in Screen.resolutions)
        {
            deviceScreenSettingDataList.Add(new ScreenSettingData(a.width, a.height));
        }

        //currend ssd load
        ScreenSettingData currentSsd = new ScreenSettingData
        (
        Screen.width,
        Screen.height,
        Screen.fullScreenMode == FullScreenMode.FullScreenWindow,
        AudioListener.volume
        );

        //savedssd load
        ScreenSettingData savedSsd = ScreenSettingMethod.LoadData();

        if (savedSsd != null && currentSsd.IsScreenSame(savedSsd))
        {
            AudioListener.volume = savedSsd.volume;
            return;
        }
        else
        {
            ScreenSettingData ssdBuffer = deviceScreenSettingDataList[deviceScreenSettingDataList.Count - 1];
            ssdBuffer.isFullscreen = true;
            ssdBuffer.volume = 1.0f;
            ScreenSettingMethod.SaveData(ssdBuffer);
            Screen.SetResolution(ssdBuffer.width, ssdBuffer.height, FullScreenMode.FullScreenWindow);
        }
    }
}