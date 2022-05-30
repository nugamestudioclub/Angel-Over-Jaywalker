using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public static SceneLoader Instance { get; private set; }

	[ReadOnly]
	[SerializeField]
	private string mainMenuScene;
	[SerializeField]
	private AudioSource music;

#if UNITY_EDITOR
	[SerializeField]
	[SerializeProperty(nameof(SetMainMenuScene))]
	private SceneAsset setMainMenuScene;
	public SceneAsset SetMainMenuScene {
		get => setMainMenuScene;
		set {
			setMainMenuScene = value;
			mainMenuScene = value.name;
		}
	}
#endif

	[ReadOnly]
	[SerializeField]
	private string creditsScene;

#if UNITY_EDITOR
	[SerializeField]
	[SerializeProperty(nameof(SetCreditsScene))]
	private SceneAsset setCreditsScene;
	public SceneAsset SetCreditsScene {
		get => setCreditsScene;
		set {
			setCreditsScene = value;
			creditsScene = value.name;
		}
	}
#endif

	[SerializeField]
	private List<string> puzzleScenes;

#if UNITY_EDITOR
	[SerializeField]
	[SerializeProperty(nameof(AddPuzzleScene))]
	private SceneAsset addPuzzleScene;
	public SceneAsset AddPuzzleScene {
		get => null;
		set => puzzleScenes.Add(value.name);
	}
#endif

	[field: ReadOnly]
	[field: SerializeField]
	public int CurrentPuzzle { get; private set; }

	void Awake() {
		if( Instance == null ) {
			Instance = this;
			music.Play();
			DontDestroyOnLoad(this);
		}
		else {
			Destroy(gameObject);
		}
	}

	public static void LoadMainMenu() {
		SceneManager.LoadScene(Instance.mainMenuScene);
	}

	public static void LoadCredits() {
		SceneManager.LoadScene(Instance.creditsScene);
	}

	public static void LoadPuzzle(int index) {
		string scene = 0 <= index && index < Instance.puzzleScenes.Count
			? Instance.puzzleScenes[index]
			: Instance.mainMenuScene;
		SceneManager.LoadScene(scene);
	}

	public static void LoadCurrentPuzzle() {
		LoadPuzzle(Instance.CurrentPuzzle);
	}

	public static void LoadNextPuzzle() {
		LoadPuzzle(++Instance.CurrentPuzzle);
	}

	public static void QuitGame()
	{
		Application.Quit();
	}

	public void PlayGlobalClip(AudioClip clip)
    {
		OneShotSound oss = gameObject.AddComponent<OneShotSound>();
		oss.Play(clip);
    }
}