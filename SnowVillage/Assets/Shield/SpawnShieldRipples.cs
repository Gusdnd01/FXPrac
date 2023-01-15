using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnShieldRipples : MonoBehaviour
{
    public GameObject obj;
    private VisualEffect shieldRipplesVFX;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bullet"){
            var ripples = Instantiate(obj, transform) as GameObject;
            shieldRipplesVFX = ripples.GetComponent<VisualEffect>();
            shieldRipplesVFX.SetVector3("SphereCenter", other.contacts[0].point);

            Destroy(ripples, 2);
            Destroy(other.gameObject);
        }
    }
}
