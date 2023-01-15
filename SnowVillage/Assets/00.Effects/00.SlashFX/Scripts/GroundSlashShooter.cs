using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlashShooter : MonoBehaviour
{
    public Camera cam;

    public GameObject projectile;
    public Transform firePoint;
    public float fireRate = 4.0f;

    private Animator _anim;

    private Vector3 destination;
    private float timeToFire;
    private GroundSlash groundSlashScripts;

    private void Awake() {
        //_anim = GetComponent<Animator>();
    }

    public void Start(){
        //StartCoroutine(Fire());
    }

    public void ShootProjectile(){
        Ray ray = cam.ViewportPointToRay(new Vector3(.5f,.5f,0));
        destination = ray.GetPoint(1000);
        InstantiateProjectile();
    }

    private void InstantiateProjectile(){
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;

        groundSlashScripts = projectileObj.GetComponent<GroundSlash>();
        RotateToDestination(projectileObj, destination, true);
        projectileObj.GetComponent<Rigidbody>().velocity = firePoint.forward * groundSlashScripts.speed;
    }

    private void RotateToDestination(GameObject obj, Vector3 dest, bool onlyY){
        var direction = dest - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);

        if(onlyY){
            rotation.x = 0;
            rotation.z = 0;
        }

        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    // private IEnumerator Fire(){
    //     while(true){
    //         yield return new WaitUntil(()=>Input.GetButtonDown("Fire1"));
    //         //_anim.SetTrigger("isAttack");
    //         yield return new WaitForSeconds(0.5f);
    //         ShootProjectile();
    //         yield return new WaitForSeconds(fireRate);
    //     }
    // }
}
