using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public int nextSceneID;

    void OnTriggerStay2D(Collider2D other)
    {
        SceneManager.LoadScene(nextSceneID);
    }
}
