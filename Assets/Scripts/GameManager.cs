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
		AudioManager.Instance.PlaySingle(AudioManager.Instance.sfxSkateOrDie);
		StartCoroutine("PlayGameMusic", 1.7f);
		StartCoroutine(IncrementSpeed());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator PlayGameMusic(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		AudioManager.Instance.PlayMusic();
	}

	IEnumerator IncrementSpeed()
	{
		yield return new WaitForSeconds(INCREMENT_TIME);
		gameSpeedMultiplier += SPEED_ADDITIVE;
		StartCoroutine(IncrementSpeed());
	}

	public void EndGame()
	{
		gameActive = false;
		AudioManager.Instance.musicSource.Stop();
		StartCoroutine(EndGameAudio());
	}

	IEnumerator EndGameAudio()
	{
		AudioManager.Instance.PlaySingle(AudioManager.Instance.sfxCrash);
		yield return new WaitForSeconds(0.5f);
		AudioManager.Instance.PlaySingle(AudioManager.Instance.sfxGameOver);
	}
}
