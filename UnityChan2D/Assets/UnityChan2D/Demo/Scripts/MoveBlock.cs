using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

	public float speed = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Move (transform.right * -1);
	}

	public void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;
	}
}
