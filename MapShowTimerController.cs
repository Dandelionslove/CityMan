using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapShowTimerController : MonoBehaviour {
	RawImage map;
	Timer timer;
	public static float totalDuration;
	public static float durationStep;
	public static int showTime;
	private float beginShowTime;
	private float endShowTime;
	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Canvas/Map").GetComponent<RawImage>();
		totalDuration = 0f;
		durationStep = 5f;
		showTime = 0;
//		Debug.Log (Application.targetFrameRate);
	}
	
	// Update is called once per frame
	void Update () {
		if (DetectCollision.isMapShow) {
//			timer = new Timer (5f); //小地图显示5秒
////			timer.OnUpdate=showMap;
//			timer.OnStart=showMap;
//			timer.OnEnd = hideMap;
//			timer.Start ();
//			DetectCollision.isMapShow = false;
//			totalDuration-=(float)1;
		}
		if (showTime == 1) {
			beginShowTime = Time.time;
//			totalDuration += durationStep;
			showTime=2;
		}
		if (totalDuration > 0) {
			endShowTime = beginShowTime + totalDuration;
//			Debug.Log (endShowTime-beginShowTime);
			showMap();
		}
		if (Time.time-endShowTime>0.1f) {
			hideMap ();
			totalDuration = 0f;
			showTime = 0;
		}
	}

	void showMap()
	{
		map.enabled = true;
	}

	void hideMap()
	{
//		Debug.Log (map.enabled);
//		DetectCollision.isMapShow = false;
		map.enabled = false;
	}
}
