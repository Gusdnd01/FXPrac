using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSlash : MonoBehaviour
{
    Slash _slash;

    private void Awake() {
        _slash = GetComponentInParent<Slash>();
    }

    public void Slash(){
        _slash.DoubleSlash();
    }

    public void Sting(){
        _slash.Sting();
    }

    public void Crash(){
        _slash.GroundCrash();
    }
}
