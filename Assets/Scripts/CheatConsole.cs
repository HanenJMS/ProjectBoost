using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatConsole : MonoBehaviour
{
    void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.L))
        {
            index++;
            SceneManager.LoadScene(index);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = !this.gameObject.GetComponent<BoxCollider>().enabled;
        }
    }
}
