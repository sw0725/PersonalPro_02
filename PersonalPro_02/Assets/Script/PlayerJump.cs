using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public float jumpPower = 2f;
    public float jumpLimit = 0.3f;
    public Action Die;

    float jumpTimer = 0.0f;
    bool isJumping = false;
    bool jumpKey = false;

    PlayerJumpInput input;
    Rigidbody rig;
    PlayerMusic musicEffect;

    private void Awake()
    {
        input = new PlayerJumpInput();
        rig = GetComponent<Rigidbody>();
        musicEffect = transform.GetChild(1).GetComponent<PlayerMusic>();
    }

    private void OnEnable()
    {
        input.Player.Enable();
        input.Player.Jump.performed += OnJump_performed;
        input.Player.Jump.canceled += OnJump_canceled;
    }

    private void OnDisable()
    {
        input.Player.Jump.performed -= OnJump_performed;
        input.Player.Jump.canceled -= OnJump_canceled;
        input.Player.Disable();
    }

    private void FixedUpdate()
    {
        if (isJumping && jumpKey) 
        {
            rig.velocity = Vector2.zero;
            rig.AddForce(Vector2.up * jumpPower * ((jumpTimer)+1f), ForceMode.Impulse);
            jumpTimer += Time.fixedDeltaTime;
        }
        if ((isJumping && !jumpKey) || jumpTimer>=jumpLimit) 
        {
            isJumping=false;
        }
    }

    private void OnJump_performed(InputAction.CallbackContext context)
    {
        
        if (!GameManager.gameOver) 
        {
            if (!isJumping)
            {
                jumpKey = true;
                isJumping = true;
                jumpTimer = 0;
                musicEffect.SoundPlay(SoundType.Jump);
            }
        }
    }
    private void OnJump_canceled(InputAction.CallbackContext context)
    {
        if (!GameManager.gameOver) 
        {
            jumpKey = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground")) 
        {
            musicEffect.SoundPlay(SoundType.Die);
            Die?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            Die?.Invoke();
        }
    }

    public void Freeze() 
    {
        rig.useGravity = false;
    }
    public void UnFreeze()
    {
        rig.useGravity = true;
    }

    public void OnButton()
    {
        musicEffect.SoundPlay(SoundType.Button);
    }

    public void OnScore()
    {
        musicEffect.SoundPlay(SoundType.Coin);
    }

    public void OnBackground()
    {
        musicEffect.SoundPlay(SoundType.Wind);
    }
}

