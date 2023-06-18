using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private float playerSpeed = 3.5f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private PlayerState state;
    private Animator animator;
    private Transform cameraTransform;

    private void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        SetState(PlayerState.Idle);
        cameraTransform = Camera.main.transform;
    }

    void Update() {
        groundedPlayer = controller.isGrounded;
     
        if (groundedPlayer && playerVelocity.y < 0) {
            //playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Transformamos el movimiento en la direccion de la cámara
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0;
        move = move.normalized;


        Vector3 displacement = move * Time.deltaTime * playerSpeed;
        controller.Move(displacement);

        if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }
        
        if (Input.GetButtonDown("Jump") && groundedPlayer) {
            //playerVelocity.y = 0f;
            Debug.Log("Salta Amy, salta");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            SetState(PlayerState.Jump);
        } else if(groundedPlayer) {
            if(move == Vector3.zero) {
                SetState(PlayerState.Idle);
            } else {
                SetState(PlayerState.Run);
            }
        }
       

        playerVelocity.y += gravityValue * Time.deltaTime;
  
        if(playerVelocity.y < 0 && !  groundedPlayer) {
            SetState(PlayerState.Fall);
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }


    private void SetState(PlayerState newState) {
        if(state != newState ) {
            animator.ResetTrigger("Idle");
            animator.ResetTrigger("Run");
            animator.ResetTrigger("Jump");
            animator.ResetTrigger("Fall");
            state = newState;
            animator.SetTrigger($"{newState}");
        }
    }

    
}

public enum PlayerState {
    Idle,
    Run,
    Jump,
    Fall
}
