using UnityEngine;
using System.Collections;

public class Unikill : MonoBehaviour {

	public static bool enemyjump = false;
	public static int jumpplan = 0;
	GameObject crow;
	GameObject crow2;

	void Start() {

		}

	void Update() {

			Move (transform.right * -1);

	}
	public void Move (Vector2 direction) 
	{

		crow = GameObject.Find ("Crow");
		crow.rigidbody2D.velocity = direction * 2;
		crow2 = GameObject.Find ("Crow2");
		crow2.rigidbody2D.velocity = direction * 3;
//		crow2.rigidbody2D.velocity = direction * 4;
//		rigidbody2D.velocity = direction * 2;
/*		float rnd = Random.Range (-1.0f, 2.0f);
		crow.rigidbody2D.velocity = direction * 4;
		crow.transform.position = new Vector2(10.0f ,rnd);
		crow2.rigidbody2D.velocity = direction * 3;
		crow2.transform.position = new Vector2(10.0f ,rnd);
*/	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag != "Player")return;

			if (gameObject.tag == "Unikill") {
					GameObject.Find ("Uni").renderer.enabled = false;
					GameObject.Find ("Uni").collider2D.enabled = false;		
		}
			if (gameObject.tag == "Unikill2") {
					GameObject.Find ("Unisi").renderer.enabled = false;
					GameObject.Find ("Unisi").collider2D.enabled = false;
		}
			if (gameObject.tag == "Unikill3") {
					GameObject.Find ("Crow").renderer.enabled = false;
					GameObject.Find ("Crow").collider2D.enabled = false;
		}
			if (gameObject.tag == "Unikill4"){
					GameObject.Find ("Crow2").renderer.enabled = false;
					GameObject.Find ("Crow2").collider2D.enabled = false;
				}
			
		enemyjump = true;
		jumpplan++; 
	}
}