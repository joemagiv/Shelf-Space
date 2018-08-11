using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {
	
	public float multiplierY;
	public float multiplierZ;
	
	public float[] possibleMultipliers = new float[3];
	
	public bool isOnBookshelf;

	// Use this for initialization
	void Start () {
		
		multiplierY = possibleMultipliers[Random.Range(0,3)];
		multiplierZ = possibleMultipliers[Random.Range(0,3)];


		transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y * multiplierY,transform.localScale.z * multiplierZ);
	}
	
	void OnTriggerEnter(Collider other){
		Debug.Log("entered " + other.name);
	}
	
	void OnTriggerStay(Collider other){
		if(other.tag == "Bookshelf"){
			isOnBookshelf = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag == "Bookshelf"){
			isOnBookshelf = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

}
