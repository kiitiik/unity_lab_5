using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderLevl : MonoBehaviour
{
    public Slider slider;
    public float oldVolume;
    void Start()
    {
        oldVolume = slider.value;
        if(!PlayerPrefs.HasKey("volume")) slider.value = 1;
        else slider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        if(oldVolume != slider.value)
        {
            PlayerPrefs.SetFloat("volume",slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }
}
