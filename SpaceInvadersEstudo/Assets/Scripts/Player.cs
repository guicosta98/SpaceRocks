using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject laserObject;
    public GameObject explosionObject;
    public Canvas canvas;

    private float shootTimer = 0;
    public int points = 0;
    public float speed = 4f;
    public float minTimeToShoot = 1f;

    MenuButtons menu;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        menu = canvas.GetComponent<MenuButtons>();
	}

    private void Update()
    {
        if (shootTimer < minTimeToShoot)
        {
            shootTimer += Time.deltaTime;
        }
        
    }

    void FixedUpdate () {
        Vector2 moveDir = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        bool btnHolder = CrossPlatformInputManager.GetButton("Shoot");

        if (btnHolder)
        {
            shoot();
        }
        

        rb.velocity = moveDir * speed;
    }

    void shoot()
    {
        if (minTimeToShoot > shootTimer)
            return;

        shootTimer = 0;
        if (laserObject != null)
        {
            Vector3 pos = this.transform.position;
            GameObject.Instantiate(laserObject, pos, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            GameObject.Instantiate(explosionObject, transform.position, Quaternion.identity);
            menu.onDeath();
            GameObject.Destroy(this.gameObject);
        }
    }
}
