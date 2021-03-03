using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLoad : MonoBehaviour
{
    [SerializeField] Slider slide_r;
    [SerializeField] Slider slide_g;
    [SerializeField] Slider slide_b;

    // Start is called before the first frame update
    void Start()
    {
        slide_r.value = FileSaveLoad.ballColor.r;
        slide_g.value = FileSaveLoad.ballColor.g;
        slide_b.value = FileSaveLoad.ballColor.b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
