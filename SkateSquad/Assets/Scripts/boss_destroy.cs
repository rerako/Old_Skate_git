using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_destroy : MonoBehaviour
{
    public List<GameObject> weak_spots;
    private int HP_numb;
    public int max_hp;
    public float dmg;
    //bool am_dead;
    // Use this for initialization
    void Start()
    {
        HP_numb = weak_spots.Count;
        //am_dead = false;
        if(max_hp == 0)
        {
            max_hp = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        kill_check();


    }

    private void kill_check()
    {
        int dmg_total = 0;
        for (int x = 0; x < HP_numb; x++)
        {
            if (weak_spots[x] != null)
            {
            }
            else
            {
                dmg_total++;
            }
        }
        dmg = dmg_total;
        if(max_hp <= dmg_total)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;

        }
    }
    public int get_hp()
    {
        return max_hp;
    }
    public bool check_dead()
    {
        if (max_hp - dmg <= 0)
        {
            return true;
        }
        else {


            return false;
        }
    }
    public int check_life()
    {
        int dmg_total = 0;
        for (int x = 0; x < HP_numb; x++)
        {
            if (weak_spots[x] != null)
            {
            }
            else
            {
                dmg_total++;
            }
        }
        return  max_hp - dmg_total ;
    }
}
