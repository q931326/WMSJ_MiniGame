using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//用来管理游戏关卡是否已经解锁
public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance {get;private set;}
    //记录已经解锁的关卡
    [SerializeField]private List<string>unlockedLevels = new List<string>();

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }else if(Instance != this){
            Destroy(gameObject);
        }
    }
    //添加方法来记录玩家完成关卡
    public void UnlockLevel(string levelName){
        if(!unlockedLevels.Contains(levelName)){
            unlockedLevels.Add(levelName);
        }
    }
    //指定关卡是否已经解锁
    public bool IsLevelUnlocked(string levelName){
        return unlockedLevels.Contains(levelName);
    }
}
