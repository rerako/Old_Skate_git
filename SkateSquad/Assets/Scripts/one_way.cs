using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class one_way : MonoBehaviour
{
    public float speed;
    public bool poke;
    public float timer = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Terrain") || hit.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
