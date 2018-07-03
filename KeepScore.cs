using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeepScore : MonoBehaviour
{
    public static int score=0; 
    Text score_display;

    public static int GetScore(){
        return score;
    }
	public void ChangeScore(int _score)
	{
		score += _score;
		score_display.text = score.ToString();
	}

    public void ShowScore(){
        score_display = GameObject.Find("Canvas/Score").GetComponent<Text>(); 
        score_display.text = score.ToString();
        //print(score_display.text);

    }

    void Awake () {
        ShowScore();
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }
}
