using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation_OnTrigger : MonoBehaviour
{
    public Animator playAnim;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
            playAnim.SetBool("IsEnabeled", true);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            playAnim.SetBool("IsEnabeled", false);
    }
}
