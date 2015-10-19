using UnityEngine;
using System.Collections;

public class GameDirectorScript : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject floorSprite;

    GameObject octo;

    // Use this for initialization
    void Start () {
        SpawnEnemy();
        SpawnFloor();
        

    }

    private void SpawnFloor() {
        for (int x = -1; x < 1; x++)
        {
            for (int y = -1; y <1; y++)
            {
                //Debug.Log("Spawning floor:" + x.ToString() + " " + y.ToString());
                Vector3 newPos = new Vector3(x, y, 0);
                GameObject octo = Instantiate(floorSprite, newPos, Quaternion.identity) as GameObject;

            }

        }

    }

    private void SpawnEnemy() {
        Debug.Log("Spawning Enemy onto Map");
        Vector3 newPos = new Vector3(0, 2, 0);
        octo = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (octo == null) {
            SpawnEnemy();
        }
	
	}
}
