using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour {

	private Rigidbody[] rigidBodies;

	// Use this for initialization
	void Start () {
		rigidBodies = GetComponentsInChildren<Rigidbody>();
	}
	
	public void dropLetters(){
		foreach (Rigidbody rb in rigidBodies){
			rb.isKinematic = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
