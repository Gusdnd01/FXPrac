using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayerController : MonoBehaviour
{
    public int FPS = 120;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;


    float yRotation;
    float xRotation;
    [SerializeField] float lookSensitivity = 100.0f;
    float currentxRotation;
    float currentyRotation;
    float yRotationV;
    float xRotationV;
    float lookSmoothness = .1f;

    private void Awake(){
        Application.targetFrameRate = FPS;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update(){
        CharacterController _controller = GetComponent<CharacterController>();

        if(_controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if(Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);

        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 100);
        currentxRotation = Mathf.SmoothDamp(currentxRotation, xRotation, ref xRotationV, lookSmoothness);
        currentxRotation = Mathf.SmoothDamp(currentyRotation, yRotation, ref yRotationV, lookSmoothness);
        transform.rotation = Quaternion.Euler(xRotation, yRotation,0);
    }
}
