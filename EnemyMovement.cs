using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
	NavMeshAgent nav;               
	Vector3 originalPosition;
	Vector3 newPosition = Vector3.zero;
	Vector3 currentDestination = Vector3.zero;

	float waitTime = 42f;    //到达某一地点以后的停留时间
	bool canMoving = true;        			//控制物体是否能够移动

	void Start () {
//		Debug.Log ("navmesh");
		nav = GetComponent <NavMeshAgent> ();

		originalPosition = transform.position;   //拿到物体初始位置
//		float x = Random.Range (-200, 200);
//		float z = Random.Range (-200, 200);
		float z=-150.0f;
		float x = 150.0f;
		if (nav.gameObject == GameObject.Find ("Enemies/MaskedOrc")) {
			newPosition = new Vector3 (originalPosition.x, originalPosition.y, originalPosition.z + z);
		} //拿到物体随机得到的另一个位置
		else if (nav.gameObject == GameObject.Find ("Enemies/CrawlingBug")) {
			newPosition = new Vector3 (originalPosition.x + x, originalPosition.y, originalPosition.z);
		}
		currentDestination = newPosition;
//		Debug.Log(currentDestination);
	}

	void Update ()
	{
		if (canMoving) {
//			Debug.Log ("remD"+nav.remainingDistance);
			nav.SetDestination (currentDestination);
//			Debug.Log("curD"+currentDestination);

			if (nav.remainingDistance < 0.05f) {       //到达目的地后暂停3s，然后切换目的地，达到来回走动的效果

				canMoving = false;
				StartCoroutine(delayCoroutine());     //停留waitTime时间后再返回
			}
		}
	}

	IEnumerator delayCoroutine() {

		if (Vector3.Equals (currentDestination, newPosition)) {

			currentDestination = originalPosition;
		} else {

			currentDestination = newPosition;
		}

		yield return new WaitForSeconds(waitTime);
		canMoving = true;

	}

}