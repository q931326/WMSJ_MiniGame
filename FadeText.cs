using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//对文字文本进行淡入淡出操作
public class FadeText : MonoBehaviour
{
    public Text textToFade;
    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float delayBetweenFades = 2.0f;
    //使用协程（自行调用，不用时yield挂起），进行淡入淡出效果
    IEnumerator FadeInOut()
    {
        // 淡入
        float startAlpha = textToFade.color.a;
        float endAlpha = 1f;
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeInDuration)
        {
            Color newColor = textToFade.color;
            newColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            textToFade.color = newColor;
            yield return null;
        }

        // 延迟一段时间
        yield return new WaitForSeconds(delayBetweenFades);

        // 淡出
        startAlpha = textToFade.color.a;
        endAlpha = 0f;
        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeOutDuration)
        {
            Color newColor = textToFade.color;
            newColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            textToFade.color = newColor;
            yield return null;
        }
    }

    void Start()
    {
        // 初始化Text的不透明度为0
        textToFade.color = new Color(textToFade.color.r, textToFade.color.g, textToFade.color.b, 0f);

        // 开始淡入淡出动画
        StartCoroutine(FadeInOut());
    }
}