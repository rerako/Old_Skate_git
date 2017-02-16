using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class system_options : MonoBehaviour {
    public int load_scene_numb;
	// Use this for initialization
	void Start () {
        UnityEngine.Cursor.visible = false;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(load_scene_numb, LoadSceneMode.Single);

        }

    }
}
