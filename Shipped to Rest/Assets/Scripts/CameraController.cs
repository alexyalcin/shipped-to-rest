using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public enum RotationAxes
	{
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public Transform target;
	public float smooth = .1f;
	public float distance = 1f;
	private float center_offset = .8f;
	// Setting for how the mouse should look
	public RotationAxes axes = RotationAxes.MouseXandY;

	// General settings - sensitivity
	[SerializeField] private float sensitivityHor = 4.0f;
	[SerializeField] private float sensitivityVert = 9.0f;
	// General settings - y rotation constraints
	[SerializeField] private float maxVert = 45f;
	[SerializeField] private float minVert = -45f;

	// My rotation value.  We have to keep our 
	// own, since localEulerAngles must be 0-360.  
	// Our variable is kept in range -45 to 45.
	private float rotationX = 0;

	void Start() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

	void SetTarget(Transform target) {
		this.target = target;
	}
	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 angle = new Vector3 (0, 0, -1);
		transform.localPosition = (angle * distance);
		Vector3 newPos = (angle * distance);
		newPos.y = newPos.y += center_offset;
		transform.localPosition = newPos;
		float currentXRot = target.eulerAngles.x;
		float currentYRot = target.eulerAngles.y;
		float xRot = getXRot();
		float yRot = getYRot();
		if (axes == RotationAxes.MouseY)
			yRot = currentYRot;
		if (axes == RotationAxes.MouseX)
			xRot = currentXRot;
		target.localEulerAngles = new Vector3(xRot, yRot, 0);
	}

	public float getXRot()
	{
		float newX = rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
		newX = Mathf.Clamp(newX, minVert, maxVert);
		rotationX = newX;
		return newX;
	}

	public float getYRot()
	{
		float newY = target.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;
		return newY;
	}
}
	
