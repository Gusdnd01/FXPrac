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
    private VisualEffect _slash;
    private bool isAttack = false;

    private void Awake() {
        _slash = _attackPosition.GetComponentInChildren<VisualEffect>();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.F) && !isAttack){
            StartCoroutine(SlahsAttack(.5f));
            print("Attack!");
        }
    }

    private IEnumerator SlahsAttack(float delay){
        _slash.SendEvent("OnPlay");
        _slash.transform.GetComponent<BoxCollider>().enabled = true;
        anim.SetTrigger("Attack");
        isAttack = true;
        yield return new WaitForSeconds(delay);
        isAttack = false;
        _slash.transform.GetComponent<BoxCollider>().enabled = false;
    }
}
