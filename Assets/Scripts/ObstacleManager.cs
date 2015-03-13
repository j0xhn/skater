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

	public const int TOTAL_ASPHALT_PIECES = 10;
	public const int TOTAL_SIDEWALK_PIECES = 17;
	public const int TOTAL_BACKGROUND_PIECES = 3;

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
		instance = this;
	}

	// Use this for initialization
	void Start () {
		CreateGround();
		CreateBackgrounds();
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
	
}
