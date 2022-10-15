using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class ScenarioOpening : MonoBehaviour
{
    public AudioSource audioSourceMain;
    public AudioSource audioSourceBgm;
    public AudioClip proceedingTalkSE;
    public AudioClip proceedingTypingSE;
    public Text text;
    private string[] speechTexts;
    public int currentPosition = 0;
    public float audioPitch = 2.5f;

    public virtual void Start()
    {
        speechTexts = new string[] {
            "カタカタ・・・ ・・・",
            "カタカタ・・・ ・・・",
            "きょうも しごとが おわらない。",
            "はぁ…",
            "… … …",
            "やりたいことって こんなこと だっけ…",
            "みんな おかねの はなし ばかり…",
            "… … …",
            "じぶんは よいもの つくりたいだけなのに…",
            "… … …",
            "… … …",
            "もう、しゅうでん の じかんだ",
            "かえらなきゃ。",
        };

        StartCoroutine(TypingBgm());
        StartCoroutine(Speech());
    }

    IEnumerator Speech()
    {
        yield return new WaitForSeconds(3f);

        string talkingText = speechTexts[currentPosition];
        currentPosition++;
        StartCoroutine(TalkText(proceedingTalkSE, audioPitch, talkingText));
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (speechTexts.Length <= currentPosition) {
                SceneManager.LoadScene("World1Scene");
                return;
            }
            string talkingText = speechTexts[currentPosition];
            currentPosition++;
            StartCoroutine(TalkText(proceedingTalkSE, audioPitch, talkingText));
        }
    }

    private IEnumerator TypingBgm() {
        var typingTexts = new string[] {
            "    ",
            "        ",
            "                    ",
        };
        var talkingText = typingTexts[Random.Range(0, typingTexts.Length)];

        StartCoroutine(TypingSe(proceedingTypingSE, audioPitch, talkingText));
        yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

        StartCoroutine(TypingBgm());
    }

    private IEnumerator TypingSe(AudioClip audioClip, float pitch, string talkingText)
    {
        int messageCount = 0; //現在表示中の文字数

        float minPitch = pitch - 0.5f;
        float maxPitch = pitch + 0.5f;

        foreach (var str in talkingText)
        {
            if (messageCount % 2 == 0)
            {
                audioSourceBgm.pitch = Random.Range(minPitch, maxPitch);
                audioSourceBgm.PlayOneShot(audioClip);
            }
            messageCount++;//現在の文字数

            yield return new WaitForSeconds(0.04f);
        }
   }

    private IEnumerator TalkText(AudioClip audioClip, float pitch, string talkingText)
    {
        int messageCount = 0; //現在表示中の文字数
        text.text = "";

        float minPitch = pitch - 0.5f;
        float maxPitch = pitch + 0.5f;

        foreach (var str in talkingText)
        {
            if (messageCount % 2 == 0)
            {
                audioSourceMain.pitch = Random.Range(minPitch, maxPitch);
                audioSourceMain.PlayOneShot(audioClip);
            }
            text.text += str;
            messageCount++;//現在の文字数

            yield return new WaitForSeconds(0.04f);
        }
   }
}