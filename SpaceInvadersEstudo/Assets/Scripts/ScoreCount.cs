using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

    Player player;
    public Text score;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        score.text = "0";
    }
    void Update () {
        score.text = "" + player.points;
	}
}
