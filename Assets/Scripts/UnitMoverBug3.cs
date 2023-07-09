using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoverBug3 : MonoBehaviour
{
    int Rando;
    bool Sleep = true;
    bool Moving = false;
    bool MovingLeft = false;
    bool MovingRight = false;

    public float moveSpeed = 1;
    public float diagSpeed = 1;

    public Transform bulletSpawn;
    public GameObject bullet;
    public float nextFire = 3.0f;
    public float currentTime = 0.0f;

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
        //Waking Code
        if (Sleep == true)
        {
            Rando = Random.Range(1, 1000);

            if (Rando <= 10)
            {
                Sleep = false;
                //Add Bullet Firerer
                shoot();
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
                    MoveDownLeft();
                }
                if (ISeeLeft < 0.03f)
                {
                    MovingLeft = false;
                    Moving = false;
                    MoveDownRight();
                }
            }

        }
 

    }

    float LookRight()
    {
        RaycastHit hit5;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit5, Mathf.Infinity, layerMask))
        {
            ISeeRight = Mathf.Abs(hit5.distance);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit5.distance, Color.yellow);
            return ISeeRight;
        }
        else
        {
            ISeeRight = Mathf.Infinity;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            Debug.Log("Did not Hit Right");
            return ISeeRight;
        }
    }

    float LookLeft()
    {
        RaycastHit hit6;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit6, Mathf.Infinity, layerMask))
        {
            ISeeLeft = Mathf.Abs(hit6.distance);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit6.distance, Color.yellow);
            return ISeeLeft;
        }
        else
        {
            ISeeLeft = Mathf.Infinity;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
            Debug.Log("Did not Hit Left");
            return ISeeLeft;
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
        this.transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, diagSpeed * -moveSpeed * Time.deltaTime, 0);
        Rando = Random.Range(1, 1000);
        if (Rando == 1)
        {
            Sleep = true;
        }
    }

    void MoveLeft()
    {
        Debug.Log("Move Left");
        MovingLeft = true;
        this.transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, diagSpeed * -moveSpeed * Time.deltaTime, 0);
        Rando = Random.Range(1, 1000);
        if (Rando == 1)
        {
            Sleep = true;
        }
    }

    void MoveDownRight()
    {
        Debug.Log("Move Down");
        this.transform.position = transform.position + new Vector3(0, 10 * -moveSpeed * Time.deltaTime, 0);
        Rando = Random.Range(1, 1000);
        if (Rando == 1)
        {
            Sleep = true;
        }
    }
    void MoveDownLeft()
    {
        Debug.Log("Move Down");
        this.transform.position = transform.position + new Vector3(0, 10 * -moveSpeed * Time.deltaTime, 0);
        Rando = Random.Range(1, 1000);
        if (Rando == 1)
        {
            Sleep = true;
        }
    }

    public void shoot()
    {
        currentTime += Time.deltaTime;

        if (currentTime > nextFire)
        {
            nextFire += currentTime;

            Instantiate(bullet, -(bulletSpawn.position + new Vector3(0, 0.7f, 0)), Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;

            nextFire = Random.Range(1.5f, 3.0f);
        }
    }
}
