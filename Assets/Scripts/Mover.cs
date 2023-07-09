using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float moveSpeed = 3.0f;

    float ISeeRight;
    float ISeeLeft;

    int layerMask = 1 << 8;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookRight();
        LookLeft();

        if (Input.GetKey(KeyCode.D) == true && ISeeRight > 0.1f)
        {
            this.transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) == true && ISeeLeft > 0.1f)
        {
            this.transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    float LookRight()
    {
        RaycastHit hit7;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit7, Mathf.Infinity, layerMask))
        {
            ISeeRight = Mathf.Abs(hit7.distance);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit7.distance, Color.blue);
            return ISeeRight;
        }
        else
        {
            ISeeRight = Mathf.Infinity;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.red);
            Debug.Log("Did not Hit Right");
            return ISeeRight;
        }
    }

    float LookLeft()
    {
        RaycastHit hit8;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit8, Mathf.Infinity, layerMask))
        {
            ISeeLeft = Mathf.Abs(hit8.distance);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit8.distance, Color.blue);
            return ISeeLeft;
        }
        else
        {
            ISeeLeft = Mathf.Infinity;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.red);
            Debug.Log("Did not Hit Left");
            return ISeeLeft;
        }
    }
}
