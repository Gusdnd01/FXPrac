using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Cinemachine;
public class HitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitFX;

    #region Cinemachine
    [SerializeField] CinemachineVirtualCamera cam;
    
    CinemachineBasicMultiChannelPerlin _multiChannelPerlin;
    #endregion

    #region VolumeSetting
    [SerializeField] private Volume _volume;
    [SerializeField] private VolumeProfile _globalVolume;
    private ColorAdjustments _colorAdjustments;
    private ShadowsMidtonesHighlights _shadowMidtonesHighlights;
    #endregion

    private void Awake() {
        _volume = FindObjectOfType<Volume>();
        _globalVolume = _volume.profile;
        _globalVolume.TryGet<ColorAdjustments>(out _colorAdjustments);
        _globalVolume.TryGet<ShadowsMidtonesHighlights>(out _shadowMidtonesHighlights);
    }

    private void Start() {
        _multiChannelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void OnHit(){
        StartCoroutine(HitEffectRoutine());
    }

    private IEnumerator HitEffectRoutine(){
        _hitFX.Play();

        yield return new WaitForSeconds(.3f);
        
    }
}
