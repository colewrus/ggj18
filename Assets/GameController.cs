using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController SharedInstance;

    public Text scoreLabel;
    public Text timerLabel;
    private int packets = 10;

    public float startTime = 20f;

    void Awake()
    {
        SharedInstance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameCountdown();
        //Debug.Log(Mathf.RoundToInt(startTime));
    }


    public void DamagePlayer(int damage)
    {
        packets -= damage;
        scoreLabel.text = "Packets: " + packets;
    }

    public void GameCountdown()
    {
        if (!(startTime <= 0)){
            startTime -= Time.deltaTime;
            timerLabel.text = "Timer: " + Mathf.RoundToInt(startTime);
        }
        else
        {
            timerLabel.text = "You Made it to next Level prepare your soul!";

            //Switch Scene here
        }
       

        
    }
}
