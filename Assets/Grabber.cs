using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {
	
	public bool isGrabbing;
	
	public bool isTouchingBook;
	
	public GameObject currentBook;
	
	public Transform booksParent;
	
	public Transform bookHoldingParent;
	
	public AudioClip pickUpBook;
	public AudioClip dropBook;
	
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		
	}
	
	void OnTriggerEnter(Collider other){
		if(!isGrabbing){
			if(other.GetComponent<Book>()){
				currentBook = other.gameObject;
			}
		}
		
	}
	
	void OnTriggerExit(Collider other){
		if (!isGrabbing){
			if(other.GetComponent<Book>()){
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
				audioSource.clip = dropBook;
				audioSource.Play();
			}
			if(currentBook!=null){
				currentBook.transform.parent = bookHoldingParent.transform;
				bookRb = currentBook.GetComponent<Rigidbody>();
				collider = currentBook.GetComponent<BoxCollider>();
				collider.enabled = false;
				isGrabbing = true;
				bookRb.useGravity = false;
				audioSource.clip = pickUpBook;
				audioSource.Play();
			} 

		}
		if (isGrabbing){
			currentBook.transform.localPosition=Vector3.zero;
			currentBook.transform.localRotation=Quaternion.identity;
			Book bookScript = currentBook.GetComponent<Book>();
			bookScript.isOnBookshelf = false;
		}
		
	}
}
