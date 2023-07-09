using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnUnits : MonoBehaviour
{
    //WorldState is used to define if you can spawn a unit- false you can't spawn,
    //true you can spawn.
    bool WorldState = true;
    bool WorldState2 = true;
    public GameObject ToSpawn;
    public GameObject Spawn;
    public float WorldTime = 0.0f;
    public float WorldTime2 = 0.0f;
    public float nextSpawn = 0.5f;
    public float nextSpawn2 = 1.0f;

    [SerializeField]
    public GameObject[] MobsPrefabs;

    GameObject ButtonPressed;
    public GameObject ErrorMessage;

    private WalletManager PlayerWallet;
    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    public AudioSource audioSource;
    public AudioClip MoneyClip;


    // Start is called before the first frame update
    void Start()
    {
        UnitSelector Selector = this.GetComponent<UnitSelector>();
        ButtonPressed = GameObject.Find("Button Unpressed");

        PlayerWallet = GameObject.Find("PlayerScore").gameObject.GetComponent<WalletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WorldState == true && Input.GetKeyDown(KeyCode.Space) == true && UnitSelector.Counter != 3)
        {
            Debug.Log("Spawner Counter: " + UnitSelector.Counter + " : " + MobsPrefabs[UnitSelector.Counter]);
            ToSpawn = MobsPrefabs[UnitSelector.Counter];
            if (UnitSelector.Counter == 0)
            {
                if (PlayerWallet.getScore() >= 10)
                {
                    PlayerWallet.subtractScore(10);
                    Instantiate(ToSpawn, this.transform.position, this.transform.rotation);
                }
                else
                {
                    Debug.Log("Failure to Spawn 10 Cost");
                    ErrorMessage.SetActive(true);
                }
            }
            else if (UnitSelector.Counter == 1)
            {
                if (PlayerWallet.getScore() >= 50)
                {
                    PlayerWallet.subtractScore(50);
                    Instantiate(ToSpawn, this.transform.position, this.transform.rotation);
                }
                else
                {
                    Debug.Log("Failure to Spawn 50 Cost");
                    ErrorMessage.SetActive(true);
                }
            }
            else if (UnitSelector.Counter == 2)
            {
                if (PlayerWallet.getScore() >= 100)
                {
                    PlayerWallet.subtractScore(100);
                    Instantiate(ToSpawn, this.transform.position, this.transform.rotation);
                }
                else
                {
                    Debug.Log("Failure to Spawn 100 Cost");
                    ErrorMessage.SetActive(true);
                }
            }



            WorldState = false;
        }

        if (WorldState2 == true && Input.GetKeyDown(KeyCode.Space) == true && UnitSelector.Counter == 3)
        {
            Debug.Log("Money.Wav");
            audioSource.PlayOneShot(MoneyClip);
            PlayerWallet.addScore(5);
            print("Test " + PlayerWallet.getScore());
            WorldState2 = false;
        }

        if (WorldState == false)
        {
            WorldTime += Time.deltaTime;

            if (WorldTime > nextSpawn)
            {
                nextSpawn += WorldTime;

                nextSpawn -= WorldTime;
                WorldTime = 0.0f;
                WorldState = true;
            }
        }

        if (WorldState2 == false)
        {
            ButtonPressed.SetActive(false);
            WorldTime2 += Time.deltaTime;

            if (WorldTime2 > nextSpawn2)
            {
                nextSpawn2 += WorldTime2;

                nextSpawn2 -= WorldTime2;
                WorldTime2 = 0.0f;
                ButtonPressed.SetActive(true);
                WorldState2 = true;
            }
        }

        
        MoneyGen();

    }

    public void MoneyGen()
    {   
        currentTime += Time.deltaTime;

        if (currentTime > nextFire)
        {
            nextFire += currentTime;

            nextFire -= currentTime;
            currentTime = 0.0f;
            ErrorMessage.SetActive(false);
            PlayerWallet.addScore(1 + GetMoneyMod());
        }
    }

    public int GetMoneyMod()
    {
        int MoneyMod = 0;

        if (PlayerWallet.getScore() < 100 )
        {
            MoneyMod = 1;
        }
        else if (PlayerWallet.getScore() >= 100 && PlayerWallet.getScore() < 200)
        {
            MoneyMod = 2;
        }
        else if (PlayerWallet.getScore() >= 200 && PlayerWallet.getScore() < 300)
        {
            MoneyMod = 3;
        }
        else if (PlayerWallet.getScore() >= 300)
        {
            MoneyMod = 4;
        }

        return MoneyMod;
    }
}
