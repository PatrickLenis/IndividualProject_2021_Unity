using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation_OnInteract : MonoBehaviour
{
    public Animator playAnim;
    public GameObject hoverItem;

    public Material opened;

    void OnMouseDown()
    {
        playAnim.SetBool("IsEnabeled", true);
        hoverItem.GetComponent<MeshRenderer>().material = opened;
    }
}
