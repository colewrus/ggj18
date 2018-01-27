using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlatformClass
{
    public bool TurnedOn; //ooooh baby
    public GameObject obj;
}


public class Platform_manager : MonoBehaviour {


    public List<PlatformClass> PlatformList = new List<PlatformClass>();
    Animator ani;

    public float timer;
    public float tick;


	// Use this for initialization
	void Start () {
         
    
        for (int i = 0; i < PlatformList.Count; i++)
        {

        }
        
    }
	
	// Update is called once per frame
	void Update () {
		if(tick < timer)
        {
            tick += 1 * Time.deltaTime;
        }else
        {
            for(int i=0; i < PlatformList.Count; i++)
            {
                if (!PlatformList[i].TurnedOn)
                {
                    PlatformList[i].TurnedOn = true;
                    
                    Color c = new Color(1, 1, 1, 0);
                    PlatformList[i].obj.GetComponent<SpriteRenderer>().color = c;
                    PlatformList[i].obj.SetActive(true);
                    PlatformList[i].obj.GetComponent<Animator>().SetBool("startOff", false);

                    //PlatformList[i].obj.GetComponent<Animator>().ResetTrigger("platformOff");
                }
                else
                {
                    PlatformList[i].TurnedOn = false;
                    //PlatformList[i].obj.SetActive(false);
                    PlatformList[i].obj.GetComponent<Animator>().SetBool("startOff", true);
                    //PlatformList[i].obj.GetComponent<Animator>().SetTrigger("platformOff");
                }

            }
            
            tick = 0;
        }

	}


    public void AnimEnded()
    {
        Debug.Log(this.gameObject.name);
    }
}
