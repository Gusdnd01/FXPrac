using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Cinemachine;
public class Slash : MonoBehaviour
{
    [SerializeField]
    private Transform _attackPosition;
    [SerializeField]
    private Animator anim;
    public VisualEffect _slash;
    public VisualEffect _doubleSlash;
    public VisualEffect _sting;
    public VisualEffect _groundCrash;
    //private GroundSlashShooter _shooter;
    private bool isAttack = false;
    private void Start() {
        _multiChannelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

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
    public void GroundCrash(){
        StartCoroutine(GroundCrash(1.5f, _groundCrash));
    }

    [SerializeField] CinemachineVirtualCamera cam;
    
    CinemachineBasicMultiChannelPerlin _multiChannelPerlin;

    public void Sting(){
        StartCoroutine(StingAttack(0.5f, _sting));
    }

    public IEnumerator StingAttack(float delay, VisualEffect slash){
        slash.SendEvent("OnPlay");
        slash.transform.GetComponent<BoxCollider>().enabled = true;
        isAttack = true;
        _multiChannelPerlin.m_AmplitudeGain = 10f;
        yield return new WaitForSeconds(delay);
        _multiChannelPerlin.m_AmplitudeGain = 0;
        isAttack = false;
        slash.transform.GetComponent<BoxCollider>().enabled = false;
    }
    public IEnumerator GroundCrash(float delay, VisualEffect slash){
        slash.SendEvent("OnPlay");
        slash.transform.GetComponent<BoxCollider>().enabled = true;
        isAttack = true;
        _multiChannelPerlin.m_AmplitudeGain = 10f;
        yield return new WaitForSeconds(delay);
        _multiChannelPerlin.m_AmplitudeGain = 0;
        isAttack = false;
        slash.transform.GetComponent<BoxCollider>().enabled = false;
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
