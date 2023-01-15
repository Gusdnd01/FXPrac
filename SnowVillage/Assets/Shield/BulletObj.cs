using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public Vector3 moveDir = Vector3.zero;
    private Rigidbody rb;
    
    [SerializeField] [Range(0, 10)]
    float _speed;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        rb.velocity += moveDir * _speed;
    }
}
