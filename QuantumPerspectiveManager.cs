using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumPerspectiveManager : MonoBehaviour
{
    public float maxDistance = 40f;
    public GameObject targetPosition;
    public LayerMask IgnoreLayer;

    private RaycastHit hit;
    private bool isHit;
    private Vector3 castScale;
    private bool isInRange;
    private string hitTag;

    private void Start()
    {
        castScale = transform.lossyScale / 2;
        isInRange = false;
    }

    private void Update()
    {
        //isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit, transform.rotation, maxDistance, ~IgnoreLayer);
        isHit = Physics.BoxCast(transform.position, castScale, transform.forward, out hit, transform.rotation, maxDistance, ~IgnoreLayer);

        if (isHit)
        {
            hitTag = hit.transform.tag;
            targetPosition.transform.position = transform.position + transform.forward * hit.distance;
            if(hit.distance <= 5f)
            {
                isInRange = true;
            }
            else
            {
                isInRange = false;
            }
        }
        else
        {
            //castScale = transform.lossyScale / 4;
            hitTag = "NoHit";
            targetPosition.transform.position = transform.position + transform.forward * maxDistance;
            isInRange = false;
        }
    }

    private void OnDrawGizmos()
    {

        if(isHit)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, castScale);
        }

        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }

    public void SetScale(Vector3 newScale)
    {
        castScale = newScale;
    }

    public bool GetGrab()
    {
        return isInRange;
    }

    public string GetTag()
    {
        return hitTag;
    }
}
