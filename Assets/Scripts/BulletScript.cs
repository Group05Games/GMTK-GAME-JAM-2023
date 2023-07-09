using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
        projectile.velocity = new Vector2(0, 1) * moveSpeed;
    }

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Bounding Box Top") {
            print("delete bullet");
            Destroy(this.gameObject);
		}
        else if (collision.gameObject.name == "Cursor") {
            print("Hit Cursor");
            Destroy(this.gameObject);
            EnemyWallet.addScore(50);
        }
        else {
            print("hello");
		}
    }

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Bug 1(Clone)") {
            print("delete Spider");

            EnemyWallet.addScore(10);
            print("Test "+ EnemyWallet.getScore());

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Bug 2(Clone)") {
            print("delete Bat");

            EnemyWallet.addScore(50);
            print("Test "+ EnemyWallet.getScore());

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Bug 3(Clone)") {
            print("delete Sonic.Plane.Speed");

            EnemyWallet.addScore(100);
            print("Test "+ EnemyWallet.getScore());

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else {
            print("hello 2");
		}
	}
}
