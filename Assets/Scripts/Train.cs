using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOMove(new Vector3(140f, 0.88f, 0f), 10f).SetEase(Ease.OutQuad);
        doorLeft.transform.DOLocalMove(new Vector3(-0.18f, 0f, 0f), 2f).SetDelay(11f).SetEase(Ease.OutQuad);
        doorRight.transform.DOLocalMove(new Vector3(+0.18f, 0f, 0f), 2f).SetDelay(11f).SetEase(Ease.OutQuad);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
