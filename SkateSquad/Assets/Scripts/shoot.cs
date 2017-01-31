using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject original;
    public float Xaxis;
    public float Yaxis;
    camScript angle;
    Vector3 localRotation;
    public Transform shootpoint;
    public int ammo;

    // Use this for initialization
    void Start()
    {
        angle = transform.parent.GetComponent<camScript>();
        if (shootpoint == null)
        {
            shootpoint = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Xaxis = angle.giveAxisX();
        Yaxis = angle.giveAxisY();
        transform.rotation = Quaternion.Euler(Xaxis, Yaxis, 0.0f);


        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            GameObject bullet = Instantiate(original, shootpoint.position, shootpoint.rotation) as GameObject;
            bullet.GetComponent<boomerang>().setTarg(transform.parent, gameObject.GetComponent<shoot>());
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
            ammo--;
        }

    }

    public void addammo()
    {
        ammo++;
    }

}
