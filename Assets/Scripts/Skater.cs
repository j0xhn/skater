using UnityEngine;
using System.Collections;

public class Skater : MonoBehaviour {

	Animator animator;
	bool jumping;

	void Awake() {
		DebugUtil.Assert(gameObject.GetComponent<Rigidbody2D>() != null);
		DebugUtil.Assert(gameObject.GetComponent<Animator>() != null);
	}
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("Fire1") && jumping == false)
		{
			jumping = true;
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
			animator.SetTrigger("ollie");
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
			jumping = false;
	}
}
