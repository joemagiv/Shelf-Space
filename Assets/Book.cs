using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {

	public Vector3 forwardMomentum;
	public float thrust;
	
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate()
	{
		rb.AddForce(transform.forward * thrust);
	}
}
