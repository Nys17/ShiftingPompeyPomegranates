using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    public Transform Ledge;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Rigidbody>().useGravity = false;

            transform.position = Ledge.position;
            transform.parent = GameObject.Find("Ledge").transform;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

   
}
