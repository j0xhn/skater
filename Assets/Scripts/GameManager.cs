using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	
	public static GameManager Instance {
		get {
			return instance;
		}
	}

	private bool gameActive = true;

	public bool GameActive {
		get {
			return gameActive;
		}
		set {
			gameActive = value;
		}
	}

	private float gameSpeedMultiplier = 1.0f;

	public float GameSpeedMultiplier {
		get {
			return gameSpeedMultiplier;
		}
		set {
			gameSpeedMultiplier = value;
		}
	}

	private float distance = 0.0f;

	public float Distance {
		get {
			return distance;
		}
		set {
			distance = value;
		}
	}

	const float SPEED_ADDITIVE = 0.05f;
	const float INCREMENT_TIME = 1.0f;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(IncrementSpeed());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator IncrementSpeed()
	{
		yield return new WaitForSeconds(INCREMENT_TIME);
		gameSpeedMultiplier += SPEED_ADDITIVE;
		StartCoroutine(IncrementSpeed());
	}
}
