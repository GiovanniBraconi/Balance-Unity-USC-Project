using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider[] slider;

    public float sliderValue;

    public void Start()
    {
        for(var i=0;i<slider.Length;i++)
        {
           slider[i].value = PlayerPrefs.GetFloat("save", sliderValue);
        }
        
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("save", sliderValue);
    }

}
