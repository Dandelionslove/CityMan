using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameState : MonoBehaviour
{
    public int exit_label=1; 
    public GameObject exit;
    public string state_game="on";

    void SetExit(){
        exit_label = (int)Random.Range(1, 3);
        for(int i=1;i<=3;i++){
            GameObject temp=GameObject.Find("Exit" + exit_label.ToString());
			Debug.Log (i);
            if(i==exit_label){
                exit=temp;
                exit.active=false;
//				temp.active=true;
            }
            else{
//                temp.active=true;
            }
        }
        print("exit_label:"+exit_label);
    }

    void ChangeState(){
        if(KeepScore.GetScore()>200){// reach the goal
            if(true){// stand at the exit
                state_game="win";// win and end the game
            }
            else{
                // state unchanged
            }
        }
        else if(KeepScore.GetScore()<0){
            // fail and end the game
        }
    }

    void Start () {
        SetExit();
    }
    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
}
