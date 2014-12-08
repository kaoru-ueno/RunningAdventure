using UnityEngine;
using System.Collections;

public class UniEmitter : MonoBehaviour {
	
	public GameObject[] exsitCrows;
	private int currentCrow;
	private GameObject main_camera = null;
	public    float WIDTH = 38f;
	// 床モデルの数.
	public    float MODEL_NUM = 1;
	private int bird = 0;

	void Start(){
		this.main_camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update(){

	float rnd = Random.Range (-1.0f, 6.0f);

	float	total_width = WIDTH * MODEL_NUM;
	
	// 背景の位置.
	Vector3	floor_position = this.transform.position;
	
	// カメラの位置.
	Vector3	camera_position = this.main_camera.transform.position;
	
	if(floor_position.x + total_width/2.0f < camera_position.x) 
	{
//			Destroy(exsitCrows);
		
		// 前にワープ.
		floor_position.x += total_width;
		
		this.transform.position = floor_position;
		
			GameObject g = (GameObject)Instantiate (exsitCrows [currentCrow],new Vector2(camera_position.x + 10f ,rnd), Quaternion.identity);
			if (bird %2 == 0){
			g.rigidbody2D.velocity = transform.right * -6;
			}else{
				g.rigidbody2D.velocity = transform.right * -8;
			}
			bird++;
//			Debug.Log ("exsitCrows" + exsitCrows);
	}
	//格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
		if (exsitCrows.Length <= ++currentCrow) 
	{
		currentCrow = 0;
		}
//		FindObjectOfType<Unikill>().Move();
	}
}