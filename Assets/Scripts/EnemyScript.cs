using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int lives;
    private int score;
    public float bulletSpeed = 10f;

    public Transform bulletSpawn;

    //[Header("Random Range")]
    //[Range(0.8f, 1.2f)]
    public float fireCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        Bullet bullet = new Bullet(bulletSpeed, "enemy");
        //bulletSpawn = 
        bulletSpawn = GetComponent<Transform>();
        print(bulletSpawn.transform.position.x);
    }

    // Update is called once per frame
    void Update() {
        shoot();
    }

    public void shoot() {
        
	}
}
