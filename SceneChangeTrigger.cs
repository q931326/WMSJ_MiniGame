using UnityEngine;
using UnityEngine.SceneManagement;
//场景切换触发器，这个脚本绑定在游戏对象上
public class SceneChangeTrigger : MonoBehaviour
{
    //目标场景名字，也就是要进入的场景
    [SerializeField]private string targetSceneName;
    //前一个场景的名字，如果前一个场景未能通关，那么进入不到下一个关卡
    [SerializeField]private string prerequisiteLevelName;
    //玩家对象
    [SerializeField]private GameObject playerObject;
    private Collider2D SceneChangeObj;
    private Fade fadeComponent;
    private void Start() {
        Collider2D c2d = GetComponent<Collider2D>();
        SceneChangeObj = c2d;
        fadeComponent = FindObjectOfType<Fade>();
        if(fadeComponent == null){
            Debug.LogError("Fade component not found in the scene");
        }
    }
    //当在触发器里时
    private void OnTriggerEnter2D(Collider2D other){
        //如果是玩家碰到了这个碰撞体
        if(other.CompareTag("Player")){
            //如果这个关卡已经解锁，那么可以进入到目标关卡
            if(GameProgressManager.Instance.IsLevelUnlocked(prerequisiteLevelName)){
                SceneChangeObj.isTrigger = true;
                LoadTargetScene();
            }else{
                //如果未进入到关卡，那么场景的触发器关闭，这个时候如果尝试进入关卡会发生碰撞反弹
                SceneChangeObj.isTrigger = false;
            }
        } 
    }
    private void LoadTargetScene(){
        SceneManager.LoadScene(targetSceneName);
        playerObject.transform.position = new Vector2(-4f,3.5f);
    }
}
