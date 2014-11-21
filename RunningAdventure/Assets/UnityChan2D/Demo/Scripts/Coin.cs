using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
//	public LayerMask whatIsPlayer;
	public int point = 0;
	public int coin = 1;
	public int scoin = 2;

/*	void GetPoint(){
				if (coin == coin) {
						point += coin;
				}
				if (scoin == scoin) {
						point += scoin;
				}
		}*/
	void OnTriggerEnter2D(Collider2D c){
				if (c.tag == "Player") {
//			if (coin == coin) {
				point += coin;
//			}else{
				point += scoin;
			}
			FindObjectOfType<Score> ().AddPoint(point);
				}
//		}


/*	private CircleCollider2D m_CircleCollider2D;
	
	private void Awake()
	{
		m_CircleCollider2D = GetComponent<CircleCollider2D>();
	}
	private void OnCollisionEnter2D(Collision2D collision2D)
    {
				if (collision2D.gameObject.tag == "Player") {
				}
		}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
