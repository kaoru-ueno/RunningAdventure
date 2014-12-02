using UnityEngine;
using System.Collections;

public class Unikill : MonoBehaviour {

	public static bool enemyjump = false;
	public static int jumpplan = 0;
	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject.Find("Uni").renderer.enabled = false;
		GameObject.Find ("Uni").collider2D.enabled = false;
		enemyjump = true;
		jumpplan++; 
		Debug.Log ("enemyjump" + enemyjump);
	}

}