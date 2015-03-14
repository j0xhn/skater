using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour {

	[SerializeField] Ground asphaltPrefab;
	[SerializeField] Ground sidewalkPrefab;
	[SerializeField] Ground backgroundBack;
	[SerializeField] Ground backgroundMiddle;
	[SerializeField] Ground backgroundFront;

	List<GameObject> asphaltPieces;
	List<GameObject> sidewalkPieces;
	List<GameObject> backgroundPieces;

	[SerializeField] List<Moveable> obstacles;

	public const int TOTAL_ASPHALT_PIECES = 10;
	public const int TOTAL_SIDEWALK_PIECES = 17;
	public const int TOTAL_BACKGROUND_PIECES = 3;

	public const float TIME_BETWEEN_OBSTACLES_MAX = 4.0f;
	public const float TIME_BETWEEN_OBSTACLES_MIN = 0.5f;

	private static ObstacleManager instance;
	
	public static ObstacleManager Instance {
		get {
			return instance;
		}
	}

	bool gameActive;

	public bool GameActive {
		get {
			return gameActive;
		}
	}

	void Awake() {
		DebugUtil.Assert(asphaltPrefab != null);
		DebugUtil.Assert(sidewalkPrefab != null);
		DebugUtil.Assert(backgroundBack != null);
		DebugUtil.Assert(backgroundMiddle != null);
		DebugUtil.Assert(backgroundFront != null);
		DebugUtil.Assert(obstacles != null && obstacles.Count > 0);
		instance = this;
	}

	// Use this for initialization
	void Start () {
		CreateGround();
		CreateBackgrounds();
		StartCoroutine(GenerateObstacle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateGround() {

		asphaltPieces = CreateMoveables(asphaltPrefab, TOTAL_ASPHALT_PIECES);
		sidewalkPieces = CreateMoveables(sidewalkPrefab, TOTAL_SIDEWALK_PIECES);
	}

	void CreateBackgrounds()
	{
		backgroundPieces = CreateMoveables(backgroundBack, TOTAL_BACKGROUND_PIECES);
		backgroundPieces.AddRange(CreateMoveables(backgroundMiddle, TOTAL_BACKGROUND_PIECES));
		backgroundPieces.AddRange(CreateMoveables(backgroundFront, TOTAL_BACKGROUND_PIECES));
	}

	List<GameObject> CreateMoveables(Moveable prefab, int totalPieces)
	{
		List<GameObject> list = new List<GameObject>();
		for (int x = 1; x <= totalPieces; x++)
		{
			GameObject go = GameObject.Instantiate(prefab.gameObject);
			SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
			Moveable move = go.GetComponent<Moveable>();
			move.TotalPieces = totalPieces;
			Vector2 pos = new Vector2((move.X_POS_START - (x * sr.bounds.size.x)), go.transform.position.y);
			go.transform.localPosition = pos;
		}
		return list;
	}
	

	IEnumerator GenerateObstacle()
	{
		float rand = Random.Range(TIME_BETWEEN_OBSTACLES_MIN, TIME_BETWEEN_OBSTACLES_MAX);

		yield return new WaitForSeconds(rand);
		int index = Random.Range(0, obstacles.Count);
		GameObject go = GameObject.Instantiate(obstacles[index].gameObject);
		Moveable m = go.GetComponent<Moveable>();
		go.transform.localPosition = new Vector2(m.X_POS_START, go.transform.localPosition.y);

		if (GameManager.Instance.GameActive)
			StartCoroutine(GenerateObstacle());
	}
	
}
