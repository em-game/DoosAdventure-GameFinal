using UnityEngine;
using System.Collections;

public class BossGun : MonoBehaviour {
    public GameObject EnemyBulletGo;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FireEnemyBullet", 1, 3f); 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FireEnemyBullet()
    {
        GameObject player = GameObject.Find("Player");

        if(player != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGo);

            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
            bullet.GetComponent<BossBullet>().SetDirection(direction);
        }
    }
}

