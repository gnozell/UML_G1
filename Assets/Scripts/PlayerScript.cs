using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed = 0.05f;
    public string up = "w";
    public string left = "a";
    public string down = "s";
    public string right = "d";

    public string attack_up = "up";
    public string attack_left = "left";
    public string attack_down = "down";
    public string attack_right = "right";



    public int health = 3;

    Animator anim;

	private bool allowed_right;
	private bool allowed_left;
	private bool allowed_down;
	private bool allowed_up;

    private bool attacking;

	public GameObject projectile;

    // Use this for initialization
    void Start () {
		//Debug.Log("Hello", gameObject);
		Debug.Log ("Starting health is: " + health.ToString());
        anim = GetComponent<Animator>();
		allowed_up = true;
		allowed_down = true;
		allowed_right = true;
		allowed_left = true;

        attacking = false;
    }

   public void releaseObject()
    {
        allowed_up = true;
        allowed_down = true;
        allowed_right = true;
        allowed_left = true;
    }

    public bool getAttacking() {
        return attacking;
    }
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("idle", true);
        anim.SetBool("going_right", false);
        anim.SetBool("going_left", false);
        anim.SetBool("going_up", false);
        anim.SetBool("going_down", false);

        anim.SetBool("attack_up", false);
        anim.SetBool("attack_down", false);
        anim.SetBool("attack_left", false);
        anim.SetBool("attack_right", false);

        attacking = false;

        

        if (Input.GetKey(attack_up))
        {
            attacking = true;
            anim.SetBool("idle", false);
            anim.SetBool("attack_up", true);
            anim.Play("link_sword_up");
        }
        if (Input.GetKey(attack_down))
        {
            attacking = true;
            anim.SetBool("idle", false);
            anim.SetBool("attack_down", true);
            anim.Play("link_sword_down");
        }
        if (Input.GetKey(attack_left))
        {
            attacking = true;
            anim.SetBool("idle", false);
            anim.SetBool("attack_left", true);
            anim.Play("link_sword_left");
        }
        if (Input.GetKey(attack_right))
        {
            attacking = true;
            anim.SetBool("idle", false);
            anim.SetBool("attack_right", true);
            anim.Play("link_sword_right");

			Vector3 startPos = transform.position;
			startPos.x += .4f;
			GameObject octo = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
        }

        if (!attacking)
        {
            if (Input.GetKey(right))
            {
                anim.SetBool("idle", false);
                anim.SetBool("going_right", true);
                if (allowed_right)
                    transform.Translate(Vector2.right * speed);
            }
            if (Input.GetKey(left))
            {
                anim.SetBool("idle", false);
                anim.SetBool("going_left", true);
                if (allowed_left)
                    transform.Translate(-Vector2.right * speed);
            }
            if (Input.GetKey(up))
            {
                anim.SetBool("idle", false);
                anim.SetBool("going_up", true);
                if (allowed_up)
                    transform.Translate(Vector2.up * speed);
            }
            if (Input.GetKey(down))
            {
                anim.SetBool("idle", false);
                anim.SetBool("going_down", true);
                if (allowed_down)
                    transform.Translate(-Vector2.up * speed);
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "hurt") {
			health--;
			Debug.Log ("Ouch! heath now:" + health.ToString());
		} if(other.name=="yellow_house") {
			Debug.Log (other.name);
			Application.LoadLevel ("scene1");
		}
	} 
	void OnCollisionEnter2D(Collision2D other){

        //Debug.Log("Player hit a wall");  
        if (other.gameObject.tag != "enemy")
        {
            Debug.Log("not an enemy");
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
        else {

            Debug.Log("ran into enemy");
        }
	}

	void OnCollisionExit2D(Collision2D other){
		//Debug.Log ("Leaving a wall");
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
