using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SEManager : SingletonMonoBehaviour<SEManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private Dictionary<string, AudioClip> audioClipDict;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClips = Resources.LoadAll<AudioClip>("SE");
        audioClipDict = audioClips.ToDictionary(clip => clip.name, clip => clip);
    }

    public void Play(string filePath)
    {
        var audioClip = audioClipDict[filePath];
        audioSource.PlayOneShot(audioClip);
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    // private static SEManager seManager;
    // private static SEManager _instance;

    // // シーンロード時にオブジェクト生成
    // {
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    // static void Init()
    //     new GameObject("SEManager", typeof(SEManager));
    //     seManager = (SEManager)FindObjectOfType(typeof(SEManager));
    // }

    // //インスタンスを外部から参照する用(getter)
    // public static SEManager Instance {
    // 	get {
    // 		// //インスタンスがまだ作られていない
    // 		// if (_instance == null) {

    // 		// 	//シーン内からインスタンスを取得
    // 		// 	_instance = (SEManager) FindObjectOfType(typeof(SEManager));

    // 		// 	//シーン内に存在しない場合はエラー
    // 		// 	if (_instance == null) {
    // 		// 		Debug.LogError(typeof(SEManager) + " is nothing");
    // 		// 	}
    // 		// 	//発見した場合は初期化
    // 		// 	else {
    // 		// 		_instance.InitIfNeeded();
    // 		// 	}

    // 		// }

    // 		return _instance;
    // 	}
    // }

    // public static SEManager Instance
    // {
    //     get { return seManager; }
    // }

    // public void Play()
    // {
    //     Debug.Log("Play!!!!");
    // }

    // public AudioSource audioSource
    // {
    //     get { return GetComponent<AudioSource>(); }
    // }

    // static SEManager Instance
    // {
    //     get { return seManager; }
    // }
}
