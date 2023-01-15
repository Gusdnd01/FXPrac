using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private float xRotation;
    private float yRotation;

    [SerializeField]
    private GameObject _bulletObj;

    [SerializeField]
    private float _sensitivity;

    [Header("Input")]
    public string mouseX = "Mouse X";
    public string mouseY = "Mouse Y";

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        CamRotate();

        if(Input.GetMouseButtonDown(0)){
            GameObject bullet = Instantiate(_bulletObj, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletObj>().moveDir = transform.forward;
        }
    }

    private void CamRotate(){
        float x = Input.GetAxis(mouseX);
        float y = Input.GetAxis(mouseY);

        xRotation += x * _sensitivity;
        yRotation += y * _sensitivity;

        transform.rotation = Quaternion.Euler(yRotation,-xRotation, 0);
    }
}
