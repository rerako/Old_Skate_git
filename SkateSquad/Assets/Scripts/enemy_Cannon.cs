using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Cannon : MonoBehaviour
{
    public GameObject e_bullet;
    public GameObject player;
    public Transform shootpoint;
    public bool lockon;
    public float timer;
    public float force;
    public bool trace_bullet;
    public float follow_speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {

        }
        else
        {
            shootpoint.LookAt(player.transform.position);
            //transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, 1f * Time.deltaTime);
        }
        if (lockon && timer < 0)
        {
            GameObject bullet = Instantiate(e_bullet, shootpoint.position, shootpoint.rotation) as GameObject;
            if (player != null)
            {

                if (trace_bullet)
                {
                    bullet.GetComponent<boomerang>().setTarg(player.transform);
                    bullet.GetComponent<Rigidbody>().AddForce(shootpoint.forward * force);

                    bullet.GetComponent<boomerang>().setFollow(follow_speed);
                }
            }
            timer = 2f;

        }
        else if (lockon && timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider poke)
    {
        if (poke.gameObject.CompareTag("Player")) {
            lockon = true;
            player = poke.gameObject;
        }


    }
    void OnTriggerExit(Collider poke)
    {
        if (poke.gameObject.CompareTag("Player"))
        {
            lockon = false;
            //player = null;
        }
    }
}
