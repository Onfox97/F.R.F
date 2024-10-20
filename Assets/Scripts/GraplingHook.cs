using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GraplingHook : MonoBehaviour
{
    public LayerMask layerMask;

    public LineRenderer lineRenderer;
    public Transform graplingPoint;
    public float ropeSpeed; 
    public float ropeCollisionDistance,ropeCollisionSize;
    public static bool isGraplingUsed;
    bool rewindRope;

    void Start()
    {
        graplingPoint.parent = null;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CastRopeStart();
        }
        else if (Input.GetMouseButton(0)&& !isGraplingUsed && !rewindRope)
        {
            CastRopeWine();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isGraplingUsed  = false;

        }
        else if (!isGraplingUsed || rewindRope)
        {
            RewineRope();
        }
        
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,graplingPoint.position);
    }
    void CastRopeStart()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 rayDirection = mousePosition - (Vector2)transform.position;

        float dir = Mathf.Atan2(rayDirection.y,rayDirection.x)*Mathf.Rad2Deg -90;

        graplingPoint.position = transform.position;
        graplingPoint.rotation = Quaternion.Euler(0,0,dir);

        lineRenderer.gameObject.SetActive(true);
    }
    void CastRopeWine()
    {

        RaycastHit2D hit;
        hit = Physics2D.CircleCast(graplingPoint.position,ropeCollisionSize,graplingPoint.up,ropeCollisionDistance,layerMask);

        if(hit.collider != null)
        {
            if(hit.collider.tag == "Moucha")
            {
                Moucha moucha =  hit.collider.GetComponent<Moucha>();
                moucha.Catch(graplingPoint);
                transform.parent = hit.collider.transform;
            }
            if(hit.collider.tag == "DontStick")
            {
                rewindRope = true;
            }
            else
            {
                //Ukotvení
                graplingPoint.position = hit.point;
                graplingPoint.gameObject.SetActive(true);
                        
            }
            isGraplingUsed = true;
            
        }
        else
        {
            graplingPoint.position += graplingPoint.up * ropeSpeed * Time.deltaTime;
        }



    }
    void CutRope()
    {
        graplingPoint.gameObject.SetActive(false);
        lineRenderer.gameObject.SetActive(false);

        transform.position = transform.parent.position;

        rewindRope = false;
    }
    void RewineRope()
    {
        if(Vector3.Distance(transform.position,graplingPoint.position) >= 0.1f)
        {
            graplingPoint.position = Vector3.MoveTowards(graplingPoint.position,transform.position,ropeSpeed*Time.deltaTime);
        }
        else CutRope();

    }
}
