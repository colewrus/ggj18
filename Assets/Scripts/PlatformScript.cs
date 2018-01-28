using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public enum PlatformType { disappear, trap, spin, move, split}

    public PlatformType myType;

    public List<GameObject> bulletGroup = new List<GameObject>();
    public GameObject bullet;
    public float timer;
    public float tick;

    public bool TurnedOn; //oooh baby

    //Moving platform vars
    public Vector3 movePos0;
    public Vector3 movePos1;
    public Vector3 startPos;
    bool moved;
    public float moveSpeed;
    Vector3 target;
    bool move;

    //split platform var
    public GameObject leftSide; //strong side
    public GameObject rightSide; //the other side
    public Transform leftTarget;
    public Transform rightTarget;
    Vector3 leftDest;
    Vector3 rightDest;
    public float splitspeed;
    Vector3 leftStart;
    Vector3 rightStart;
    bool split;


    private void Start()
    {
        if(myType == PlatformType.move)
        {
            startPos = transform.position;
            target = startPos;
        }

        if(myType == PlatformType.split)
        {
            leftStart = leftSide.transform.position;
            rightStart = rightSide.transform.position;
            leftDest = leftStart;
            rightDest = rightStart;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
		if(myType == PlatformType.trap)
        {
            if(tick < timer){
                tick += 1 * Time.deltaTime;

            }else
            {
                for (int i = 0; i < bulletGroup.Count; i++)
                {
                    bulletGroup[i].SetActive(true);
                }
                tick = 0;
            }
        }

        if(myType == PlatformType.spin)
        {

        }

        DisappearType();
        MoveType();
        SplitType();
	}

    void MoveType()
    {

        if(myType == PlatformType.move)
        {
            //transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
            if (tick < timer)
            {
                tick += 1 * Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
            }
            else
            {
                if (!moved)
                {
                    target = movePos0;
                    moved = true;            
                }else if (moved)
                {
                    target = startPos;
                    //transform.position = Vector3.Lerp(transform.position, startPos, moveSpeed * Time.deltaTime);
                    moved = false;
                }
                tick = 0;
            }
        }
    }

    void SplitType()
    {
        if(myType == PlatformType.split)
        {
            if(tick < timer)
            {
                tick += 1 * Time.deltaTime;
                leftSide.transform.position = Vector3.Lerp(leftSide.transform.position, leftDest, splitspeed * Time.deltaTime);
                rightSide.transform.position = Vector3.Lerp(rightSide.transform.position, rightDest, splitspeed * Time.deltaTime);
            }
            else
            {
                if (split)
                {
                    leftDest = leftStart;
                    rightDest = rightStart;
                    split = false;
                    tick = 0;
                }
                else
                {
                    leftDest = leftTarget.position;
                    rightDest = rightTarget.position;
                    split = true;
                    tick = timer / 2;
                }
                
            }
        }
    }


    void DisappearType()
    {
        if (myType == PlatformType.disappear)
        {
            if (tick < timer)
            {
                tick += 1 * Time.deltaTime;
            }
            else
            {
                tick = 0;
                if (TurnedOn)
                {
                    this.GetComponent<Animator>().SetBool("startOff", true);
                    TurnedOn = false;
                }
                else if (!TurnedOn)
                {
                    //gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    // Color c = new Color(1, 1, 1, 0);
                    // GetComponent<SpriteRenderer>().color = c;
                    gameObject.SetActive(true);
                    this.GetComponent<Animator>().SetBool("startOff", false);
                    TurnedOn = true;
                }

            }
        }
    }
        


    public void SwitchOff()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Color c = new Color(1, 1, 1, 0);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        
    }

    public void EnableRender()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
    

    public void EnableBox()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        
    }
}
