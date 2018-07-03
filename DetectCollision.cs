using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DetectCollision : MonoBehaviour {
	RawImage map;
	public static bool isMapShow = false;
	public static bool isMeetCrawlingBug = false;
	public static bool isMeetMaskedOrc = false;
	// Use this for initialization
	void Start () {
//		GameObject map = GameObject.Find ("Canvas/Map");
		map = GameObject.Find ("Canvas/Map").GetComponent<RawImage>();
		if (!map) {
			Debug.Log ("no map");
		}
		map.enabled = false;
//		map.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//	void onTriggerEnter(Collider other)
//	{
//		Debug.Log (other.gameObject.name);
//	}
	void OnCollisionEnter(Collision c)
	{
//		Debug.Log ("Collision object" + c.gameObject.name);
		string tag = c.collider.tag;
		string name = c.gameObject.name;
//		if (tag == "Bonus") {
////			Debug.Log ("Collision object" + c.gameObject.name);
//			//Bonus游戏效果
//			KeepScore.score += 1;   //分数增加
//			Destroy (c.gameObject);
//		} else if (tag == "Risk") {
//			//risk游戏效果
//			KeepScore.score -= 1;
//			Time.timeScale = 0;
//			Destroy (c.gameObject);
//		} else if (tag == "Bean") {
//			//一般的Bean的游戏效果
//			Destroy(c.gameObject);
//		}
		switch (tag)
		{
		case "Bean":    //普通豆子
			KeepScore.score += 1;   //分数加1
			Destroy(c.gameObject);
			break;
		case "Risk":     //第一个Risk
			KeepScore.score -= 1;
			Destroy (c.gameObject);
			break;
		case "Bonus":     //第一个Bonus
//			KeepScore.score += 5;
			isMapShow = true;
			Destroy (c.gameObject);
			Debug.Log (c.gameObject);
			break;
		case "bonusAdd5Scores":
			KeepScore.score += 5;	//分数加5
			Destroy(c.gameObject);
			Debug.Log (c.gameObject);

			break;
		case "bonusShowMap":
//			map.enabled = true;
//			TimeManager.Register (this, 3.0f, () => {
//				map.enabled=false;
//			});
			Debug.Log("show map");
			isMapShow=true;
			Destroy(c.gameObject);
			Debug.Log (c);

			break;
		case "bonusAddTime":
			TimerCountDown.time += 5;
			Destroy(c.gameObject);
			Debug.Log (c.gameObject);

			break;
		case "riskMinusScores":
			int minusScore = Random.Range (3, 10);
			KeepScore.score -= minusScore;
			if (KeepScore.score < 0) {
				//显示失败画面
				LoadFailureScene();
			}
			Destroy(c.gameObject);
			break;
		case "riskMinusTime":
			TimerCountDown.time -= 5;
			if (TimerCountDown.time <= 0.5f) {     
				LoadFailureScene ();
			}
			Destroy(c.gameObject);
			break;
		case "Enemy":
			if (!isMeetCrawlingBug || !isMeetMaskedOrc) {
				Animation e_anim = c.gameObject.GetComponent<Animation> ();
				e_anim.CrossFade ("attack01", 0.25f);
			}
			if (c.gameObject == GameObject.Find ("Enemies/CrawlingBug")) {
				isMeetCrawlingBug = true;
			} else {
				isMeetMaskedOrc = true;
			}
			break;
		default:
			break;
		}
	}

	void LoadFailureScene()   //切换至失败场景
	{
		Application.LoadLevel ("FailureScene");
	}
}
