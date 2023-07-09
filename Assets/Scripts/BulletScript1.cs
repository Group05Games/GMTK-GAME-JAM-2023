using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript1 : MonoBehaviour
{
    private Rigidbody2D projectile;
    private WalletManager EnemyWallet;
    public float moveSpeed = 3.0f;
    
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
        EnemyWallet = GameObject.Find("EnemyScore").gameObject.GetComponent<WalletManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = this.transform.position.y;
        projectile.velocity = new Vector2(0, -1) * moveSpeed;
    }

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Bounding Box Bottom") {
            print("delete bullet");
            Destroy(this.gameObject);
		}
        else {
            print("hello");
		}
    }

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Enemy") {
            print("delete Enemy");

            print("You Win");

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else {
            print("Crash");
		}
	}
}
