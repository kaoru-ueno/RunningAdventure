using UnityEngine;
using System.Collections;

public class Crustal : MonoBehaviour {

	// ゲームオブジェクト生成から削除するまでの時間
	public float lifeTime = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// lifeTime秒後に削除
		Destroy (gameObject, lifeTime);
	}
}
