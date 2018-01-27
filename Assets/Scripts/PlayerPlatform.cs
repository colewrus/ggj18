using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour {

    public Transform deathTransform;
    public Transform startPos;

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
        DeathCheck();
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


    void DeathCheck()
    {
        if(transform.position.y < deathTransform.position.y)
        {
            //rb.velocity = new Vector2(0, 0);
            Color c = new Color(1, 1, 1, 0);
            GetComponent<SpriteRenderer>().color = c;
            StartCoroutine(PlayerRespawn(0.5f));
        }
    }

    IEnumerator PlayerRespawn(float t)
    {
        yield return new WaitForSeconds(t);
        transform.position = startPos.position;
        Color c = new Color(1, 1, 1, 1);
        GetComponent<SpriteRenderer>().color = c;
    }
}
