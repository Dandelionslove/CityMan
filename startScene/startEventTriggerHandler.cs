using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]

public class startEventTriggerHandler : MonoBehaviour {
	public Button playBtn;
	public Button opeBtn;
	// Use this for initialization
	void Start () {
		playBtn = GameObject.Find ("UI/playBtn").GetComponent<Button> ();
		opeBtn = GameObject.Find ("UI/opeBtn").GetComponent<Button> ();
		EventTrigger triggerPlay = playBtn.gameObject.GetComponent<EventTrigger> ();
		EventTrigger.Entry entryPlayClick = new EventTrigger.Entry ();
		entryPlayClick.eventID = EventTriggerType.PointerClick;
		entryPlayClick.callback=new EventTrigger.TriggerEvent();
		entryPlayClick.callback.AddListener (playBtnClick);
		triggerPlay.triggers.Add (entryPlayClick);

		EventTrigger triggerOpe = opeBtn.gameObject.GetComponent<EventTrigger> ();
		EventTrigger.Entry entryOpeClick = new EventTrigger.Entry ();
		entryOpeClick.eventID = EventTriggerType.PointerClick;
		entryOpeClick.callback = new EventTrigger.TriggerEvent ();
		entryOpeClick.callback.AddListener (opeBtnClick);
		triggerOpe.triggers.Add (entryOpeClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playBtnClick(BaseEventData pointData)
	{
//		Debug.Log ("play Btn");
		SceneManager.LoadScene(5);
	}
	public void opeBtnClick(BaseEventData pointData)
	{
		SceneManager.LoadScene (2);
	}
}
