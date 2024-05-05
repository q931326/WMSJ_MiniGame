using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image baChange;
    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float delayBetweenFades = 1.0f;

    //使用协程（自行调用，不用时yield挂起），进行淡入淡出效果
    IEnumerator FadeInOut()
    {
        // 淡入
        float startAlpha = baChange.color.a;
        float endAlpha = 1f;
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeInDuration)
        {
            Color newColor = baChange.color;
            newColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            baChange.color = newColor;
            yield return null;
        }

        // 延迟一段时间
        yield return new WaitForSeconds(delayBetweenFades);

        // 淡出
        startAlpha = baChange.color.a;
        endAlpha = 0f;
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeOutDuration)
        {
            Color newColor = baChange.color;
            newColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            baChange.color = newColor;
            yield return null;
        }
    }

    void Start()
    {
        // 初始化Text的不透明度为0
        baChange.color = new Color(baChange.color.r, baChange.color.g, baChange.color.b, 0f);
        // 开始淡入淡出动画
        StartCoroutine(FadeInOut());
    }
}
