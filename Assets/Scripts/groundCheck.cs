using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool isGrounded;
    void OnTriggerStay2D(Collider2D other)
    {
        isGrounded = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
}
