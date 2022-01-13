using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    PlayerAttributes playerAttributes;
    [SerializeField] float launchSpeed = 1000f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] ParticleSystem thrusters;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        playerAttributes = GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    private void PlayerControls()
    {
        //normalizing thrust speed
        float launch = launchSpeed * Time.deltaTime;

        //Engaging thrust y-positive relative to local y-axis. adding sound effects to thrust
        if (Input.GetKey(KeyCode.Space) && playerAttributes.hasFuel())
        {
            StartThrusting(launch);
        }
        else
        {
            StopThrusting();
        }
        //normalizing rotation and speed of rotation according to local z-axis.
        RotateRocket();
    }

    
    private void StartThrusting(float launch)
    {
        rb.AddRelativeForce(Vector3.up * launch);
        if (!audioSource.isPlaying && !thrusters.isPlaying)
        {
            foreach (AudioClip audio in audioClips)
            {
                if (audio.name == "SFX - Main engine thrust")
                {
                    audioSource.PlayOneShot(audio);
                    thrusters.Play();
                }
            }
        }
        playerAttributes.UsingFuel();
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        thrusters.Stop();
    }
    private void RotateRocket()
    {
        float horizontal = -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        rb.freezeRotation = true;
        transform.Rotate(0, 0, horizontal);
        rb.freezeRotation = false;
    }
}
