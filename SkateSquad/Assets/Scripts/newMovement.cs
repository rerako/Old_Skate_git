using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float mForce = 10;
    public float acceleration = 1;
    public float deceleration = 0.5f;
    public float maxSpeed = 50;
    public float jump_pow = 5;
    private float fall_speed = 0;
    public float fall_speed_multiplier = 0;
    public float B_pad_force;
    public float horizontal_speed;
    public Vector3 playerVelocity;
    public Vector3 forwardVector;
    public Transform Right;
    public bool left_wall;
    public bool right_wall;

    RaycastHit hit;
    Vector3 dir;
    RaycastHit hitR;
    Vector3 dirR;
    RaycastHit hitL;
    Vector3 dirL;

    public bool grounded;
    public bool wall_running;
    public float wall_jump;

    public GameObject right_feed;
    public GameObject left_feed;


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
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.AddForce(transform.right * Input.GetAxis("Horizontal") * horizontal_speed);
        }
        if (Input.GetKeyDown("space") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump_pow, rb.velocity.z);
        }



    }

    void FixedUpdate()
    {
        playerVelocity = rb.velocity;
        forwardVector = new Vector3(0, 0, mForce);
        rb.AddRelativeForce(forwardVector, ForceMode.Force);

        ground_check();

        top_speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        dirL = (Right.position - transform.position).normalized * -1;
        dirR = (Right.position - transform.position).normalized;
        if (left_wall)
        {
            left_feed.SetActive(true);

            if (Input.GetKey("space"))
            {
                rb.velocity = new Vector3(rb.velocity.x, 15, rb.velocity.z);
                rb.AddForce(dirL * -wall_jump, ForceMode.Impulse);
                //rb.AddForce(transform.up * wall_jump * 2);
                fall_speed = -0.25f;
            }
            
        }
        else if (right_wall)
        {
            right_feed.SetActive(true);

            if (Input.GetKey("space"))
            {
                rb.velocity = new Vector3(rb.velocity.x, 15, rb.velocity.z);
                rb.AddForce(dirR * -wall_jump, ForceMode.Impulse);
                //rb.AddForce(transform.up * wall_jump * 2);
                fall_speed = -0.25f;
            }


        }
        if (!grounded && top_speed > 1 && Physics.Raycast(transform.position, dirL, out hitL, 1.0f) && Physics.Raycast(transform.position, dirR, out hitR, 1.0f))
        {

        }
        else if (!grounded && top_speed > 1 && Physics.Raycast(transform.position, dirR, out hitR, 1.0f))
        {
            walljumpR();

        }
        else if (!grounded && top_speed > 1 && Physics.Raycast(transform.position, dirL, out hitL, 1.0f))
        {
            walljumpL();

        }
        else
        {
            wall_running = false;
            left_wall = false;
            right_wall = false;
            right_feed.gameObject.SetActive(false);
            left_feed.gameObject.SetActive(false);


        }

    }

    public void g_physic()
    {
        grounded = true;
    }
    public void ground_check()
    {

        if (Physics.Raycast(transform.position, dir, out hit, 1.5f))
        {

            if (hit.transform.gameObject.CompareTag("Terrain") || hit.transform.gameObject.CompareTag("Rail"))
            {            //the ray collided with something, you can interact
                         // with the hit object now by using hit.collider.gameObject
                grounded = true;
                fall_speed = 0;
            }

        }
        else if (!Physics.Raycast(transform.position, dir, out hit, 1.5f))
        {

            grounded = false;
            if (wall_running == false)
            {
                fall_speed -= Time.deltaTime * fall_speed_multiplier;

            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + fall_speed, rb.velocity.z);


        }

    }
    void OnTriggerEnter(Collider boing)
    {
        if (boing.gameObject.CompareTag("Bounce"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + B_pad_force, rb.velocity.z);
        }
        if (boing.gameObject.CompareTag("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        }
    }
    public void air_physic()
    {
        grounded = false;
    }
    public void walljumpR()
    {
        if (hitR.transform.CompareTag("Terrain"))
        {
            wall_running = true;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            right_wall = true;


        }
    }
    public void walljumpL()
    {
        if (hitL.transform.CompareTag("Terrain"))
        {
            wall_running = true;
            rb.velocity = new Vector3(rb.velocity.x, 0.01f, rb.velocity.z);
            left_wall = true;

        }
    }
}
