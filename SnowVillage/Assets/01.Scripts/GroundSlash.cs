using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlash : MonoBehaviour
{
    //일단 만들어야징
    public float speed = 30f;
    public float slowDownRate = .01f;
    public float detectingDistance = .1f;
    public float destroyDelay = 5f;

    private Rigidbody rb;
    private bool stopped = false;

    void Start(){
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if(GetComponent<Rigidbody>() != null){
            rb = GetComponent<Rigidbody>();
            StartCoroutine(SlowDown());
        }
        else{
            print($"{gameObject.name} haven't Rigidbody");
        }

        Destroy(gameObject, destroyDelay);
    }

    private void FixedUpdate() {
        if(!stopped){
            RaycastHit hit;
            Vector3 distance = new Vector3(transform.position.x, transform.position.y+1,transform.position.z );
            if(Physics.Raycast(distance, transform.TransformDirection(-Vector3.up), out hit, detectingDistance,LayerMask.GetMask("Ground"))){
                transform.position = new Vector3(transform.position.x, hit.point.y,transform.position.z);
            }
            else{
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            Debug.DrawRay(distance, transform.TransformDirection(-Vector3.up * detectingDistance), Color.blue);
        }
    }

    private IEnumerator SlowDown(){
        float t = 1;
        while(t>0){
            rb.velocity = Vector3.Lerp(Vector3.zero, rb.velocity, t);
            t -= slowDownRate;
            yield return new WaitForSeconds(.1f);
        }

        stopped = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")){
            other.GetComponent<HitEffect>().OnHit();
        }
    }
}
