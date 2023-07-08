using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    int Rando;
    int direction = 0;
    bool Sleep = true;
    bool Moving = false;
    bool MovingLeft = false;
    bool MovingRight = false;

    public float moveSpeed = 1;

    float ISeeRight;
    float ISeeLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Waking Code
        if (Sleep == true)
        {
            Rando = Random.Range(1, 1000);

            if (Rando <= 10)
            {
                Sleep = false;
            }
        }

        //Movement Code
        if (Sleep == false)
        {
            //Looking Right and Left
            LookRight();
            Debug.Log("Right: " + ISeeRight);
            LookLeft();
            Debug.Log("Left: " + ISeeLeft);

            if (Moving == false)
            {
                CheckDirection();
            }

            if (Moving == true)
            {
                if (MovingRight == true)
                {
                    MoveRight();
                }
                if (MovingLeft == true)
                { 
                    MoveLeft();
                }

                if (ISeeRight < 0.03f)
                {
                    MovingRight = false;
                    Moving = false;
                    MoveDown();
                }
                if (ISeeLeft < 0.03f)
                {
                    MovingLeft = false;
                    Moving = false;
                    MoveDown();
                }
            }

        }
 

    }

    float LookRight()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
        {
            ISeeRight = Mathf.Abs(hit.distance);
            return ISeeRight;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
        }
        else
        {
            ISeeRight = Mathf.Infinity;
            return ISeeRight;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            //Debug.Log("Did not Hit Right");
        }
    }

    float LookLeft()
    {
        RaycastHit hit2;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit2, Mathf.Infinity))
        {
            ISeeLeft = Mathf.Abs(hit2.distance);
            return ISeeLeft;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit2.distance, Color.yellow);
        }
        else
        {
            ISeeLeft = Mathf.Infinity;
            return ISeeLeft;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
            //Debug.Log("Did not Hit Left");
        }
    }

    void CheckDirection()
    {
        if (ISeeRight > ISeeLeft && MovingLeft == false)
        {
            Debug.Log("Moving Right");
            MovingRight = true;
            Moving = true;
        }

        if (ISeeLeft > ISeeRight && MovingRight == false)
        {
            Debug.Log("Moving Left");
            MovingLeft = true;
            Moving = true;
        }
    }


    void MoveRight()
    {
        Debug.Log("Move Right");
        MovingRight = true;
        this.transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0, 0);   
    }

    void MoveLeft()
    {
        Debug.Log("Move Left");
        MovingLeft = true;
        this.transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
    }

    void MoveDown()
    {
        Debug.Log("Move Down");
        this.transform.position = transform.position + new Vector3(0, 30 * -moveSpeed * Time.deltaTime, 0);
    }
}
