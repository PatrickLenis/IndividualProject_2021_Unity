using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LadderClimb : MonoBehaviour
{
    private GameObject player;
    private GameObject playerCamera;

    public bool isClimbing = false;

    public bool isInRange;
    public bool isBottom;

    public bool done;

    public float smoothLookSpeed;
    public GameObject lookTarget;

    private Quaternion cameraStartRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("PlayerCamera");

        isInRange = false;
        isBottom = false;

        done = true;

    }

    private void ClimbLook()
    {

        Vector3 lookDirection = lookTarget.transform.position - playerCamera.transform.position;
        playerCamera.transform.rotation = Quaternion.RotateTowards(playerCamera.transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * smoothLookSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isClimbing = !isClimbing;
            }
        }
        else if (isInRange == false)
        {
            isClimbing = false;
        }

        
        if (isClimbing == true)
        {
            ClimbLook();

            if (done)
            {
                SetClimbTrue();
            }
        }

        else if (isClimbing == false)
        {
            if (!done)
            {
                playerCamera.transform.rotation = Quaternion.RotateTowards(playerCamera.transform.rotation, cameraStartRotation, Time.deltaTime * smoothLookSpeed);

                if (playerCamera.transform.rotation == cameraStartRotation)
                {
                    player.GetComponent<FirstPersonController>().mouseControll = true;

                    player.GetComponent<FirstPersonController>().useTraversal = false;
                    player.GetComponent<FirstPersonController>().isLadder = false;

                    player.GetComponent<FirstPersonController>().movementControll = true;

                    done = true;
                }
                //StartCoroutine(CameraReset());
            }
        }
    }

    private void SetClimbTrue()
    {
        isClimbing = true;
        cameraStartRotation = playerCamera.transform.rotation;

        player.GetComponent<FirstPersonController>().useTraversal = true;
        player.GetComponent<FirstPersonController>().isLadder = true;

        player.GetComponent<FirstPersonController>().movementControll = false;
        player.GetComponent<FirstPersonController>().mouseControll = false;

        done = false;
    }

    private void SetClimbFalse()
    {
        isClimbing = false;

        /*player.GetComponent<FirstPersonController>().useTraversal = false;
        player.GetComponent<FirstPersonController>().isLadder = false;

        player.GetComponent<FirstPersonController>().movementControll = true;

        if (playerCamera.transform.rotation == cameraStartRotation)
        {
            player.GetComponent<FirstPersonController>().mouseControll = true;
            done = true;
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
        }
    }

    private IEnumerator CameraReset()
    {   
        yield return new WaitForSeconds(1.0f);

        player.GetComponent<FirstPersonController>().mouseControll = true;
        done = true;
    }
}
