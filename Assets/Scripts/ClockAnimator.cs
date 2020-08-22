using System;
using UnityEngine;

public class ClockAnimator : MonoBehaviour
{

    public Transform hourHand, minuteHand;
    public DateTime startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currTime = DateTime.Now;
        TimeSpan elapsedT = currTime - startTime;
        hourHand.localRotation = Quaternion.Euler(0f, 0f, (float)elapsedT.TotalMinutes * -360f/12f);
        minuteHand.localRotation = Quaternion.Euler(0f, 0f, (float)elapsedT.TotalSeconds * -360f/60f);
    }
}
