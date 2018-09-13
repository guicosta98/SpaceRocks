using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    Player player;
    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    public GameObject explosionObject;
    public float speed = 5f;
    public int hp = 3;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	

	void Update () {
        rb.velocity = Vector2.down * speed;
	}

    public void hit()
    {
        hp -= 1;

        switch (hp)
        {
            case 2:
                renderer.color = Color.yellow;
                break;
            case 1:
                renderer.color = Color.red;
                break;
            default:
                renderer.color = new Color(122, 66, 6);
                break;
    }

        if(hp <= 0)
        {
            player.points++;
            GameObject.Instantiate(explosionObject, transform.position, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
        }
    }

    
}
