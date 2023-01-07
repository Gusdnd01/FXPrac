using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCast : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")){
            other.GetComponent<HitEffect>().OnHit();
            print("asd");
        }
    }
}
