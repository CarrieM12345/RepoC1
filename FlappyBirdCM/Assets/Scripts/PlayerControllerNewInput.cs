using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNewInput : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private MyInputMap mapa;

    private Vector2 inputData;

    private bool isJumping;

    public Transform camTransform;

    public float charaterRotationSpeed = 10.0f; 

    public Animator animator;


    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();

        mapa = new MyInputMap();

        mapa.PlayerWorld.Movement.performed += Movement_performed =>
        {
            inputData = Movement_performed.ReadValue<Vector2>();
        };


        mapa.PlayerWorld.Movement.canceled += Movement_canceled =>
        {
            inputData = Movement_canceled.ReadValue<Vector2>();
        };


        mapa.PlayerWorld.Jump.performed += Jump_performed =>
        {
            isJumping = Jump_performed.ReadValueAsButton();
        };

        mapa.PlayerWorld.Jump.canceled += Jump_canceled =>
        {
            isJumping = Jump_canceled.ReadValueAsButton();
        };
    }


    private void OnEnable()
    {
        mapa.Enable();
    }
    private void OnDisable()
    {
        mapa.Disable();
    }

    Vector3 move;

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer == true && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0f;
        }

        if(camTransform != null)
        {
            //nos interesa recoger a donde mira la camara
            Vector3 camForward = camTransform.forward;
            // prroyectamos la camara con respecto al suelo(ignoramos el eje y)
            camForward.y = 0.0f;
            camForward.Normalize();

            Vector3 camRight = camTransform.right;
            // prroyectamos la camara con respecto al suelo(ignoramos el eje y)
            camRight.y = 0.0f;
            camRight.Normalize();

            move = camForward * inputData.y + camRight * inputData.x;
        }
        else
        {
            move = transform.forward * inputData.y + transform.right * inputData.x;
        }

        if(move.magnitude > 1.0f)
        {
            move.Normalize();
        }


        // Read input
        //Vector2 input = new Vector2(inputData.x, inputData.y);
        //move = new Vector3(inputData.x, 0.0f, inputData.y);
        Debug.Log("X : " + inputData.x + " | Y: " + inputData.y);
        move = Vector3.ClampMagnitude(move, 1f);


        //Queremos rotar el personaje?
        //
        if(move.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * charaterRotationSpeed);
        }

        // Jump
        if (isJumping && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
