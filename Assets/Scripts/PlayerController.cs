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
            rb.AddRelativeForce(Vector3.up * launch);
            if (!audioSource.isPlaying)
                audioSource.Play();
            playerAttributes.UsingFuel();
        }
        else
        {
            audioSource.Stop();
        }
        //normalizing rotation and speed of rotation according to local z-axis.
        float horizontal = -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        rb.freezeRotation = true;
        transform.Rotate(0, 0, horizontal);
        rb.freezeRotation = false;
    }
}
