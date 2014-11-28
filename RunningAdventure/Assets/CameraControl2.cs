using UnityEngine;
using System.Collections;

public class CameraControl2 : MonoBehaviour {

	// プレイヤー.
	private GameObject	player = null;
	
	public Vector3		offset;

	//最初のカメラの位置
	public Vector3		homePosition;

	//ボーナスステージにいる時間をカウントする値
	private int bonustart = 0;

	//ボーナスステージにいる時間
	public int bonusrage = 200;
	
	void Start () {
		
		// プレイヤーのインスタンスを探しておく.
		this.player = GameObject.FindGameObjectWithTag("Player");
		
		this.offset = this.transform.position - this.player.transform.position;

		this.homePosition = this.transform.position;
	}
	
	void Update () {
		//ボーナスステージの終わり
		if(bonustart > bonusrage)
		{
			bonustart = 0;
			UnityChan2DController.bonusflg = false;
		}

		//ボーナスステージ中ならカメラを上に移す
		if(UnityChan2DController.bonusflg == true)
		{
			bonustart++;

			//print("bonustart"+bonustart);

			this.transform.position = new Vector3(player.transform.position.x + this.offset.x, this.homePosition.y + 11, this.transform.position.z);
		}

		else
		{
		// プレイヤーと一緒に移動.
			this.transform.position = new Vector3(player.transform.position.x + this.offset.x, this.homePosition.y, this.transform.position.z);
		}
	}
}
