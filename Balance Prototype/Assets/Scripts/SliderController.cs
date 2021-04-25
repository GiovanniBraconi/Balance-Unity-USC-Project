using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider[] sliders;

    public float sliderValue;

    public void Start()
    {
        for(var i=0;i<sliders.Length;i++)
        {
           sliders[i].value = PlayerPrefs.GetFloat("save", sliderValue);
        }
        
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("save", sliderValue);
    }

}
