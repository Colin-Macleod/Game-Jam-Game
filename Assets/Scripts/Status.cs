using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{

    public Slider sliderHunger;
    public Slider sliderThirst;
    public Slider sliderSunlight;



    public void SetHunger(int hunger, int thirst, int sun)
    {

        sliderHunger.value = hunger;
        sliderThirst.value = thirst;
        sliderSunlight.value = sun;

    }
}

