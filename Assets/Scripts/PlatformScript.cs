using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public enum PlatformType { disappear, trap, spin }

    public PlatformType myType;

    public List<GameObject> bulletGroup = new List<GameObject>();
    public GameObject bullet;
    public float trapTimer;
    float trapTick;

    public bool TurnedOn; //oooh baby


	// Update is called once per frame
	void Update () {
		if(myType == PlatformType.trap)
        {
            if(trapTick < trapTimer){
                trapTimer += 1 * Time.deltaTime;
                for(int i=0; i < bulletGroup.Count; i++)
                {
                    bulletGroup[i].SetActive(true);
                }
            }
        }

        if(myType == PlatformType.spin)
        {

        }
            
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
