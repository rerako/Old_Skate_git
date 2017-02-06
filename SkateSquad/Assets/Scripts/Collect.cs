using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int collect;
    public shoot gun;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Collect"))
        {
            hit.gameObject.SetActive(false);
            gun.addammo();
            collect++;
        }
    }
}
