using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rig;

    public groundCheck groundCheck;
    public Transform bodySprite;

    [Header("Nastavení skoki")]
    public float maxJumpCharge;
    public float jumpChargeSpeed;

    [Header("Nastavení zvuku")]
    public float randomPitchModifier;
    public AudioSource JumpAudioSource;

    float jumpCharge;


    // Update is called once per frame
    void Update()
    {
        int jumpDirection;
        jumpDirection = (int)Input.GetAxisRaw("Horizontal");

        //JumpCharging
        if(Input.GetKey(KeyCode.W)   && groundCheck.isGrounded)
        {
            ChargeJump();
        }

        //JumpRelease
        if(Input.GetKeyUp(KeyCode.W) && groundCheck.isGrounded)
        {
            ReleaseJump(jumpDirection);
        }
    }

    void ChargeJump()
    {
        if(jumpCharge < maxJumpCharge)        jumpCharge += jumpChargeSpeed * Time.deltaTime;

        float i =  jumpCharge/maxJumpCharge;

        float y = -0.5f+ (-0.2f*i);

        bodySprite.transform.localPosition = new Vector3(0,y,0);
        //Debug.Log(jumpCharge);
    }
    void ReleaseJump(int jumpDirection)
    {
        rig.AddForce((transform.up + transform.right*jumpDirection)*jumpCharge);
        jumpCharge = 0;

        bodySprite.transform.localPosition = new Vector3(0,-0.5f,0);

        playSound(JumpAudioSource);
    }
    void playSound(AudioSource audioSource)
    {
        audioSource.pitch = 1+ Random.Range(randomPitchModifier*-1,randomPitchModifier);
        audioSource.Play();
    }
    
}
