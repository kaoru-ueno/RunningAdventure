using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	private int ButtonWidth = 300;
	private int ButtonHeight = 70;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// ボタンを表示する
		//GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+20, ButtonWidth, ButtonHeight), "ゲームスタート");
		//GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+100, ButtonWidth, ButtonHeight), "ランキング");
		if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+20, ButtonWidth, ButtonHeight), "ゲームスタート")){
			print ("スタートをクリックしました");
			Application.LoadLevel ("Test");
		}
		if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+100, ButtonWidth, ButtonHeight), "ランキング")){
			print ("ランキングをクリックしました");
			Application.LoadLevel ("Ranking");
		}
	}
}
