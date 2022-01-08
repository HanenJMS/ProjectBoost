using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float launchSpeed = 1000f;
    [SerializeField] float rotateSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        //Engaging thrust y-positive relative to local y-axis
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * launch);
        }

        //normalizing rotation and speed of rotation according to local z-axis.
        float horizontal = -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        rb.freezeRotation = true;
        transform.Rotate(0, 0, horizontal);
        rb.freezeRotation = false;
    }
}
