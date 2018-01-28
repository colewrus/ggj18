using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController SharedInstance;

    public Text scoreLabel;
    private int packets = 10;

    void Awake()
    {
        SharedInstance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void DamagePlayer(int damage)
    {
        packets -= damage;
        scoreLabel.text = "Packets: " + packets;
    }
}
