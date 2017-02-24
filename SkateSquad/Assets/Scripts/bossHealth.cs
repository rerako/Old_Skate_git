using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossHealth : MonoBehaviour {
    public boss_destroy boss;
    public float hp;
    public Slider hpSlide;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hp = divide(boss.check_life(), boss.get_hp());
        hpSlide.value = hp;
        if (boss.check_life() <= 0)
        {
            gameObject.SetActive(false);
        }
	}
    public float divide(float a, float b)
    {
        return a / b;
    }
}
