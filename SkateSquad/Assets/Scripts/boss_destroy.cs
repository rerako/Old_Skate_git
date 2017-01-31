using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_destroy : MonoBehaviour
{
    public GameObject[] weakpoints;
    public int HP_numb;
    bool am_dead;
    // Use this for initialization
    void Start()
    {
        am_dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (kill_check())
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;

        }

    }

    private bool kill_check()
    {
        am_dead = false;
        for (int x = 0; x < HP_numb; x++)
        {
            if (weakpoints[x] != null)
            {
                am_dead = false;
                return am_dead;
            }
        }
        am_dead = true;
        return am_dead;
    }
}
