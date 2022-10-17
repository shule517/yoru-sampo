using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSVColorController : MonoBehaviour
{
    private Material material = null;
    [Range(0f, 1f)]
    public float hue = 0f;
    [Range(0f, 1f)]
    public float sat = 0f;
    [Range(0f, 5f)]
    public float val = 5f;

    // Use this for initialization
    void Start()
    {
        this.material = gameObject.GetComponent<Renderer>().material;
        this.material.DOFloat(1, "_Sat", 10);
    }

    // Update is called once per frame
    void Update()
    {
        //this.material.SetFloat("_Hue", hue);
        //this.material.SetFloat("_Sat", sat);
        //this.material.SetFloat("_Val", val);
    }
}