using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAnimateController : MonoBehaviour {

	Animation e_anim;

	Animation e_animation;
	GameObject enemy;

	// Use this for initialization
	void Start () {
		e_anim = GetComponent<Animation> ();
		if (!e_anim.isPlaying) {
			e_anim.CrossFade ("run", 0.25f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (DetectCollision.isMeetCrawlingBug) {
			enemy = GameObject.Find ("Enemies/CrawlingBug");
			e_animation = enemy.GetComponent<Animation> ();
			e_animation.CrossFade ("attack01", 0.25f);
			DetectCollision.isMeetCrawlingBug = false;
//			if (!DetectCollision.isMeetCrawlingBug) {
//				enemy = GameObject.Find ("Enemies/CrawlingBug");
//				e_animation = enemy.GetComponent<Animation> ();
//				e_animation.CrossFade ("run", 0.25f);
//			}
			SceneManager.LoadScene(3);
		} else if(DetectCollision.isMeetMaskedOrc){
			enemy = GameObject.Find ("Enemies/MaskedOrc");
			e_animation = enemy.GetComponent<Animation> ();
			e_animation.CrossFade ("attack01", 0.25f);
			DetectCollision.isMeetMaskedOrc = false;
//			if (!DetectCollision.isMeetMaskedOrc) {
//				enemy = GameObject.Find ("Enemies/MaskedOrc");
//				e_animation = enemy.GetComponent<Animation> ();
//				e_animation.CrossFade ("run", 0.25f);
//			}
			SceneManager.LoadScene(3);
		}
//		if (!DetectCollision.isMeetCrawlingBug) {
//			enemy = GameObject.Find ("Enemies/CrawlingBug");
//			e_animation = enemy.GetComponent<Animation> ();
//			e_animation.CrossFade ("run", 0.25f);
//		}
//		if (!DetectCollision.isMeetMaskedOrc) {
//			enemy = GameObject.Find ("Enemies/MaskedOrc");
//			e_animation = enemy.GetComponent<Animation> ();
//			e_animation.CrossFade ("run", 0.25f);
//		}
	}
}
