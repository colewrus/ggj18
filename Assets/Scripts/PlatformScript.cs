using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public bool TurnedOn; //oooh baby


	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchOff()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.SetActive(false);
    }

    public void EnableBox()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
