using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tombstone : MonoBehaviour
{
    string currentScene;

    void Start()
    {   
        DontDestroyOnLoad(gameObject);
        currentScene = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name != currentScene)
        {
            Destroy(gameObject);
        }
    }


}
