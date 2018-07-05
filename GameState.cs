using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameState : MonoBehaviour
{
    public int exit_label=1; 
    public GameObject exit;
    public string state_game="on";
	public static Vector3 exitPosition;

    void SetExit(){
//        exit_label = (int)Random.Range(1, 3);
//		Debug.Log (exit_label);
//        for(int i=1;i<=3;i++){
//			GameObject temp=GameObject.Find("Exit" + exit_label.ToString());
////			Debug.Log (i);
//            if(i==exit_label){
//                exit=temp;
//				Debug.Log (exit);
////                exit.active=false;
////				temp.active=true;
//				exit.gameObject.SetActive(true);
//				Debug.Log (exit.gameObject);
//            }
//            else{
////                temp.active=false;
//				temp.gameObject.SetActive(false);
//            }
//        }
//        print("exit_label:"+exit_label);
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
//        SetExit();
//		GameObject exit=GameObject.Find("exit");
//		Debug.Log (exit.GetInstanceID ());
//		Debug.Log(exit);
    }
    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
}
