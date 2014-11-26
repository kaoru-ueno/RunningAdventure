using UnityEngine;
using System.Collections;

public class CameraControl2 : MonoBehaviour {

	// プレイヤー.
	private GameObject	player = null;
	
	public Vector3		offset;

	private int bonustart = 0;

	public int bonusrage = 200;
	
	void Start () {
		
		// プレイヤーのインスタンスを探しておく.
		this.player = GameObject.FindGameObjectWithTag("Player");
		
		this.offset = this.transform.position - this.player.transform.position;
	}
	
	void Update () {

		if(bonustart > bonusrage)
		{
			bonustart = 0;
			UnityChan2DController.bonusflg = false;
		}

		if(UnityChan2DController.bonusflg == true)
		{
			bonustart++;

			//print("bonustart"+bonustart);

			this.transform.position = new Vector3(player.transform.position.x + this.offset.x, player.transform.position.y + this.offset.y, this.transform.position.z);
		}

		else
		{
		// プレイヤーと一緒に移動.
		this.transform.position = new Vector3(player.transform.position.x + this.offset.x, this.transform.position.y, this.transform.position.z);
		}
	}
}
