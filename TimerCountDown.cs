using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerCountDown : MonoBehaviour
{

//    public static float time = 99;    //闯一关所需总时间
	public static float time = 99;    //闯一关所需总时间
    private long nowTime;
    Text text_timeSpend;
    int hour;  
    int minute;  
    int second;  
    int millisecond; 

    void Start () {
        StartCoroutine (Timer());
    }

    public IEnumerator Timer(){

        text_timeSpend = GameObject.Find("Canvas/Time").GetComponent<Text>(); 
        while (time>=0) {
            yield return new WaitForSeconds (1);

            hour = (int)time / 3600;  
            minute = ((int)time - hour * 3600) / 60;  
            second = (int)time - hour * 3600 - minute * 60;  
//            millisecond = (int)((time - (int)time) * 1000); 
            
			text_timeSpend.text = string.Format("{0:D2}:{1:D2}", minute, second);
            //print(string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", hour, minute, second, millisecond));
            time--;
        }
//		if (time <= 0) {           //此失败画面受DetectCollision控制
//			LoadFailureScene ();
//		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//	void LoadFailureScene()
//	{
//	}
}