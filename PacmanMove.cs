using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {
	Animation p_anim;   //角色动画
	// Use this for initialization
	void Start () {
		p_anim = GetComponent<Animation> ();
		if (!p_anim.isPlaying) {
			p_anim.CrossFade ("idle", 0.2f);
		}
	}

	private int MoveSpeed=12;
	private int RotateSpeed=100;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {    //向前移动
			this.transform.Translate (Vector3.forward * Time.deltaTime * MoveSpeed);
			p_anim.CrossFade ("run", 0.2f);
		}
		if(Input.GetKey(KeyCode.A) )       //向左旋转并移动
			{
				this.transform.Rotate(Vector3.up*Time.deltaTime*(-RotateSpeed));
			}
		if(Input.GetKey(KeyCode.D))
		{
			this.transform.Rotate(Vector3.up*Time.deltaTime*RotateSpeed);
		}
//		if (Input.GetKey (KeyCode.S)) {
//			this.transform.Rotate (Vector3.back*Time.deltaTime*5);   //向后旋转有待改进
//		}
	}
	void OnGUI()
	{
		
	}
}
