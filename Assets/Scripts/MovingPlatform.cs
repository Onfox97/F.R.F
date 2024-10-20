using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] Points;
    public float movingSpeed;

    int currentPoint;
    void Update()
    {
        if(Vector3.Distance(transform.position,Points[currentPoint].position) < 0.1f)
        {
            if(currentPoint >= Points.Length-1) currentPoint = 0;
            else currentPoint ++;
        }
        else
        {
            Vector3 newPoos = Vector3.MoveTowards(transform.position,Points[currentPoint].position,movingSpeed*Time.deltaTime);
            transform.position = newPoos;
        }
    }

    void OnDrawGizmosSelected()
    {
        for(int i = 0; i < Points.Length;i++)
        {

        }
    }
}
