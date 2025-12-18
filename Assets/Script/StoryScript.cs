using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public Button nextScriptButton;
    public Button skipButton;

    public GameObject characterGO;

    public Sprite character1Sprite;

    public GameObject storyScriptArea;
    public Text storyScriptCharacterName;
    public Text storyScriptCharacterScript;

    List<StoryScriptData> storyScriptDataList = new List<StoryScriptData>()
    {
        new StoryScriptData("識持", "照括"),
        new StoryScriptData("識持", "更背?"),
        new StoryScriptData("識持", "更背?"),
        new StoryScriptData("識持", "更背?"),
        new StoryScriptData("識持", "更背?"),
        new StoryScriptData("識持", "更背?"),
    };

    int currentStoryScriptIndex = 0;

    void Start()
    {
        StoryScriptRun();
    }

    void Update()
    {
        
    }

    public void NextScriptButtonClicked()
    {
        currentStoryScriptIndex += 1;
        StoryScriptRun();
    }

    void StoryScriptRun()
    {
        storyScriptCharacterName.text = storyScriptDataList[currentStoryScriptIndex].characterName;
        storyScriptCharacterScript.text = storyScriptDataList[currentStoryScriptIndex].characterScript;
        MotionPreset.Move(characterGO, new Vector2(-3000, 0), new Vector2(1000, 0));

    }

    public class StoryScriptData
    {
        public string characterName;
        public string characterScript;

        public StoryScriptData(string characterName, string characterScript)
        {
            this.characterName = characterName;
            this.characterScript = characterScript;
        }
    }

    public static class MotionPreset
    {
        public static void UpDownBounce(GameObject gameObject)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.DOKill();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(rectTransform.DOAnchorPos(new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 50), 0.2f).SetEase(Ease.InOutSine));
            sequence.Append(rectTransform.DOAnchorPos(new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y), 0.2f).SetEase(Ease.InOutSine));
        }

        public static void DownUpBounce(GameObject gameObject)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.DOKill();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(rectTransform.DOAnchorPos(new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 50), 0.2f).SetEase(Ease.InOutSine));
            sequence.Append(rectTransform.DOAnchorPos(new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y), 0.2f).SetEase(Ease.InOutSine));
        }

        public static void Move(GameObject gameObject, Vector2 start, Vector2 end)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.DOKill();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(rectTransform.DOAnchorPos(end, 1f).From(start).SetEase(Ease.InOutSine));
        }
    }
}
