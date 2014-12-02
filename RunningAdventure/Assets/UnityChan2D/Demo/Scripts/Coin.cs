using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int point;

	private float Delay = 5;

	IEnumerator OnTriggerEnter2D(Collider2D c){

			FindObjectOfType<Score> ().AddPoint(point);

			yield return new WaitForSeconds (Delay);
			
			gameObject.renderer.enabled = true;
	}
}