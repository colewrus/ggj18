using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    public enum BulletType {straight, explode};

    public BulletType myType;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(myType == BulletType.straight)
        {
            transform.Translate(Vector3.left * speed *   Time.deltaTime);
        }
	}
}
