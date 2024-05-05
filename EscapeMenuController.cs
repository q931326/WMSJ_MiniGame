using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EscapeMenuController : MonoBehaviour
{
    [SerializeField] private GameObject escapeMenuPanel; // 在Inspector中拖曳进来的你需要显示/隐藏的UI Panel
    [SerializeField] private GameObject GameScene;//按下Esc后，这个游戏对象将会被缩小至0.8倍
    [SerializeField] private Vector2 baseSize; // 添加一个新的变量来存储原始尺寸
    private bool isMenuVisible = false; // 用来记录菜单当前是否可见
    private void Start()
    {
        baseSize = new Vector2(1f, 1f); 
        InitializeEscapeMenu();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscapeMenu();
            ImageScale();
        }
    }
    //对画面进行缩放操作
    private void ImageScale(){
        if (GameScene != null)
        {
            float scaleFactor = !isMenuVisible ? 1.0f : 0.8f; // 根据菜单状态确定缩放因子
            Vector3 targetScale = new Vector3(baseSize.x*scaleFactor,baseSize.y*scaleFactor,1.0f);
            // 设置新的尺寸
            GameScene.transform.localScale = targetScale;
        }else{
            Debug.LogError("GameScene is null.");
        }
    }
    //设置场景是否为可见的
    private void ToggleEscapeMenu()
    {
        isMenuVisible = !isMenuVisible;
        escapeMenuPanel.SetActive(isMenuVisible); 
    }
    //在原场景的基础上加上新的场景内容。
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //在原场景的基础上切换回去，减去现在的场景
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //场景加载切换
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeEscapeMenu();
    }
    //切换场景后会发生脚本上的绑定丢失，在这里重新进行绑定
    private void InitializeEscapeMenu(){
        // Canvas位于名为"Canvas"的GameObject下，并且位于名为"SceneManagement"的GameObject下
        GameObject sceneManagementObj = GameObject.Find("SceneManagement");
        if (sceneManagementObj != null)
        {
            escapeMenuPanel = sceneManagementObj.transform.Find("Canvas").gameObject;
            GameScene = sceneManagementObj;
        }else{
            Debug.LogError("SceneManagement object not found in the scene.");
        }
    }
}