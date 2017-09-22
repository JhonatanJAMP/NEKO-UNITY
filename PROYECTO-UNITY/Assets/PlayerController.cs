using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float maxspeed = 5f;
	public float speed = 2f;
	public bool grounded;

	private Rigidbody2D rb2d;
	private Animator anim;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));
		anim.SetBool ("Grounded", grounded);

	}
	void FixedUpdate(){
		float h = Input.GetAxis("Horizontal");
		rb2d.AddForce (Vector2.right * speed * h);
		float limitedspeed = Mathf.Clamp (rb2d.velocity.x, -maxspeed, maxspeed);
		rb2d.velocity = new Vector2(limitedspeed, rb2d.velocity.y);
		if (h > 0.1f) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
		if (h < -0.1f) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
		
		Debug.Log (rb2d.velocity.x);


	}
}
