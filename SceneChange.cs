using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChange : MonoBehaviour
{
    //按下按钮后进行不同的操作，通过调用场景管理器里的函数来执行
    public void OnButtonClickStart(int SeqNumber){
        SceneChangeManagement.Instance.StartGame(SeqNumber);
    }
    public void OnButtonClickQuit(){
        SceneChangeManagement.Instance.QuitGame();
    }
    public void OnChangeScene2D(Collider2D collider){
        SceneChangeManagement.Instance.OnTriggerEnter2D(collider);
    }
}
