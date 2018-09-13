using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplosion : MonoBehaviour {

    private float lifetime = 0;
    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= ps.main.duration)
        {
            Destroy(this.gameObject);
        }
    }
}
