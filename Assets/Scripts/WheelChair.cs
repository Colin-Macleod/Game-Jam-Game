using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChair : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("grab Wheel chair");
        }
    }
}
