using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    //every obj to be picked up has to have a seccond collider for a trigger
    public Transform Player;
   public bool isGrabbed = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                GrabObject();
                isGrabbed = true;
            }

           
        }
    
    }

    private void Update()
    {
        if (isGrabbed == true)
        {
            if (Input.GetKey(KeyCode.G))
            {
                Release();
                isGrabbed = false;
            }

        }
    }
    void GrabObject()
    {
        GetComponent<Rigidbody>().useGravity= false;
        GetComponent<Rigidbody>().isKinematic= true;
        GetComponent<Rigidbody>().velocity=Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
        
        transform.position = new Vector3 (Player.position.x + 0.8f, Player.position.y, Player.position.z);
        transform.parent = GameObject.Find("Player").transform;
    }
    
    void Release()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;

    }
}
