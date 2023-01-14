using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    public void Start()
    {
        if (MainManager.hasChanged == true)
        {
            volumeSlider.value = MainManager.Volume;
        }
    }

    public void onSliderChange()
    {
        MainManager.Volume = volumeSlider.value;
        MainManager.hasChanged = true;
    }

    void Update()
    {
        Debug.Log(MainManager.Volume);
    }
}
