﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_rails : MonoBehaviour {
    float ratio;
    public float scroll;
    [Range(0f, 5f)]public float scroll_multiplier;
    public float push_force;
    public Transform startPos;
    public Transform scrollPos;
    public Transform endPos;
    public Transform grinder;
    public float total_dist;
    public float timer;
    public bool grinding;
    // Use this for initialization
    void Start () {
        total_dist = Vector3.Distance(startPos.position, endPos.position);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            grinding = false;
            grinder.GetComponent<Rigidbody>().AddForce((endPos.position - startPos.position).normalized * push_force);

            grinder = null;
        }
        if (grinding && scroll < 1)
        {
            timer += Time.deltaTime;
            scroll = Mathf.Clamp(scroll, 0, 1f);
            scroll += ((Time.deltaTime / total_dist) * scroll_multiplier) ;
            scrollPos.position = startPos.position + ((endPos.position - startPos.position) * scroll);
            grinder.position = scrollPos.position;
        }
        else if(grinding && scroll >= 1) {
            if (grinder.GetComponent<Rigidbody>() != null)
            {
                grinder.GetComponent<Rigidbody>().AddForce((endPos.position - startPos.position).normalized * push_force);

            }
            grinding = false;
            grinder = null;
        }

    }
    void OnTriggerEnter(Collider grind)
    {
        if (grind.gameObject.CompareTag("Player") && grinding == false)
        {
            grinder = grind.transform;
            grinding = true;
            grindPoint();
        }
    }
    void OnTriggerExit(Collider grind)
    {
        if (grind.gameObject.CompareTag("Player") && grinding == true)
        {
            grinder = null;
            grinding = false;
            scroll = 0;
        }
    }
    void grindPoint() {
        float p1 = Vector3.Distance(grinder.position, startPos.position);
        float p2 = Vector3.Distance(startPos.position, endPos.position);
        scroll = p1 / p2;
    }

}
