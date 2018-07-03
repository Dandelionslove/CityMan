﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//因为中心计时器应该只有一个，所以所有新定义的成员都应该为静态成员
public class CenterTimer : MonoBehaviour {

	static List<Timer> timers = new List<Timer> ();

	//添加计时器
	public static void AddTimer(Timer timer)
	{
		timers.Add (timer);
	}

	//移除计时器
	public static void RemoveTimer(Timer timer)
	{
		timers.Remove (timer);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("timers:"+timers.Count);
//		if (Timer.FinishCount == Timer.StartCount)
//			return;
//		Debug.Log ("StartCount:" + Timer.StartCount + "FinishCount:" + Timer.FinishCount);
		foreach (var timer in timers) {
			timer.Update ();
		}
	}
}
