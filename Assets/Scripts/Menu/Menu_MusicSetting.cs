using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_MusicSetting : MonoBehaviour
{
    public GameObject onButton,offButton;
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Music")!= gameObject) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        int isOff = PlayerPrefs.GetInt("MusicSetting");
        if(isOff == 0)
        {
            onButton.SetActive(false);
        }
        else
        {
            offButton.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void turnOn()
    {
        PlayerPrefs.SetInt("MusicSetting",0);
    }
    public void turnOff()
    {
        PlayerPrefs.SetInt("MusicSetting",1);
    }
}
