using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moucha : MonoBehaviour
{
    public AudioSource FlyEatSound;
    bool isCatched = false;
    Transform point;
    void Update()
    {
        if(isCatched)
        {
            if(!GraplingHook.isGraplingUsed) Eat();
        }
    }
    public void Catch(Transform graplingPoint)
    {
        point = graplingPoint;
        isCatched = true;
    }
    
    public void Eat()
    {
        FlyEatSound.gameObject.SetActive(true);
        FlyEatSound.transform.SetParent(null);

        float soundTime = FlyEatSound.clip.length;
        Destroy(FlyEatSound.gameObject,soundTime);
    
        Destroy(gameObject);
    }

}
