using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : Moveable {
	
	[SerializeField] List<Sprite> sprites;
	float padding = 1f;

	void Awake() {
		DebugUtil.Assert(sprites != null && sprites.Count > 0);
	}
	
	// Use this for initialization
	void Start () {
		totalPieces = 1;
		xPosEnd -= padding;
		xPosStart += padding;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}
	
	protected override void MoveableExceededBoundary ()
	{
		base.MoveableExceededBoundary();
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

		Sprite sprite = sprites[Random.Range(0, sprites.Count)];
		sr.sprite = sprite;

		Vector2 newPos = new Vector2(XPosStart + padding, gameObject.transform.position.y);
		transform.position = newPos;
	}
}
