using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumPossition : MonoBehaviour
{
    //Variables
    public GameObject quantumObject;
    public GameObject[] quantumPossitions;

    //Move if not in sight
    void OnBecameInvisible()
    {
        //Chose random position
        int random = Random.Range(0, quantumPossitions.Length);

        //Move to position
        quantumObject.transform.position = quantumPossitions[random].transform.position;
        quantumObject.transform.rotation = quantumPossitions[random].transform.rotation;
        quantumObject.transform.localScale = quantumPossitions[random].transform.localScale;

        //Cancel velocity
        quantumObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        quantumObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
