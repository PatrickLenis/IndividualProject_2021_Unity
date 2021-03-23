using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnPlay : MonoBehaviour
{
    //Disables object renderer on start
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
