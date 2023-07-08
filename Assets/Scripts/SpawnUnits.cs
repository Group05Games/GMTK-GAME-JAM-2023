using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    //WorldState is used to define if you can spawn a unit- false you can't spawn,
    //true you can spawn.
    new bool WorldState = true;
    public GameObject ToSpawn;
    int WorldCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WorldState == true && Input.GetKeyDown(KeyCode.Space) == true)
        {
            Instantiate(ToSpawn, this.transform.position, this.transform.rotation);
            WorldState = false;
        }

        if (WorldState == true)
        {
            WorldCounter = Random.Range(1, 1000);

            if (Rando <= 10)
            {
                Sleep = false;
            }
        }

    }
}
