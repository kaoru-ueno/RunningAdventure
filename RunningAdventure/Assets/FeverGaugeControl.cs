using UnityEngine;
using System.Collections;

public class FeverGaugeControl : MonoBehaviour {
	// ゲージ用
	private GameObject gaugeObject;
	private GameObject feverGaugeObject;
	private float gaugeScale = 1;
	private int playerScore;
	private int localScore;
	public int FeverScore;
	// Use this for initialization
	void Start () {
		// ゲージの取得
		gaugeObject = transform.FindChild("Bar").gameObject;
		feverGaugeObject = transform.FindChild("Fever").gameObject;

		// 初期化
		init ();
	}
	
	// Update is called once per frame
	void Update () {

		localScore = Score.score - playerScore;
		if(localScore < FeverScore){
			ChangeGauge ();
		}else{
			// FeverTime!
			// フィーバーゲージ表示
			gaugeObject.renderer.enabled = false;
			feverGaugeObject.renderer.enabled = true;
		}
	}
	
	// ゲージ描画用(ダメージからゲージのスケールと位置を求め変更)
	void ChangeGauge(){
		gaugeScale = Mathf.Round(10.0F* localScore / FeverScore) / 10;
		gaugeObject.transform.localScale = new Vector3(gaugeScale, 1,1);
		float gaugePosition = 5f *(gaugeScale - 1) / 2;
		gaugeObject.transform.localPosition = new Vector3(gaugePosition, 0, 0);
	}

	// 初期化
	void init(){
		// スコアを0にする
		localScore = 0;
		// スコアを取得
		playerScore = Score.score;
		// フィーバーゲージ非表示
		gaugeObject.renderer.enabled = true;
		feverGaugeObject.renderer.enabled = false;
	}
}
