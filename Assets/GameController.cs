using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System;



public class GameController : MonoBehaviour {
	//Attribute for exceptions in Parse
	public static List<System.Exception> parseExceptions;
	
	public static GameController _singleton;
	public string lastScene;
	public string videoToPlay;
	public float durationOfVideo;
	public bool videoToLoop;

	//This is to disable components
	public static GameObject _blockCollider;
	
	//Session Attributes Selected
	public static SchoolSerialized schoolSerialized;
	public static TeacherSerialized teacherSerialized;
	public static StudentSerialized studentSerialized;
	public static StudentGroupSerialized studentGroupSerialized;

	public static bool isChild;
	public static bool isVisiter = false;
	public static VisiterSerialized visiterSerialized;
	
	//Session Lists Loaded
	public static List<TeacherSerialized> teacherSerializedList;
	public static List<StudentGroupSerialized> studentGroupSerializedList;
	public static List<StudentSerialized> studentSerializedList;
	
	//Session Parse List
	//public static List<ParseObject> parseObjects = new List<ParseObject> ();

	public static List<int> idStudentGroups;
	public int difficultyLevel;
	public bool motocatIntro;
	AsyncOperation asyncToLoad;
	public bool toLoad;

	//MOTO CAT
	public enum gender { male, female, none };
	public bool isSecondTimeMotocat;
	public gender playerGender;
	public int chancesMotocat;
	public bool firstWin; 
	//public List<MotocatGameChoose> challanges;
	int n;

	// loading Video
	string _sceneNameToLoad;
	string _videoToPlay;

	public string textDiagnostic;
	public bool hasBoard;
	public int challangeGroupChoosen;

	// Buildings conditions
	public bool canBuildMotocat;
	public bool canBuildBird;

	// Checking if its TTS
	public bool isTTS;

	// Checking if voice over is playing
	public bool voiceOverPlaying;


	void OnLevelWasLoaded()
	{
		//challanges.Clear();
	}

	void Awake () {

		#if UNITY_IOS
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		#endif

		chancesMotocat = 2;

		if (toLoad)
			StartCoroutine(VideoLoadingScreen());

		//If I am the first instance, make me the Singleton
		if(_singleton == null){
			_singleton = this;
			DontDestroyOnLoad(this);
		}
		//If a Singleton already exists and you find another reference in scene, destroy it!
		else{
			if(this != _singleton)
				Destroy(this.gameObject);
		}

		//Parse Extra Initializer
		ParseObject.RegisterSubclass<School>();
		ParseObject.RegisterSubclass<Teacher>();
		ParseObject.RegisterSubclass<StudentGroup>();
		ParseObject.RegisterSubclass<Student>();
		ParseObject.RegisterSubclass<studentgroup_teacher>();
		ParseObject.RegisterSubclass<DiagnosisLevelSnapshot>();
		ParseObject.RegisterSubclass<WrittenWord>();
		ParseObject.RegisterSubclass<WeekSummary>();
		
		//Todo
		ParseObject.RegisterSubclass<Note>();
		ParseObject.RegisterSubclass<ChallengeOutput>();
		ParseObject.RegisterSubclass<ChallengeSummary>();

	}
	
	void Start(){
		//This is for a realease
		//RealeaseOffLine ();
		//DeleteAll();
#if UNITY_IOS
		Application.targetFrameRate = 60;
#endif
	}
	
	public static GameController GetInstance()
	{
		if (_singleton == null)
		{
			Instantiate(Resources.Load("GameController"));
		}
		return _singleton;
	}
	
	public void SceneLoad(string nameScene)
	{
		StartCoroutine(LoadScene(nameScene));
	}
	
	public void PlayVideo(string videoName, float videoDuration, bool loop = false)
	{
		videoToPlay = videoName;
		durationOfVideo = videoDuration;
		lastScene = Application.loadedLevelName;
		//	Application.LoadLevel("VideoPlayer");
		if (loop)
			videoToLoop = true;
		
		StartCoroutine(LoadScene("VideoPlayer"));
	}

	public IEnumerator VideoLoadingScreen()
	{
		asyncToLoad = Application.LoadLevelAsync(lastScene);
		asyncToLoad.allowSceneActivation = false;
		toLoad = true;
		Debug.Log("Loading complete");
		yield return asyncToLoad;
	}

	void Update()
	{
//		Debug.Log("Chances: " + chancesMotocat);
		if (toLoad)
		{
			Debug.Log("Async Progress: " + asyncToLoad.progress);
			if (asyncToLoad.isDone)
			{
				Debug.Log("Async LOADED");
				asyncToLoad.allowSceneActivation = true;
			}
		}
	}

	public void PlayVideoAndChangeScene(string videoName, float videoDuration , string nextScene, bool loop = true)
	{
		if (loop)
			videoToLoop = true;
		
		videoToPlay = videoName;
		durationOfVideo = videoDuration;
		lastScene = nextScene;
		StartCoroutine(LoadScene("VideoPlayer"));
//		Application.LoadLevel("VideoPlayer");
	}
	
	IEnumerator LoadScene(string sceneName)
	{
		AsyncOperation async = Application.LoadLevelAsync(sceneName);
		yield return async;
		Debug.Log("Loading complete");
	}

	public void PlayAudio (AudioClip ac) {
		audio.clip = ac;
		audio.Play ();
	}

	/*public bool IsChallangeRepeating(string challangeName)
	{
		for (int i = 0; i < challanges.Count; i++)
		{

			if (challangeName == challanges[i].choosen)
			{
				n++;
				if (n > 2)
				{
					n = 0;
					return true;
				}
			}
		}
		return false;
	}*/



}
