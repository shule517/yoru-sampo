using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movePerSecond = 3f;
    public Vector3 moveVector = new Vector3(0, 0f, 0f);
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public static string standAnime = "PlayerStand";
    public static string walkAnime = "PlayerWalk";
    string nowAnime = standAnime;
    string oldAnime = standAnime;

    public AudioSource audioSource;
    public AudioClip audioClipWalk;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 現在向きを基準に、入力されたベクトルに向かって移動
        transform.position += transform.rotation * moveVector.normalized * movePerSecond * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.DOColor(new Color(0, 0, 0), 1.5f);
            TextManager.Instance.Speech("信号機のボタンを押しますか？");
        }
        if (Input.GetKey(KeyCode.Z)) {
            spriteRenderer.DOColor(new Color(1, 1, 1), 1.5f);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveVector = new Vector3(-1, 0f, 0f);
            spriteRenderer.flipX = true;
            nowAnime = walkAnime;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            moveVector = new Vector3(1, 0f, 0f);
            spriteRenderer.flipX = false;
            nowAnime = walkAnime;
        } else {
            moveVector = new Vector3(0, 0f, 0f);
            nowAnime = standAnime;
        }
    }

    void FixedUpdate() {
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);

            if (nowAnime == walkAnime)
            {
                BgmManager.Instance.Play("se_walk1");
            } else {
                BgmManager.Instance.Stop();
            }
        }
    }
}
