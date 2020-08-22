﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ItemPickup : MonoBehaviour
{
    public PlayerInputManager PlayerInputManager;
    public PlayerLogic PlayerLogic;
    public Transform objectUp;
    public bool isHolding = false;

    private void Update()
    {
        if (PlayerInputManager.OtherInput.interactInstant && isHolding == false)
        {
            this.transform.position = objectUp.position;
            this.transform.parent = GameObject.Find("Pickup").transform;
            isHolding = true;
        }
        else if (PlayerInputManager.OtherInput.interactInstant && isHolding == true)
        {
            this.transform.parent = null;
            isHolding = false;
        }
    }

}
