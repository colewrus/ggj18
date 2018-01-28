using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
    public GameObject bullet;
    public float timer;
    public float tick;

    public float startWait = 2.0f;
    public int enemiesPerWave = 5;

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
        //Debug.Log(Random.Range(-11, 11));
    }

    //IEnumerator SpawnEnemyWaves()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    while (true)
    //    {
    //        float waveType = Random.Range(0.0f, 10.0f);
    //        for (int i = 0; i < enemiesPerWave; i++)
    //        {
    //            Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight + 2, 0));
    //            Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight + 2, 0));
    //            Vector3 spawnPosition = new Vector3(Random.Range(topLeft.x, topRight.x), topLeft.y, 0);
    //            Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
    //            if (waveType >= 5.0f)
    //            {
    //                Instantiate(enemyType1, spawnPosition, spawnRotation);
    //            }
    //            else
    //            {
    //                Instantiate(enemyType2, spawnPosition, spawnRotation);
    //            }
    //            yield return new WaitForSeconds(spawnInterval);
    //        }
    //        yield return new WaitForSeconds(waveInterval);
    //    }
    //}
}
