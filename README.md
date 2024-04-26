# WMSJ_MiniGame
总结一下做MiniGame时出现的问题，暂时不放代码，等MiniGame结束后再放置
所做的工作：主要是负责界面方面的工作
做了存档系统，关卡切换（切换关卡时保存部分游戏对象，同时判断是否重复），解锁关卡功能，进入未解锁关卡角色放大的动画，弹出菜单，进入关卡时文本的淡入淡出效果。
完美世界MiniGame总结：
遇到的问题：


问题①：使用DontDestroyOnLoad函数，原本场景中有游戏对象了，后续切换场景出现了重复的游戏对象。

问题原因：DontDestroyOnLoad之后把之前的游戏对象带到了第二个场景，切换回第一个场景的时候，原本场景有一个游戏对象，第二个场景中的又被带回来了，因此就有重复了。

解决办法：1.改成动态加载人物，加载前判断是否存在。2.提供一个初始化场景"init"，这个场景只加载一次。


问题②：跳转场景时，使用DontDestroyOnLoad保存UI，但是UI上的按钮失效

问题原因：只保留了CANVAS，未保留Eventsystem。

解决办法：1.把EventSystem也加入进DontDestroyOnLoad。2.UI单独创建一个不销毁的场景，进行叠加。


问题③：接问题①，使用DontDestroyOnLoad函数并且增添了判断重复逻辑，依然不能解决问题。

问题原因：在Unity编辑器中直接将游戏对象拖入场景Hierarchy导致的

解决办法：使用代码动态加载游戏对象

具体代码：
private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 这里的"SceneManagement"是一个目录，而Canvas和SceneManagement（目录本身）则是这个目录的子对象。
        GameObject sceneManagementObj = GameObject.Find("SceneManagement");
        if (sceneManagementObj != null)
        {
            GameObject canvasObj = sceneManagementObj.transform.Find("Canvas").gameObject;
            if (canvasObj != null)
            {
                escapeMenuPanel = canvasObj.GetComponent<GameObject>();
            }
        }
        GameObject sceneManagementObj2 = GameObject.Find("SceneManagement");
        if (sceneManagementObj2 != null)
        {
            GameObject sceneObj = sceneManagementObj.transform.Find("SceneManagement").gameObject;
            if (sceneObj != null)
            {
                GameScene = sceneObj.GetComponent<GameObject>();
            }
        }
    }

其中，OnEnable()：当一个 MonoBehaviour 组件（脚本）被激活（enabled）或其所在的 GameObject 被启用时，Unity 自动调用此方法。
发生的几种情况：
游戏对象首次被实例化。
游戏对象从禁用状态变为启用状态。
脚本组件从禁用状态变为启用状态。
OnDisable()：与 OnEnable 相反，当 MonoBehaviour 组件被禁用（disabled）或其所在的 GameObject 被禁用时，Unity 会自动调用此方法。
常见情况包括：
游戏对象被禁用。
脚本组件被禁用。
游戏对象被销毁（Destroy）前。

问题④：

设计，玩家每次按下移动按键后，会在方格内，一格一格的走，在实现Esc页面的时候，会将场景内的所有对象都缩小0.8倍，此时空气墙的厚度也缩小了，
玩家的移动距离超过了这个范围。

解决办法：1.加厚空气墙的厚度 2.缩小玩家移动的距离 3.缩小时间间隔
