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

    public float scrollSpeed = -1.5f;

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
        

        if(packets <= 0)
        {
            //Game over 
        }
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
            StartCoroutine(SceneChange(2));
            //Switch Scene here
        }
       

       
    }

    IEnumerator SceneChange(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("platformTest");
    }
}
