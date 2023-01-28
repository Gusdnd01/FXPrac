using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeatherSystem : MonoBehaviour
{
    [SerializeField] private Transform timeObj;
    private Material mat;

    [Range(0f, 24f)]
    [SerializeField] private float curTime;

    private float timeAmount = 0;
    private float starAmount = 0;

    private void Awake()
    {
        mat = RenderSettings.skybox;
    }
    private void FixedUpdate()
    {
        timeObj.rotation = Quaternion.Euler(curTime * 15,0,0);

        if (curTime >= 17 || curTime < 7)
        {
            if (curTime < 7)
            {
                mat.SetFloat("_isNight", 1);
                timeAmount = 24 - (curTime*(24/7));
                //starAmount = 
            }

            else
            {
                mat.SetFloat("_isNight", 1);
                timeAmount = 24;
            }
        }
        else
        {
            mat.SetFloat("_isNight", 0);
            timeAmount = curTime;
        }
        /* if (DateTime.Now.Hour >= 17 || DateTime.Now.Hour < 7)
        {
            if (DateTime.Now.Hour < 7)
            {
                curTime = 24 - DateTime.Now.Hour;
            }

            else
            {

                mat.SetFloat("_isNight", 1);
                curTime = 24;
            }
        }
        else
        {
            mat.SetFloat("_isNight", 0);
            curTime = DateTime.Now.Hour;
        } */

        mat.SetFloat("_NowTime", timeAmount);
    }
}
