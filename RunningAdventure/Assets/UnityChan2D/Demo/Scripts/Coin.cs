using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int point;

	void OnTriggerEnter2D(Collider2D c){

			FindObjectOfType<Score> ().AddPoint(point);
	}
}