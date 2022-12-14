using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class ScenarioOpening : MonoBehaviour
{
    //public Text text;
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
        StartCoroutine(TextManager.Instance.TalkText(audioPitch, talkingText));
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
            TextManager.Instance.Speech(talkingText, audioPitch);
        }
    }

    private IEnumerator TypingBgm() {
        var typingTexts = new string[] {
            "    ",
            "        ",
            "                    ",
        };
        var talkingText = typingTexts[Random.Range(0, typingTexts.Length)];

        StartCoroutine(TypingSe(audioPitch, talkingText));
        yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

        StartCoroutine(TypingBgm());
    }

    private IEnumerator TypingSe(float pitch, string talkingText)
    {
        int messageCount = 0;

        float minPitch = pitch - 0.5f;
        float maxPitch = pitch + 0.5f;

        foreach (var str in talkingText)
        {
            if (messageCount % 2 == 0)
            {
                SeManager.Instance.Play("カーソル移動2", Random.Range(minPitch, maxPitch));
            }
            messageCount++;

            yield return new WaitForSeconds(0.04f);
        }
   }
}