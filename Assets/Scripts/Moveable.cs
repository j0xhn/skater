using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	public float speed = 3.0f;
	private float MOVEABLE_SPEED_MULTIPLIER = 1.0f;
	public float X_POS_START = 5.0f;
	public float X_POS_END = -5.0f;
	protected int totalPieces = 0;

	public int TotalPieces {
		get {
			return totalPieces;
		}
		set {
			totalPieces = value;
		}
	}

	void Awake () {

	}

	// Use this for initialization
	void Start () {
		DebugUtil.Assert(gameObject.GetComponentInChildren<SpriteRenderer>() != null);
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		transform.Translate(Vector3.left  * ((speed * MOVEABLE_SPEED_MULTIPLIER) * Time.deltaTime));
		
		if (transform.localPosition.x <= X_POS_END)
		{
			MoveableExceededBoundary();
		}
	}

	protected virtual void MoveableExceededBoundary()
	{

	}
}
