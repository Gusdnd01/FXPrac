using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _gravity;
    private CharacterController _controller;
    Vector3 moveDir = Vector3.zero;

    private void Awake() {
        _controller = GetComponent<CharacterController>();

        _gravity = -9.81f;
    }

    private void Update() {
        Movement();
        GravityCalculator();
    }

    private void Movement(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(v, moveDir.y, h);
        moveDir = transform.TransformDirection(moveDir);

        _controller.Move(moveDir * _speed * Time.deltaTime);
    }

    private void GravityCalculator(){
        if(!_controller.isGrounded){
            moveDir.y = _gravity;
        }
        else{
            return;
        }
    }
}
