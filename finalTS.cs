using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalTS : MonoBehaviour {
	public Text time;
	public Text scores;

	// Use this for initialization
	void Start () {
		time = GameObject.Find ("Canvas/time").GetComponent<Text>();
		scores = GameObject.Find ("Canvas/scores").GetComponent<Text>();
		scores.text = KeepScore.score.ToString();
		float leftTime = TimerCountDown.time;
		float spentTime = (float)100 - leftTime;
		int hour = (int)spentTime / 3600;
		int minute = ((int)spentTime - hour * 3600) / 60;
		int second = (int)spentTime - hour * 3600 - minute * 60;
		time.text = string.Format ("{0:D2}:{1:D2}", minute, second);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
