using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public float duration = 1f;
	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0) {
			Destroy (gameObject);
		} else {
			transform.Translate(Vector2.right * speed);
		}
	
	}
	void OnCollisionEnter2D(Collision2D other){
		Destroy (gameObject);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "projectile"){
			Destroy (gameObject);
		}

	}
}
