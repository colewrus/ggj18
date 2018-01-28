using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour {

    Rigidbody2D rb; 
    public float speed;
    float horiz;
    float vert;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}


    void Movement()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horiz, vert) * speed;
    }

    private void OnTriggerEnter2D(Collider2D hit) {
        

        //Lets see if it gets hit by a 

        if(hit.gameObject.tag == "bullet")
        {
            Debug.Log("You were hit!");

            //Now we need to do some magic
            hit.gameObject.SetActive(false);

            //Decrease packets by 1
            GameController.SharedInstance.DamagePlayer(1);
        }
    }
}
