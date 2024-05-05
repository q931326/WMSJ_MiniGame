using UnityEngine;
//用来控制动画效果，绑定在角色身上
public class PlayerController : MonoBehaviour
{
    //如果碰到了未解锁的关卡，那么播放动画
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("SceneChangeTrigger")){
            DoAnim();
        } 
    }
    //将触发器置为false
    private void OnCollisionExit2D(Collision2D other) {
        DoExit();
    }
    //碰到未解锁关卡后，将动画的触发器设置为true，开始播放动画
    public void DoAnim() {
        this.gameObject.GetComponent<Animator>().SetBool("CrashTrigger",true);
    }
    //退出范围后，将触发器设置为false
    public void DoExit(){
        this.gameObject.GetComponent<Animator>().SetBool("CrashTrigger",false);
    }
}