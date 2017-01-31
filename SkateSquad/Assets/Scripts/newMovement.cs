using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour {
    public Rigidbody rb;
    public float mForce = 10;
    public float acceleration = 1;
    public float deceleration = 0.5f;
    public float maxSpeed = 50;
    public Vector3 playerVelocity;
     
    

    public Vector3 forwardVector;
    
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
    // Update is called once per frame
    void Update () {
        if (Input.GetKey("w"))
        {
            
            if( mForce < maxSpeed)
            {
                mForce += acceleration;
            }
            
        }
        else if (Input.GetKey("s"))
        {
            
            if(mForce > 0)
            {
                mForce  *= (deceleration / 100);
            }
        }
        
        else
        {
            if (mForce > 0)
            {
                mForce *= deceleration;
            }
        }
        if (Input.GetKey("space") /*&& GetComponent<CharacterController>().isGrounded*/)
        {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }
    }

    void FixedUpdate()

    {
        playerVelocity = rb.velocity;


        forwardVector = new Vector3(0, 0, mForce);


        GetComponent<Rigidbody>().AddRelativeForce(forwardVector, ForceMode.Force);
    }
}
