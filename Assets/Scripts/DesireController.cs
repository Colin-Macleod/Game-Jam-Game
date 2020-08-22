using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesireController : MonoBehaviour
{
    private LayerMask windowLayer;
    public Status status; 

    // Start is called before the first frame update
    void Start()
    {
        windowLayer = LayerMask.GetMask("Window");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collider hit");
        if (other.gameObject.layer != windowLayer)
        {
            //Increase happiness
            StartCoroutine("IncreaseHappiness");
            print("start");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == windowLayer)
        {
            //Increase happiness
            StopCoroutine("IncreaseHappiness");
        }
    }

    public IEnumerator IncreaseHappiness()
    {   
        while(status.happiness < 1)
        {
            status.happiness += 0.1f;
            yield return new WaitForSeconds(2f);
        }
        
    }
}
