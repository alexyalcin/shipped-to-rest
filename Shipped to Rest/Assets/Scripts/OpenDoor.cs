using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public float doorOpenAngle = 90.0f;
    public float doorCloseAngle = 0.0f;
    public float doorAnimSpeed = 2.0f;
    private Quaternion doorOpen = Quaternion.identity;
    private Quaternion doorClose = Quaternion.identity;
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

        if (Input.GetKeyDown(KeyCode.O) && !doorGo)
        {
            {
                if (doorStatus)
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
}
