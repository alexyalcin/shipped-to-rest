﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PossessObject : MonoBehaviour, IInteractable {

	public float speed;

	protected Rigidbody rb;
	public void setRigidbody(Rigidbody rb){
		this.rb = rb;
	}

	public abstract void ActivateAbility();

	public void Move(Vector3 dir){
		rb.AddForce (speed * dir);
	}

    public string GetMessage()
    {
        return "Possess";
    }

}
