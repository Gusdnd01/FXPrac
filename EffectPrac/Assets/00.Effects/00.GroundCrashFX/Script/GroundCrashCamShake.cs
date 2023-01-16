using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Cinemachine;

public class GroundCrashCamShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private VisualEffect vfx;
    private CinemachineBasicMultiChannelPerlin multiPerlin;


    private void Awake()
    {
        multiPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        StartCoroutine(CamShake(.4f, .9f));
    }

    IEnumerator CamShake(float firstDelay, float secondDelay)
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
            vfx.SendEvent("OnPlay");
            multiPerlin.m_AmplitudeGain = 5;
            yield return new WaitForSeconds(firstDelay);
            multiPerlin.m_AmplitudeGain = 0;
            yield return new WaitForSeconds(0.1f);
            multiPerlin.m_AmplitudeGain = 10;
            yield return new WaitForSeconds(secondDelay);
            multiPerlin.m_AmplitudeGain = 0;
            yield return new WaitForSeconds(0.1f);
            multiPerlin.m_AmplitudeGain = 20;
            yield return new WaitForSeconds(1f);
            multiPerlin.m_AmplitudeGain = 0;
        }
    }
}
