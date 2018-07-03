using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapShowTimerController : MonoBehaviour {
	RawImage map;
	Timer timer;

	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Canvas/Map").GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		if (DetectCollision.isMapShow) {
			timer = new Timer (5f); //小地图显示5秒
//			timer.OnUpdate=showMap;
			timer.OnStart=showMap;
			timer.OnEnd = hideMap;
			timer.Start ();
		}
	}

	void showMap()
	{
		map.enabled = true;
	}

	void hideMap()
	{
//		Debug.Log (map.enabled);
		DetectCollision.isMapShow = false;
		map.enabled = false;
	}
}
