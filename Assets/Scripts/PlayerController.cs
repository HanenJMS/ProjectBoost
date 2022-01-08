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
        float launch = launchSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0, launch, 0);
        }

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, launch, 0);
        }
        float horizontal = -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        rb.freezeRotation = true;
        transform.Rotate(0, 0, horizontal);
        rb.freezeRotation = false;
    }
}
