using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject explosionObject;

    public float speed = 5f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = Vector2.up * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Main Camera")
        {
            GameObject.Destroy(this.gameObject);
        }

        if(collision.tag == "Meteor")
        {
            collision.transform.GetComponent<Meteor>().hit();
            GameObject.Destroy(this.gameObject);
            GameObject.Instantiate(explosionObject, this.transform.position, Quaternion.identity);
        }
    }
}
