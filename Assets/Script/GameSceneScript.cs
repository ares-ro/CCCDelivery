using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    public Transform mainCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerStat.Instance.TrainHP == 0)
        {
            SceneFadeManagement.FadeOut(mainCanvas, "");
        }
    }
}
