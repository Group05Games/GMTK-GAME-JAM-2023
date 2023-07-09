using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript1 : MonoBehaviour
{
    private Rigidbody2D projectile;
    public float moveSpeed = 3.0f;

    [Serialize]
    public AudioSource audioSource;
    public AudioClip ShootClip2;

    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
        audioSource.PlayOneShot(ShootClip2);
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(0, -1) * moveSpeed;
    }

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Bounding Box Bottom") {
            print("delete ally bullet");
            Destroy(this.gameObject);
		}
        else {
            print("hello from ally bullet");
		}
    }
}
