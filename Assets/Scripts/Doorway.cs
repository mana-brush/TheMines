using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    
    [SerializeField]
    private string sceneName;
    private GameManager _gameManager;

    private void Awake()
    {
        GameObject foundObject = GameObject.FindGameObjectWithTag("GameController");
        if (foundObject)
        {
            _gameManager = foundObject.GetComponent<GameManager>();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero")
        {
            String currentScene = SceneManager.GetActiveScene().name;

            if (!_gameManager.LastScenePositionDictionary.TryAdd(currentScene, other.gameObject.transform.position)) // if we could not add it
            {
                _gameManager.LastScenePositionDictionary[currentScene] = other.gameObject.transform.position; // replace it
            }

            if (_gameManager.LastScenePositionDictionary.TryGetValue(sceneName, out var value))
            {
                other.gameObject.transform.position = value;
            }
            SceneManager.LoadScene(sceneName);
        }
    }
}
