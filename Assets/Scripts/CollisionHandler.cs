using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("On Friendly Ground");
                break;
            case "Finish":
                Debug.Log($"Congrats! You Won!");
                SceneManager.LoadScene(++currentSceneIndex);
                break;
            case "Fuel":
                Debug.Log("Got some fuel.");
                break;
            default:
                ReloadScene(currentSceneIndex);
                break;

        }
    }

    private static void ReloadScene(int currentSceneIndex)
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
