using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//切换场景时，在一定的时间间隔内将画面淡入淡出
public class ChangeScene : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Image transitionImage;
    [SerializeField]float fadeTime = 3.5f;
    Color color;
    string GAMEPLAY = "Gameplay";
    void Load(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator LoadCoroutine(string sceneName){
        //load new scene in background and
        var loadingOperator = SceneManager.LoadSceneAsync(sceneName);
        //Set this scene inactive
        loadingOperator.allowSceneActivation = false;

        transitionImage.gameObject.SetActive(true);
        //Fade out
        while(color.a< 1f){
            color.a = Mathf.Clamp01(color.a+Time.unscaledDeltaTime/fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        //Load new scene
        Load(sceneName);
        //Fade in
        while(color.a > 0f){
            color.a = Mathf.Clamp01(color.a-Time.unscaledDeltaTime/fadeTime);
            transitionImage.color = color;
            yield return null;
        }
        transitionImage.gameObject.SetActive(false);
    }
    public void LoadGameplayScene(){
        StartCoroutine(LoadCoroutine(GAMEPLAY));
    }
}
