using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {
    RaycastHit hit;
    float distance;
    public Animation swing;
    public camScript Cam_script;
    public Transform fork;
    void Start()
    {
        Cam_script = gameObject.GetComponent<camScript>();
    }
	void Update () {

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        fork.rotation = Cam_script.GiveCam2().transform.rotation;
        //Ray ray = Cam_script.GiveCam2().ScreenPointToRay(Input.mousePosition);

        Vector3 fwd = fork.TransformDirection(Vector3.forward);
        Debug.DrawRay(fork.transform.position, fwd * 5, Color.green);

        if (Input.GetButtonDown("Fire1"))
        {

            swing.Play("melee");
            if (Physics.SphereCast(fork.position, 6f,fwd, out hit, 5))
            {
                if (hit.collider.gameObject.tag.Equals("Target"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }

        }
    }
}
