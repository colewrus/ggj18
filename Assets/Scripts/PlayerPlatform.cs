using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour {

    public Transform deathTransform;

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    float horiz;
    float vert;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Platforming();
	}

    void Platforming()
    {

        
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        //rb.AddForce(new Vector2(horiz,0) * speed);
        rb.velocity = new Vector2(horiz*speed, Mathf.Clamp(rb.velocity.y, -12,15));
        
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
