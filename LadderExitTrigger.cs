using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LadderExitTrigger : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && player.GetComponent<FirstPersonController>().useTraversal == true)
        {
            player.GetComponent<FirstPersonController>().isLadder = false;
            player.GetComponent<FirstPersonController>().movementControll = true;
            player.GetComponent<FirstPersonController>().useTraversal = false;
        }
    }

}
