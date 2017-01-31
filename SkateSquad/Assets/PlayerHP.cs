using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int hp;
    // Use this for initialization
    void Start()
    {
        if (hp <= 0)
        {
            hp = 3;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void hpminus()
    {
        hp = hp - 1;
    }
}

