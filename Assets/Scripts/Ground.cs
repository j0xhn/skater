using UnityEngine;
using System.Collections;

public class Ground : Moveable {

	void Awake() {

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}

	protected override void MoveableExceededBoundary ()
	{
		base.MoveableExceededBoundary();
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		Vector2 newPos = new Vector2(transform.position.x + (sr.bounds.size.x * totalPieces),gameObject.transform.position.y);
		transform.position = newPos;
	}
}
