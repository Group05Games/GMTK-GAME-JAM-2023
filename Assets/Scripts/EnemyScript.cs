using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int lives;
    private int score;

    public Transform bulletSpawn;
    public GameObject bullet;
    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Bullet bullet = new Bullet(bulletSpeed, "enemy");
        bulletSpawn = this.gameObject.transform;
        //print(bulletSpawn.transform.position.x);
    }

    // Update is called once per frame
    void Update() {
        shoot();
    }

    public void shoot() {
        currentTime += Time.deltaTime;

        if (currentTime > nextFire) {
            nextFire += currentTime;

            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;
		}
	}
}
