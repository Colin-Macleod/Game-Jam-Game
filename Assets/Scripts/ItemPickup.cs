using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Transform objectUp;
    public bool isHolding = false;

    void OnMouseDown()
    {
        if (isHolding == false)
        {
            this.transform.position = objectUp.position;
            this.transform.parent = GameObject.Find("Pickup").transform;
            isHolding = true;
        }
        else if (isHolding == true)
        {
            this.transform.parent = null;
            isHolding = false;
        }
    }

}
