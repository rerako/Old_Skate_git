using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goals : MonoBehaviour {
    public bool timer = true;
    public float run_time;
    public Text win_statement;
    public Text boss_statement;
    public bool end_goal;
    public bool boss;
    public Text neutral_statement;
    public Text Time_counter;
    public boss_destroy Boss;
	// Use this for initialization
	void Start () {
        run_time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        Time_counter.text = "" + run_time;
        if (timer)
        {
            run_time += Time.deltaTime;
        }
        if (end_goal)
        {
            if (Boss.check_dead())
            {
                boss_statement.gameObject.SetActive(true);
            }
            else
            {
                neutral_statement.gameObject.SetActive(true);

            }
            win_statement.gameObject.SetActive(true);

        }

    }

    void OnTriggerEnter(Collider end)
    {
        if (end.gameObject.CompareTag("Goal"))
        {
            timer = false;
            
        }
        
    }
}
