using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class KassadinSlash : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField]
    private VisualEffect _kassadinSlashEffect;

    [Header("Other Data")]
    [SerializeField] private float _effectDelay = 0.3f;
    [SerializeField] private float _attackDelay = 1f;
    private Animator _animator;

    [Header("VFX Event Name")]
    public string PlayEvent = "OnPlay";

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    private void Start() {
        StartCoroutine(KassadinSlashActive(_attackDelay));
    }

    private IEnumerator KassadinSlashActive(float delay){
        while(true){
            yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));

            _animator.SetTrigger("isAttack");
            yield return new WaitForSeconds(_effectDelay);
            _kassadinSlashEffect.SendEvent(PlayEvent);

            yield return new WaitForSeconds(delay);
        }
    }
}
