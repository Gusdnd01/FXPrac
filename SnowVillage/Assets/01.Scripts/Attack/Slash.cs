using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Slash : MonoBehaviour
{
    [SerializeField]
    private Transform _attackPosition;
    [SerializeField]
    private Animator anim;
    public VisualEffect _slash;
    public VisualEffect _doubleSlash;
    //private GroundSlashShooter _shooter;
    private bool isAttack = false;


    private void Update(){
        if(Input.GetKeyDown(KeyCode.F) && !isAttack){
            StartCoroutine(SlahsAttack(.5f, _slash));
            //_shooter.ShootProjectile();
            print("Attack!");
        }
    }

    public void DoubleSlash(){
        StartCoroutine(DoubleSlashAttack(.5f, _doubleSlash));
    }

    public IEnumerator DoubleSlashAttack(float delay, VisualEffect slash){
        slash.SendEvent("OnPlay");
        slash.transform.GetComponent<BoxCollider>().enabled = true;
        isAttack = true;
        yield return new WaitForSeconds(delay);
        isAttack = false;
        slash.transform.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator SlahsAttack(float delay, VisualEffect slash){
        slash.SendEvent("OnPlay");
        slash.transform.GetComponent<BoxCollider>().enabled = true;
        anim.SetTrigger("Attack");
        isAttack = true;
        yield return new WaitForSeconds(delay);
        isAttack = false;
        slash.transform.GetComponent<BoxCollider>().enabled = false;
    }
}
