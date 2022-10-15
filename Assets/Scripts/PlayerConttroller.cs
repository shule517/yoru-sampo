using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConttroller : MonoBehaviour
{
    public float movePerSecond = 3f;
    public Vector3 moveVector = new Vector3(0, 0f, 0f);
    private SpriteRenderer renderer;
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
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 現在向きを基準に、入力されたベクトルに向かって移動
        transform.position += transform.rotation * moveVector.normalized * movePerSecond * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {
            SeManager.Instance.Play("se_walk1");
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveVector = new Vector3(-1, 0f, 0f);
            renderer.flipX = true;
            nowAnime = walkAnime;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            moveVector = new Vector3(1, 0f, 0f);
            renderer.flipX = false;
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
                SeManager.Instance.Play("se_walk1");
            } else {
                SeManager.Instance.Stop();
            }
        }
    }
}
