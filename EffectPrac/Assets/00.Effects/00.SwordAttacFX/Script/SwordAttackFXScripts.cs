using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SwordAttackFXScripts : MonoBehaviour
{
    [SerializeField] private VisualEffect _swordSpawn;
    [SerializeField] private VisualEffect _swordFall;
    [SerializeField] private VisualEffect _swordPoint;

    private void Start() {
        StartCoroutine(SwordAttack());
        StartCoroutine(SwordAttack2());
    }

    private IEnumerator SwordAttack(){
        while(true){
            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.F));
            _swordSpawn.SendEvent("OnPlay");
            yield return new WaitForSeconds(1.5f);
            _swordFall.SendEvent("OnPlay");
        }
    }
    private IEnumerator SwordAttack2(){
        while(true){
            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.V));
            _swordPoint.SendEvent("OnPlay");
        }
    }
}
