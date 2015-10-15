using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.05f;
    public string up = "w";
    public string left = "a";
    public string down = "s";
    public string right = "d";

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("idle", true);
        anim.SetBool("going_right", false);
        anim.SetBool("going_left", false);
        anim.SetBool("going_up", false);
        anim.SetBool("going_down", false);

        if (Input.GetKey(right))
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_right", true);
            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(left))
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_left", true);
            transform.Translate(-Vector2.right * speed);
        }
        if (Input.GetKey(up))
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_up", true);
            transform.Translate(Vector2.up * speed);
        }
        if (Input.GetKey(down))
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_down", true);
            transform.Translate(-Vector2.up * speed);
        }

    }
}
