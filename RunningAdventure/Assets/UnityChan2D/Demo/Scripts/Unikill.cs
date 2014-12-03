using UnityEngine;
using System.Collections;

public class Unikill : MonoBehaviour {

	public static bool enemyjump = false;
	public static int jumpplan = 0;
	// Use this for initialization
	void Start () {
		Move (transform.right * -1);
	}

	public void Move (Vector2 direction) 
	{
		GameObject.Find ("Crow").rigidbody2D.velocity = direction * 4;

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (gameObject.tag == "Unikill") {
						GameObject.Find ("Uni").renderer.enabled = false;
						GameObject.Find ("Uni").collider2D.enabled = false;
				}else if(gameObject.tag == "Unikill2") {
						GameObject.Find ("Unisi").renderer.enabled = false;
						GameObject.Find ("Unisi").collider2D.enabled = false;
				}else{
						GameObject.Find ("Crow").renderer.enabled = false;
						GameObject.Find ("Crow").collider2D.enabled = false;
				}
		enemyjump = true;
		jumpplan++; 
		Debug.Log ("enemyjump" + enemyjump);
	}
}