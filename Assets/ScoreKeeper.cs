using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour {

	public Text scoreText;
	public Text timerText;
	public GameObject gameOver;

	public FirstPersonController firstPersonController;
	
	public bool gameIsOver;

	
	public int countOfBooksOnShelf;
	
	private GameObject[] allBooks;

	
	public float timerStart;
	
	public float timer;
	

	// Use this for initialization
	void Start () {
		gameOver.SetActive(false);
		timer = timerStart;
		firstPersonController = FindObjectOfType<FirstPersonController>().GetComponent<FirstPersonController>();
	}
	
	void GameOver(){
		firstPersonController.m_MouseLook.lockCursor = false;
		firstPersonController.m_MouseLook.UpdateCursorLock();
		firstPersonController.m_WalkSpeed = 0;
		firstPersonController.m_RunSpeed = 0;
		SetCursorState(CursorLockMode.None);
		gameOver.SetActive(true);
		gameIsOver = true;


	}
	
	public void RestartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
	}
	
	void SetCursorState (CursorLockMode wantedMode)
	 {
		 Cursor.lockState = wantedMode;
		 // Hide cursor when locking
		 Cursor.visible = (CursorLockMode.Locked != wantedMode);
	 }
	
	private Book currentBook;
	
	// Update is called once per frame
	void Update () {
		countOfBooksOnShelf = 0;
		allBooks = GameObject.FindGameObjectsWithTag("Book");
		foreach (GameObject book in allBooks){
			currentBook = book.GetComponent<Book>();
			if(currentBook.isOnBookshelf){
				countOfBooksOnShelf++;
			}
		}
		scoreText.text = countOfBooksOnShelf.ToString();
		
		if (timer>0){
			timer = timer -Time.deltaTime;
			float minutes = Mathf.Floor(timer / 60);
			float seconds = Mathf.Floor(timer%60);
				timerText.text = minutes.ToString() + ":" + seconds.ToString("00");
		} else {
			timerText.text = "0:00";
			GameOver();
		}
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
		
	}
}
