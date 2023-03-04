using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    //public Transform player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PickUpObject"))
        {
            collision.collider.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("PickUpObject"))
        {
            collision.collider.transform.parent = null;
        }
    }
}
