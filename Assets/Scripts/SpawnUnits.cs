using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float nextSpawn = 5.0f;
    public float nextSpawn2 = 1.0f;

    [SerializeField]
    public GameObject[] MobsPrefabs;

    GameObject ButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        UnitSelector Selector = this.GetComponent<UnitSelector>();
        ButtonPressed = GameObject.Find("Button Unpressed");
    }

    // Update is called once per frame
    void Update()
    {
        if(WorldState == true && Input.GetKeyDown(KeyCode.Space) == true && UnitSelector.Counter != 3)
        {
            Debug.Log("Spawner Counter: " + UnitSelector.Counter + " : " + MobsPrefabs[UnitSelector.Counter]);
            ToSpawn = MobsPrefabs[UnitSelector.Counter];
            Instantiate(ToSpawn, this.transform.position, this.transform.rotation);
            WorldState = false;
        }

        if (WorldState2 == true && Input.GetKeyDown(KeyCode.Space) == true && UnitSelector.Counter == 3)
        {
            Debug.Log("Money.Wav");
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

    }
}
