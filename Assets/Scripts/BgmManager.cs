using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BgmManager : SingletonMonoBehaviour<BgmManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private Dictionary<string, AudioClip> audioClipDict;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        new GameObject("BgmManager", typeof(BgmManager));
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioClips = Resources.LoadAll<AudioClip>("BGM");
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
}
