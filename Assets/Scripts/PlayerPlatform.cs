using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatform : MonoBehaviour {

    public Transform deathTransform;
    public Transform startPos;

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    float horiz;
    float vert;


    public int health;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "win")
        {
            SceneManager.LoadScene("titleCard");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "mover")
        {
            transform.parent = collision.transform;
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }

        if(collision.transform.tag == "bullet")
        {
            //you got hit
            transform.position = startPos.position;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "mover")
        {
            transform.parent = null;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "mover")
        {
            transform.parent = collision.transform;
        }
    }
}
