using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<GameObject> gameObjectToStayAlive;

    private Dictionary<string,GameObject>_persistentObjectsDict = new Dictionary<string, GameObject>();
    private void Start() {
        if(gameObjectToStayAlive != null)
            {
                foreach(GameObject go in gameObjectToStayAlive)
                    {
                        string key = go.name+"_"+go.GetInstanceID();
                        if(!_persistentObjectsDict.ContainsKey(key)){
                            DontDestroyOnLoad(go);
                            _persistentObjectsDict[key] = go;                            
                        }
                        else {
                            Debug.LogWarning($"Found duplicate persistent object with key '{key}'.Destorying the duplicate");
                            Destroy(go);
                        }
                    }
            }        
    }

}
