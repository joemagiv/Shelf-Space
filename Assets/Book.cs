using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {
	
	public float multiplierY;
	public float multiplierZ;
	
	public Material[] materials = new Material[3];
	private MeshRenderer meshRenderer;
	
	public float[] possibleMultipliers = new float[4];
	
	public AudioClip[] audioClips;
	private AudioSource audioSource;
	
	private bool hasPlayedHitSound = false;
	
	public bool isOnBookshelf;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material = materials[Random.Range(0, materials.Length)];
		multiplierY = possibleMultipliers[Random.Range(0,3)];
		multiplierZ = possibleMultipliers[Random.Range(0,3)];

		audioSource.clip = audioClips[Random.Range(0,audioClips.Length)];
		transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y * multiplierY,transform.localScale.z * multiplierZ);
	}
	
	void OnTriggerEnter(Collider other){
		
	}
	
	void OnTriggerStay(Collider other){
		if(other.tag == "Bookshelf"){
			isOnBookshelf = true;
		}
	}
	
	void OnCollisionEnter(Collision other){
		if(!hasPlayedHitSound){
			audioSource.Play();
			hasPlayedHitSound = true;
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
