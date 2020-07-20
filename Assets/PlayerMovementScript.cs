using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float ForwardForce = 2000f, SidewaysForce = 500f;
    Rigidbody rb;
    public bool SphereOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, ForwardForce * Time.deltaTime);
        if (Input.GetKey("right"))
        {
            if (transform.position.x > 5.04f)
            {
                transform.position = new Vector3(5.04f, transform.position.y, transform.position.z);
                
            }
            rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        if (Input.GetKey("left"))
        {
            if(transform.position.x< -5.04f)
            {
                transform.position = new Vector3(-5.04f, transform.position.y, transform.position.z);
                
            }
            rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetButton("Jump") && SphereOnGround)
        {
            rb.AddForce(new Vector3(0, 6, 0) , ForceMode.Impulse);
            SphereOnGround = false;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        
        SphereOnGround = true;
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Finish"))
        {
            ForwardForce = 0f;
            SidewaysForce = 0f;
            Time.timeScale = 0;
        }
    }
}
