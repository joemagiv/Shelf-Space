using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour {


	public float currentTimer;
	public float timeToNextSpawn;
	
	public GameObject bookPrefab;

	// Use this for initialization
	void Start () {
		timeToNextSpawn = Random.Range(4,15);
	}
	
	void SpawnBook(){
		currentTimer = 0;
		Instantiate(bookPrefab,transform.position,Quaternion.identity);
		timeToNextSpawn = Random.Range(4,15);
	}
	
	// Update is called once per frame
	void Update () {
		
		currentTimer += Time.deltaTime;
		if (currentTimer > timeToNextSpawn){
			SpawnBook();
		}
		
	}
}
