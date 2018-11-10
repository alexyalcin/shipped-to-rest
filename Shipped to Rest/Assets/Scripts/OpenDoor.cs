using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private float doorOpenAngle = 180.0f;
    private float doorCloseAngle = 90.0f;
    private float doorAnimSpeed = 2.0f;
    private Quaternion doorOpen = Quaternion.identity;
    private Quaternion doorClose = Quaternion.identity;
    [SerializeField] private string keyID;
    public bool doorStatus = false; 
    private bool doorGo = false; 
    void Start()
    {
        doorStatus = false; 
        doorOpen = Quaternion.Euler(0, doorOpenAngle, 0);
        doorClose = Quaternion.Euler(0, doorCloseAngle, 0);

    }
    void Update()
    {

        if (Input.GetKey("n") && doorGo == false)
        {
            {
                if (doorStatus == true)
                { 
                    StartCoroutine(this.moveDoor(doorClose));
                }
                else
                { 
                    StartCoroutine(this.moveDoor(doorOpen));
                }
            }
        }
    }
    public IEnumerator moveDoor(Quaternion dest)
    {
        doorGo = true;

        while (Quaternion.Angle(transform.localRotation, dest) > 10f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, dest, Time.deltaTime * doorAnimSpeed);

            yield return null;
        }

        doorStatus = !doorStatus;
        doorGo = false;

        yield return null;
    }

    public bool Interact(PlayerController pc)
    {
        if (pc.HasItem(keyID))
        {
            moveDoor(doorOpen);
        }
        else{
            return true;
        }
        return false;

    }
}
