using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smrt : MonoBehaviour
{
    public GameObject TombStone;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Death")
        {
            Instantiate(TombStone,transform.position,Quaternion.identity);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
