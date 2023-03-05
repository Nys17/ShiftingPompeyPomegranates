using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeChecker : MonoBehaviour
{
    /// u have to have ledge checker attached to player and ledge holder attached to the ledge 
    public Transform handPositon;
    public Transform standPosition;
    //public Movement pMovement;
    [SerializeField] private float yOffset = 6.5f;
    private CharacterController pController;
    public Vector3 newHandPos;
    public bool onLedge = false;
    public Animator pAnimator;
    private void Awake()
    {
        pController = GetComponent<CharacterController>();

        //pMovement = GetComponent<Movement>();
        //fMOvement = pMovement.GrabLedge();
    }
    void Start()
    {
        newHandPos = new Vector3(handPositon.position.x, handPositon.position.y - yOffset, handPositon.position.z);
    }

    //// Update is called once per frame
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        pAnimator.SetBool("isHanging", true);
    //        other.GetComponent<Movement>().enabled = false;
    //        //var player = GameObject.FindGameObjectWithTag("Player");
    //        Rigidbody rb = other.GetComponent<Rigidbody>();

    //        other.GetComponent<Movement>().enabled = false;
    //        //var player = GameObject.FindGameObjectWithTag("Player");
    //        rb.isKinematic = true;
    //        rb.velocity = Vector3.zero;
    //        rb.angularVelocity = Vector3.zero;
    //        other.transform.position = newHandPos;
    //        //player.transform.parent = GameObject.Find("LedgeHolder").transform;

    //        onLedge = true;
    //    }


    //}
    //private void FixedUpdate()
    //{
    //    if (onLedge == true && Input.GetKey(KeyCode.W))
    //    {
    //        //pAnimator.SetBool("isHanging", false);
    //        pAnimator.SetBool("isClimbing", true);
    //        transform.parent = null;
    //        //GameObject.Find("Player").GetComponent<Rigidbody>().useGravity = true;
    //        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
    //        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = true;
    //        GameObject.FindGameObjectWithTag("Player").transform.position = standPosition.position;
    //        onLedge = false;

    //    }
    //}
}
//public void GrabLedge(Vector3 handPos, LedgeChecker currentLedge)
//{
//    //pController.enabled = false;
//    //grabbedLedge = true;  animation trigger
//    transform.position = handPos;

//    //isjumping = false;

//    //lChecker = currentLedge;
//}
//    public Vector3 GetStandPosition()
//{
//    return standPosition.position;
//}

