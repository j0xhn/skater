using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] Skater skater;
	private static GameManager instance;
	
	public static GameManager Instance {
		get {
			return instance;
		}
	}

	private bool gameActive = false;

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

	private Text distanceText;
	private Button playButton;

	private bool firstTimeLoad = true;

	public bool FirstTimeLoad {
		get {
			return firstTimeLoad;
		}
	}

	const float SPEED_ADDITIVE = 0.05f;
	const float INCREMENT_TIME = 1.0f;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
		playButton = GameObject.Find("PlayButton").GetComponent<Button>();
	}

	void Update()
	{
		if (gameActive)
		{
			distance += .1f * gameSpeedMultiplier;
			distanceText.text = Mathf.RoundToInt(distance) + " Meters";
		}
	}

	public void InitGame()
	{
		gameActive = true;
		distanceText.text = "0 Meters";
		if (!firstTimeLoad)
			StartCoroutine("PlayGameMusic", 1.7f);
		firstTimeLoad = false;
		StartCoroutine(IncrementSpeed());
	}

	IEnumerator PlayGameMusic(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		AudioManager.Instance.PlayMusic(AudioManager.Instance.musicMain);
	}

	IEnumerator IncrementSpeed()
	{
		yield return new WaitForSeconds(INCREMENT_TIME);
		gameSpeedMultiplier += SPEED_ADDITIVE;

		if (gameActive)
			StartCoroutine(IncrementSpeed());
	}

	public void EndGame()
	{
		gameSpeedMultiplier = 1.0f;
		distance = 0;
		gameActive = false;
		AudioManager.Instance.musicSource.Stop();
		StartCoroutine(EndGameAudio());
	}

	IEnumerator EndGameAudio()
	{
		AudioManager.Instance.PlaySingle(AudioManager.Instance.sfxCrash);
		yield return new WaitForSeconds(0.5f);
		AudioManager.Instance.PlaySingle(AudioManager.Instance.sfxGameOver);
		playButton.gameObject.SetActive(true);
	}

	public void PlayButtonPressed()
	{
		if (gameActive == false)
		{
			ObstacleManager.Instance.DestroyObstacles();
			skater.InitSkater();
			playButton.gameObject.SetActive(false);
			AudioManager.Instance.PlaySingle(AudioManager.Instance.sfxSkateOrDie);
			ObstacleManager.Instance.InitObstacles();
			InitGame();
		}
	}
}
