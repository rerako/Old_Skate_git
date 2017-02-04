using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float mForce = 10;
    public float acceleration = 1;
    public float deceleration = 0.5f;
    public float maxSpeed = 50;
    public float jump_pow = 5;
    public float fall_speed = 0;
    public float fall_speed_multiplier = 0;

    public Vector3 playerVelocity;
    public Vector3 forwardVector;
    RaycastHit hit;
    Vector3 dir;

    public bool grounded;
    /*
    public float speed;
    public float top_speed;
    public Vector3 velo;
    public Vector3 motion;
    public float motor;
    public float T_motor;
        */



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = Vector3.down;
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("w"))
        {

            if (mForce < maxSpeed)
            {
                mForce += acceleration;
            }

        }
        else if (Input.GetKey("s"))
        {

            if (mForce > 0)
            {
                mForce *= (deceleration / 100);
            }
        }

        else
        {
            if (mForce > 0)
            {
                mForce *= deceleration;
            }
        }
        if (Input.GetKey("space") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump_pow, rb.velocity.z);
        }
        Debug.DrawRay(transform.position, dir * 2, Color.blue);
        if (Physics.Raycast(transform.position, dir, 2f))
        {
            //the ray collided with something, you can interact
            // with the hit object now by using hit.collider.gameObject
            grounded = true;
            fall_speed = 0;
        }
        else
        {
            grounded = false;
            fall_speed -= Time.deltaTime / fall_speed_multiplier;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + fall_speed, rb.velocity.z);
            //nothing was below your gameObject within 10m.
        }
        /*
    */




    }

    void FixedUpdate()

    {

        playerVelocity = rb.velocity;


        forwardVector = new Vector3(0, 0, mForce);


        rb.AddRelativeForce(forwardVector, ForceMode.Force);
        /*
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            velo = Vector3.Normalize(motion);
            //motor = Mathf.Abs(motion.x) + Mathf.Abs(motion.z);
            //T_motor = (1 / motor);
            //velo = rb.velocity;
        }
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && grounded)
        {
            rb.velocity = (speed * velo);
            //rb.AddForce(velo * speed * T_motor * Input.GetAxis("Vertical"));

        }

        top_speed = rb.velocity.magnitude;
        */
    }
    public void g_physic()
    {
        grounded = true;
    }
    public void air_physic()
    {
       grounded = false;
    }
}
