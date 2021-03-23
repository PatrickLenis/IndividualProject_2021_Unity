using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{
    public bool isOpen;

    public GameObject Door;

    public GameObject openPosition;
    public GameObject closePosition;

    public GameObject indicator;
    public GameObject button;

    public Material opened;
    public Material closed;

    // Start is called before the first frame update
    void Start()
    {
        if (isOpen == true)
        {
            Door.transform.position = openPosition.transform.position;
            indicator.GetComponent<MeshRenderer>().material = opened;
            button.GetComponent<MeshRenderer>().material = opened;
        }
        else
        {
            Door.transform.position = closePosition.transform.position;
            indicator.GetComponent<MeshRenderer>().material = closed;
            button.GetComponent<MeshRenderer>().material = closed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen == true)
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, openPosition.transform.position, Time.deltaTime * 2);
        }
        else
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, closePosition.transform.position, Time.deltaTime * 2);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isOpen = true;
        indicator.GetComponent<MeshRenderer>().material = opened;
        button.GetComponent<MeshRenderer>().material = opened;
    }

    private void OnTriggerExit(Collider other)
    {
        isOpen = false;
        indicator.GetComponent<MeshRenderer>().material = closed;
        button.GetComponent<MeshRenderer>().material = closed;
    }
}
