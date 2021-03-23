using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    //Variables
    private GameObject targetDestination;
    private GameObject player;
    private GameObject playerCamera;

    //Initialisation
    private void Start()
    {
        targetDestination = GameObject.Find("PickUpDestination");
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("PlayerCamera");
    }
   
    //Grab on mouse button
    private void OnMouseDown()
    {
        if (playerCamera.GetComponent<QuantumPerspectiveManager>().GetGrab())
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = targetDestination.transform.position;
            this.transform.parent = targetDestination.transform;
        }
    }

    //Relses grab
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    //Updates stats on grab
    private void OnMouseDrag()
    {
        if (playerCamera.GetComponent<QuantumPerspectiveManager>().GetGrab())
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.transform.rotation = player.transform.rotation;
            this.transform.position = Vector3.Lerp(this.transform.position, targetDestination.transform.position, Time.deltaTime * 2);
        }
    }

}
