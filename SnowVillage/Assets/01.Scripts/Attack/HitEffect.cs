using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitFX;

    public void OnHit(){
        _hitFX.Play();
    }
}
