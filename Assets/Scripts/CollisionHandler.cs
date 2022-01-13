using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float sceneDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem[] particleSystems;

    bool isTransitioning = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) return;
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("On Friendly Ground");
                break;
            case "Finish":
                StartNextLevelSequene();
                break;
            case "Fuel":
                Debug.Log("Got some fuel.");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartNextLevelSequene()
    {
        isTransitioning = true;
        //TODO add Confetti
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(success);
        foreach (ParticleSystem ps in particleSystems)
        {
            if (ps.name.Equals("Success Particles"))
            {
                ps.Play();
            }

        }
        this.gameObject.GetComponent<PlayerController>().enabled = false;
        Invoke("LoadNextScene", sceneDelay);
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        foreach(ParticleSystem ps in particleSystems)
        {
            if (ps.name.Equals("Explosion Particles"))
            {
                ps.Play();
            }
                
        }
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(crash);
        //TODO add SFX + Particle effects on Crash
        this.gameObject.GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadScene", sceneDelay);
    }

    void LoadNextScene()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings)
            currentSceneIndex = 0;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
