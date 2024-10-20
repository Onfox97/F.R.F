using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_LevelSelect : MonoBehaviour
{
    public int levelID;

    public void loadLevel()
    {
        SceneManager.LoadScene(levelID);
    }
}
