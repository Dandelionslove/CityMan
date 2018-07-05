using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class operationEventTriggerHandler : MonoBehaviour {
	public Button closeBtn;
	// Use this for initialization
	void Start () {
		closeBtn = GameObject.Find ("operationUI/closeBtn").GetComponent<Button>();
//		Debug.Log (closeBtn);

		EventTrigger trigger = closeBtn.gameObject.GetComponent<EventTrigger> ();
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerClick;
		entry.callback = new EventTrigger.TriggerEvent ();
		entry.callback.AddListener (closeBtnClick);
		trigger.triggers.Add (entry);
//		closeBtn.onClick.AddListener(closeBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void closeBtnClick(BaseEventData data)
	{
//		Debug.Log ("operation");
		SceneManager.LoadScene (0);
	}
}
