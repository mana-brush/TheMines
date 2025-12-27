using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public readonly Dictionary<String, Vector3> LastScenePositionDictionary = new ();
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LastScenePositionDictionary.Add("StartingScene", new Vector3(0, 1.48f, 0));
        LastScenePositionDictionary.Add("TunnelScene", new Vector3(0, 0.14f, 7.99f));
        LastScenePositionDictionary.Add("BossScene", new Vector3(0, 0, 0));

    }


    public bool HasScene(String sceneName)
    {
        return LastScenePositionDictionary.ContainsKey(sceneName);
    }

    public string CurrentScene { get; set; }
}
