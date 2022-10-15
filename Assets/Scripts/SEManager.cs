using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SEManager : SingletonMonoBehaviour<SEManager>
{
    private AudioSource audioSource;
    [SerializeField] public AudioClip[] audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(int number)
    {
        audioSource.PlayOneShot(audioClip[number]);
    }

    public void Stop()
    {
        audioSource.Stop();
    }

	// private static SEManager seManager;
	// private static SEManager _instance;

    // // シーンロード時にオブジェクト生成
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    // static void Init()
    // {
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
