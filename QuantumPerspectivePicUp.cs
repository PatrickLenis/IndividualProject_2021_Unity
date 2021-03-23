using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumPerspectivePicUp : MonoBehaviour
{
    //Variables
    private GameObject targetDestination;
    private GameObject player;
    private GameObject playerCamera;
    private Vector3 initialScale;
    private Vector3 newScale;
    private Quaternion initialRotation;
    public float initialDistance;
    public float newDistance;
    public float scaleRatio;


    //Initialisation
    private void Start()
    {
        targetDestination = GameObject.Find("QuantumTarget");
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("PlayerCamera");
        initialScale = this.transform.localScale;
        //initialRotation = this.transform.rotation;
    }

    //Grab on mouse button
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        //this.transform.position = targetDestination.transform.position;
        this.transform.parent = targetDestination.transform;
        initialScale = this.transform.localScale;
        initialDistance = Vector3.Distance(this.transform.position, playerCamera.transform.position);
        initialRotation = this.transform.localRotation;
        //playerCamera.GetComponent<QuantumPerspectiveManager>().SetScale(this.transform.lossyScale);
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
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.transform.localRotation = initialRotation; //Quaternion.Lerp(this.transform.rotation, initialRotation, Time.deltaTime * 2);
        this.transform.position = Vector3.Lerp(this.transform.position, targetDestination.transform.position, Time.deltaTime * 2);

        newDistance = Vector3.Distance(this.transform.position, playerCamera.transform.position);
        scaleRatio = newDistance / initialDistance;
        newScale = initialScale * scaleRatio;
        this.transform.localScale = newScale;

        //playerCamera.GetComponent<QuantumPerspectiveManager>().SetScale(this.transform.localScale);
    }

}
