using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float moveSpeed = 5.0f;
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
}
