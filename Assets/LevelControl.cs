using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour {

	public GameObject shelfSpaceLogo;
	public GameObject startButton;
	public GameObject instructionsButton;
	public GameObject instructionsText;
	public GameObject infoText;
	
	public float timer;
	public float timeToShowStuff;
	
	private bool buttonsShown = false;

	// Use this for initialization
	void Start () {
		//		shelfSpaceLogo.SetActive(false);
		startButton.SetActive(false);
		instructionsButton.SetActive(false);
		instructionsText.SetActive(false);
		infoText.SetActive(false);
		
	}
	
	public void NextLogo(){
		//		shelfSpaceLogo.SetActive(true);
		LetterController controller = FindObjectOfType<LetterController>().GetComponent<LetterController>();
		controller.dropLetters();
	}
	
	void ShowButtons(){
		startButton.SetActive(true);
		instructionsButton.SetActive(true);
		infoText.SetActive(true);
		buttonsShown = true;

	}
	
	public void ShowInstructions(){
		instructionsText.SetActive(true);
	}
	
	public void LoadNextLevel(){
		SceneManager.LoadScene("Scene01", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		timer+= Time.deltaTime;
		
		if (timer>timeToShowStuff){
			if(!buttonsShown){
				ShowButtons();
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
