using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{

    public Slider sliderHunger;
    public Slider sliderThirst;
    public Slider sliderSunlight;

    public float hunger = 1;
    public float thirst = 1;  
    public float happiness = 1; 

    private void Update()
    {
        SetStats(hunger, thirst, happiness);
    }

    public void SetStats(float hunger, float thirst, float sun)
    {

        sliderHunger.value = hunger;
        sliderThirst.value = thirst;
        sliderSunlight.value = sun;

    }
}

