using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour {
    public float hp;
    public float max_hp;
    public GameObject droid;
    public float rate;
    public int repair_bots;
    // Use this for initialization
    void Start () {
        hp = max_hp;
	}
	
	// Update is called once per frame
	void Update () {
		if(hp < max_hp)
        {
            //send droids

            
        }

        if(repair_bots > 0)
        {
            if(hp < max_hp)
            {
                hp += Time.deltaTime * repair_bots * rate;

            }
            else
            {
                //turn off droids
            }
        }
	}
}
