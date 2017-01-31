using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

    public float movementSpeed = 0.0f;
    public float airRate = 0.0f;
    public float minSpeed = 0.0f;
    public float maxSpeed = 0.0f;
    public float moveRate = 0.0f;
    public float jumpSpeed = 0.0f;

    public float mouseSens = 0.0f;
    float verRotate = 0;
    public float upDownRange = 0.0f;

    float verVelocity = 0;
    public CharacterController cc;


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cc = GetComponent<CharacterController>();
        movementSpeed = minSpeed;
    }

    // Update is called once per frame
    void FixedUpdate() {


        // Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSens;
        transform.Rotate(0, rotLeftRight, 0);

        verRotate -= Input.GetAxis("Mouse Y") * mouseSens;
        verRotate = Mathf.Clamp(verRotate, -upDownRange, upDownRange);
        //Camera.main.transform.localRotation = Quaternion.Euler(verRotate, 0, 0);

        // Movement


        float forwardSpeed;

        // speed decreasing while in air
        if(movementSpeed > minSpeed && !cc.isGrounded)
        {
                movementSpeed -= airRate;
        }
        
        //braking button
        else if (Input.GetButton("Fire3")) {
            if (movementSpeed > minSpeed) {
                movementSpeed -= moveRate * 3;
            }

        }
        // Gaining speed when pressing w
        else if (Input.GetButton("Vertical")) {
            if (movementSpeed < maxSpeed) {
                movementSpeed += moveRate;
            }

        }


        //decreasing speed when not pressing w 
        else
        {
            if (movementSpeed > minSpeed)
            {
                movementSpeed -= moveRate;
            }
        }
        forwardSpeed = movementSpeed;

        float sideSpeed = 0.0f;

        //side-to-side movement
        if (cc.isGrounded)
        { 
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        }

        //gravity
        verVelocity += (Physics.gravity.y) * Time.deltaTime;

        //Jump
        if (cc.isGrounded && Input.GetButton("Jump"))
        {
            verVelocity = jumpSpeed;
        }



        Vector3 speed = new Vector3(sideSpeed, verVelocity, forwardSpeed);
        speed = transform.rotation * speed;
        cc.Move(speed* Time.fixedDeltaTime);

    }
}
