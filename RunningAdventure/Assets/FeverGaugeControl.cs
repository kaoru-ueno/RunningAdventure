using UnityEngine;
using System.Collections;

public class FeverGaugeControl : MonoBehaviour {
	// ゲージ用
	private GameObject gaugeObject;
	private float gaugeScale = 1;

	private int hp;
	private int maxHp;
	// Use this for initialization
	void Start () {
		// ゲージの取得
		gaugeObject = transform.FindChild("Bar").gameObject;
		ChangeGauge ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// ゲージ描画用(ダメージからゲージのスケールと位置を求め変更)
	void ChangeGauge(){
		gaugeScale = 2;
		gaugeObject.transform.localScale = new Vector3(gaugeScale, 1,1);
/*		gaugeScale = Mathf.Round(10.0F* hp / maxHp) / 10;
		//Vector3 scale = gaugeObject.transform.localScale;
		//scale.x = gaugeScale;
		//gaugeObject.transform.localScale = scale;
		gaugeObject.transform.localScale = new Vector3(gaugeScale, 1,1);
		float gaugePosition = (gaugeScale - 1) / 2;
		gaugeObject.transform.localPosition = new Vector3(gaugePosition, 0, 0);;
*/	}
}
