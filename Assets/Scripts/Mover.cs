using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
