using UnityEngine;
using System.Collections;

public class CrystalsetControl : MonoBehaviour {

	// カメラ.
	private GameObject main_camera = null;

	// Waveプレハブを格納する
	public GameObject[] crystal;
	
	// 現在のWave
	private int currentcrystal;

	// 初期位置.
	//private Vector3	initial_position;
	
	// 床の幅（X方向）.
	public    float WIDTH = 38f;

	// 床モデルの数.
	public    float MODEL_NUM = 1;


	
	IEnumerator Start ()
	{
		
		// Waveが存在しなければコルーチンを終了する
		if (crystal.Length == 0) {
			yield break;
		}
		// カメラのインスタンスを探しておく.
		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");
		
		//this.initial_position = this.transform.position;
		
		//print (this.main_camera);
		for (int i = 0; i < crystal.Length; i++) 
		{
		GameObject g = (GameObject)Instantiate (crystal [currentcrystal], transform.position, Quaternion.identity);
		}
	}
	
	void	Update()
	{
		// 無限に床が繰り返すようにする.
		
		#if true
		// 簡易的な方法.
		// 画面外に出たらプレイヤーの前方（後方）にワープする.
		// プレイヤーがワープしたときに問題あり.
		
		
		// 背景全体（すべてのモデルを並べた）の幅.
		//
		float	total_width = WIDTH * MODEL_NUM;
		
		// 背景の位置.
		Vector3	floor_position = this.transform.position;
		
		// カメラの位置.
		Vector3	camera_position = this.main_camera.transform.position;
		
		if(floor_position.x + total_width/2.0f < camera_position.x) 
		{
			//Destroy(crystal);

			// 前にワープ.
			floor_position.x += total_width;

			this.transform.position = floor_position;

			GameObject g = (GameObject)Instantiate (crystal [currentcrystal], transform.position, Quaternion.identity);
			
		}

		// 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
		if (crystal.Length <= ++currentcrystal) 
		{
			currentcrystal = 0;
		}
			//print (this.transform.position);
	}
		
		//if(camera_position.x < floor_position.x - total_width/2.0f) {
		
		// 後ろにワープ.
		//	floor_position.x -= total_width;
		
		//	this.transform.position = floor_position;
		
		//print (this.transform.position);
		//}
		#else
		// プレイヤーがワープしても対応できる方法.
		
		// 背景全体（すべてのモデルを並べた）の幅.
		//
		float		total_width = FloorControl.WIDTH*FloorControl.MODEL_NUM;
		
		Vector3		camera_position = this.main_camera.transform.position;
		
		float		dist = camera_position.x - this.initial_position.x;
		
		// モデルは total_width の整数倍の位置に現れる.
		// 初期位置の距離を背景全体の幅で割って、四捨五入する.
		
		int			n = Mathf.RoundToInt(dist/total_width);
		
		Vector3		position = this.initial_position;
		
		position.x += n*total_width;
		
		this.transform.position = position;
		#endif
	}