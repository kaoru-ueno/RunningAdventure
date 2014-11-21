using UnityEngine;
using System.Collections;

public class StopControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			
			// タッチ情報を取得する
			Touch touch = Input.GetTouch (i);
			
			// ゲーム中ではなく、タッチ直後であればtrueを返す。
			if (touch.phase == TouchPhase.Began) {
				print (touch.position.x);
				print (touch.position.y);
			}
		}
	}
}
