using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    Animator anim;
    public float speed = 0.01f;
    public float health = 3;
    private GameObject player;
    //private PlayerScript ps;
    private PlayerGamepad ps;
    private bool invulnerable;
    private float invulCounter;

    // Use this for initialization
    void Start () {
        invulnerable = false;
        invulCounter = 0;

        Debug.Log(invulCounter);
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        //ps = (PlayerScript)player.GetComponent(typeof(PlayerScript));
        ps = (PlayerGamepad)player.GetComponent(typeof(PlayerGamepad));

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.name == "Player") && (ps.getAttacking())&&(!invulnerable))
        {
            Debug.Log("Enemy Ouch");
            health--;
            invulnerable = true;
            invulCounter = 1f;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if ((other.gameObject.name == "Player") && (ps.getAttacking()) && (!invulnerable))
        {
            Debug.Log("Enemy Ouch");
            health--;
            invulnerable = true;
            invulCounter = 1f;

        }
    }

    // Update is called once per frame
    void Update () {
        invulCounter -= Time.deltaTime;
        if ((invulnerable)&&(invulCounter <= 0)) {
            invulnerable = false;
            invulCounter = 0;
        }
        

        // monsters position
        Vector3 bar = transform.position;

        //players postition
        Vector3 bar2 = GameObject.Find("Player").transform.position;

        if (GameObject.Find("Player") != null)
        {

            anim.SetBool("going_right", false);
            anim.SetBool("going_left", false);
            anim.SetBool("going_up", false);
            anim.SetBool("going_down", false);

            float x_diff = System.Math.Abs(bar.x - bar2.x);
            float y_diff = System.Math.Abs(bar.y - bar2.y);

            //Debug.Log("difs: x" + x_diff.ToString() + " y" + y_diff.ToString());

            if ((bar2.x > bar.x) && (x_diff > y_diff))
            {
                anim.SetBool("going_right", true);
                transform.Translate(Vector2.right * speed);
            }

            else if ((bar2.x <= bar.x) && (x_diff >= y_diff))
            {
                anim.SetBool("going_left", true);
                transform.Translate(-Vector2.right * speed);
            }

            else if ((bar2.y > bar.y) && (x_diff < y_diff))
            {
                anim.SetBool("going_up", true);
                transform.Translate(Vector2.up * speed);

            }

            else if ((bar2.y <= bar.y) && (x_diff <= y_diff))
            {
                anim.SetBool("going_down", true);
                transform.Translate(-Vector2.up * speed);
            }
        }

        if (health <= 0)
        {
            ps.releaseObject();

            Vector3 buttfuck = new Vector3(-999999999, -999999999, 0);
            transform.position = buttfuck;
            Destroy(gameObject);
        }

    }
}
