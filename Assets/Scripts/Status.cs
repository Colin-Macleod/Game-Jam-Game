using System;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{

    public Slider sliderHunger;
    public Slider sliderThirst;
    public Slider sliderSunlight;

    public float hunRate = 0.001f;
    public float thirRate = 0.001f;
    public float sunRate = 0.001f; //this value should be less than 1 and greater than 0 to decrease stats

    public float hunger = 1;
    public float thirst = 1;  
    public float happiness = 1;

    private void FixedUpdate()
    {
        hunger = hunger - hunRate;
        thirst = thirst - thirRate;
        happiness = happiness - sunRate;
        SetStats(hunger, thirst, happiness);
    }

    public void SetStats(float hunger, float thirst, float sun)
    {

        sliderHunger.value = hunger;
        sliderThirst.value = thirst;
        sliderSunlight.value = sun;

    }
}

