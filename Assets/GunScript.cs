using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
    public GameObject bullet;
    public float timer;
    public float tick;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(tick < timer){
            tick += 1 * Time.deltaTime;
        }
        else{
            Instantiate(bullet, transform.position, Quaternion.identity);
            tick = 0;
        }

        MoveSpawn(Random.Range(-11, 11));
	}


    void MoveSpawn(float randomNum){
            transform.position = new Vector3(11.5f, randomNum, 0);
        Debug.Log(Random.Range(-11, 11));
    }
}
