using UnityEngine;
using System.Collections;

public class FloorCrystalsetControl : MonoBehaviour {

	// カメラ.
	private GameObject		main_camera = null;
	
	// 初期位置.
	//private Vector3	initial_position;
	
	// 床の幅（X方向）.
	public	static float	WIDTH = 32f;
	
	// 床モデルの数.
	public static float		MODEL_NUM = 10;
	
	public GameObject floorcrystal;
	
	void	Start() 
	{
		// カメラのインスタンスを探しておく.
		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");

		GameObject g = (GameObject)Instantiate (floorcrystal, transform.position, Quaternion.identity);
		
		//this.initial_position = this.transform.position;
		
		//print (this.main_camera);
		
	}
	
	void	Update()
	{
		// 無限に床が繰り返すようにする
		
		
		// 背景全体（すべてのモデルを並べた）の幅.
		//
		float	total_width = FloorCrystalsetControl.WIDTH * FloorCrystalsetControl.MODEL_NUM;
		
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
			
			GameObject g = (GameObject)Instantiate (floorcrystal, transform.position, Quaternion.identity);
			
		}
		
		//print (this.transform.position);
	}
}