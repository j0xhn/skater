using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;

	public AudioClip musicMain;
	public AudioClip sfxOllie;
	public AudioClip sfxCrash;
	public AudioClip sfxGameOver;
	public AudioClip sfxButtonPress;
	public AudioClip sfxSkateOrDie;

	private float lowPitchRange = 0.95f;
	private float highPitchRange = 1.05f;

	private static AudioManager instance;

	public static AudioManager Instance {
		get {
			return instance;
		}
	}

	// Use this for initialization
	void Awake () {
		DebugUtil.Assert(sfxSource != null);
		DebugUtil.Assert(musicSource != null);
		DebugUtil.Assert(sfxOllie != null);
		DebugUtil.Assert(sfxCrash != null);
		DebugUtil.Assert(sfxButtonPress != null);
		DebugUtil.Assert(sfxGameOver != null);
		DebugUtil.Assert(sfxSkateOrDie != null);
		DebugUtil.Assert(musicMain != null);
		instance = this;
	}

	public void PlaySingle(AudioClip clip)
	{
		float pitch = Random.Range(lowPitchRange,highPitchRange);
		sfxSource.pitch = pitch;
		sfxSource.clip = clip;
		sfxSource.Play();
	}

	public void PlayMusic(AudioClip clip)
	{
		musicSource.clip = clip;
		musicSource.Play();
	}

}
