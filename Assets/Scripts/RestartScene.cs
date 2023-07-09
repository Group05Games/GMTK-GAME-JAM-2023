using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void restartLevel() {
        if (this.isActiveAndEnabled) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Sprite Clicked");
        }
        else {
            Debug.Log("Sprite Clicked but Inactive");
        }
    }

    void OnMouseDown() {
        restartLevel();
    }
}
