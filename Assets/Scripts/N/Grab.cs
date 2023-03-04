using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    //every obj to be picked up has to have a seccond collider for a trigger
    // public Transform Player;
    public GameObject Player;
    public bool check = false;
   public bool isGrabbed = false;

    public void OnTriggerEnter(Collider other)
    {
        check = true;
        if (other.CompareTag("Player"))
        {
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    GrabObject();
            //    isGrabbed = true;
            //}
            GrabObject();
            isGrabbed = true;

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
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().mass = 0;


        transform.position = new Vector3(Player.transform.position.x + 0.8f, Player.transform.position.y + 1f, Player.transform.position.z);
        transform.parent = Player.transform;
    }
    void Release()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;

    }
}
