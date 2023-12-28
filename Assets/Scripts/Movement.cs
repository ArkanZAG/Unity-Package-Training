using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private float jumpHeigth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem jumpParticle;
    [SerializeField] private ShakeCamera shakeCamera;
    private void Start()
    {
        
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector3(horizontalInput * moveSpeed, playerRigidBody.velocity.y, playerRigidBody.velocity.z);
        playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, playerRigidBody.velocity.y, verticalInput * moveSpeed);
        
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOScaleY(0.5f, 0.1f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpHeigth, playerRigidBody.velocity.z);
            shakeCamera.CameraShake(5f, 0.3f);
            transform.DOScaleY(1f, 0.1f);
            jumpParticle.Stop();
            jumpParticle.Play();
        }
    }
}
