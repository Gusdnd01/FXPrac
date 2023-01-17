using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpearAttackScript : MonoBehaviour
{
    public List<VisualEffect> attackFX = new List<VisualEffect>();
    public Transform afterFXPos;

    private Animator _anim;

    private bool _isAfterEffect = false;
    private float _positionX = -10;
    private float _lastPos = 20;

    private void Awake() {
        _anim = GetComponent<Animator>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)){
            _anim.SetTrigger("Attack");
        }

        if(_isAfterEffect){
            _positionX = Mathf.Lerp(_positionX, _lastPos, Time.deltaTime);
            afterFXPos.position = new Vector3(_positionX, afterFXPos.position.y, afterFXPos.position.z); 
        }
    }

    public void FirstAttack(){
        Attack(0);
    }
    public void SecondAttack(){
        Attack(1);
    }
    public void LastAttack(){
        Attack(2);
    }

    public void AfterEffect(){
        StartCoroutine(AE());
    }

    IEnumerator AE(){
        _isAfterEffect = true;
        yield return new WaitForSeconds(1f);
        _isAfterEffect = false;
        _positionX = -10;
        afterFXPos.position = new Vector3(-10, afterFXPos.position.y,afterFXPos.position.z);
    }

    private void Attack(int index){
        attackFX[index].SendEvent("OnPlay");
    }
}
