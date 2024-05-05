using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//用来管理不用销毁的内容游戏对象
public class PersistentObjectsManager : MonoBehaviour
{
    public static PersistentObjectsManager Instance { get; private set; }

    [SerializeField] private GameObject[] _persistentObjectPrefabs; // 在Inspector中拖曳进来的需要跨场景生存的预制体

    private readonly Dictionary<string, GameObject> _persistentObjects = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        InitializePersistentObjects();
    }

    private void InitializePersistentObjects()
    {
        foreach (var prefab in _persistentObjectPrefabs)
        {
            var instance = Instantiate(prefab);
            string key = instance.name + "_" + instance.GetInstanceID();
            _persistentObjects[key] = instance;
            DontDestroyOnLoad(instance);
        }
    }
}