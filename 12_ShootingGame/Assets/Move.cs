using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// 床の移動スピード
	public float speed = 1;
	
	void Start () {
		//Moves (transform.right);
		
	}
	
	void Update () {
		Moves (transform.right);
		print (transform.position);
	}
	
	public void Moves (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;
	}
}
