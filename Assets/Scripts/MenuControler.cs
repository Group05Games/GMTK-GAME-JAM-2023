using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    int Counter = 0;

    public GameObject TButton;
    public GameObject SButton;
    public GameObject CButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            --Counter;
            if (Counter == -1)
            {
                Counter = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            ++Counter;
            if (Counter == 3)
            {
                Counter = 0;
            }
        }

        if (Counter == 0)
        {
            TButton.SetActive(true);
            SButton.SetActive(false);
            CButton.SetActive(false);
        }
        else if (Counter == 1)
        {
            TButton.SetActive(false);
            SButton.SetActive(true);
            CButton.SetActive(false);
        }
        else if (Counter == 2)
        {
            TButton.SetActive(false);
            SButton.SetActive(false);
            CButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (Counter == 0)
            {
                SceneManager.LoadScene(2);
            }
            else if (Counter == 1)
            {
                SceneManager.LoadScene(1);
            }
            if (Counter == 2)
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
