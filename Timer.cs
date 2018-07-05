using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer{
	//开始时间
	public float StartTime{ get; private set;}
	//持续时间
	public float Duration{get;private set;}
	//结束时间
	public float EndTime{get;private set;}
	//当前时间
	public float CurTime{get;private set;}

	//运行标识
//	public bool IsStart{get;private set;}
	private bool IsStart;

	//开始和结束事件，这里直接用System.Action（相当于返回值无参数委托）
	public Action OnStart{get;set;}
	public Action OnEnd{ get; set; }
	public Action OnUpdate{ get; set; }

	//构造函数，设置计时器
	public Timer(float duration)
	{
		Duration = duration;
		CenterTimer.AddTimer (this);
		Debug.Log ("Timer");
		IsStart = true;
	}

	//开始计时 Timer类不继承于MonoBehaviour，该方法不会在任何对象开始时被调用
	public void Start()
	{
		if (!IsStart)
			return;
		Debug.Log (IsStart);
		IsStart = true;
		StartTime = Time.time;
		CurTime = StartTime;
		EndTime = StartTime + Duration;
//		CenterTimer.AddTimer (this);
		StartCount++;
		Debug.Log("Start");
		if (OnStart != null)
			OnStart ();
	}

	//计时器结束
	public void End()
	{
		IsStart = false;
		FinishCount++;
		Debug.Log ("End");
//		CenterTimer.RemoveTimer (this);
		if (OnEnd != null)
			OnEnd ();
		CenterTimer.RemoveTimer (this);
	}

	//取消事件
	public Action OnCancel{get;set;}
	//取消接口
	public void Cancel()
	{
		IsStart = false;
		if (OnCancel != null)
			OnCancel ();
	}

	//暂停和继续事件
	public Action OnPause{get;set;}
	public Action OnContinue{ get; set; }
	//属性
	public bool IsPause{get;private set;}
	//接口
	public void Pause()
	{
		IsPause = true;
		if (OnPause != null)
			OnPause ();
	}
	public void Continue()
	{
		IsPause = false;
		if (OnContinue != null)
			OnContinue ();
	}


	//一些public属性
	//计时器已经完成的百分比
	public float Ratio {
		get {
			if (!IsStart) {
				return 0;
			} else {
				return 1 - (EndTime - CurTime) / Duration;
			}
		}
	}
	//计时器次数，可用于循环计时，检测是否已经完成等
	//开始次数
//	public static int StartCount{get;private set;}
	public static int StartCount=0;
	//完成次数
//	public static int FinishCount{get;private set;}
	public static int FinishCount=0;
	//更新时间，并检查状态。Timer类不继承于MonoBehaviour，该方法将在中心计时器每帧调用
	public void Update()
	{
		if (!IsStart)
			return;
		CurTime += Time.deltaTime;
		if (IsPause)
			EndTime += Time.deltaTime;
		if (CurTime >= EndTime) {
			End ();
		} else if (OnUpdate != null) {
			OnUpdate ();
		}
	}

	//重置接口
	public void Reset()
	{
		IsStart = false;
		IsPause = false;
		CenterTimer.RemoveTimer (this);
	}
}
