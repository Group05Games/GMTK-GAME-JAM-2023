using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int lives;
    private int score;

    public Transform bulletSpawn;
    public GameObject bullet;
    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    bool Moving = false;
    bool MovingLeft = false;
    bool MovingRight = false;

    public float moveSpeed = 1.5f;

    float ISeeRight;
    float ISeeLeft;

    int layerMask = 1 << 8;

    float MoveRando = .03f;

    private WalletManager EnemyWallet;
    public float nextScore = 1.0f;
    public float currentTimeScore = 0.0f;

    public int LifeCounter = 3;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject WinScreen;

    public AudioSource audioSource;
    public AudioClip ShootClip3;

    // Start is called before the first frame update
    void Start()
    {
        //Bullet bullet = new Bullet(bulletSpeed, "enemy");
        bulletSpawn = this.gameObject.transform;
        //print(bulletSpawn.transform.position.x);

        EnemyWallet = GameObject.Find("EnemyScore").gameObject.GetComponent<WalletManager>();
        WinScreen = FindObjectOfType<RestartScene>(true).gameObject;
        Debug.Log(WinScreen.ToString());
    }

    // Update is called once per frame
    void Update() {
        shoot();

        LookRight();
        //Debug.Log("Right: " + ISeeRight);
        LookLeft();
        //Debug.Log("Left: " + ISeeLeft);

        Debug.Log(MoveRando);

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

            if (ISeeRight < MoveRando)
            {
                MovingRight = false;
                Moving = false;
            }
            if (ISeeLeft < MoveRando)
            {
                MovingLeft = false;
                Moving = false;
            }
        }

        MoneyGen();
    }

    public void shoot() {
        currentTime += Time.deltaTime;

        if (currentTime > nextFire) {
            nextFire += currentTime;

            Instantiate(bullet, bulletSpawn.position + new Vector3(0, 0.7f, 0), Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;

            MoveRando = Random.Range(0.03f, 1.0f);
            nextFire = Random.Range(1, 3);
		}
	}


float LookRight()
{
    RaycastHit hit;

    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity, layerMask))
    {
        ISeeRight = Mathf.Abs(hit.distance);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.magenta);
        return ISeeRight;
    }
    else
    {
        ISeeRight = Mathf.Infinity;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.green);
        Debug.Log("Did not Hit Right");
        return ISeeRight;
    }
}

float LookLeft()
{
    RaycastHit hit2;

    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit2, Mathf.Infinity, layerMask))
    {
        ISeeLeft = Mathf.Abs(hit2.distance);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit2.distance, Color.magenta);
        return ISeeLeft;
    }
    else
    {
        ISeeLeft = Mathf.Infinity;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.green);
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
    this.transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0, 0);
}

void MoveLeft()
{
    Debug.Log("Move Left");
    MovingLeft = true;
    this.transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
}

public void MoneyGen()
{
    currentTimeScore += Time.deltaTime;

    if (currentTimeScore > nextScore)
    {
        nextScore += currentTimeScore;

        nextScore -= currentTimeScore;
        currentTimeScore = 0.0f;
        EnemyWallet.addScore(1);
    }
}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Enemy" && collision.gameObject.name != "Bullet(Clone)")
        {
            LifeCounter--;
            audioSource.PlayOneShot(ShootClip3);
            if (LifeCounter == 2)
            {
                Life2.SetActive(false);
            }
            else if(LifeCounter == 1)
            {
                Life1.SetActive(false);
            }
            else if(LifeCounter == 0)
            {
                Debug.Log("You Win");
                WinScreen.SetActive(true);
                Destroy(this.gameObject);
            }
            
            Destroy(collision.gameObject);
        }
        else
        {
            print("Crash");
        }
    }
}
