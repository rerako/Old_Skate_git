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
    public float B_pad_force;
    public Vector3 playerVelocity;
    public Vector3 forwardVector;
    public Transform Right;
    RaycastHit hit;
    Vector3 dir;
    RaycastHit hitR;
    Vector3 dirR;
    RaycastHit hitL;
    Vector3 dirL;

    public bool grounded;
    public bool wall_running;
    public float wall_jump;


    public float top_speed;

    /*
    public float speed;
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
  


    }

    void FixedUpdate()
    {
        playerVelocity = rb.velocity;
        forwardVector = new Vector3(0, 0, mForce);
        rb.AddRelativeForce(forwardVector, ForceMode.Force);
        Debug.DrawRay(transform.position, dir * 2, Color.blue);
        if (Physics.Raycast(transform.position, dir, 1.5f))
        {
            //the ray collided with something, you can interact
            // with the hit object now by using hit.collider.gameObject
            grounded = true;
            fall_speed = 0;
        }
        else
        {
            grounded = false;
            if (wall_running == false) {
                fall_speed -= Time.deltaTime / fall_speed_multiplier;

            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + fall_speed, rb.velocity.z);
            //nothing was below your gameObject within 10m.
        }
        /*
    */
        //Debug.DrawRay(transform.position, Vector3.Normalize(transform.TransformPoint(dirL * 1)), Color.blue);
        Debug.DrawRay(transform.position, dirR * 2, Color.blue);
        Debug.DrawRay(transform.position, dirL * 2, Color.blue);

        top_speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        dirL = (Right.position - transform.position).normalized * -1;
        dirR = (Right.position - transform.position).normalized;

        if (!grounded && top_speed > 1 && Physics.Raycast(transform.position, dirR, 1))
        {
            wall_running = true;

            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            if (Input.GetKey("space"))
            {
                //rb.velocity = new Vector3(rb.velocity.x, jump_pow, rb.velocity.z);
                rb.AddForce(dirR * -wall_jump);
                rb.AddForce(transform.up * wall_jump);

            }
        }
        else if (!grounded && top_speed > 1 && Physics.Raycast(transform.position, dirL,1))
        {
            wall_running = true;
            rb.velocity = new Vector3(rb.velocity.x, 0.01f, rb.velocity.z);
            if (Input.GetKey("space"))
            {
                //rb.velocity = new Vector3(rb.velocity.x, jump_pow, rb.velocity.z);
                rb.AddForce(dirL * -wall_jump);
                rb.AddForce(transform.up * wall_jump);
            }
        }
        else {
            wall_running = false;
        }

    }

    public void g_physic()
    {
        grounded = true;
    }

    void OnTriggerEnter(Collider boing)
    {
        if (boing.gameObject.CompareTag("Bounce"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + B_pad_force, rb.velocity.z);
        }
    }
    public void air_physic()
    {
       grounded = false;
    }
}
