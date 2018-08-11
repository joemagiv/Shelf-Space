﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {
	
	public bool isGrabbing;
	
	public bool isTouchingBook;
	
	public GameObject currentBook;
	
	public Transform booksParent;
	
	public Transform bookHoldingParent;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if(!isGrabbing){
			if(other.GetComponent<Book>()){
				Debug.Log("Touching Book");
				currentBook = other.gameObject;
			}
		}
		
	}
	
	void OnTriggerExit(Collider other){
		if (!isGrabbing){
			if(other.GetComponent<Book>()){
				Debug.Log("Touching Book");
				currentBook = null;
			}
		}
		
	}
	
	private Rigidbody bookRb;
	private BoxCollider collider;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			if(isGrabbing) {
				currentBook.transform.parent = booksParent;
				isGrabbing = false;
				bookRb.useGravity = true;
				collider.enabled = true;
				
				currentBook =null;
			}
			if(currentBook!=null){
				currentBook.transform.parent = bookHoldingParent.transform;
				bookRb = currentBook.GetComponent<Rigidbody>();
				collider = currentBook.GetComponent<BoxCollider>();
				collider.enabled = false;
				isGrabbing = true;
				bookRb.useGravity = false;
			} 

		}
		if (isGrabbing){
			currentBook.transform.localPosition=Vector3.zero;
			currentBook.transform.localRotation=Quaternion.identity;
		}
		
	}
}
