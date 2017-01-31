using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulsing : MonoBehaviour {
    public Vector3 scale;
    public float size = 1f;
    public bool mode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (mode)
        {
            size = Mathf.Lerp(size, 6f, 3f * Time.deltaTime);
            if (size > 5f)
            {
                mode = false;
            }
        }
        else if (!mode)
        {
            size = Mathf.Lerp(size, 2f, 2f * Time.deltaTime);
            if (size < 3f)
            {
                mode = true;
            }
        }
        transform.localScale = scale * size;
	}
}
