using UnityEngine;

public static class SceneFadeManagement
{
    public static void FadeIn(Transform parent)
    {
        GameObject prefab = Resources.Load<GameObject>("FadePrefab");
        GameObject panel = Object.Instantiate(prefab, parent);

        panel.GetComponent<FadePrefabScript>().FadeIn();
    }

    public static void FadeOut(Transform parent, string sceneName)
    {
        GameObject prefab = Resources.Load<GameObject>("FadePrefab");
        GameObject panel = Object.Instantiate(prefab, parent);

        panel.GetComponent<FadePrefabScript>().FadeOut(sceneName);
    }
}
