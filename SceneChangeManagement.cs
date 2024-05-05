using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeManagement : MonoBehaviour
{
    private static SceneChangeManagement _instance;
    public static SceneChangeManagement Instance{
        get{
            if(_instance == null){
                _instance = FindObjectOfType<SceneChangeManagement>();
                if(_instance == null){
                    var obj = new GameObject("SceneChangeManagement");
                    _instance = obj.AddComponent<SceneChangeManagement>();
                }
            }
            return _instance;
        }
    }
    public void StartGame(int SceneNumber){
        SceneManager.LoadScene(SceneNumber);
    }
    public void QuitGame(){
        //在编辑器里关闭游戏
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //在打包执行的exe文件里关闭游戏
        #else 
        Application.Quit();
        #endif
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //当玩家遇见触发器并且标签为SceneChangeTrigger的对象
        if (other.CompareTag("SceneChangeTrigger"))
        {
            //切换场景
            SwitchScene(other.name);
            //保留原有物体
            DontDestroyOnLoad(gameObject);
        }
    }
    //选择场景物体
    void SwitchScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
