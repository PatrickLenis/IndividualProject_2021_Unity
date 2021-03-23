using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TopTriggerReturn : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Climb")
        {
            player.GetComponent<FirstPersonController>().canClimb = true;
            player.GetComponent<FirstPersonController>().topObstructed = true;
        }
        else if (other.tag == "Ladder")
        {
            player.GetComponent<FirstPersonController>().canLadder = true;
            player.GetComponent<FirstPersonController>().topObstructed = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Climb")
        {
            player.GetComponent<FirstPersonController>().canClimb = false;
            player.GetComponent<FirstPersonController>().topObstructed = false;
        }
        else if (other.tag == "Ladder")
        {
            player.GetComponent<FirstPersonController>().canLadder = false;
            player.GetComponent<FirstPersonController>().topObstructed = false;
        }
    }
}
