using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoWindow : MonoBehaviour
{
    public Button exitButton;
    
    void Start()
    {

    }

    public void InfoExitClicked()
    {
        exitButton.GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }
}