using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class replayClickEventHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button replayBtn = this.GetComponent<Button> ();
		replayBtn.onClick.AddListener (replayBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void replayBtnClick()
	{
		KeepScore.score = 0;
		TimerCountDown.time = 99;
		SceneManager.LoadScene (0);
	}
}
