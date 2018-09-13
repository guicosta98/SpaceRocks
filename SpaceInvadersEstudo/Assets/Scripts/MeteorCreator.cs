using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

    public GameObject meteor;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private float delayToSpawn;
    private float countTimer;
    private float xMin;
    private float xMax;
	void Start () {
        float horizontalExtension = Camera.main.orthographicSize * Screen.width / Screen.height;
        xMin = -horizontalExtension * 0.8f;
        xMax = horizontalExtension * 0.8f;
        generateNextTime();
	}
	
	void Update () {
        countTimer += Time.deltaTime;

        if(countTimer >= delayToSpawn)
        {
            countTimer = 0;
            generateNextTime();
            Vector3 pos = transform.position;
            pos.x = Random.Range(xMin, xMax);

            GameObject.Instantiate(meteor, pos, Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }
	}

    void generateNextTime()
    {
        delayToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor"))
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
