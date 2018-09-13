using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private float lifetime = 0;
	void Update () {
        lifetime += Time.deltaTime;

        if(lifetime >= 0.8f)
        {
            Destroy(this.gameObject);
        }
	}
}
