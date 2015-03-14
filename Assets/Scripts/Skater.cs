using UnityEngine;
using System.Collections;

public class Skater : MonoBehaviour {

	Animator animator;
	bool jumping;
	Rigidbody2D rigidBody;

	void Awake() {
		DebugUtil.Assert(gameObject.GetComponent<Rigidbody2D>() != null);
		DebugUtil.Assert(gameObject.GetComponent<Animator>() != null);
	}
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		rigidBody = gameObject.GetComponent<Rigidbody2D>();

		rigidBody.fixedAngle = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		//Lets make him ollie
		if (Input.GetButtonDown("Fire1") && jumping == false)
		{
			//We don't want to keep adding force while the button is down 
			//so only allow it to happen once
			jumping = true;

			//Add jump force
			rigidBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

			//Play the ollie animation
			animator.SetTrigger("ollie");

			//Play sfx
			AudioManager.Instance.PlaySingle(AudioManager.Instance.sfxOllie);
		}
	}

	//The skater only crashes on a trigger, so it is ok for him to ride on top of certain obstacles
	void OnCollisionEnter2D(Collision2D coll) {

		//If he hits the ground or is riding on top of certain obstacles
		//then he is no longer jumping
		if (coll.gameObject.tag == "ground" || coll.gameObject.tag == "obstacle")
			jumping = false;
	}

	void OnTriggerEnter2D(Collider2D other) {

		//By design we only use triggers for parts of obstacles that will make
		//the skater crash
		animator.SetTrigger("crash");

		GameManager.Instance.EndGame();
	}
}
