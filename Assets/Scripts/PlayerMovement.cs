using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.05f;
    public string up = "w";
    public string left = "a";
    public string down = "s";
    public string right = "d";

	public int health = 3;

    Animator anim;

	private bool allowed_right;
	private bool allowed_left;
	private bool allowed_down;
	private bool allowed_up;

    // Use this for initialization
    void Start () {
		Debug.Log("Hello", gameObject);
		Debug.Log ("Starting health is: " + health.ToString());
        anim = GetComponent<Animator>();
		allowed_up = true;
		allowed_down = true;
		allowed_right = true;
		allowed_left = true;
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("idle", true);
        anim.SetBool("going_right", false);
        anim.SetBool("going_left", false);
        anim.SetBool("going_up", false);
        anim.SetBool("going_down", false);

        if (Input.GetKey(right) && allowed_right)
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_right", true);
            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(left) && allowed_left)
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_left", true);
            transform.Translate(-Vector2.right * speed);
        }
        if (Input.GetKey(up) && allowed_up)
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_up", true);
            transform.Translate(Vector2.up * speed);
        }
        if (Input.GetKey(down) && allowed_down)
        {
            anim.SetBool("idle", false);
            anim.SetBool("going_down", true);
            transform.Translate(-Vector2.up * speed);
        }

    }

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "hurt") {
			health--;
			Debug.Log ("Ouch! heath now:" + health.ToString());
		} else {
			Debug.Log (other.name);
			Application.LoadLevel ("scene1");
		}
	} 
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log("Player hit a wall");  
		if (Input.GetKey(right))
		{
			allowed_right = false;
		}
		if (Input.GetKey(left))
		{
			allowed_left = false;
		}
		if (Input.GetKey(up))
		{
			allowed_up = false;
		}
		if (Input.GetKey(down))
		{
			allowed_down = false;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		Debug.Log ("Leaving a wall");
		if (!allowed_up) {
			allowed_up = true;
		}
		if (!allowed_down) {
			allowed_down = true;
		}
		if (!allowed_left) {
			allowed_left = true;
		}
		if (!allowed_right) {
			allowed_right = true;
		}
	}



}
