using UnityEngine;
using System.Collections;

public class Obstacle : Moveable {
	
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
		Destroy(gameObject);
	}
}
