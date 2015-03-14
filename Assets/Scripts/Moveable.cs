using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	public float speed = 3.0f;
	protected float xPosStart = 5.0f;

	public float XPosStart {
		get {
			return xPosStart;
		}
	}

	public float xPosEnd = -7.0f;

	public float XPosEnd {
		get {
			return xPosEnd;
		}
	}

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

		if (GameManager.Instance.GameActive || GameManager.Instance.FirstTimeLoad)
		{
			transform.Translate(Vector3.left  * ((speed * GameManager.Instance.GameSpeedMultiplier) * Time.deltaTime));
			
			if (transform.localPosition.x <= XPosEnd)
			{
				MoveableExceededBoundary();
			}
		}
	}

	protected virtual void MoveableExceededBoundary()
	{

	}
}
