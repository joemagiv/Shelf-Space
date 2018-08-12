using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// OnTriggerEnter is called when the Collider other enters the trigger.
	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
	}
}
