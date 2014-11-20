using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

	// 床の移動スピード
	public float speed = 1;

	// ゲームオブジェクト生成から削除するまでの時間
	public float lifeTime = 1;

	void Start () {
		Move (transform.right * -1);

		// lifeTime秒後に削除
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		//Move (transform.right * -1);
	}

	public void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;
	}
	void OnTriggerEnter2D (Collider2D c){
	//	Emitter.EmitterCall();
	}
}
