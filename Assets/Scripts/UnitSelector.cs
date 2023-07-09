using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    [SerializeField]
    public static int Counter = 0;
    [SerializeField]
    public int[] value = { 0, 1, 2, 3 };
    [SerializeField]
    public GameObject[] SelectorBox;
    [SerializeField]
    public GameObject[] MobsPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        //SelectorBox[1] = GameObject.Find("Selector 1");
        //SelectorBox[2] = GameObject.Find("Selector 2");
        //SelectorBox[3] = GameObject.Find("Selector 3");
        //SelectorBox[4] = GameObject.Find("Selector 4");
    }

    // Update is called once per frame
    void Update()
    {
        Vizualizer();

        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            --Counter;
            if (Counter == -1)
            {
                Counter = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            ++Counter;
            if (Counter == 4)
            {
                Counter = 0;
            }
        }

        
    }

    void Vizualizer()
    {
        Debug.Log("Vizual: " + Counter);
        for(int i = 0; i <SelectorBox.Length; i++)
        {
            if (Counter == 0)
            {
                SelectorBox[0].SetActive(true);
                SelectorBox[1].SetActive(false);
                SelectorBox[2].SetActive(false);
                SelectorBox[3].SetActive(false);
            }
            if (Counter == 1)
            {
                SelectorBox[0].SetActive(false);
                SelectorBox[1].SetActive(true);
                SelectorBox[2].SetActive(false);
                SelectorBox[3].SetActive(false);
            }
            if (Counter == 2)
            {
                SelectorBox[0].SetActive(false);
                SelectorBox[1].SetActive(false);
                SelectorBox[2].SetActive(true);
                SelectorBox[3].SetActive(false);
            }
            if (Counter == 3)
            {
                SelectorBox[0].SetActive(false);
                SelectorBox[1].SetActive(false);
                SelectorBox[2].SetActive(false);
                SelectorBox[3].SetActive(true);
            }
        }

        /*Debug.Log("1:" + SelectorBox[0]);
        Debug.Log("2:" + SelectorBox[1]);
        Debug.Log("3:" + SelectorBox[2]);
        Debug.Log("4:" + SelectorBox[3]);*/
    }

}
