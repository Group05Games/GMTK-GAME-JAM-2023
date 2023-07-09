using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D projectile;
    public float moveSpeed = 3.0f;
    
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
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
        else {
            print("hello");
		}
    }

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Legaly Distinct") {
            print("delete Bat");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
		}
        else if (collision.gameObject.name == "Legaly Distinct 2") {
            print("delete Bee");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Legaly Distinct 3") {
            print("delete Sonic");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else {
            print("hello 2");
		}
	}
}
