using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class system_options : MonoBehaviour
{
    public int load_scene_numb;
    public GameObject menu;
    public float time_scale_temp;
    public float diff = 150;
    public bool pause = false;
    public Scrollbar mouse_sensibility;
    public float mouse_scroll;
    public camScript player_controls;
    // Use this for initialization
    void Start()
    {
        UnityEngine.Cursor.visible = false;

        //player_controls.setMouseSensi(mouse_sensibility.value * diff);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            pause = true;
            UnityEngine.Cursor.visible = true;
            menu.SetActive(true);
            player_controls.setMouseSensi(0);


        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            pause = false;
            UnityEngine.Cursor.visible = false;
            menu.SetActive(false);
            mouse_scroll = 5 + (mouse_sensibility.value * diff);
            player_controls.setMouseSensi(mouse_scroll);
        }

        if (pause == true)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;

        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(load_scene_numb, LoadSceneMode.Single);

        }

    }
    public void restart()
    {
        SceneManager.LoadScene(load_scene_numb, LoadSceneMode.Single);

    }
}
